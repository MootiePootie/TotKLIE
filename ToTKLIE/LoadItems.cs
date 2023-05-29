using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ToTKLIE.Enums;
using ToTKLIE.Vision;


namespace ToTKLIE
{
    public class LoadItems
    {
        public static Item ProcessData(List<byte> Data, int ItemType) 
        {
            Item item = new Item();


            if (ItemType == -1)
            {
                item.ID = Encoding.ASCII.GetString(Data.ToArray());
            }
            else if (ItemType == (int)ItemEnum.armors)
            {
                item.Type = ItemType;
                item.ID = Encoding.ASCII.GetString(Data.ToArray());
                item.Health = 0;
                item.Quantity = 1;
                item.Image = Form1.AllItems[ItemType].FirstOrDefault(o => o.ID == item.ID).Image;
                item.Name = Form1.AllItems[ItemType].FirstOrDefault(o => o.ID == item.ID).Image;
            }
            else 
            {
                item.Type = ItemType;
                item.ID = Encoding.ASCII.GetString(Data.ToArray());
                item.Health = 0;
                item.Quantity = 1;
                item.Image = Encoding.ASCII.GetString(Data.ToArray());
                Debug.WriteLine(BitConverter.ToString(Data.ToArray()));
                item.Name = Form1.AllItems[ItemType].FirstOrDefault(o => o.ID == item.ID).Image;
            }
            


            return item;
        }


        public static byte[] PrepareData(Item item, int ItemType) 
        {
            List<byte> bytes = new List<byte>();
            bytes = Encoding.ASCII.GetBytes(item.ID).ToList();
            while (bytes.Count != Sizes.DataSize[ItemType]) 
            {
                bytes.Add(0x0);
            }
            return bytes.ToArray();

        }

    }
}
