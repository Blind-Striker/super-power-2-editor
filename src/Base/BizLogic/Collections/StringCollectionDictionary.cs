using System.Collections;

namespace SuperPowerEditor.Base.BizLogic.Collections
{
    public class StringCollectionDictionary : DictionaryBase
    {
        public void Add(string key, IntegerKeyedStringCollection col)
        {
            Dictionary.Add(key.ToLower(), col);
        }

        public IntegerKeyedStringCollection Add(string key)
        {
            IntegerKeyedStringCollection stringCollection = new IntegerKeyedStringCollection();
            Dictionary.Add(key.ToLower(), stringCollection);
            return stringCollection;
        }

        public void Remove(string key)
        {
            Dictionary.Remove(key.ToLower());
        }

        public ICollection Keys
        {
            get { return Dictionary.Keys; }
        }

        public bool Contains(string key)
        {
            return Dictionary.Contains(key.ToLower());
        }

        public IntegerKeyedStringCollection this[string key]
        {
            get { return (IntegerKeyedStringCollection)Dictionary[key.ToLower()]; }
            set { Dictionary[key.ToLower()] = value; }
        }
    }
}