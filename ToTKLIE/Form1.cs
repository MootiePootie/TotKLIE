using SysBot.Base;
using System.Diagnostics;
using System.Net.Sockets;
using System.Numerics;
using ToTKLIE.Enums;
using ToTKLIE.InventoryHandlers;
using ToTKLIE.Vision;

namespace ToTKLIE
{
    public partial class Form1 : Form
    {
        public static SwitchConnectionConfig Config = new SwitchConnectionConfig() { Protocol = SwitchProtocol.WiFi, Port = 6000 };
        public static SwitchSocketAsync SwitchConnection;

        //public IReadOnlyList<long> TestPointer { get; } = new long[] { 0x47242B8, 0x138, 0xEF8, 0x7F8 };  --BACKUP
        private ulong ArmorOffset;
        private ulong BowOffset;
        private ulong ArrowOffset;
        private ulong ShieldOffset;
        private ulong WeaponOffset;
        private ulong MaterialsOffset;
        private ulong FoodOffset;
        private ulong ZonaiOffset;

        private ulong MaterialCountOffset;
        private ulong FoodCountOffset;
        public static ulong ArrowCountOffset;
        private ulong ZonaiCountOffset;

        private ulong BowModifierOffset;
        private ulong ShieldModifierOffset;
        private ulong WeaponModifierOffset;
        private ulong ArmorModifierOffset;
        private ulong FoodModifierOffset;

        private ulong ShieldModifierValueOffset;
        private ulong BowModifierValueOffset;
        private ulong WeaponModifierValueOffset;
        private ulong FoodModifierValueOffset;

        private ulong ShieldDurabilityOffset;
        private ulong BowDurabilityOffset;
        private ulong WeaponDurabilityOffset;

        public static ulong FoodDurationOffset;
        public static ulong FoodHealthOffset;

        public static ulong ShieldFusionOffset;
        public static ulong WeaponFusionOffset;

        private ulong CurrentOffset;


        public List<Dictionary<string, string>> Dictionaries = new List<Dictionary<string, string>>() {
            ItemDictionary.ArmorDictionary,
            ItemDictionary.BowDictionary,
            ItemDictionary.ArrowDictionary,
            ItemDictionary.ShieldDictionary,
            ItemDictionary.WeaponDictionary,
            ItemDictionary.MaterialsDictionary,
            ItemDictionary.FoodDictionary,
            ItemDictionary.ZonaiDictionary

        };

        List<List<Item>> AllFusions = new List<List<Item>>();


        public static List<List<Item>> AllItems = new List<List<Item>>();

        public static List<Item> LoadedItems = new List<Item>();
        public static List<ulong> OffsetList;
        public static List<ulong> QuantityOffsetList;
        public static List<ulong> ModifierOffsetList;
        public static List<ulong> ModValueOffsetList;
        public static List<ulong> DurabilityOffsetList;
        int selectedItem;
        int SelectedInventory;

        List<int> IndexChanged = new List<int>();

