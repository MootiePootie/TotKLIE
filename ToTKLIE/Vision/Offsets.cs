
namespace ToTKLIE.Vision
{
    public class Offsets
    {
        //Item Pointers
        public static IReadOnlyList<long> ArmorPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x260, 0x2C4, 0x4C, 0x0C };
        public static IReadOnlyList<long> BowPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x260, 0x2C4, 0x1FC, 0x0C };
        public static IReadOnlyList<long> ShieldPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x354, 0x354,0xDC,0xC };
        public static IReadOnlyList<long> WeaponPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x354, 0x354, 0x31C, 0xC };
        public static IReadOnlyList<long> MaterialsPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x2C4, 0x354, 0x4C, 0xC };
        public static IReadOnlyList<long> FoodPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x354, 0x1A4, 0x4C, 0xC };
        public static IReadOnlyList<long> ZonaiPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x354, 0x354, 0x16C, 0xC };

        //Quantity Pointers
        public static IReadOnlyList<long> MaterialCountPointer { get; } = new long[] { 0x471E6B8, 0xCF0, 0x138, 0xEE8,0xFF0};
        public static IReadOnlyList<long> FoodCountPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x58, 0x188, 0xDB8, 0x960 };
        public static IReadOnlyList<long> ArrowCountPointer { get; } = new long[] { 0x471ECF8, 0x10, 0x80, 0xB8, 0x188, 0xB68, 0x20 };

        public static IReadOnlyList<long> ZonaiCountPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x58, 0x188, 0x1168, 0x10 };

        //Modifier Pointers
        public static IReadOnlyList<long> BowModifierPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x60, 0x08, 0x308, 0x5D8, 0x4F0 };
        public static IReadOnlyList<long> ShieldModifierPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x18, 0x10, 0x2D8, 0x638, 0x510 };
        public static IReadOnlyList<long> WeaponModifierPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x60, 0x310, 0x17B8, 0xD0 };
        public static IReadOnlyList<long> ArmorModifierPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x78, 0x298, 0x4108, 0x30 };
        public static IReadOnlyList<long> FoodModifierPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x78, 0x2A8, 0x3188, 0x110 };

        //Modifier Values
        public static IReadOnlyList<long> ShieldModifierValuePointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x58, 0x188, 0xFE8, 0x280 };
        public static IReadOnlyList<long> BowModifierValuePointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x78, 0x158, 0xBE8, 0x20 };
        public static IReadOnlyList<long> WeaponModifierValuePointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x58, 0x190, 0x37B8, 0xA0};
        public static IReadOnlyList<long> FoodModifierValuePointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x88, 0x178, 0x31A8,0x20 };

        //Durability Pointers
        public static IReadOnlyList<long> ShieldDurabilityPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x60, 0x188, 0x10B8, 0xA0 };
        public static IReadOnlyList<long> BowDurabilityPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x60, 0x190, 0x3128, 0xE0};
        public static IReadOnlyList<long> WeaponDurabilityPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x60, 0x188, 0x1378, 0xA0 };

        //Misc Pointers
        public static IReadOnlyList<long> FoodHealthPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x88, 0x178, 0x3238, 0x5A0 };
        public static IReadOnlyList<long> FoodDurationPointer { get; } = new long[] { 0x471ECF8, 0x08, 0x60, 0x88, 0x178, 0x31F8, 0x3C8 };

        //Fusions
        public static IReadOnlyList<long> ShieldFusionPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x354, 0x354, 0x4C, 0xC };
        public static IReadOnlyList<long> WeaponFusionPointer { get; } = new long[] { 0x471E6B8, 0x678, 0x2F0, 0x354, 0x354, 0x28C, 0xC };

    }

    public class Sizes 
    {
        //3rd item is arrow count, unsure how those work rn
        public static IReadOnlyList<int> ChunkSize { get; } = new int[] { 0x50, 0x50, 0x0, 0x50, 0x50, 0x50, 0x50, 0x50 };
        public static IReadOnlyList<int> DataSize { get; } = new int[] { 0x10, 0xE,0x0, 0x11,0x11,0x30, 0x11, 0x30 };
        public static IReadOnlyList<int> SavePersistDistance { get; } = new int[] { 0x5DC0, 0x8C0,0x0, 0xC80, 0xC80, 0x9F60 , 0x2580, 0x12C0};



        public static IReadOnlyList<int> QuantitySavePersistDistance { get; } = new int[] { 0x0,0x0,0x8,0x0,0x0,0x7F8,0x1E0,0xF0 };
        public static IReadOnlyList<int> ModifierSavePersistDistance { get; } = new int[] { 0x4B0, 0x70, 0x0, 0xA0, 0xA0, 0x0,0x1E0 };
        public static IReadOnlyList<int> ModifierValueSavePersistDistance { get; } = new int[] { 0x0, 0x70, 0x0, 0xA0, 0xA0, 0x0,0x1E0 };
        public static IReadOnlyList<int> HealthSavePersistDistance { get; } = new int[] { 0x0, 0x00, 0x0, 0x00, 0x0, 0x1E0 };



        public static IReadOnlyList<int> FusionChunkSize { get; } = new int[] { 0x0,0x0,0x0,0x50,0x50};
        public static IReadOnlyList<int> FusionDataSize { get; } = new int[] { 0x0, 0x0, 0x0, 0x44, 0x44};
        public static IReadOnlyList<int> FusionSavePersistDistance { get; } = new int[] { 0x0,0x0,0x0,0xC80,0xC80 };

    }

}
