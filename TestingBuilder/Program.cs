// See https://aka.ms/new-console-template for more information
using TestingBuilder;

var upsertDto = new UpsertShipmentDto(
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

ConsignorMap.Map(upsertDto.Retailer, builder);
ConsigneeMap.Map(upsertDto.Shopper, builder);
LineItemsMap.Map(upsertDto.Items, builder);

var carrierDto = builder.GetResult();

// approach #2 -> using the builder inside one unique mapper, for simple mappers
var dto = CarrierDtoMapper.Map(upsertDto);