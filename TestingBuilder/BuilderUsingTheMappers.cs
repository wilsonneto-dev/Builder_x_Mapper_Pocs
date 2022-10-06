namespace TestingBuilder;

public sealed class CarrierDtoBuilder
{
    private readonly RegisterShipmentInputDto _result;

    public CarrierDtoBuilder() => _result = new();

    public RegisterShipmentInputDto GetResult() => _result;

    public void With(UpsertShipmentDto upsertDto)
    {

    }

    public void WithConsignor(string ConsignorName, string ConsignorAddress, string ConsignorReference)
    {
        _result.ConsignorName = ConsignorName;
        _result.ConsignorAddress = ConsignorAddress;
        _result.ConsignorReference = ConsignorReference;
    }

    public void WithConsignee(string ConsigneeName, string ConsigneeAddress, string ConsigneeReference)
    {
        _result.ConsigneeName = ConsigneeName;
        _result.ConsigneeReference = ConsigneeReference;
        _result.ConsigneeAddress = ConsigneeAddress;
    }

    public void WithLineItems(List<string> items) => _result.LineItems = items;
}

//internal static class ConsignorMap
//{
//    public static void Map(Person source, RegisterShipmentInputDtoBuilder builder)
//        => builder.AddConsignor(source.Name, source.Address, source.Id.ToString());
//}

//internal static class ConsigneeMap
//{
//    public static void Map(Person source, RegisterShipmentInputDtoBuilder builder)
//        => builder.AddConsignee(source.Name, source.Address, source.Id.ToString());
//}
//internal static class LineItemsMap
//{
//    public static void Map(IEnumerable<Item> source, RegisterShipmentInputDtoBuilder builder)
//        => builder.AddLineItems(
//            source.Select(x => $"id: {x.ProductId} - qty: {x.Quantity}").ToList());
//}
