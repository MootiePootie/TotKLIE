using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToTKLIE
{
    internal class ItemData
    {
    }

    public class FoodData 
    {
        public int HealthRestoration { get; set; }
        public int ID { get; set; }
        public int Quantity { get; set; }

    }

    public class ArmorData 
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string Image { get; set; }
    }


    public class Item 
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string Image { get; set; }
        public int Health { get; set; }
        public int Quantity { get; set; }
        public byte[] Modifier { get; set; }
        public int Durability { get; set; }
        public int ModifierValue { get; set; }
        public int Duration { get; set; }

        public string Fusion { get; set; }

    }



}
