using System.Collections.Generic;

namespace AutomatedAccountingSystem.BusinessObjects
{
    public class Milk
    {
        public Milk() { }
        public int MilkId { get; set; }
        public string Class { get; set; }
        public string Density { get; set; }
        public float? FatContent { get; set; }
        public float? Acidity { get; set; }
        public float? Temperature { get; set; }
        public string Packing { get; set; }
        public int? Seats { get; set; }
        public float? Grossmass { get; set; }
        public float? NetMass { get; set; }
        public float? TareMass { get; set; }
        public string Bucterial { get; set; }
        public float? BaseMass { get; set; }
        public float? Price { get; set; }
        public string GroupPurity { get; set; }

        public static List<Milk> GetAllMilk()
        {
            return new List<Milk>{
                    new Milk{
                        MilkId = 111,
                        Class = "Milk 1"
                    },
                    new Milk{
                        MilkId = 222,
                        Class = "Milk 2"
                    },
                    new Milk{
                        MilkId = 333,
                        Class = "Milk 3"
                    }
                };
        }
    }
}
