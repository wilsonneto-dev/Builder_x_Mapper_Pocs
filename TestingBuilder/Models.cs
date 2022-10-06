namespace TestingBuilder;

// Carrier DTO
public record RegisterShipmentInputDto
{
    public string ConsignorAddress { get; set; }
    public string ConsignorName { get; set; }
    public string ConsignorReference { get; set; }
    public string ConsigneeAddress { get; set; }
    public string ConsigneeName { get; set; }
    public string ConsigneeReference { get; set; }
    public decimal InsuranceValue { get; set; }
    public List<string> LineItems { get; set; }
}

// Ordering DTO
public record UpsertShipmentDto(
    Guid Id,
    string Status,
    DateTime Date,
    Person Retailer,
    Person Shopper,
    Delivery? Delivery,
    IEnumerable<Item> Items);

public record Person(int Id, string Name, string Address);

public record Item(int ProductId, int Quantity, decimal Value);

public record Delivery(string Status);

public record GetOrderInput(Guid OrderId);