        Item EditItem = new Item() { Health = 0, ID = "Armor_001_Head", Name = "Hylian Hood", Image = "Armor_001_Head", Type = (int)ItemEnum.armors, Modifier = new byte[4] { 0x50, 0x50, 0x50, 0x50 } };
        public Form1()
        {
            InitializeComponent();
            string temppic = string.Empty;
            int loop = 0;

            foreach (var Dictionary in Dictionaries)
            {
                List<Item> L = new List<Item>();
                foreach (var I in Dictionary)
                {

                    if (I.Value.Contains("★"))
                    {

                    }
                    else
                    {
                        temppic = I.Key;
                    }
                    Item item = new Item();
                    item.Type = loop;
                    item.Name = I.Value;
                    item.ID = I.Key;
                    item.Image = temppic;
                    item.Fusion = "None";
                    L.Add(item);

                }
                AllItems.Add(L);
                loop++;
            }
            SelectedInventory = 0;
            selectedItem = 0;

            ItemNameCB.DataSource = new BindingSource(ItemDictionary.ArmorDictionary, null);
            ItemModifierCB.DataSource = new BindingSource(ItemDictionary.DyeDictionary, null);

            ItemModifierCB.DisplayMember = "Value";
            ItemModifierCB.ValueMember = "Key";

            ItemNameCB.DisplayMember = "Value";
            ItemNameCB.ValueMember = "Key";
            EditItem = AllItems[0][0];
            UpdateEditor(EditItem);
            MessageBox.Show(
                "This program is experimentantal.\nBy using this program you assume all responsibility for any damage that may occur to your games save file. \nIt is highly recommended that you create a backup of your save before using this program, just to be safe. \nIf you encounter a bug please report it to the Github or contact me on Twitter.",
                "Important");

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            Config.IP = textBox1.Text;
            SwitchConnection = new SwitchSocketAsync(Config);

            if (await ConnectionRoutine())
            {

            }
        }


        async Task<bool> ConnectionRoutine()
        {
            StatusLabel.Text = "Attempting Connection...";
            await Task.Delay(100);
            try
            {
                SwitchConnection.Connect();
                StatusLabel.Text = $"Connected to {Config.IP}";
                await Task.Delay(500);

            }
            catch (SocketException err)
            {
                StatusLabel.Text = ("Connection Failed!");

            }
            if (SwitchConnection.Connected)
            {
                StatusLabel.Text = "Performing Initial Reads...";
                ArmorOffset = await SwitchConnection.PointerAll(Offsets.ArmorPointer, CancellationToken.None);
                BowOffset = await SwitchConnection.PointerAll(Offsets.BowPointer, CancellationToken.None);
                ArrowOffset = await SwitchConnection.PointerAll(Offsets.ArrowCountPointer, CancellationToken.None);
                ShieldOffset = await SwitchConnection.PointerAll(Offsets.ShieldPointer, CancellationToken.None);
                WeaponOffset = await SwitchConnection.PointerAll(Offsets.WeaponPointer, CancellationToken.None);
                MaterialsOffset = await SwitchConnection.PointerAll(Offsets.MaterialsPointer, CancellationToken.None);
                FoodOffset = await SwitchConnection.PointerAll(Offsets.FoodPointer, CancellationToken.None);
                ZonaiOffset = await SwitchConnection.PointerAll(Offsets.ZonaiPointer, CancellationToken.None);

                MaterialCountOffset = await SwitchConnection.PointerAll(Offsets.MaterialCountPointer, CancellationToken.None);
                ArrowCountOffset = await SwitchConnection.PointerAll(Offsets.ArrowCountPointer, CancellationToken.None);
                ZonaiCountOffset = await SwitchConnection.PointerAll(Offsets.ZonaiCountPointer, CancellationToken.None);

                BowModifierOffset = await SwitchConnection.PointerAll(Offsets.BowModifierPointer, CancellationToken.None);
                ShieldModifierOffset = await SwitchConnection.PointerAll(Offsets.ShieldModifierPointer, CancellationToken.None);
                WeaponModifierOffset = await SwitchConnection.PointerAll(Offsets.WeaponModifierPointer, CancellationToken.None);
                ArmorModifierOffset = await SwitchConnection.PointerAll(Offsets.ArmorModifierPointer, CancellationToken.None);
                FoodModifierOffset = await SwitchConnection.PointerAll(Offsets.FoodModifierPointer, CancellationToken.None);

                WeaponFusionOffset = await SwitchConnection.PointerAll(Offsets.WeaponFusionPointer, CancellationToken.None);
                ShieldFusionOffset = await SwitchConnection.PointerAll(Offsets.ShieldFusionPointer, CancellationToken.None);

                ShieldModifierValueOffset = await SwitchConnection.PointerAll(Offsets.ShieldModifierValuePointer, CancellationToken.None);
                BowModifierValueOffset = await SwitchConnection.PointerAll(Offsets.BowModifierValuePointer, CancellationToken.None);
                WeaponModifierValueOffset = await SwitchConnection.PointerAll(Offsets.WeaponModifierValuePointer, CancellationToken.None);
                FoodModifierValueOffset = await SwitchConnection.PointerAll(Offsets.FoodModifierValuePointer, CancellationToken.None);

                BowDurabilityOffset = await SwitchConnection.PointerAll(Offsets.BowDurabilityPointer, CancellationToken.None);
                ShieldDurabilityOffset = await SwitchConnection.PointerAll(Offsets.ShieldDurabilityPointer, CancellationToken.None);
                WeaponDurabilityOffset = await SwitchConnection.PointerAll(Offsets.WeaponDurabilityPointer, CancellationToken.None);

                FoodDurationOffset = await SwitchConnection.PointerAll(Offsets.FoodDurationPointer, CancellationToken.None);
                FoodHealthOffset = await SwitchConnection.PointerAll(Offsets.FoodHealthPointer, CancellationToken.None);
                FoodCountOffset = await SwitchConnection.PointerAll(Offsets.FoodCountPointer, CancellationToken.None);

                ModValueOffsetList = new List<ulong> { 0, BowModifierValueOffset, 0, ShieldModifierValueOffset, WeaponModifierValueOffset, 0, FoodModifierValueOffset };
                DurabilityOffsetList = new List<ulong> { 0, BowDurabilityOffset, 0, ShieldDurabilityOffset, WeaponDurabilityOffset };
                QuantityOffsetList = new List<ulong> { 0, 0, ArrowCountOffset, 0, 0, MaterialCountOffset, FoodCountOffset, ZonaiCountOffset };
                ModifierOffsetList = new List<ulong> { ArmorModifierOffset, BowModifierOffset, 0, ShieldModifierOffset, WeaponModifierOffset, 0, FoodModifierOffset, };
                OffsetList = new List<ulong> { ArmorOffset, BowOffset, ArrowOffset, ShieldOffset, WeaponOffset, MaterialsOffset, FoodOffset, ZonaiOffset };
                CurrentOffset = ArmorOffset;

                ItemTypeCB.Enabled = true;
                ItemTypeCB.SelectedIndex = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchConnection.Disconnect();
                Debug.WriteLine("disconnected");
            }
            catch (SocketException err)
            {
                MessageBox.Show("No Switch Connected");
            }

        }
        private void ItemNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditItem.Image = AllItems[SelectedInventory][ItemNameCB.SelectedIndex].Image;
            EditItem.Name = ItemNameCB.SelectedText;
            EditItem.ID = ItemNameCB.SelectedValue.ToString();
            UpdateEditor(EditItem);
        }




