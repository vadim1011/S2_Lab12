using System;

namespace S2_Lab12.Models;

public class Person
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public double Height { get; set; }
    public double Weight { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public Address HomeAddress { get; set; } = new Address();

    public int Age => DateTime.Now.Year - BirthDate.Year -
        (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

    public string FullName => $"{LastName} {FirstName} {MiddleName}";

    public override string ToString() =>
        $"ФИО: {FullName}\n" +
        $"Пол: {Gender}\n" +
        $"Национальность: {Nationality}\n" +
        $"Рост: {Height} см\n" +
        $"Вес: {Weight} кг\n" +
        $"Дата рождения: {BirthDate:dd.MM.yyyy}\n" +
        $"Возраст: {Age} лет\n" +
        $"Телефон: {PhoneNumber}\n" +
        $"Адрес: {HomeAddress}";
}