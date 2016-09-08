using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

using Artina.Extensions;
using Artina.Attributes;
using Artina.TypeConverters;

namespace Artina.FileFormats
{
    public enum InnocentType : byte
    {
        None = 0,
        Stat = 1,
        Ailment = 2,
        Resist = 3,
        Special = 4,
        Boss = 6
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public sealed class InnocentItemChances : ParsableData
    {
        public byte Unknown1 { get; private set; }
        public byte Fist { get; private set; }
        public byte Sword { get; private set; }
        public byte Spear { get; private set; }
        public byte Bow { get; private set; }
        public byte Gun { get; private set; }
        public byte Axe { get; private set; }
        public byte Staff { get; private set; }
        public byte Monster { get; private set; }
        public byte Unknown2 { get; private set; }
        public byte Armor { get; private set; }
        public byte Belt { get; private set; }
        public byte Shoes { get; private set; }
        public byte Orb { get; private set; }
        public byte Glasses { get; private set; }
        public byte Muscle { get; private set; }
        public byte Unknown3 { get; private set; }
        public byte Unknown4 { get; private set; }
        public byte Unknown5 { get; private set; }

        public InnocentItemChances(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Unknown1 = reader.ReadByte();
            Fist = reader.ReadByte();
            Sword = reader.ReadByte();
            Spear = reader.ReadByte();
            Bow = reader.ReadByte();
            Gun = reader.ReadByte();
            Axe = reader.ReadByte();
            Staff = reader.ReadByte();
            Monster = reader.ReadByte();
            Unknown2 = reader.ReadByte();
            Armor = reader.ReadByte();
            Belt = reader.ReadByte();
            Shoes = reader.ReadByte();
            Orb = reader.ReadByte();
            Glasses = reader.ReadByte();
            Muscle = reader.ReadByte();
            Unknown3 = reader.ReadByte();
            Unknown4 = reader.ReadByte();
            Unknown5 = reader.ReadByte();

            base.ReadFromStream(stream);
        }

        public override string ToString()
        {
            return this.ToPropertiesString();
        }
    }

    public sealed class Innocent : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public ushort Unknown0x00 { get; private set; }
        public ushort EffectiveLimit { get; private set; }
        public ushort ID { get; private set; }
        public ushort Unknown0x06 { get; private set; }
        [DisplayProperty()]
        public string Name { get; private set; }
        public string Description { get; private set; }

        public InnocentItemChances ItemChances { get; private set; }

        public InnocentType Type { get; private set; }
        public byte Unknown0xDC { get; private set; }
        public byte Unknown0xDD { get; private set; }
        public byte Unknown0xDE { get; private set; }
        public byte Unknown0xDF { get; private set; }

        public Innocent(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Unknown0x00 = reader.ReadUInt16();
            EffectiveLimit = reader.ReadUInt16();
            ID = reader.ReadUInt16();
            Unknown0x06 = reader.ReadUInt16();
            Name = sjis.GetString(reader.ReadBytes(0x40)).TrimEnd('\0');
            Description = sjis.GetString(reader.ReadBytes(0x80)).TrimEnd('\0');

            ItemChances = new InnocentItemChances(stream);

            Type = (InnocentType)reader.ReadByte();
            Unknown0xDC = reader.ReadByte();
            Unknown0xDD = reader.ReadByte();
            Unknown0xDE = reader.ReadByte();
            Unknown0xDF = reader.ReadByte();

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^HABIT\\.dat$")]
    public sealed class InnocentData : ParsableData
    {
        [DisplayName("Number of Innocents"), Description("Number of innocent definitions in the file."), Category("Main")]
        public ushort NumInnocents { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Innocents"), Description("Array with innocent definitions."), Category("Data")]
        [DataProperty()]
        public Innocent[] Innocents { get; private set; }

        public InnocentData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumInnocents = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();
            Innocents = new Innocent[NumInnocents];
            for (int i = 0; i < Innocents.Length; i++) Innocents[i] = new Innocent(stream);

            base.ReadFromStream(stream);
        }
    }
}
