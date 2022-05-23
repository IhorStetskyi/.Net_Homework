using System;


namespace DictionaryReplacer
{
    public static class ExtensionClass
    {
        public static string ReplaceWords(this string str)
        {

            string[] words = str.Split();

            words.ReplaceWordsInArray();

            str = words.FormStringFromArray();

            return str;

        }



        public static string[] ReplaceWordsInArray(this string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].StartsWith('$') && arr[i].EndsWith('$'))
                {
                    arr[i] = GetDictionaryValue(arr[i].RemoveFirstAndLastCharacterAndToLower());
                }
            }
            return arr;
        }

        public static string FormStringFromArray(this string[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += (arr[i] + " ");
            }
            return str.Trim();
        }

        public static string RemoveFirstAndLastCharacterAndToLower(this string str)
        {
            string result = str.Substring(1, str.Length - 2).ToLower();
            return result;
        }

        public static string GetDictionaryValue(string str)
        {
            foreach (var key in DictionarySource.sourceDict.Keys)
            {
                if (key == str)
                {
                    return DictionarySource.sourceDict[key];
                }
            }
            throw new Exception("No Value Found");
        }
    }
       
}
