using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChannelEngine_Sheldon.BusinessLogic.Models
{
    public partial class Welcome
    {
        [JsonProperty("Content")]
        public Content[] Content { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }

        [JsonProperty("TotalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("ItemsPerPage")]
        public long ItemsPerPage { get; set; }

        [JsonProperty("StatusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }

        [JsonProperty("LogId")]
        public string LogId { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ValidationErrors")]
        public ValidationErrors ValidationErrors { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("ChannelName")]
        public string ChannelName { get; set; }

        [JsonProperty("ChannelId")]
        public long ChannelId { get; set; }

        [JsonProperty("GlobalChannelName")]
        public string GlobalChannelName { get; set; }

        [JsonProperty("GlobalChannelId")]
        public long GlobalChannelId { get; set; }

        [JsonProperty("ChannelOrderSupport")]
        public string ChannelOrderSupport { get; set; }

        [JsonProperty("ChannelOrderNo")]
        public string ChannelOrderNo { get; set; }

        [JsonProperty("MerchantOrderNo")]
        public string MerchantOrderNo { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("IsBusinessOrder")]
        public bool IsBusinessOrder { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("UpdatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("MerchantComment")]
        public string MerchantComment { get; set; }

        [JsonProperty("BillingAddress")]
        public IngAddress BillingAddress { get; set; }

        [JsonProperty("ShippingAddress")]
        public IngAddress ShippingAddress { get; set; }

        [JsonProperty("SubTotalInclVat")]
        public long SubTotalInclVat { get; set; }

        [JsonProperty("SubTotalVat")]
        public long SubTotalVat { get; set; }

        [JsonProperty("ShippingCostsVat")]
        public long ShippingCostsVat { get; set; }

        [JsonProperty("TotalInclVat")]
        public long TotalInclVat { get; set; }

        [JsonProperty("TotalVat")]
        public long TotalVat { get; set; }

        [JsonProperty("OriginalSubTotalInclVat")]
        public long OriginalSubTotalInclVat { get; set; }

        [JsonProperty("OriginalSubTotalVat")]
        public long OriginalSubTotalVat { get; set; }

        [JsonProperty("OriginalShippingCostsInclVat")]
        public long OriginalShippingCostsInclVat { get; set; }

        [JsonProperty("OriginalShippingCostsVat")]
        public long OriginalShippingCostsVat { get; set; }

        [JsonProperty("OriginalTotalInclVat")]
        public long OriginalTotalInclVat { get; set; }

        [JsonProperty("OriginalTotalVat")]
        public long OriginalTotalVat { get; set; }

        [JsonProperty("Lines")]
        public Line[] Lines { get; set; }

        [JsonProperty("ShippingCostsInclVat")]
        public long ShippingCostsInclVat { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("CompanyRegistrationNo")]
        public string CompanyRegistrationNo { get; set; }

        [JsonProperty("VatNo")]
        public string VatNo { get; set; }

        [JsonProperty("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("PaymentReferenceNo")]
        public string PaymentReferenceNo { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("OrderDate")]
        public DateTimeOffset OrderDate { get; set; }

        [JsonProperty("ChannelCustomerNo")]
        public string ChannelCustomerNo { get; set; }

        [JsonProperty("ExtraData")]
        public ExtraData ExtraData { get; set; }
    }

    public partial class IngAddress
    {
        [JsonProperty("Line1")]
        public string Line1 { get; set; }

        [JsonProperty("Line2")]
        public string Line2 { get; set; }

        [JsonProperty("Line3")]
        public string Line3 { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("CompanyName")]
        public string CompanyName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("StreetName")]
        public string StreetName { get; set; }

        [JsonProperty("HouseNr")]
        public string HouseNr { get; set; }

        [JsonProperty("HouseNrAddition")]
        public string HouseNrAddition { get; set; }

        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Region")]
        public string Region { get; set; }

        [JsonProperty("CountryIso")]
        public string CountryIso { get; set; }

        [JsonProperty("Original")]
        public string Original { get; set; }
    }

    public partial class ExtraData
    {
        [JsonProperty("additionalProp1")]
        public string AdditionalProp1 { get; set; }

        [JsonProperty("additionalProp2")]
        public string AdditionalProp2 { get; set; }

        [JsonProperty("additionalProp3")]
        public string AdditionalProp3 { get; set; }
    }

    public partial class Line
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("IsFulfillmentByMarketplace")]
        public bool IsFulfillmentByMarketplace { get; set; }

        [JsonProperty("Gtin")]
        public string Gtin { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("StockLocation")]
        public StockLocation StockLocation { get; set; }

        [JsonProperty("UnitVat")]
        public long UnitVat { get; set; }

        [JsonProperty("LineTotalInclVat")]
        public long LineTotalInclVat { get; set; }

        [JsonProperty("LineVat")]
        public long LineVat { get; set; }

        [JsonProperty("OriginalUnitPriceInclVat")]
        public long OriginalUnitPriceInclVat { get; set; }

        [JsonProperty("OriginalUnitVat")]
        public long OriginalUnitVat { get; set; }

        [JsonProperty("OriginalLineTotalInclVat")]
        public long OriginalLineTotalInclVat { get; set; }

        [JsonProperty("OriginalLineVat")]
        public long OriginalLineVat { get; set; }

        [JsonProperty("OriginalFeeFixed")]
        public long OriginalFeeFixed { get; set; }

        [JsonProperty("BundleProductMerchantProductNo")]
        public string BundleProductMerchantProductNo { get; set; }

        [JsonProperty("JurisCode")]
        public string JurisCode { get; set; }

        [JsonProperty("JurisName")]
        public string JurisName { get; set; }

        [JsonProperty("VatRate")]
        public long VatRate { get; set; }

        [JsonProperty("ExtraData")]
        public ExtraDatum[] ExtraData { get; set; }

        [JsonProperty("ChannelProductNo")]
        public string ChannelProductNo { get; set; }

        [JsonProperty("MerchantProductNo")]
        public string MerchantProductNo { get; set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; set; }

        [JsonProperty("CancellationRequestedQuantity")]
        public long CancellationRequestedQuantity { get; set; }

        [JsonProperty("UnitPriceInclVat")]
        public long UnitPriceInclVat { get; set; }

        [JsonProperty("FeeFixed")]
        public long FeeFixed { get; set; }

        [JsonProperty("FeeRate")]
        public long FeeRate { get; set; }

        [JsonProperty("Condition")]
        public string Condition { get; set; }

        [JsonProperty("ExpectedDeliveryDate")]
        public DateTimeOffset ExpectedDeliveryDate { get; set; }
    }

    public partial class ExtraDatum
    {
        [JsonProperty("Key")]
        public string Key { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }

    public partial class StockLocation
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class ValidationErrors
    {
        [JsonProperty("additionalProp1")]
        public string[] AdditionalProp1 { get; set; }

        [JsonProperty("additionalProp2")]
        public string[] AdditionalProp2 { get; set; }

        [JsonProperty("additionalProp3")]
        public string[] AdditionalProp3 { get; set; }
    }

}
