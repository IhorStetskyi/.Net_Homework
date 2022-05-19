using System.Collections;


namespace FoldersHW
{
    /// <summary>
    /// Just user collection for values from Filter List. Yes, i know i could use List<string>
    /// </summary>
    public class FilterValuesList : IEnumerator, IEnumerable
    {
        string[] filterValues = new string[0];
        int position = -1;

        public object Current
        {
            get { return filterValues[position]; }
            set { filterValues[position] = value.ToString(); }
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (position < filterValues.Length-1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public void Add(string newValue)
        {
            if (newValue.Trim() != "")
            {
                string[] temp = new string[filterValues.Length + 1];
                for (int i = 0; i < filterValues.Length; i++)
                {
                    temp[i] = filterValues[i];
                }
                filterValues = temp;
                filterValues[filterValues.Length - 1] = newValue;
            }
        }

        public void Clear()
        {
            filterValues = new string[0];
            position = -1;
        }

    }
}
