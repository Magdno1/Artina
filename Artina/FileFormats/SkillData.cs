using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

using Artina.Attributes;

namespace Artina.FileFormats
{
    public enum SkillEffect : byte
    {
        Unknown0 = 0,
        Unknown1 = 1,
        Unknown2 = 2,

        AtkModifier = 11,
        DefModifier = 12,
        ResModifier = 13,
        IntModifier = 14,
        SpdModifier = 15,
        HitModifier = 16,

        Poison = 21,
        Sleep = 22,
        Paralyze = 23,
        Amnesia = 24,
        Deprave = 25,

        FireModifier = 31,
        WindModifier = 32,
        IceModifier = 33,

        ExpManaModifier = 51,

        MovementModifier = 61,
        JumpModifier = 62,
        CounterModifier = 63,
        ThrowRangeModifier = 64,
        MagicRangeModifier = 65,
        CriticalModifier = 66,

        CureAilments = 101,
        HPDrain = 102,//?
        Suicide = 104,//?
    }

    public enum SkillElement : byte
    {
        None = 0,
        Fire = 1,
        Wind = 2,
        Ice = 3,
        Star = 4
    }

    public enum SkillType : byte
    {
        Melee = 2,
        Magic = 3,
        Heal = 4,
        Buff = 5,
        Debuff = 6
    }

    public enum SkillWeaponType : byte
    {
        None = 0,
        Fist = 1,
        Sword = 2,
        Spear = 3,
        Bow = 4,
        Gun = 5,
        Axe = 6
    }

    public sealed class Skill : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public uint ManaCostBase { get; private set; }

        public uint ManaCostBoostPlus1 { get; private set; }//40/80/160/320/640/1280/...
        public uint ManaCostBoostPlus2 { get; private set; }//...
        public uint ManaCostBoostPlus3 { get; private set; }//...
        public uint ManaCostBoostPlus4 { get; private set; }//...
        public uint ManaCostBoostPlus5 { get; private set; }//...
        public uint ManaCostBoostPlus6 { get; private set; }//...
        public uint ManaCostBoostPlus7 { get; private set; }//...
        public uint ManaCostBoostPlus8 { get; private set; }//...
        public uint ManaCostBoostPlus9 { get; private set; }//...

        public ushort ID { get; private set; }

        public ushort Unknown0x26 { get; private set; }//...
        public ushort Unknown0x28 { get; private set; }//...
        public ushort Unknown0x2A { get; private set; }//...
        public ushort Unknown0x2C { get; private set; }//...
        public ushort Unknown0x2E { get; private set; }//...
        public ushort Unknown0x30 { get; private set; }//...
        public ushort Unknown0x32 { get; private set; }//...

        public string Description { get; private set; }
        [DisplayProperty()]
        public string Name { get; private set; }
        public string NameDuplicate { get; private set; }

        public SkillEffect Effect { get; private set; }
        public byte Unknown0x12F { get; private set; }
        public byte Unknown0x130 { get; private set; }
        public byte Unknown0x131 { get; private set; }
        public byte Unknown0x132 { get; private set; }

        public sbyte Parameter1 { get; private set; }
        public sbyte Parameter2 { get; private set; }
        public sbyte Parameter3 { get; private set; }
        public sbyte Parameter4 { get; private set; }
        public sbyte Parameter5 { get; private set; }

        public byte Unknown0x138 { get; private set; }
        public byte Unknown0x139 { get; private set; }
        public byte Unknown0x13A { get; private set; }
        public byte Unknown0x13B { get; private set; }

        public SkillElement Element { get; private set; }
        public SkillType Type { get; private set; }
        public SkillWeaponType WeaponType { get; private set; }
        public byte Unknown0x13F { get; private set; }
        public byte Unknown0x140 { get; private set; }
        public byte Unknown0x141 { get; private set; }
        public byte Unknown0x142 { get; private set; }
        public byte Unknown0x143 { get; private set; }
        public byte Unknown0x144 { get; private set; }
        public byte Unknown0x145 { get; private set; }

        public ushort Unknown0x146 { get; private set; }
        public ushort Unknown0x148 { get; private set; }

        public byte HeightUp { get; private set; }
        public byte HeightDown { get; private set; }
        public byte Unknown0x14C { get; private set; }
        public byte Unknown0x14D { get; private set; }
        public byte Unknown0x14E { get; private set; }
        public byte Unknown0x14F { get; private set; }
        public byte Unknown0x150 { get; private set; }
        public byte Unknown0x151 { get; private set; }
        public byte Unknown0x152 { get; private set; }
        public byte Unknown0x153 { get; private set; }
        public byte Unknown0x154 { get; private set; }
        public byte Unknown0x155 { get; private set; }
        public byte Unknown0x156 { get; private set; }
        public byte Unknown0x157 { get; private set; }

