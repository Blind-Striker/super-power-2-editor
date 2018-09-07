using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;
using SuperPowerEditor.Base.BizLogic.Collections;

namespace SuperPowerEditor.Base.BizLogic.StringTable
{
    public class SpStringTable
    {
        private const int SOk = 0;
        private const int SFalse = 1;
        private readonly StringCollectionDictionary _allStrings;
        private readonly List<int> _ids;
        private readonly StringCollection _languages;
        private int _nextId;
        private bool _modified;
        private string _currentLanguage;
        private IDictionaryEnumerator _currentPosition;
        private bool _currentPositionValid;
        private bool _sendEquiv;
        private string _baseDir;

        public SpStringTable()
        {
            _allStrings = new StringCollectionDictionary();
            _ids = new List<int>();
            _languages = new StringCollection();
            _nextId = 0;
            _modified = false;
            _sendEquiv = false;
            _baseDir = string.Empty;
        }

        public IList Ids => _ids;

        internal IList Languages => _languages;

        public string CurrentLanguage
        {
            get
            {
                if (_currentLanguage != null)
                {
                    return _currentLanguage;
                }

                IEnumerator enumerator = Languages.GetEnumerator();

                if (enumerator.Current != null)
                {
                    _currentLanguage = !enumerator.MoveNext() ? "English" : enumerator.Current?.ToString();
                }

                return _currentLanguage;
            }
            set => _currentLanguage = value;
        }

        public int NextId
        {
            get
            {
                checked
                {
                    ++_nextId;
                }

                return checked(_nextId - 1);
            }
        }

        public string GetString(int id, string language)
        {
            if (id == 0 || !_allStrings.Contains(language))
            {
                return string.Empty;
            }

            return _allStrings[language][id];
        }

        public void SetString(int id, string language, string value)
        {
            if (id == 0)
            {
                return;
            }

            if (!_ids.Contains(id))
            {
                _ids.Add(id);
            }

            _allStrings[language][id] = value;
            _modified = true;
        }

        internal void AddLanguage(string language)
        {
            if (_allStrings.Contains(language))
            {
                throw new ApplicationException("Language already exists");
            }

            _allStrings.Add(language);
            _languages.Add(language);
            _modified = true;
        }

        internal void RenameLanguage(string language, string newLanguage)
        {
            if (!_allStrings.Contains(language))
            {
                throw new ApplicationException("Language doesn't exists");
            }

            if (_allStrings.Contains(newLanguage))
            {
                throw new ApplicationException("Language already exists");
            }

            _allStrings.Add(newLanguage, _allStrings[language]);
            _languages.Add(newLanguage);
            RemoveLanguage(language);
            _modified = true;
        }

        internal void RemoveLanguage(string language)
        {
            _allStrings.Remove(language);
            _languages.Remove(language);
            try
            {
                if (File.Exists(_baseDir + "StringTable." + language + ".gst.deleted"))
                {
                    File.Delete(_baseDir + "StringTable." + language + ".gst.deleted");
                }

                File.Move(_baseDir + "StringTable." + language + ".gst",
                    _baseDir + "StringTable." + language + ".gst.deleted");
            }
            catch (Exception ex)
            {
                //ProjectData.SetProjectError(ex);
                //ProjectData.ClearProjectError();
            }

            if (_allStrings.Count != 0)
            {
                return;
            }

            _ids.Clear();
        }

        internal void RemoveId(int id)
        {
            foreach (object allString in _allStrings)
            {
                ((IDictionary)((DictionaryEntry)(allString ?? Activator.CreateInstance(typeof(DictionaryEntry))))
                    .Value).Remove(id);
            }

            if (_ids.Contains(id))
            {
                _ids.Remove(id);
            }

            _modified = true;
        }

