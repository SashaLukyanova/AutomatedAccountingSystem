using System;
using System.Collections.Generic;

namespace AutomatedAccountingSystem.BusinessObjects
{
    public class Order
    {
        //public Order() { }

        public List<Milk> MilkObject;
        public List<Cattle> CattleObject;
        public Order()
        {
            MilkObject = new List<Milk>();
            CattleObject = new List<Cattle>();
        }
        public int OrderId { get; set; }
        public string TransportOwner { get; set; }
        public string Auto { get; set; }
        public string Waybill { get; set; }
        public string Driver { get; set; }
        public string TypeTransporation { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public string LoadingPoint { get; set; }
        public string ShippingPoint { get; set; }
        public string Route { get; set; }
        public string Contract { get; set; }
        public string Trailer { get; set; }
        public string Garage { get; set; }
        public float? Rate { get; set; }
        public DateTime DateContract { get; set; }
        public DateTime DateShipping { get; set; }
        public int? Customer { get; set; }
        public int? Product { get; set; }
    }
}
