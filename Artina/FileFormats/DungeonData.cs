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
    public class Map : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public uint Unknown0x00 { get; private set; }
        public uint Unknown0x04 { get; private set; }
        public uint Unknown0x08 { get; private set; }
        public uint Unknown0x0C { get; private set; }
        public ushort ID { get; private set; }
        public short Unknown0x12 { get; private set; }
        public ushort Unknown0x14 { get; private set; }
        public ushort BonusRank { get; private set; }
        public sbyte Unknown0x18 { get; private set; }
        public sbyte Unknown0x19 { get; private set; }
        public sbyte Unknown0x1A { get; private set; }
        public sbyte Unknown0x1B { get; private set; }
        public sbyte Unknown0x1C { get; private set; }
        public sbyte Unknown0x1D { get; private set; }
        public sbyte Unknown0x1E { get; private set; }
        public sbyte Unknown0x1F { get; private set; }
        public sbyte Unknown0x20 { get; private set; }
        public sbyte Unknown0x21 { get; private set; }
        public sbyte Unknown0x22 { get; private set; }
        public sbyte Unknown0x23 { get; private set; }
        public sbyte Unknown0x24 { get; private set; }
        public sbyte Unknown0x25 { get; private set; }
        public sbyte Unknown0x26 { get; private set; }
        public sbyte Unknown0x27 { get; private set; }
        public sbyte Unknown0x28 { get; private set; }
        public sbyte Unknown0x29 { get; private set; }
        public sbyte Unknown0x2A { get; private set; }
        public sbyte Unknown0x2B { get; private set; }
        public int Unknown0x2C { get; private set; }
        public uint Unknown0x30 { get; private set; }
        public uint Unknown0x34 { get; private set; }
        public uint Unknown0x38 { get; private set; }
        public uint Unknown0x3C { get; private set; }
        public sbyte Unknown0x40 { get; private set; }
        public sbyte Unknown0x41 { get; private set; }
        public sbyte Unknown0x42 { get; private set; }
        public sbyte Unknown0x43 { get; private set; }
        public sbyte Unknown0x44 { get; private set; }
        public sbyte Unknown0x45 { get; private set; }
        public sbyte Unknown0x46 { get; private set; }
        public sbyte Unknown0x47 { get; private set; }
        public sbyte Unknown0x48 { get; private set; }
        public sbyte Unknown0x49 { get; private set; }
        public sbyte Unknown0x4A { get; private set; }
        public sbyte Unknown0x4B { get; private set; }
        public sbyte Unknown0x4C { get; private set; }
        public sbyte Unknown0x4D { get; private set; }
        public sbyte Unknown0x4E { get; private set; }
        [DisplayProperty()]
        public string Name { get; private set; }
        public sbyte Unknown0x7F { get; private set; }
        public sbyte Unknown0x80 { get; private set; }
        public sbyte Unknown0x81 { get; private set; }
        public sbyte Unknown0x82 { get; private set; }
        public sbyte Unknown0x83 { get; private set; }
        public sbyte Unknown0x84 { get; private set; }
        public sbyte Unknown0x85 { get; private set; }
        public sbyte Unknown0x86 { get; private set; }
        public sbyte Unknown0x87 { get; private set; }
        public sbyte Unknown0x88 { get; private set; }
        public sbyte Unknown0x89 { get; private set; }
        public sbyte Unknown0x8A { get; private set; }
        public sbyte Unknown0x8B { get; private set; }

        public Map(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Unknown0x00 = reader.ReadUInt32();
            Unknown0x04 = reader.ReadUInt32();
            Unknown0x08 = reader.ReadUInt32();
            Unknown0x0C = reader.ReadUInt32();
            ID = reader.ReadUInt16();
            Unknown0x12 = reader.ReadInt16();
            Unknown0x14 = reader.ReadUInt16();
            BonusRank = reader.ReadUInt16();
            Unknown0x18 = reader.ReadSByte();
            Unknown0x19 = reader.ReadSByte();
            Unknown0x1A = reader.ReadSByte();
            Unknown0x1B = reader.ReadSByte();
            Unknown0x1C = reader.ReadSByte();
            Unknown0x1D = reader.ReadSByte();
            Unknown0x1E = reader.ReadSByte();
            Unknown0x1F = reader.ReadSByte();
            Unknown0x20 = reader.ReadSByte();
            Unknown0x21 = reader.ReadSByte();
            Unknown0x22 = reader.ReadSByte();
            Unknown0x23 = reader.ReadSByte();
            Unknown0x24 = reader.ReadSByte();
            Unknown0x25 = reader.ReadSByte();
            Unknown0x26 = reader.ReadSByte();
            Unknown0x27 = reader.ReadSByte();
            Unknown0x28 = reader.ReadSByte();
            Unknown0x29 = reader.ReadSByte();
            Unknown0x2A = reader.ReadSByte();
            Unknown0x2B = reader.ReadSByte();
            Unknown0x2C = reader.ReadInt32();
            Unknown0x30 = reader.ReadUInt32();
            Unknown0x34 = reader.ReadUInt32();
            Unknown0x38 = reader.ReadUInt32();
            Unknown0x3C = reader.ReadUInt32();
            Unknown0x40 = reader.ReadSByte();
            Unknown0x41 = reader.ReadSByte();
            Unknown0x42 = reader.ReadSByte();
            Unknown0x43 = reader.ReadSByte();
            Unknown0x44 = reader.ReadSByte();
            Unknown0x45 = reader.ReadSByte();
            Unknown0x46 = reader.ReadSByte();
            Unknown0x47 = reader.ReadSByte();
            Unknown0x48 = reader.ReadSByte();
            Unknown0x49 = reader.ReadSByte();
            Unknown0x4A = reader.ReadSByte();
            Unknown0x4B = reader.ReadSByte();
            Unknown0x4C = reader.ReadSByte();
            Unknown0x4D = reader.ReadSByte();
            Unknown0x4E = reader.ReadSByte();
            Name = sjis.GetString(reader.ReadBytes(0x30)).TrimEnd('\0');
            Unknown0x7F = reader.ReadSByte();
            Unknown0x80 = reader.ReadSByte();
            Unknown0x81 = reader.ReadSByte();
            Unknown0x82 = reader.ReadSByte();
            Unknown0x83 = reader.ReadSByte();
            Unknown0x84 = reader.ReadSByte();
            Unknown0x85 = reader.ReadSByte();
            Unknown0x86 = reader.ReadSByte();
            Unknown0x87 = reader.ReadSByte();
            Unknown0x88 = reader.ReadSByte();
            Unknown0x89 = reader.ReadSByte();
            Unknown0x8A = reader.ReadSByte();
            Unknown0x8B = reader.ReadSByte();

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^dungeon\\.dat$")]
    public class DungeonData : ParsableData
    {
        [DisplayName("Number of Dungeons"), Description("Number of dungeon definitions in the file."), Category("Main")]
        public ushort NumDungeons { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Dungeons"), Description("Array with dungeon definitions."), Category("Data")]
        [DataProperty()]
        public Map[] Dungeons { get; private set; }

        public DungeonData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumDungeons = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();

            Dungeons = new Map[NumDungeons];
            for (int i = 0; i < Dungeons.Length; i++) Dungeons[i] = new Map(stream);

            base.ReadFromStream(stream);
        }
    }
}