        public short Unknown0x158 { get; private set; }
        public short Unknown0x15A { get; private set; }

        public Skill(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            ManaCostBase = reader.ReadUInt32();
            ManaCostBoostPlus1 = reader.ReadUInt32();
            ManaCostBoostPlus2 = reader.ReadUInt32();
            ManaCostBoostPlus3 = reader.ReadUInt32();
            ManaCostBoostPlus4 = reader.ReadUInt32();
            ManaCostBoostPlus5 = reader.ReadUInt32();
            ManaCostBoostPlus6 = reader.ReadUInt32();
            ManaCostBoostPlus7 = reader.ReadUInt32();
            ManaCostBoostPlus8 = reader.ReadUInt32();
            ManaCostBoostPlus9 = reader.ReadUInt32();

            ID = reader.ReadUInt16();

            Unknown0x26 = reader.ReadUInt16();
            Unknown0x28 = reader.ReadUInt16();
            Unknown0x2A = reader.ReadUInt16();
            Unknown0x2C = reader.ReadUInt16();
            Unknown0x2E = reader.ReadUInt16();
            Unknown0x30 = reader.ReadUInt16();
            Unknown0x32 = reader.ReadUInt16();

            Description = sjis.GetString(reader.ReadBytes(0x96)).TrimEnd('\0');
            Name = sjis.GetString(reader.ReadBytes(0x30)).TrimEnd('\0');
            NameDuplicate = sjis.GetString(reader.ReadBytes(0x30)).TrimEnd('\0');

            Effect = (SkillEffect)reader.ReadByte();
            Unknown0x12F = reader.ReadByte();
            Unknown0x130 = reader.ReadByte();
            Unknown0x131 = reader.ReadByte();
            Unknown0x132 = reader.ReadByte();

            Parameter1 = reader.ReadSByte();
            Parameter2 = reader.ReadSByte();
            Parameter3 = reader.ReadSByte();
            Parameter4 = reader.ReadSByte();
            Parameter5 = reader.ReadSByte();

            Unknown0x138 = reader.ReadByte();
            Unknown0x139 = reader.ReadByte();
            Unknown0x13A = reader.ReadByte();
            Unknown0x13B = reader.ReadByte();

            Element = (SkillElement)reader.ReadByte();
            Type = (SkillType)reader.ReadByte();
            WeaponType = (SkillWeaponType)reader.ReadByte();
            Unknown0x13F = reader.ReadByte();
            Unknown0x140 = reader.ReadByte();
            Unknown0x141 = reader.ReadByte();
            Unknown0x142 = reader.ReadByte();
            Unknown0x143 = reader.ReadByte();
            Unknown0x144 = reader.ReadByte();
            Unknown0x145 = reader.ReadByte();

            Unknown0x146 = reader.ReadUInt16();
            Unknown0x148 = reader.ReadUInt16();

            HeightUp = reader.ReadByte();
            HeightDown = reader.ReadByte();
            Unknown0x14C = reader.ReadByte();
            Unknown0x14D = reader.ReadByte();
            Unknown0x14E = reader.ReadByte();
            Unknown0x14F = reader.ReadByte();
            Unknown0x150 = reader.ReadByte();
            Unknown0x151 = reader.ReadByte();
            Unknown0x152 = reader.ReadByte();
            Unknown0x153 = reader.ReadByte();
            Unknown0x154 = reader.ReadByte();
            Unknown0x155 = reader.ReadByte();
            Unknown0x156 = reader.ReadByte();
            Unknown0x157 = reader.ReadByte();

            Unknown0x158 = reader.ReadInt16();
            Unknown0x15A = reader.ReadInt16();

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^magic\\.dat$")]
    public sealed class SkillData : ParsableData
    {
        [DisplayName("Number of Skills"), Description("Number of skills defined."), Category("Main")]
        public ushort NumSkills { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Skills"), Description("Array with skill data."), Category("Data")]
        [DataProperty()]
        public Skill[] Skills { get; private set; }

        public SkillData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumSkills = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();
            Skills = new Skill[NumSkills];
            for (int i = 0; i < Skills.Length; i++) Skills[i] = new Skill(stream);

            base.ReadFromStream(stream);
        }
    }
}
