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
    public sealed class Evility : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public int ManaCost { get; private set; }
        public ushort Unknown0x04 { get; private set; }
        public ushort Unknown0x06 { get; private set; }
        public ushort ID { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Prerequisite { get; private set; }
        public byte Parameter1 { get; private set; }
        public byte Parameter2 { get; private set; }
        public byte Parameter3 { get; private set; }
        [DisplayProperty()]
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte Unknown0xDF { get; private set; }
        public uint Unknown0xE0 { get; private set; }
        public byte Icon { get; private set; }
        public byte Unknown0xE5 { get; private set; }
        public byte Unknown0xE6 { get; private set; }
        public byte Unknown0xE7 { get; private set; }

        public Evility(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            ManaCost = reader.ReadInt32();
            Unknown0x04 = reader.ReadUInt16();
            Unknown0x06 = reader.ReadUInt16();
            ID = reader.ReadUInt16();
            Prerequisite = reader.ReadUInt16();
            Parameter1 = reader.ReadByte();
            Parameter2 = reader.ReadByte();
            Parameter3 = reader.ReadByte();
            Name = sjis.GetString(reader.ReadBytes(0x50));
            Description = sjis.GetString(reader.ReadBytes(0x80));
            Unknown0xDF = reader.ReadByte();
            Unknown0xE0 = reader.ReadUInt32();
            Icon = reader.ReadByte();
            Unknown0xE5 = reader.ReadByte();
            Unknown0xE6 = reader.ReadByte();
            Unknown0xE7 = reader.ReadByte();

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^mskill\\.dat$")]
    public sealed class EvilityData : ParsableData
    {
        [DisplayName("Number of Evilities"), Description("Number of evilities defined."), Category("Main")]
        public ushort NumEvilities { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Evilities"), Description("Array with evility data."), Category("Data")]
        [DataProperty()]
        public Evility[] Evilities { get; private set; }

        public EvilityData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumEvilities = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();
            Evilities = new Evility[NumEvilities];
            for (int i = 0; i < Evilities.Length; i++) Evilities[i] = new Evility(stream);

            base.ReadFromStream(stream);
        }
    }
}
