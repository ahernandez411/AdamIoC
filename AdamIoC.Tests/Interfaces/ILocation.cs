namespace AdamIoC.Tests.Interfaces
{
    public interface ILocation
    {
        string Street { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string State { get; set; }
    }
}
