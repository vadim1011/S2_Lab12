using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using S2_Lab12.Models;

namespace S2_Lab12.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Person> People { get; set; } = new();

    private Person? _youngestPerson;
    public Person? YoungestPerson
    {
        get => _youngestPerson;
        set
        {
            _youngestPerson = value;
            OnPropertyChanged();
        }
    }

    public ICommand FindYoungestCommand { get; }

    public MainViewModel()
    {
        FindYoungestCommand = new RelayCommand(_ => FindYoungest());
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        People.Add(new Person
        {
            LastName = "Иванов",
            FirstName = "Иван",
            MiddleName = "Иванович",
            Gender = "Мужской",
            Nationality = "Русский",
            Height = 180,
            Weight = 75,
            BirthDate = new DateTime(1990, 5, 15),
            PhoneNumber = "+7-900-123-45-67",
            HomeAddress = new Address
            {
                PostalCode = "123456",
                Country = "Россия",
                Region = "Московская область",
                District = "Одинцовский",
                City = "Одинцово",
                Street = "Ленина",
                House = "10",
                Apartment = "25"
            }
        });

        People.Add(new Person
        {
            LastName = "Петрова",
            FirstName = "Мария",
            MiddleName = "Сергеевна",
            Gender = "Женский",
            Nationality = "Русская",
            Height = 165,
            Weight = 55,
            BirthDate = new DateTime(2005, 8, 22),
            PhoneNumber = "+7-901-234-56-78",
            HomeAddress = new Address
            {
                PostalCode = "654321",
                Country = "Россия",
                Region = "Санкт-Петербург",
                District = "Центральный",
                City = "Санкт-Петербург",
                Street = "Невский",
                House = "5",
                Apartment = "12"
            }
        });

        People.Add(new Person
        {
            LastName = "Сидоров",
            FirstName = "Алексей",
            MiddleName = "Петрович",
            Gender = "Мужской",
            Nationality = "Украинец",
            Height = 175,
            Weight = 80,
            BirthDate = new DateTime(1985, 3, 10),
            PhoneNumber = "+7-902-345-67-89",
            HomeAddress = new Address
            {
                PostalCode = "111111",
                Country = "Россия",
                Region = "Краснодарский край",
                District = "Городской",
                City = "Краснодар",
                Street = "Красная",
                House = "20",
                Apartment = "8"
            }
        });
    }

    private void FindYoungest()
    {
        YoungestPerson = People
            .OrderByDescending(p => p.BirthDate)
            .FirstOrDefault();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;

    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute(parameter);

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}