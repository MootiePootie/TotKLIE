
using System.Diagnostics;
using System.Text;
using SysBot.Base;
using ToTKLIE.Enums;
using ToTKLIE.Vision;

namespace ToTKLIE.InventoryHandlers
{
    public class ItemHandlers
    {
        
        public static async Task<List<Item>> ReadItems(SwitchSocketAsync SwitchConnection, ulong CurrentOffset, int SkipSize, int ReadSize, int DataSize, int ItemType)
        {
            List<Item> list = new List<Item>();
            byte[] tempdata;
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(CurrentOffset, DataSize, CancellationToken.None);

            for (int i = 0; i < 500; i++)
            {
                if (ItemType != (int)ItemEnum.arrows)
                {
                    tempdata = data[((i * SkipSize)..((i * SkipSize) + ReadSize))];
                    if (tempdata.All(b => b == 0))
                    {
                        break;
                    }

                    if (Encoding.ASCII.GetString(tempdata).Contains("Head"))
                    {
                        tempdata = tempdata.SkipLast(1).ToArray();
                    }
                    while (tempdata[tempdata.Length - 1] == 0x0)
                    {
                        tempdata = tempdata.SkipLast(1).ToArray();
                    }
                    if (ItemType == (int)ItemEnum.food)
                    {
                        if (Array.Exists(tempdata, element => element == 0x0))
                        {
                            break;
                        }
                    }

                    Item Current = LoadItems.ProcessData(tempdata.ToList(), ItemType);
                    list.Add(Current);

                }
                
            }
            if (ItemType == (int)ItemEnum.arrows) 
            {
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.ArrowCountOffset, 0x8, CancellationToken.None);
                Item Current = new Item() { Type = (int)ItemEnum.arrows, Quantity = BitConverter.ToInt32(data[0..4]), Name = "Normal Arrows", ID = "NormalArrow", Image = "NormalArrow" };
                Debug.WriteLine(Current.Quantity);
                list.Add(Current);
            }
            if (ItemType == (int)ItemEnum.materials || ItemType == (int)ItemEnum.zonai) 
            {
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.QuantityOffsetList[ItemType], Sizes.QuantitySavePersistDistance[ItemType], CancellationToken.None);
                
                int i = 0;
                foreach (var item in list) 
                {
                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Quantity = BitConverter.ToInt32(tempdata);
                    i++;
                }
            }
            if (ItemType == (int)ItemEnum.bows || ItemType == (int)ItemEnum.shields || ItemType == (int)ItemEnum.weapons) 
            {
                int i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.ModifierOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {
                    
                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Modifier = tempdata.Reverse().ToArray();
                    i++;
                }
                i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.ModValueOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.ModifierValue = BitConverter.ToInt32(tempdata);
                    i++;
                }
                i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.DurabilityOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Durability = BitConverter.ToInt32(tempdata);
                    i++;
                }
            }
            if (ItemType == (int)ItemEnum.armors)
            {
                int i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.ModifierOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Modifier = tempdata.Reverse().ToArray();
                    i++;
                }
            }

            if (ItemType == (int)ItemEnum.food)
            {
                int i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.ModifierOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Modifier = tempdata.Reverse().ToArray();
                    i++;
                }
                i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.ModValueOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    if (tempdata.All(b => b == 0xFF))
                    {
                        tempdata = new byte[4] { 0x0, 0x0, 0x0, 0x0 };
                        
                    }
                    
                    item.ModifierValue = BitConverter.ToInt32(tempdata);
                    i++;
                }
                i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.QuantityOffsetList[ItemType], Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Quantity = BitConverter.ToInt32(tempdata);
                    i++;
                }
                i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.FoodHealthOffset, Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {

                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    item.Health = BitConverter.ToInt32(tempdata);
                    i++;
                }
                i = 0;
                data = await SwitchConnection.ReadBytesAbsoluteAsync(Form1.FoodDurationOffset, Sizes.ModifierSavePersistDistance[ItemType], CancellationToken.None);
                foreach (var item in list)
                {
                    
                    tempdata = data[(i * 4)..((i * 4) + 4)];
                    if (tempdata.All(b => b == 0xFF))
                    {
                        tempdata = new byte[4] { 0x0, 0x0, 0x0, 0x0 };
                        
                    }
                    item.Duration = BitConverter.ToInt32(tempdata);
                    i++;
                }
            }
            return list;
        }





        
    }
}
