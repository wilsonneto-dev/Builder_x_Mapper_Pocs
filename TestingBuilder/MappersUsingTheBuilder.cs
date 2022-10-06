namespace TestingBuilder;

public sealed class RegisterShipmentInputDtoBuilder
{
    private readonly RegisterShipmentInputDto _result;

    public RegisterShipmentInputDtoBuilder() => _result = new();

    public RegisterShipmentInputDto GetResult() => _result;

    public RegisterShipmentInputDtoBuilder WithConsignor(string ConsignorName, string ConsignorAddress, string ConsignorReference)
    {
        _result.ConsignorName = ConsignorName;
        _result.ConsignorAddress = ConsignorAddress;
        _result.ConsignorReference = ConsignorReference;
        return this;
    }

    public RegisterShipmentInputDtoBuilder WithConsignee(string ConsigneeName, string ConsigneeAddress, string ConsigneeReference)
    {
        _result.ConsigneeName = ConsigneeName;
        _result.ConsigneeReference = ConsigneeReference;
        _result.ConsigneeAddress = ConsigneeAddress;
        return this;
    }

    public RegisterShipmentInputDtoBuilder WithGeneralData(decimal insuranceValue)
    {
        _result.InsuranceValue = insuranceValue;
        return this;
    }

    public RegisterShipmentInputDtoBuilder WithLineItems(List<string> items)
    {
        _result.LineItems = items;
        return this;
    }
}

internal static class ConsignorMap
{
    public static void Map(Person source, RegisterShipmentInputDtoBuilder builder)
        => builder.WithConsignor(source.Name, source.Address, source.Id.ToString());
}

internal static class ConsigneeMap
{
    public static void Map(Person source, RegisterShipmentInputDtoBuilder builder)
        => builder.WithConsignee(source.Name, source.Address, source.Id.ToString());
}

internal static class LineItemsMap
{
    public static void Map(IEnumerable<Item> source, RegisterShipmentInputDtoBuilder builder)
        => builder.WithLineItems(
            source.Select(x => $"id: {x.ProductId} - qty: {x.Quantity}").ToList());
}
