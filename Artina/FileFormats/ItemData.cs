using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

using Artina.Attributes;
using Artina.TypeConverters;

namespace Artina.FileFormats
{
    // TODO: fix/verify
    public enum ItemType : ushort
    {
        None = 0,
        Fist = 1,
        Sword = 2,
        Spear = 3,
        Bow = 4,
        Gun = 5,
        Axe = 6,
        Staff = 7,
        Monster = 8,
        Armor = 9,
        Belt = 10,
        ShoesTeethPropeller = 11,
        Orb = 12,
        Glasses = 13,
        Muscle = 14,
        Weight = 15,
        SouvenirCostumeSacred = 16,
        Type17 = 17,
        Type18 = 18,
        Emblem = 19,
        Recovery = 20,
        Steal = 21,
        Escape = 22,
        ReinforcementDelivery = 23,
        Cellphone = 24,
        XDimensionTicket = 25,
        Senate = 26,
        ManaPotion = 27,
        EXPPotion = 28,
        StatRaise = 29,
        Type30 = 30,
        TreasureMapTicket = 31,
        TransmitterOtherUser = 32
    }

    public sealed class Item : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public uint BasePrice { get; private set; }
        public short BaseHPModifier { get; private set; }
        public short BaseSPModifier { get; private set; }
        public short BaseATKModifier { get; private set; }
        public short BaseDEFModifier { get; private set; }
        public short BaseINTModifier { get; private set; }
        public short BaseSPDModifier { get; private set; }
        public short BaseHITModifier { get; private set; }
        public short BaseRESModifier { get; private set; }
        public ushort ID { get; private set; }
        public ushort IconNumber { get; private set; }
        public ItemType Type { get; private set; }
        public ushort MovementRangeModifier { get; private set; }
        [TypeConverter(typeof(InnocentStringConverter))]
        public ushort Innocent { get; private set; }
        public ushort AssetID { get; private set; }
        [DisplayProperty()]
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ushort Unknown0xD0 { get; private set; }
        public ushort Unknown0xD2 { get; private set; }
        public ushort Unknown0xD4 { get; private set; }
        public ushort Unknown0xD6 { get; private set; }
        public byte Unknown0xD8 { get; private set; }
        public byte Unknown0xD9 { get; private set; }
        public byte Unknown0xDA { get; private set; }
        public byte Unknown0xDB { get; private set; }
        public ushort Rank { get; private set; }
        public byte Range { get; private set; }
        public byte JumpHeightModifier { get; private set; }
        public byte Unknown0xE0 { get; private set; }
        public sbyte CriticalHit { get; private set; }
        public byte Unknown0xE2 { get; private set; }
        public byte Unknown0xE3 { get; private set; }
        public byte Unknown0xE4 { get; private set; }
        public byte Unknown0xE5 { get; private set; }
        public byte Unknown0xE6 { get; private set; }
        public byte Unknown0xE7 { get; private set; }
        public short Unknown0xE8 { get; private set; }
        public ushort Unknown0xEA { get; private set; }

        public Item(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            BasePrice = reader.ReadUInt32();
            BaseHPModifier = reader.ReadInt16();
            BaseSPModifier = reader.ReadInt16();
            BaseATKModifier = reader.ReadInt16();
            BaseDEFModifier = reader.ReadInt16();
            BaseINTModifier = reader.ReadInt16();
            BaseSPDModifier = reader.ReadInt16();
            BaseHITModifier = reader.ReadInt16();
            BaseRESModifier = reader.ReadInt16();
            ID = reader.ReadUInt16();
            IconNumber = reader.ReadUInt16();
            Type = (ItemType)reader.ReadUInt16();
            MovementRangeModifier = reader.ReadUInt16();
            Innocent = reader.ReadUInt16();
            AssetID = reader.ReadUInt16();
            Name = sjis.GetString(reader.ReadBytes(0x30)).TrimEnd('\0');
            Description = sjis.GetString(reader.ReadBytes(0x80)).TrimEnd('\0');
            Unknown0xD0 = reader.ReadUInt16();
            Unknown0xD2 = reader.ReadUInt16();
            Unknown0xD4 = reader.ReadUInt16();
            Unknown0xD6 = reader.ReadUInt16();
            Unknown0xD8 = reader.ReadByte();
            Unknown0xD9 = reader.ReadByte();
            Unknown0xDA = reader.ReadByte();
            Unknown0xDB = reader.ReadByte();
            Rank = reader.ReadUInt16();
            Range = reader.ReadByte();
            JumpHeightModifier = reader.ReadByte();
            Unknown0xE0 = reader.ReadByte();
            CriticalHit = reader.ReadSByte();
            Unknown0xE2 = reader.ReadByte();
            Unknown0xE3 = reader.ReadByte();
            Unknown0xE4 = reader.ReadByte();
            Unknown0xE5 = reader.ReadByte();
            Unknown0xE6 = reader.ReadByte();
            Unknown0xE7 = reader.ReadByte();
            Unknown0xE8 = reader.ReadInt16();
            Unknown0xEA = reader.ReadUInt16();

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^mitem\\.dat$")]
    public sealed class ItemData : ParsableData
    {
        [DisplayName("Number of Items"), Description("Number of item definitions in the file."), Category("Main")]
        public ushort NumItems { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Items"), Description("Array with item definitions."), Category("Data")]
        [DataProperty()]
        public Item[] Items { get; private set; }

        public ItemData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumItems = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();

            Items = new Item[NumItems];
            for (int i = 0; i < Items.Length; i++) Items[i] = new Item(stream);

            base.ReadFromStream(stream);
        }
    }
}
