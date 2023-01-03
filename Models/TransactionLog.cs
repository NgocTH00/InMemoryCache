using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Models
{
    public class TransactionLog
    {

        [JsonInclude]
        public Guid ATranId { get; set; }
        [JsonInclude]
        public Guid AOrderId { get; set; }
        [JsonInclude]
        public string AClientCode { get; set; }
        [JsonInclude]
        public string AStockCode { get; set; }
        [JsonInclude]
        public string AExchange { get; set; }
        [JsonInclude]
        public string ABuySell { get; set; }
        [JsonInclude]
        public string AOrderType { get; set; }
        [JsonInclude]
        public int AQuantity { get; set; }
        [JsonInclude]
        public double APrice { get; set; }
        [JsonInclude]
        public string APriceType { get; set; }
        [JsonInclude]
        public string ATradingAccount { get; set; }
        [JsonInclude]
        public string APlaceBy { get; set; }
        [JsonInclude]
        public string AProductType { get; set; }
        [JsonInclude]
        public string AMarketSegment { get; set; }
        [JsonInclude]
        public int AModifyFlag { get; set; }
        [JsonInclude]
        public int ACancelFlag { get; set; }
        [JsonInclude]
        public DateTime ALastTradedTime { get; set; }
        [JsonInclude]
        public Guid AOrigOrderId { get; set; }
        [JsonInclude]
        public string ASource { get; set; }
        [JsonInclude]
        public DateTime ADateTime { get; set; }
        [JsonInclude]
        public double ALatestPrice { get; set; }
        [JsonInclude]
        public int AQuantityMax { get; set; }
        [JsonInclude]
        public int ACallMargin_Call { get; set; }
        [JsonInclude]
        public int AIsExpired { get; set; }
        [JsonInclude]
        public string ALastestStatus { get; set; }
        [JsonInclude]
        public int ARemainQty { get; set; }
        [JsonInclude]
        public string AConditionType { get; set; }
        [JsonInclude]
        public int AMaxAid { get; set; }

        [JsonConstructor]
        public TransactionLog(Guid aTranId, Guid aOrderId, string aClientCode, string aStockCode, string aExchange, string aBuySell, string aOrderType, int aQuantity, double aPrice, string aPriceType, string aTradingAccount, string aPlaceBy, string aProductType, string aMarketSegment, int aModifyFlag, int aCancelFlag, DateTime aLastTradedTime, Guid aOrigOrderId, string aSource, DateTime aDateTime, double aLatestPrice, int aQuantityMax, int aCallMargin_Call, int aIsExpired, string aLastestStatus, int aRemainQty, string aConditionType, int aMaxAid)
        {
            ATranId = aTranId;
            AOrderId = aOrderId;
            AClientCode = aClientCode;
            AStockCode = aStockCode;
            AExchange = aExchange;
            ABuySell = aBuySell;
            AOrderType = aOrderType;
            AQuantity = aQuantity;
            APrice = aPrice;
            APriceType = aPriceType;
            ATradingAccount = aTradingAccount;
            APlaceBy = aPlaceBy;
            AProductType = aProductType;
            AMarketSegment = aMarketSegment;
            AModifyFlag = aModifyFlag;
            ACancelFlag = aCancelFlag;
            ALastTradedTime = aLastTradedTime;
            AOrigOrderId = aOrigOrderId;
            ASource = aSource;
            ADateTime = aDateTime;
            ALatestPrice = aLatestPrice;
            AQuantityMax = aQuantityMax;
            ACallMargin_Call = aCallMargin_Call;
            AIsExpired = aIsExpired;
            ALastestStatus = aLastestStatus;
            ARemainQty = aRemainQty;
            AConditionType = aConditionType;
            AMaxAid = aMaxAid;
        }

        public TransactionLog(
            Guid aTranId, Guid aOrderId, string aClientCode,
            string aStockCode, string aExchange, string buyOrSell,
            string aOrderType, int aQuantity, double aPrice,
            string aPriceType, string aTradingAccount, string aPlaceBy,
            string aProductType, string aMarketSegment, string aSource)
        {
            ATranId = aTranId;
            AOrderId = aOrderId;
            AClientCode = aClientCode;
            AStockCode = aStockCode;
            AExchange = aExchange;
            ABuySell = buyOrSell;
            AOrderType = aOrderType;
            AQuantity = aQuantity;
            APrice = aPrice;
            APriceType = aPriceType;
            ATradingAccount = aTradingAccount;
            APlaceBy = aPlaceBy;
            AProductType = aProductType;
            AMarketSegment = aMarketSegment;
            AModifyFlag = 0;
            ACancelFlag = 0;
            AOrigOrderId = aOrderId;
            ASource = aSource;
            ADateTime = DateTime.Now;
            ALatestPrice = 200000;
            AQuantityMax = 100000000;
        }
    }
}
