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
    public enum CharacterGender : byte
    {
        UniqueMale = 1,
        UniqueFemale = 2,
        HumanoidMale = 11,
        HumanoidFemale = 12,
        Misc = 13, // Specify?
        MonsterMale = 21,
        MonsterFemale = 22
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public sealed class CharacterBaseSkills : ParsableData
    {
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill1 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill2 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill3 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill4 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill5 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill6 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill7 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill8 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill9 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill10 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill11 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill12 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill13 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill14 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill15 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill16 { get; private set; }

        public ushort Skill1ReqLevel { get; private set; }
        public ushort Skill2ReqLevel { get; private set; }
        public ushort Skill3ReqLevel { get; private set; }
        public ushort Skill4ReqLevel { get; private set; }
        public ushort Skill5ReqLevel { get; private set; }
        public ushort Skill6ReqLevel { get; private set; }
        public ushort Skill7ReqLevel { get; private set; }
        public ushort Skill8ReqLevel { get; private set; }
        public ushort Skill9ReqLevel { get; private set; }
        public ushort Skill10ReqLevel { get; private set; }
        public ushort Skill11ReqLevel { get; private set; }
        public ushort Skill12ReqLevel { get; private set; }
        public ushort Skill13ReqLevel { get; private set; }
        public ushort Skill14ReqLevel { get; private set; }
        public ushort Skill15ReqLevel { get; private set; }
        public ushort Skill16ReqLevel { get; private set; }

        public CharacterBaseSkills(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Skill1 = reader.ReadUInt16();
            Skill2 = reader.ReadUInt16();
            Skill3 = reader.ReadUInt16();
            Skill4 = reader.ReadUInt16();
            Skill5 = reader.ReadUInt16();
            Skill6 = reader.ReadUInt16();
            Skill7 = reader.ReadUInt16();
            Skill8 = reader.ReadUInt16();
            Skill9 = reader.ReadUInt16();
            Skill10 = reader.ReadUInt16();
            Skill11 = reader.ReadUInt16();
            Skill12 = reader.ReadUInt16();
            Skill13 = reader.ReadUInt16();
            Skill14 = reader.ReadUInt16();
            Skill15 = reader.ReadUInt16();
            Skill16 = reader.ReadUInt16();

            Skill1ReqLevel = reader.ReadUInt16();
            Skill2ReqLevel = reader.ReadUInt16();
            Skill3ReqLevel = reader.ReadUInt16();
            Skill4ReqLevel = reader.ReadUInt16();
            Skill5ReqLevel = reader.ReadUInt16();
            Skill6ReqLevel = reader.ReadUInt16();
            Skill7ReqLevel = reader.ReadUInt16();
            Skill8ReqLevel = reader.ReadUInt16();
            Skill9ReqLevel = reader.ReadUInt16();
            Skill10ReqLevel = reader.ReadUInt16();
            Skill11ReqLevel = reader.ReadUInt16();
            Skill12ReqLevel = reader.ReadUInt16();
            Skill13ReqLevel = reader.ReadUInt16();
            Skill14ReqLevel = reader.ReadUInt16();
            Skill15ReqLevel = reader.ReadUInt16();
            Skill16ReqLevel = reader.ReadUInt16();

            base.ReadFromStream(stream);
        }

        public override string ToString()
        {
            return this.ToPropertiesString();
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public sealed class CharacterLearnableSkills : ParsableData
    {
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill1 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill2 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill3 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill4 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill5 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill6 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill7 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill8 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill9 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill10 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill11 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill12 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill13 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill14 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill15 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill16 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill17 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill18 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill19 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill20 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill21 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill22 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill23 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill24 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill25 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill26 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill27 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill28 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill29 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill30 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill31 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill32 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill33 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill34 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill35 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill36 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill37 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill38 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill39 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill40 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill41 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill42 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill43 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill44 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill45 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill46 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill47 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill48 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill49 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill50 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill51 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill52 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill53 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill54 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill55 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill56 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill57 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill58 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill59 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill60 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill61 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill62 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill63 { get; private set; }
        [TypeConverter(typeof(SkillStringConverter))]
        public ushort Skill64 { get; private set; }

        public ushort Skill1ReqLevel { get; private set; }
        public ushort Skill2ReqLevel { get; private set; }
        public ushort Skill3ReqLevel { get; private set; }
        public ushort Skill4ReqLevel { get; private set; }
        public ushort Skill5ReqLevel { get; private set; }
        public ushort Skill6ReqLevel { get; private set; }
        public ushort Skill7ReqLevel { get; private set; }
        public ushort Skill8ReqLevel { get; private set; }
        public ushort Skill9ReqLevel { get; private set; }
        public ushort Skill10ReqLevel { get; private set; }
        public ushort Skill11ReqLevel { get; private set; }
        public ushort Skill12ReqLevel { get; private set; }
        public ushort Skill13ReqLevel { get; private set; }
        public ushort Skill14ReqLevel { get; private set; }
        public ushort Skill15ReqLevel { get; private set; }
        public ushort Skill16ReqLevel { get; private set; }
        public ushort Skill17ReqLevel { get; private set; }
        public ushort Skill18ReqLevel { get; private set; }
        public ushort Skill19ReqLevel { get; private set; }
        public ushort Skill20ReqLevel { get; private set; }
        public ushort Skill21ReqLevel { get; private set; }
        public ushort Skill22ReqLevel { get; private set; }
        public ushort Skill23ReqLevel { get; private set; }
        public ushort Skill24ReqLevel { get; private set; }
        public ushort Skill25ReqLevel { get; private set; }
        public ushort Skill26ReqLevel { get; private set; }
        public ushort Skill27ReqLevel { get; private set; }
        public ushort Skill28ReqLevel { get; private set; }
        public ushort Skill29ReqLevel { get; private set; }
        public ushort Skill30ReqLevel { get; private set; }
        public ushort Skill31ReqLevel { get; private set; }
        public ushort Skill32ReqLevel { get; private set; }
        public ushort Skill33ReqLevel { get; private set; }
        public ushort Skill34ReqLevel { get; private set; }
        public ushort Skill35ReqLevel { get; private set; }
        public ushort Skill36ReqLevel { get; private set; }
        public ushort Skill37ReqLevel { get; private set; }
        public ushort Skill38ReqLevel { get; private set; }
        public ushort Skill39ReqLevel { get; private set; }
        public ushort Skill40ReqLevel { get; private set; }
        public ushort Skill41ReqLevel { get; private set; }
        public ushort Skill42ReqLevel { get; private set; }
        public ushort Skill43ReqLevel { get; private set; }
        public ushort Skill44ReqLevel { get; private set; }
        public ushort Skill45ReqLevel { get; private set; }
        public ushort Skill46ReqLevel { get; private set; }
        public ushort Skill47ReqLevel { get; private set; }
        public ushort Skill48ReqLevel { get; private set; }
        public ushort Skill49ReqLevel { get; private set; }
        public ushort Skill50ReqLevel { get; private set; }
        public ushort Skill51ReqLevel { get; private set; }
        public ushort Skill52ReqLevel { get; private set; }
        public ushort Skill53ReqLevel { get; private set; }
        public ushort Skill54ReqLevel { get; private set; }
        public ushort Skill55ReqLevel { get; private set; }
        public ushort Skill56ReqLevel { get; private set; }
        public ushort Skill57ReqLevel { get; private set; }
        public ushort Skill58ReqLevel { get; private set; }
        public ushort Skill59ReqLevel { get; private set; }
        public ushort Skill60ReqLevel { get; private set; }
        public ushort Skill61ReqLevel { get; private set; }
        public ushort Skill62ReqLevel { get; private set; }
        public ushort Skill63ReqLevel { get; private set; }
        public ushort Skill64ReqLevel { get; private set; }

        public CharacterLearnableSkills(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Skill1 = reader.ReadUInt16();
            Skill2 = reader.ReadUInt16();
            Skill3 = reader.ReadUInt16();
            Skill4 = reader.ReadUInt16();
            Skill5 = reader.ReadUInt16();
            Skill6 = reader.ReadUInt16();
            Skill7 = reader.ReadUInt16();
            Skill8 = reader.ReadUInt16();
            Skill9 = reader.ReadUInt16();
            Skill10 = reader.ReadUInt16();
            Skill11 = reader.ReadUInt16();
            Skill12 = reader.ReadUInt16();
            Skill13 = reader.ReadUInt16();
            Skill14 = reader.ReadUInt16();
            Skill15 = reader.ReadUInt16();
            Skill16 = reader.ReadUInt16();
            Skill17 = reader.ReadUInt16();
            Skill18 = reader.ReadUInt16();
            Skill19 = reader.ReadUInt16();
            Skill20 = reader.ReadUInt16();
            Skill21 = reader.ReadUInt16();
            Skill22 = reader.ReadUInt16();
            Skill23 = reader.ReadUInt16();
            Skill24 = reader.ReadUInt16();
            Skill25 = reader.ReadUInt16();
            Skill26 = reader.ReadUInt16();
            Skill27 = reader.ReadUInt16();
            Skill28 = reader.ReadUInt16();
            Skill29 = reader.ReadUInt16();
            Skill30 = reader.ReadUInt16();
            Skill31 = reader.ReadUInt16();
            Skill32 = reader.ReadUInt16();
            Skill33 = reader.ReadUInt16();
            Skill34 = reader.ReadUInt16();
            Skill35 = reader.ReadUInt16();
            Skill36 = reader.ReadUInt16();
            Skill37 = reader.ReadUInt16();
            Skill38 = reader.ReadUInt16();
            Skill39 = reader.ReadUInt16();
            Skill40 = reader.ReadUInt16();
            Skill41 = reader.ReadUInt16();
            Skill42 = reader.ReadUInt16();
            Skill43 = reader.ReadUInt16();
            Skill44 = reader.ReadUInt16();
            Skill45 = reader.ReadUInt16();
            Skill46 = reader.ReadUInt16();
            Skill47 = reader.ReadUInt16();
            Skill48 = reader.ReadUInt16();
            Skill49 = reader.ReadUInt16();
            Skill50 = reader.ReadUInt16();
            Skill51 = reader.ReadUInt16();
            Skill52 = reader.ReadUInt16();
            Skill53 = reader.ReadUInt16();
            Skill54 = reader.ReadUInt16();
            Skill55 = reader.ReadUInt16();
            Skill56 = reader.ReadUInt16();
            Skill57 = reader.ReadUInt16();
            Skill58 = reader.ReadUInt16();
            Skill59 = reader.ReadUInt16();
            Skill60 = reader.ReadUInt16();
            Skill61 = reader.ReadUInt16();
            Skill62 = reader.ReadUInt16();
            Skill63 = reader.ReadUInt16();
            Skill64 = reader.ReadUInt16();

            Skill1ReqLevel = reader.ReadUInt16();
            Skill2ReqLevel = reader.ReadUInt16();
            Skill3ReqLevel = reader.ReadUInt16();
            Skill4ReqLevel = reader.ReadUInt16();
            Skill5ReqLevel = reader.ReadUInt16();
            Skill6ReqLevel = reader.ReadUInt16();
            Skill7ReqLevel = reader.ReadUInt16();
            Skill8ReqLevel = reader.ReadUInt16();
            Skill9ReqLevel = reader.ReadUInt16();
            Skill10ReqLevel = reader.ReadUInt16();
            Skill11ReqLevel = reader.ReadUInt16();
            Skill12ReqLevel = reader.ReadUInt16();
            Skill13ReqLevel = reader.ReadUInt16();
            Skill14ReqLevel = reader.ReadUInt16();
            Skill15ReqLevel = reader.ReadUInt16();
            Skill16ReqLevel = reader.ReadUInt16();
            Skill17ReqLevel = reader.ReadUInt16();
            Skill18ReqLevel = reader.ReadUInt16();
            Skill19ReqLevel = reader.ReadUInt16();
            Skill20ReqLevel = reader.ReadUInt16();
            Skill21ReqLevel = reader.ReadUInt16();
            Skill22ReqLevel = reader.ReadUInt16();
            Skill23ReqLevel = reader.ReadUInt16();
            Skill24ReqLevel = reader.ReadUInt16();
            Skill25ReqLevel = reader.ReadUInt16();
            Skill26ReqLevel = reader.ReadUInt16();
            Skill27ReqLevel = reader.ReadUInt16();
            Skill28ReqLevel = reader.ReadUInt16();
            Skill29ReqLevel = reader.ReadUInt16();
            Skill30ReqLevel = reader.ReadUInt16();
            Skill31ReqLevel = reader.ReadUInt16();
            Skill32ReqLevel = reader.ReadUInt16();
            Skill33ReqLevel = reader.ReadUInt16();
            Skill34ReqLevel = reader.ReadUInt16();
            Skill35ReqLevel = reader.ReadUInt16();
            Skill36ReqLevel = reader.ReadUInt16();
            Skill37ReqLevel = reader.ReadUInt16();
            Skill38ReqLevel = reader.ReadUInt16();
            Skill39ReqLevel = reader.ReadUInt16();
            Skill40ReqLevel = reader.ReadUInt16();
            Skill41ReqLevel = reader.ReadUInt16();
            Skill42ReqLevel = reader.ReadUInt16();
            Skill43ReqLevel = reader.ReadUInt16();
            Skill44ReqLevel = reader.ReadUInt16();
            Skill45ReqLevel = reader.ReadUInt16();
            Skill46ReqLevel = reader.ReadUInt16();
            Skill47ReqLevel = reader.ReadUInt16();
            Skill48ReqLevel = reader.ReadUInt16();
            Skill49ReqLevel = reader.ReadUInt16();
            Skill50ReqLevel = reader.ReadUInt16();
            Skill51ReqLevel = reader.ReadUInt16();
            Skill52ReqLevel = reader.ReadUInt16();
            Skill53ReqLevel = reader.ReadUInt16();
            Skill54ReqLevel = reader.ReadUInt16();
            Skill55ReqLevel = reader.ReadUInt16();
            Skill56ReqLevel = reader.ReadUInt16();
            Skill57ReqLevel = reader.ReadUInt16();
            Skill58ReqLevel = reader.ReadUInt16();
            Skill59ReqLevel = reader.ReadUInt16();
            Skill60ReqLevel = reader.ReadUInt16();
            Skill61ReqLevel = reader.ReadUInt16();
            Skill62ReqLevel = reader.ReadUInt16();
            Skill63ReqLevel = reader.ReadUInt16();
            Skill64ReqLevel = reader.ReadUInt16();

            base.ReadFromStream(stream);
        }

        public override string ToString()
        {
            return this.ToPropertiesString();
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public sealed class CharacterLearnableEvilities : ParsableData
    {
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility1 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility2 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility3 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility4 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility5 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility6 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility7 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility8 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility9 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility10 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility11 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility12 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility13 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility14 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility15 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort Evility16 { get; private set; }

        public ushort Evility1ReqLevel { get; private set; }
        public ushort Evility2ReqLevel { get; private set; }
        public ushort Evility3ReqLevel { get; private set; }
        public ushort Evility4ReqLevel { get; private set; }
        public ushort Evility5ReqLevel { get; private set; }
        public ushort Evility6ReqLevel { get; private set; }
        public ushort Evility7ReqLevel { get; private set; }
        public ushort Evility8ReqLevel { get; private set; }
        public ushort Evility9ReqLevel { get; private set; }
        public ushort Evility10ReqLevel { get; private set; }
        public ushort Evility11ReqLevel { get; private set; }
        public ushort Evility12ReqLevel { get; private set; }
        public ushort Evility13ReqLevel { get; private set; }
        public ushort Evility14ReqLevel { get; private set; }
        public ushort Evility15ReqLevel { get; private set; }
        public ushort Evility16ReqLevel { get; private set; }

        public CharacterLearnableEvilities(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Evility1 = reader.ReadUInt16();
            Evility2 = reader.ReadUInt16();
            Evility3 = reader.ReadUInt16();
            Evility4 = reader.ReadUInt16();
            Evility5 = reader.ReadUInt16();
            Evility6 = reader.ReadUInt16();
            Evility7 = reader.ReadUInt16();
            Evility8 = reader.ReadUInt16();
            Evility9 = reader.ReadUInt16();
            Evility10 = reader.ReadUInt16();
            Evility11 = reader.ReadUInt16();
            Evility12 = reader.ReadUInt16();
            Evility13 = reader.ReadUInt16();
            Evility14 = reader.ReadUInt16();
            Evility15 = reader.ReadUInt16();
            Evility16 = reader.ReadUInt16();

            Evility1ReqLevel = reader.ReadUInt16();
            Evility2ReqLevel = reader.ReadUInt16();
            Evility3ReqLevel = reader.ReadUInt16();
            Evility4ReqLevel = reader.ReadUInt16();
            Evility5ReqLevel = reader.ReadUInt16();
            Evility6ReqLevel = reader.ReadUInt16();
            Evility7ReqLevel = reader.ReadUInt16();
            Evility8ReqLevel = reader.ReadUInt16();
            Evility9ReqLevel = reader.ReadUInt16();
            Evility10ReqLevel = reader.ReadUInt16();
            Evility11ReqLevel = reader.ReadUInt16();
            Evility12ReqLevel = reader.ReadUInt16();
            Evility13ReqLevel = reader.ReadUInt16();
            Evility14ReqLevel = reader.ReadUInt16();
            Evility15ReqLevel = reader.ReadUInt16();
            Evility16ReqLevel = reader.ReadUInt16();

            base.ReadFromStream(stream);
        }

        public override string ToString()
        {
            return this.ToPropertiesString();
        }
    }

    public sealed class Character : ParsableData
    {
        static Encoding sjis = Encoding.GetEncoding(932);

        public uint Unknown0x000 { get; private set; }
        public ushort BaseHP { get; private set; }
        public ushort BaseSP { get; private set; }
        public ushort BaseATK { get; private set; }
        public ushort BaseDEF { get; private set; }
        public ushort BaseINT { get; private set; }
        public ushort BaseSPD { get; private set; }
        public ushort BaseHIT { get; private set; }
        public ushort BaseRES { get; private set; }

        public CharacterBaseSkills SkillSet1 { get; private set; } // ex. Valzy = Impaler Prince, Bloody Hole, Tyrant Flughude
        public CharacterBaseSkills SkillSet2 { get; private set; }

        public CharacterLearnableSkills LearnableSkills { get; private set; } // Learnable skills? IDs aren't quite right, tho (10xxx here, xxx in skill data?)

        public ushort CharaBaseID { get; private set; }
        public ushort AssetBaseID { get; private set; } // ex. 50 = Desco & Des X, 1010 = Fighter
        public ushort Unknown0x198 { get; private set; }
        public ushort Unknown0x19A { get; private set; }
        public ushort Unknown0x19C { get; private set; }
        public ushort CharaSubID { get; private set; }
        public ushort AssetSubID { get; private set; } // ex. 54 = Des X, 1019 = Fighter (Malice)
        public ushort Unknown0x1A2 { get; private set; }
        public ushort MovementRange { get; private set; }
        public ushort Unknown0x1A6 { get; private set; }
        public ushort Unknown0x1A8 { get; private set; }
        public ushort Unknown0x1AA { get; private set; }
        public ushort Unknown0x1AC { get; private set; }
        public ushort Unknown0x1AE { get; private set; }
        public ushort ManaForIncompetentRank { get; private set; }
        public ushort Unknown0x1B2 { get; private set; }
        [TypeConverter(typeof(EvilityStringConverter))]
        public ushort BaseEvility { get; private set; }
        public ushort Unknown0x1B6 { get; private set; }
        public ushort Unknown0x1B8 { get; private set; }
        public ushort Unknown0x1BA { get; private set; }
        public ushort Unknown0x1BC { get; private set; }

        public CharacterLearnableEvilities LearnableEvilities { get; private set; }

        [DisplayProperty()]
        public string Name { get; private set; }
        public string Class { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte HPAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte SPAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte ATKAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte DEFAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte INTAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte SPDAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte HITAptitude { get; private set; }
        [TypeConverter(typeof(PercentageByteConverter))]
        public byte RESAptitude { get; private set; }
        public byte Unknown0x266 { get; private set; }
        public byte Unknown0x267 { get; private set; }
        public byte Unknown0x268 { get; private set; }
        public byte Unknown0x269 { get; private set; }
        public byte Unknown0x26A { get; private set; }
        public byte Unknown0x26B { get; private set; }
        public byte Unknown0x26C { get; private set; }
        public byte Unknown0x26D { get; private set; }
        [TypeConverter(typeof(PercentageSbyteConverter))]
        public sbyte FireResistance { get; private set; }
        [TypeConverter(typeof(PercentageSbyteConverter))]
        public sbyte WindResistance { get; private set; }
        [TypeConverter(typeof(PercentageSbyteConverter))]
        public sbyte IceResistance { get; private set; }
        public byte Unknown0x271 { get; private set; }
        public CharacterGender Gender { get; private set; }
        public byte Unknown0x273 { get; private set; }
        public byte Tier { get; private set; }
        public byte Unknown0x275 { get; private set; }
        public byte JumpHeight { get; private set; }
        public byte Unknown0x277 { get; private set; }
        public byte Unknown0x278 { get; private set; }
        public byte ThrowRange { get; private set; }
        public byte CounterAttacks { get; private set; }
        public byte AttackRange { get; private set; }
        public byte Unknown0x27C { get; private set; }
        public byte Unknown0x27D { get; private set; }
        public byte Unknown0x27E { get; private set; }
        public byte Unknown0x27F { get; private set; }
        public byte Unknown0x280 { get; private set; }
        public byte Unknown0x281 { get; private set; }
        public byte Unknown0x282 { get; private set; }
        public byte Unknown0x283 { get; private set; }
        public byte Unknown0x284 { get; private set; }
        public byte Unknown0x285 { get; private set; }
        public byte Unknown0x286 { get; private set; }
        public byte Unknown0x287 { get; private set; }
        public byte Unknown0x288 { get; private set; }
        public byte Unknown0x289 { get; private set; }
        public byte Unknown0x28A { get; private set; }
        public byte Unknown0x28B { get; private set; }

        public Character(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            Unknown0x000 = reader.ReadUInt32();
            BaseHP = reader.ReadUInt16();
            BaseSP = reader.ReadUInt16();
            BaseATK = reader.ReadUInt16();
            BaseDEF = reader.ReadUInt16();
            BaseINT = reader.ReadUInt16();
            BaseSPD = reader.ReadUInt16();
            BaseHIT = reader.ReadUInt16();
            BaseRES = reader.ReadUInt16();

            SkillSet1 = new CharacterBaseSkills(stream);
            SkillSet2 = new CharacterBaseSkills(stream);

            LearnableSkills = new CharacterLearnableSkills(stream);

            CharaBaseID = reader.ReadUInt16();
            AssetBaseID = reader.ReadUInt16();
            Unknown0x198 = reader.ReadUInt16();
            Unknown0x19A = reader.ReadUInt16();
            Unknown0x19C = reader.ReadUInt16();
            CharaSubID = reader.ReadUInt16();
            AssetSubID = reader.ReadUInt16();
            Unknown0x1A2 = reader.ReadUInt16();
            MovementRange = reader.ReadUInt16();
            Unknown0x1A6 = reader.ReadUInt16();
            Unknown0x1A8 = reader.ReadUInt16();
            Unknown0x1AA = reader.ReadUInt16();
            Unknown0x1AC = reader.ReadUInt16();
            Unknown0x1AE = reader.ReadUInt16();
            ManaForIncompetentRank = reader.ReadUInt16();
            Unknown0x1B2 = reader.ReadUInt16();
            BaseEvility = reader.ReadUInt16();
            Unknown0x1B6 = reader.ReadUInt16();
            Unknown0x1B8 = reader.ReadUInt16();
            Unknown0x1BA = reader.ReadUInt16();
            Unknown0x1BC = reader.ReadUInt16();
            LearnableEvilities = new CharacterLearnableEvilities(stream);
            Name = sjis.GetString(reader.ReadBytes(0x30)).TrimEnd('\0');
            Class = sjis.GetString(reader.ReadBytes(0x30)).TrimEnd('\0');
            HPAptitude = reader.ReadByte();
            SPAptitude = reader.ReadByte();
            ATKAptitude = reader.ReadByte();
            DEFAptitude = reader.ReadByte();
            INTAptitude = reader.ReadByte();
            SPDAptitude = reader.ReadByte();
            HITAptitude = reader.ReadByte();
            RESAptitude = reader.ReadByte();
            Unknown0x266 = reader.ReadByte();
            Unknown0x267 = reader.ReadByte();
            Unknown0x268 = reader.ReadByte();
            Unknown0x269 = reader.ReadByte();
            Unknown0x26A = reader.ReadByte();
            Unknown0x26B = reader.ReadByte();
            Unknown0x26C = reader.ReadByte();
            Unknown0x26D = reader.ReadByte();
            FireResistance = reader.ReadSByte();
            WindResistance = reader.ReadSByte();
            IceResistance = reader.ReadSByte();
            Unknown0x271 = reader.ReadByte();
            Gender = (CharacterGender)reader.ReadByte();
            Unknown0x273 = reader.ReadByte();
            Tier = reader.ReadByte();
            Unknown0x275 = reader.ReadByte();
            JumpHeight = reader.ReadByte();
            Unknown0x277 = reader.ReadByte();
            Unknown0x278 = reader.ReadByte();
            ThrowRange = reader.ReadByte();
            CounterAttacks = reader.ReadByte();
            AttackRange = reader.ReadByte();
            Unknown0x27C = reader.ReadByte();
            Unknown0x27D = reader.ReadByte();
            Unknown0x27E = reader.ReadByte();
            Unknown0x27F = reader.ReadByte();
            Unknown0x280 = reader.ReadByte();
            Unknown0x281 = reader.ReadByte();
            Unknown0x282 = reader.ReadByte();
            Unknown0x283 = reader.ReadByte();
            Unknown0x284 = reader.ReadByte();
            Unknown0x285 = reader.ReadByte();
            Unknown0x286 = reader.ReadByte();
            Unknown0x287 = reader.ReadByte();
            Unknown0x288 = reader.ReadByte();
            Unknown0x289 = reader.ReadByte();
            Unknown0x28A = reader.ReadByte();
            Unknown0x28B = reader.ReadByte();

            base.ReadFromStream(stream);
        }
    }

    [FileNamePattern("^char\\.dat$")]
    public sealed class CharacterData : ParsableData
    {
        [DisplayName("Number of Characters"), Description("Number of characters defined."), Category("Main")]
        public ushort NumCharacters { get; private set; }
        [DisplayName("Unknown 0x02"), Description("Unknown unsigned short."), Category("Main")]
        public ushort Unknown0x02 { get; private set; }

        [DisplayName("Characters"), Description("Array with character data."), Category("Data")]
        [DataProperty()]
        public Character[] Characters { get; private set; }

        public CharacterData(Stream stream) : base(stream) { }

        public override void ReadFromStream(Stream stream)
        {
            EndianBinaryReader reader = new EndianBinaryReader(stream, Endian.BigEndian);

            NumCharacters = reader.ReadUInt16();
            Unknown0x02 = reader.ReadUInt16();
            Characters = new Character[NumCharacters];
            for (int i = 0; i < Characters.Length; i++) Characters[i] = new Character(stream);

            base.ReadFromStream(stream);
        }
    }
}