        public void Save(string baseDir)
        {
            if (!_modified)
            {
                return;
            }

            foreach (object allString in _allStrings)
            {
                DictionaryEntry dictionaryEntry1 =
                    (DictionaryEntry)(allString ?? Activator.CreateInstance(typeof(DictionaryEntry)));
                string str1 = dictionaryEntry1.Key.ToString();
                IntegerKeyedStringCollection stringCollection = (IntegerKeyedStringCollection)dictionaryEntry1.Value;
                SpStringTableFile spStringTableFile = new SpStringTableFile();
                ArrayList arrayList1 = new ArrayList();
                ArrayList arrayList2 = new ArrayList();

                foreach (object obj in stringCollection)
                {
                    DictionaryEntry dictionaryEntry2 =
                        (DictionaryEntry)(obj ?? Activator.CreateInstance(typeof(DictionaryEntry)));
                    string str2 = dictionaryEntry2.Value.ToString();
                    if (str2.Length > 0)
                    {
                        arrayList2.Add(new SpStringTableFile.Index()
                        {
                            Id = Convert.ToInt32(dictionaryEntry2.Key),
                            Length = checked(str2.Length * 2)
                        });
                        arrayList1.Add(str2);
                    }
                }

                spStringTableFile.Length = arrayList2.Count;
                spStringTableFile.Indices = (SpStringTableFile.Index[])arrayList2.ToArray(typeof(SpStringTableFile.Index));
                spStringTableFile.Strings = (string[])arrayList1.ToArray(typeof(string));
                int num1 = checked(arrayList2.Count * 3 + 1 * 4);
                int num2 = 0;
                int num3 = checked(arrayList2.Count - 1);
                int index = num2;

                while (index <= num3)
                {
                    ((SpStringTableFile.Index)arrayList2[index]).Offset = num1;
                    checked
                    {
                        num1 += ((SpStringTableFile.Index)arrayList2[index]).Length;
                    }

                    checked
                    {
                        ++index;
                    }
                }

                spStringTableFile.Save(baseDir + "StringTable." + str1 + ".gst");
                _modified = false;
            }
        }

        internal void Load(string baseDir)
        {
            _allStrings.Clear();
            _ids.Clear();
            _nextId = 100000;
            _modified = false;
            _baseDir = baseDir;
            string[] files = Directory.GetFiles(baseDir, "StringTable.*.gst");
            Hashtable hashtable = new Hashtable();
            string[] strArray = files;
            int index1 = 0;

            while (index1 < strArray.Length)
            {
                string str = strArray[index1];
                SpStringTableFile spStringTableFile = new SpStringTableFile();
                spStringTableFile.Load(str);
                string language = Regex.Match(str, "StringTable\\.(.*)\\.gst$").Groups[1].Value;
                AddLanguage(language);
                IntegerKeyedStringCollection allString = _allStrings[language];
                int num1 = 0;
                int num2 = checked(spStringTableFile.Indices.Length - 1);
                int index2 = num1;

                while (index2 <= num2)
                {
                    allString[spStringTableFile.Indices[index2].Id] = spStringTableFile.Strings[index2];
                    if (spStringTableFile.Indices[index2].Id >= _nextId)
                    {
                        _nextId = checked(spStringTableFile.Indices[index2].Id + 1);
                    }

                    if (!hashtable.Contains(spStringTableFile.Indices[index2].Id))
                    {
                        hashtable.Add(spStringTableFile.Indices[index2].Id, null);
                    }

                    checked
                    {
                        ++index2;
                    }
                }

                checked
                {
                    ++index1;
                }
            }

            if (_languages.Count == 0)
            {
                AddLanguage("English");
            }

            int[] numArray1 = new int[checked(hashtable.Keys.Count - 1 + 1)];
            hashtable.Keys.CopyTo(numArray1, 0);
            Array.Sort((Array)numArray1);
            int[] numArray2 = numArray1;
            int index3 = 0;

            while (index3 < numArray2.Length)
            {
                _ids.Add(numArray2[index3]);
                checked
                {
                    ++index3;
                }
            }
        }

        public int Reset()
        {
            _currentPosition = _allStrings[CurrentLanguage].GetEnumerator();
            _currentPositionValid = _currentPosition.MoveNext();
            _sendEquiv = false;
            return 0;
        }

        public int Skip(int celt)
        {
            while (celt > 0)
            {
                if (!_currentPosition.MoveNext())
                {
                    return 1;
                }

                checked
                {
                    --celt;
                }
            }

            return 0;
        }

        public IntegerKeyedStringCollection GetStringTable(string language)
        {
            return _allStrings[language];
        }
    }
}
