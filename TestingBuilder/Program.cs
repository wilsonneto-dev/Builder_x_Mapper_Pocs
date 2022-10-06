// See https://aka.ms/new-console-template for more information
using TestingBuilder;

var upsaertDto = new UpsertShipmentDto(
    Guid.NewGuid(), 
    "Active", 
    DateTime.Now, 
    new(1, "Retailer", "Address Retailer"), 
    new(2, "Customer", "Customer Address"), 
    null, 
    new List<Item> { 
        new(1, 1, 200)});

// approach #1 -> passing the builder to maps
var builder = new RegisterShipmentInputDtoBuilder();

ConsignorMap.Map(upsaertDto.Retailer, builder);
ConsigneeMap.Map(upsaertDto.Shopper, builder);
LineItemsMap.Map(upsaertDto.Items, builder);

var carrierDto = builder.GetResult();

// ------------------