        void RefreshGrid(int Section)
        {

            flowLayoutPanel1.Controls.Clear();
            int i = 0;
            foreach (Item item in LoadedItems)
            {
                PictureBox pic = new PictureBox() { Width = 80, Height = 80, SizeMode = PictureBoxSizeMode.StretchImage };
                Image itemImg;
                string ItemFolder = string.Empty;
                ItemFolder = Enum.GetName(typeof(ItemEnum), item.Type);
                try
                {
                    itemImg = Image.FromFile($"Icons/{ItemFolder}/{item.Image}.png");
                }
                catch (Exception ex)
                {
                    itemImg = Image.FromFile($"Icons/_blank.png");
                }

                pic.Image = itemImg;
                pic.Tag = i;
                pic.Click += (s, e) =>
                {
                    selectedItem = (int)pic.Tag;
                    label2.Text = $"Index: {selectedItem + 1}";
                    EditItem = item;
                    //Debug.WriteLine(BitConverter.ToString(item.Modifier));
                    //ItemNameCB.SelectedIndex = ItemDictionary.ArmorDictionary.Keys.ToList().IndexOf(item.ID);
                    UpdateEditor(EditItem);
                };
                pic.MouseEnter += (s, e) => { pic.BackColor = Color.LightCyan; };
                pic.MouseLeave += (s, e) => { pic.BackColor = Color.FromKnownColor(KnownColor.ControlDark); };
                pic.BackColor = pic.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
                flowLayoutPanel1.Controls.Add(pic);
                i++;
            }
            StatusLabel.Text = $"Loaded {Enum.GetName(typeof(ItemEnum), SelectedInventory)}!";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditItem.Name = ItemNameCB.Text;
            EditItem.ID = ItemIDBox.Text;

            switch (SelectedInventory)
            {
                case (int)ItemEnum.armors:
                    break;
                case (int)ItemEnum.bows:
                case (int)ItemEnum.shields:
                case (int)ItemEnum.weapons:
                    EditItem.ModifierValue = (int)ItemProperty1.Value;
                    EditItem.Durability = (int)ItemProperty2.Value;
                    break;
                case (int)ItemEnum.arrows:
                case (int)ItemEnum.materials:
                case (int)ItemEnum.zonai:
                case (int)ItemEnum.key:
                    EditItem.Quantity = (int)ItemProperty1.Value;
                    break;
                case (int)ItemEnum.food:
                    EditItem.ModifierValue = (int)ItemProperty1.Value;
                    EditItem.Quantity = (int)ItemProperty2.Value;
                    EditItem.Health = (int)ItemProperty3.Value;
                    EditItem.Duration = (int)ItemProperty4.Value;
                    break;
            }


            IndexChanged.Add(selectedItem);

            LoadedItems[selectedItem] = EditItem;
            RefreshGrid(SelectedInventory);
        }



        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var toChange in IndexChanged)
                {

                    if (SelectedInventory != (int)ItemEnum.arrows)
                    {
                        var Data = LoadItems.PrepareData(LoadedItems[toChange], SelectedInventory);
                        await SwitchConnection.WriteBytesAbsoluteAsync(Data, OffsetList[ItemTypeCB.SelectedIndex] + (ulong)(Sizes.ChunkSize[SelectedInventory] * toChange), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(Data, OffsetList[ItemTypeCB.SelectedIndex] + (ulong)(Sizes.ChunkSize[SelectedInventory] * toChange) + (ulong)Sizes.SavePersistDistance[SelectedInventory], CancellationToken.None);
                    }

                    if (SelectedInventory == (int)ItemEnum.materials || SelectedInventory == (int)ItemEnum.arrows || SelectedInventory == (int)ItemEnum.zonai)
                    {
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Quantity), QuantityOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Quantity), QuantityOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.QuantitySavePersistDistance[SelectedInventory]), CancellationToken.None);
                    }
                    if (SelectedInventory == (int)ItemEnum.bows || SelectedInventory == (int)ItemEnum.shields || SelectedInventory == (int)ItemEnum.weapons)
                    {
                        await SwitchConnection.WriteBytesAbsoluteAsync(LoadedItems[toChange].Modifier.Reverse().ToArray(), ModifierOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(LoadedItems[toChange].Modifier.Reverse().ToArray(), ModifierOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);

                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].ModifierValue), ModValueOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].ModifierValue), ModValueOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);

                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Durability), DurabilityOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Durability), DurabilityOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);
                    }
                    if (SelectedInventory == (int)ItemEnum.armors)
                    {
                        await SwitchConnection.WriteBytesAbsoluteAsync(LoadedItems[toChange].Modifier.Reverse().ToArray(), ArmorModifierOffset + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(LoadedItems[toChange].Modifier.Reverse().ToArray(), ArmorModifierOffset + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);
                    }
                    if (SelectedInventory == (int)ItemEnum.food)
                    {
                        await SwitchConnection.WriteBytesAbsoluteAsync(LoadedItems[toChange].Modifier.Reverse().ToArray(), ModifierOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(LoadedItems[toChange].Modifier.Reverse().ToArray(), ModifierOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);

                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].ModifierValue), ModValueOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].ModifierValue), ModValueOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);

                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Duration), FoodDurationOffset + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Duration), FoodDurationOffset + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);

                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Health), FoodHealthOffset + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Health), FoodHealthOffset + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);

                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Quantity), QuantityOffsetList[SelectedInventory] + (ulong)(toChange * 4), CancellationToken.None);
                        await SwitchConnection.WriteBytesAbsoluteAsync(BitConverter.GetBytes(LoadedItems[toChange].Quantity), QuantityOffsetList[SelectedInventory] + (ulong)(toChange * 4) + (ulong)(Sizes.ModifierSavePersistDistance[SelectedInventory]), CancellationToken.None);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Switch Connected!");
            }


            IndexChanged.Clear();
        }

        void UpdateEditor(Item ItemType)
        {

            switch (ItemType.Type)
            {
                case (int)ItemEnum.armors:
                    PropertyLabel1.Visible = false;
                    ItemProperty1.Visible = false;


                    ModifierLabel.Text = "Dye:";
                    ItemModifierCB.Enabled = true;


                    PropertyLabel2.Visible = false;
                    ItemProperty2.Visible = false;

                    PropertyLabel3.Visible = false;
                    ItemProperty3.Visible = false;

                    PropertyLabel4.Visible = false;
                    ItemProperty4.Visible = false;

                    break;

                case (int)ItemEnum.bows:
                case (int)ItemEnum.shields:
                case (int)ItemEnum.weapons:
                    ModifierLabel.Text = "Modifier:";
                    ItemModifierCB.Enabled = true;

                    PropertyLabel1.Text = "Mod Value:";
                    ItemProperty1.Visible = true;
                    PropertyLabel1.Visible = true;

                    PropertyLabel2.Text = "Durability:";
                    ItemProperty2.Visible = true;
                    PropertyLabel2.Visible = true;

                    ItemProperty3.Visible = false;
                    PropertyLabel3.Visible = false;

                    PropertyLabel4.Visible = false;
                    ItemProperty4.Visible = false;


                    break;
                case (int)ItemEnum.arrows:
                case (int)ItemEnum.materials:
                case (int)ItemEnum.zonai:
                case (int)ItemEnum.key:
                    ModifierLabel.Text = "Modifier:";
                    ItemModifierCB.Enabled = false;

                    PropertyLabel1.Text = "Quantity:";
                    PropertyLabel1.Visible = true;
                    ItemProperty1.Visible = true;

                    PropertyLabel2.Visible = false;
                    ItemProperty2.Visible = false;

                    PropertyLabel3.Visible = false;
                    ItemProperty3.Visible = false;

                    PropertyLabel4.Visible = false;
                    ItemProperty4.Visible = false;
                    break;
                case (int)ItemEnum.food:
                    ModifierLabel.Text = "Effect:";
                    ItemModifierCB.Enabled = true;

                    PropertyLabel1.Text = "Multiplier:";
                    ItemProperty1.Visible = true;
                    PropertyLabel1.Visible = true;

                    PropertyLabel2.Text = "Quantity:";
                    ItemProperty2.Visible = true;
                    PropertyLabel2.Visible = true;

                    PropertyLabel3.Text = "Health:";
                    ItemProperty3.Visible = true;
                    PropertyLabel3.Visible = true;

                    PropertyLabel4.Text = "Duration:";
                    PropertyLabel4.Visible = true;
                    ItemProperty4.Visible = true;
                    break;

            }
            try
            {
                editor_ItemImage.Image = Image.FromFile($"Icons/{((ItemEnum)ItemType.Type).ToString()}/{EditItem.Image}.png");
            }
            catch (Exception ex)
            {
                editor_ItemImage.Image = Image.FromFile($"Icons/_blank.png");
            }
            try
            {
                ItemNameCB.SelectedValue = ItemType.ID;
                ItemIDBox.Text = ItemType.ID;


                switch (SelectedInventory)
                {
                    case (int)ItemEnum.armors:
                        ItemModifierCB.SelectedValue = BitConverter.ToString(ItemType.Modifier).Replace("-", "");
                        break;
                    case (int)ItemEnum.bows:
                    case (int)ItemEnum.shields:
                    case (int)ItemEnum.weapons:
                        ItemProperty1.Value = ItemType.ModifierValue;
                        ItemProperty2.Value = ItemType.Durability;
                        ItemModifierCB.SelectedValue = BitConverter.ToString(ItemType.Modifier).Replace("-", "");
                        break;
                    case (int)ItemEnum.zonai:
                    case (int)ItemEnum.arrows:
                    case (int)ItemEnum.materials:
                        ItemProperty1.Value = ItemType.Quantity;
                        break;
                    case (int)ItemEnum.food:
                        ItemProperty1.Value = ItemType.ModifierValue;
                        ItemProperty2.Value = ItemType.Quantity;
                        ItemProperty3.Value = ItemType.Health;
                        ItemProperty4.Value = ItemType.Duration;
                        break;
                }

            }
            catch (Exception ex2)
            {
                Debug.WriteLine($"{ItemType.Quantity}, {ItemType.Health}, {ItemType.Duration}, {ItemType.ModifierValue}");
                Debug.WriteLine($"UPEEX {ex2.Message}");
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            RamViewer rv = new RamViewer();
            rv.Show();
        }

        private async void ItemTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                IndexChanged.Clear();
                flowLayoutPanel1.Controls.Clear();
                SelectedInventory = ItemTypeCB.SelectedIndex;

                ItemTypeCB.Enabled = false;
                StatusLabel.Text = $"Loading {Enum.GetName(typeof(ItemEnum), SelectedInventory)}...";

                LoadedItems = await ItemHandlers.ReadItems(SwitchConnection, OffsetList[SelectedInventory], Sizes.ChunkSize[SelectedInventory], Sizes.DataSize[SelectedInventory], Sizes.SavePersistDistance[SelectedInventory], SelectedInventory);
                if (SelectedInventory == (int)ItemEnum.armors)
                {
                    ItemModifierCB.DataSource = new BindingSource(ItemDictionary.DyeDictionary, null);

                }
                else if (SelectedInventory == (int)ItemEnum.food)
                {
                    ItemModifierCB.DataSource = new BindingSource(ItemDictionary.EffectDictionary, null);
                }
                else
                {
                    ItemModifierCB.DataSource = new BindingSource(ItemDictionary.ModifierDictionary, null);
                }
                ItemNameCB.DataSource = new BindingSource(Dictionaries[SelectedInventory], null);
                EditItem = LoadedItems[0];
                UpdateEditor(EditItem);
                RefreshGrid(SelectedInventory);
                ItemTypeCB.Enabled = true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                ItemTypeCB.SelectedIndex = 0;
                MessageBox.Show("Unsupported Item");
            }
        }

        private void ItemModifierCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedInventory == (int)ItemEnum.bows || SelectedInventory == (int)ItemEnum.shields || SelectedInventory == (int)ItemEnum.weapons || SelectedInventory == (int)ItemEnum.armors || SelectedInventory == (int)ItemEnum.food)
            {
                try
                {

                    Debug.WriteLine(BitConverter.ToString(LoadedItems[selectedItem].Modifier));
                    EditItem.Modifier = BigInteger.Parse(ItemModifierCB.SelectedValue.ToString(), System.Globalization.NumberStyles.HexNumber).ToByteArray().Reverse().ToArray();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("IMCBEX");
                }

            }
        }
    }
}
