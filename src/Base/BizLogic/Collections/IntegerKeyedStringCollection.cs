using System.Collections;

namespace SuperPowerEditor.Base.BizLogic.Collections
{
    public class IntegerKeyedStringCollection : DictionaryBase
    {
        public void Add(int key, string value)
        {
            Dictionary.Add(key, value);
        }

        public void Remove(int key)
        {
            Dictionary.Remove(key);
        }

        public bool Contains(int key)
        {
            return Dictionary.Contains(key);
        }

        public ICollection Keys
        {
            get { return Dictionary.Keys; }
        }

        public string this[int key]
        {
            get { return Dictionary[key].ToString(); }
            set { Dictionary[key] = value; }
        }

        public ICollection Values
        {
            get { return Dictionary.Values; }
        }
    }
}