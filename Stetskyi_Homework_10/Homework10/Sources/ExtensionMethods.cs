using System.Runtime.Serialization;


namespace Sources
{
    public static class ExtensionMethods
    {
        public static T DeepClone<T>(this T obj)
        {
            DataSerializer DataS = new DataSerializer();
            string Path = @"../../../../FolderToSaveFile/TEMP.txt";
            DataS.BinarySerialize(obj, Path);
            return DataS.BinaryDeserialize<T>(Path);
        }
    }
}
