namespace MusicShop.Domain.Entities;

public class Address : BaseEntity
{
    public string Country { get; set; }
    public string Region { get; set; }
    public string City { get; set; }
    public string Place { get; set; }
    public string Index { get; set; }
    public List<OrderEntity> Orders { get; set; }
}
