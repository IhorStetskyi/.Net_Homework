using System;
using System.IO;
using OOP_HW.Enums;
using OOP_HW.Interfaces;
using OOP_HW.Documents;
using System.Text.RegularExpressions;

namespace OOP_HW.ExtensionMethods
{
    public static class Extensions
    {
        //Here new Type should be added
        public static DocumentTypeEnum GetFileType(this string filename)
        {
            string typepart = filename.GetFileTypeString();
            switch (typepart)
            {
                case "book":
                    return DocumentTypeEnum.Book;
                case "localizedbook":
                    return DocumentTypeEnum.LocalizedBook;
                case "patent":
                    return DocumentTypeEnum.Patent;
                case "magazine":
                    return DocumentTypeEnum.Magazine;
                default:
                    return DocumentTypeEnum.NotExistingType;
            }
        }
        //Here Instantiation of new Type should be added
        public static IDocument Initialize(this FileInfo file)
        {
            DocumentTypeEnum type = file.Name.GetFileType();
            IDocument result = null;
            switch (type)
            {
                case DocumentTypeEnum.Book:
                    result = new Book();
                    SetTypeAndNumber(ref result, file);
                    break;
                case DocumentTypeEnum.Patent:
                    result = new Patent();
                    SetTypeAndNumber(ref result, file);
                    break;
                case DocumentTypeEnum.LocalizedBook:
                    result = new LocalizedBook();
                    SetTypeAndNumber(ref result, file);
                    break;
                case DocumentTypeEnum.Magazine:
                    result = new Magazine();
                    SetTypeAndNumber(ref result, file);
                    break;
                case DocumentTypeEnum.NotExistingType:
                    result = new DummyDocument();
                    SetTypeAndNumber(ref result, file);
                    break;
            }
            return result;
        }

        private static string GetFileTypeString(this string filename)
        {
            string typepart = filename.Substring(0, filename.IndexOf('_')).ToLower();
            return typepart;
        }
        private static int GetNumber(this string filename)
        {
            int numberpart = Int32.Parse(Regex.Match(filename, @"\d+").Value);
            return numberpart;
        }
        private static void SetTypeAndNumber(ref IDocument document, FileInfo file)
        {
            document.DocumentNumber = file.Name.GetNumber();
            document.DocumentTypeString = file.Name.GetFileTypeString();
        }

    }
}
