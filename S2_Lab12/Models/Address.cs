namespace S2_Lab12.Models;

public class Address
{
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string House { get; set; } = string.Empty;
    public string Apartment { get; set; } = string.Empty;

    public override string ToString() =>
        $"{PostalCode}, {Country}, {Region}, {District}, {City}, ул. {Street}, д. {House}, кв. {Apartment}";
}