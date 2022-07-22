using System.Runtime.Serialization;


namespace Sources
{
    public static class ExtensionMethods
    {
        private const string Path = @"../../../../FolderToSaveFile/TEMP.txt";
        public static T DeepClone<T>(this T obj)
        {
            DataSerializer dataSerializer = new DataSerializer();
            dataSerializer.BinarySerialize(obj, Path);
            return dataSerializer.BinaryDeserialize<T>(Path);
        }
    }
}
