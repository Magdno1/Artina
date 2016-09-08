using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

using Artina.Attributes;
using Artina.FileFormats;

namespace Artina
{
    class IdentificationMatch
    {
        public Type Type { get; private set; }
        public string FileNamePattern { get; private set; }
        public int Weight { get; private set; }

        public IdentificationMatch(Type type, string pattern, int weight)
        {
            Type = type;
            FileNamePattern = pattern;
            Weight = weight;
        }
    }

    public static class DataManager
    {
        static Dictionary<string, ParsableData> datasets = new Dictionary<string, ParsableData>();

        public static Dictionary<ushort, string> EvilityNames = null;
        public static Dictionary<ushort, string> SkillNames = null;
        public static Dictionary<ushort, string> InnocentNames = null;

        public static void LoadDatasets(IEnumerable<FileInfo> files)
        {
            foreach (FileInfo file in files)
            {
                using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    Type fileType = IdentifyFile(stream, file.FullName);
                    if (fileType != null)
                    {
                        DataManager.datasets.Add(file.Name, (ParsableData)Activator.CreateInstance(fileType, new object[] { stream }));
                    }
                }
            }

            if (EvilityNames == null)
            {
                var evilityData = GetDataset<EvilityData>();
                if (evilityData != null)
                {
                    EvilityNames = evilityData.Evilities.ToDictionary(x => x.ID, x => x.Name);
                    if (EvilityNames.ContainsKey((ushort)0)) EvilityNames[(ushort)0] = "(None)";
                }
            }

            if (SkillNames == null)
            {
                var skillData = GetDataset<SkillData>();
                if (skillData != null)
                {
                    SkillNames = skillData.Skills.ToDictionary(x => x.ID, x => x.Name);
                    if (SkillNames.ContainsKey((ushort)0)) SkillNames[(ushort)0] = "(None)";
                }
            }

            if (InnocentNames == null)
            {
                var innocentData = GetDataset<InnocentData>();
                if (innocentData != null)
                    InnocentNames = innocentData.Innocents.ToDictionary(x => x.ID, x => x.Name);
            }
        }

        public static Dictionary<string, T> GetDatasets<T>() where T : ParsableData
        {
            return DataManager.datasets.Where(x => x.Value is T).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value as T);
        }

        public static T GetDataset<T>() where T : ParsableData
        {
            return GetDatasets<T>().FirstOrDefault().Value;
        }

        private static Type IdentifyFile(Stream input, string filename = "")
        {
            EndianBinaryReader reader = new EndianBinaryReader(input, Endian.BigEndian);

            long position = reader.BaseStream.Position;
            List<IdentificationMatch> matchedTypes = new List<IdentificationMatch>();

            Type baseType = typeof(ParsableData);
            foreach (Type t in baseType.Assembly.GetTypes().Where(x => x.IsSubclassOf(baseType)))
            {
                if (filename != string.Empty)
                {
                    FileNamePatternAttribute attrib = (t.GetCustomAttributes(typeof(FileNamePatternAttribute), false).FirstOrDefault() as FileNamePatternAttribute);
                    if (attrib != null)
                    {
                        Regex reg = new Regex(attrib.Pattern, RegexOptions.IgnoreCase);
                        if (reg.IsMatch(Path.GetFileName(filename)))
                            matchedTypes.Add(new IdentificationMatch(t, attrib.Pattern, attrib.Pattern.Length));
                    }
                }
            }
            reader.BaseStream.Seek(position, SeekOrigin.Begin);

            IdentificationMatch bestMatch = matchedTypes.OrderByDescending(x => x.Weight).FirstOrDefault();
            return (bestMatch == null ? null : bestMatch.Type);
        }
    }
}
