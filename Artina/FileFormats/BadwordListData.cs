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
    public class Badword : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public ushort ID { get; private set; }
        [DisplayProperty()]
        public string Word { get; private set; }

        public Badword(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            ID = reader.ReadUInt16();
            Word = sjis.GetString(reader.ReadBytes(0x16)).TrimEnd('\0');

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^BadwordList\\.dat$")]
    public class BadwordListData : ParsableData
    {
        [DisplayName("Number of Bad Words"), Description("Number of bad words in the file."), Category("Main")]
        public ushort NumBadwords { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Bad Words"), Description("Array with bad words."), Category("Data")]
        [DataProperty()]
        public Badword[] Badwords { get; private set; }

        public BadwordListData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumBadwords = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();

            Badwords = new Badword[NumBadwords];
            for (int i = 0; i < Badwords.Length; i++) Badwords[i] = new Badword(stream);

            base.ReadFromStream(stream);
        }
    }
}
