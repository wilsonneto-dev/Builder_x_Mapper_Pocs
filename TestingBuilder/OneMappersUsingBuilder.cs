namespace TestingBuilder;

public sealed class CarrierDtoBuilder
{
    private readonly RegisterShipmentInputDto _result;

    public CarrierDtoBuilder() => _result = new();

    public RegisterShipmentInputDto GetResult() => _result;

    public CarrierDtoBuilder WithConsignor(string ConsignorName, string ConsignorAddress, string ConsignorReference)
    {
        _result.ConsignorName = ConsignorName;
        _result.ConsignorAddress = ConsignorAddress;
        _result.ConsignorReference = ConsignorReference;
        return this;
    }

    public CarrierDtoBuilder WithConsignee(string ConsigneeName, string ConsigneeAddress, string ConsigneeReference)
    {
        _result.ConsigneeName = ConsigneeName;
        _result.ConsigneeReference = ConsigneeReference;
        _result.ConsigneeAddress = ConsigneeAddress;
        return this;
    }

    public CarrierDtoBuilder WithGeneralData(decimal insuranceValue) {
        _result.InsuranceValue = insuranceValue;
        return this;
    }

    public CarrierDtoBuilder WithLineItems(List<string> items)
    {
        _result.LineItems = items;
        return this;
    }
}

internal static class CarrierDtoMapper
{
    public static RegisterShipmentInputDto Map(UpsertShipmentDto src)
        => (new RegisterShipmentInputDtoBuilder())
            .WithConsignee(src.Shopper.Name, src.Shopper.Address, src.Shopper.Id.ToString())
            .WithConsignor(src.Retailer.Name, src.Retailer.Address, src.Retailer.Id.ToString())
            .WithLineItems(src.Items.Select(x => $"id: {x.ProductId} - qty: {x.Quantity}").ToList())
            .WithGeneralData(src.Items.Aggregate((decimal)0, (total, x) => total + x.Value))
            .GetResult();
}