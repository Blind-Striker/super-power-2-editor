using System;
using System.Collections;
using System.IO;
using System.Text;

namespace SuperPowerEditor.Base.BizLogic.StringTable
{
    public class SpStringTableFile
    {
        public int Length;
        public Index[] Indices;
        public string[] Strings;

        public void Save(string filename)
        {
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(filename, FileMode.Create, FileAccess.Write), Encoding.Unicode);
            binaryWriter.Write(Length);
            Index[] indices = Indices;
            int index1 = 0;

            while (index1 < indices.Length)
            {
                Index index2 = indices[index1];
                binaryWriter.Write(index2.Id);
                binaryWriter.Write(index2.Offset);
                binaryWriter.Write(index2.Length);
                checked { ++index1; }
            }

            string[] strings = Strings;
            int index3 = 0;
            while (index3 < strings.Length)
            {
                string str = strings[index3];
                binaryWriter.Write(str.ToCharArray());
                checked { ++index3; }
            }
            binaryWriter.Close();
        }

        public void Load(string filename)
        {
            BinaryReader binaryReader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read), Encoding.Unicode);
            Length = binaryReader.ReadInt32();
            Index[] indexArray = new Index[checked(Length - 1 + 1)];
            string[] strArray = new string[checked(Length - 1 + 1)];
            Indices = indexArray;
            Strings = strArray;
            int num1 = 0;
            int num2 = checked(Length - 1);
            int index1 = num1;

            while (index1 <= num2)
            {
                Indices[index1] = new Index();
                Indices[index1].Id = binaryReader.ReadInt32();
                Indices[index1].Offset = binaryReader.ReadInt32();
                Indices[index1].Length = binaryReader.ReadInt32();
                checked { ++index1; }
            }

            Array.Sort(Indices, new OffsetSorter());
            int num3 = 0;
            int num4 = checked(Length - 1);
            int index2 = num3;

            while (index2 <= num4)
            {
                binaryReader.BaseStream.Seek(Indices[index2].Offset, SeekOrigin.Begin);
                Strings[index2] = new string(binaryReader.ReadChars(Indices[index2].Length / 2));

                int i = checked(Indices[index2].Length / 2 - 1);

                if (i >=0 && Strings[index2][i] == char.MinValue)
                {
                    Strings[index2] = Strings[index2].Substring(0, checked(Indices[index2].Length / 2 - 1));
                }
                checked { ++index2; }
            }

            binaryReader.Close();
        }

        private class OffsetSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((Index)x).Offset.CompareTo((object)((Index)y).Offset);
            }
        }

        public class Index
        {
            public int Id;
            public int Offset;
            public int Length;
        }
    }
}