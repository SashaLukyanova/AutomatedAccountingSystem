
namespace AutomatedAccountingSystem.BusinessObjects
{
    public class Cattle
    {
        public Cattle() { }
        public int CattleId { get; set; }
        public string ObjectsGroup { get; set; }
        public float? LiveWeight { get; set; }
        public float? Age { get; set; }
        public float? InventoryNum { get; set; }
        public string Fatness { get; set; }
        public int? Number { get; set; }
        public float? Price { get; set; }
    }
}
