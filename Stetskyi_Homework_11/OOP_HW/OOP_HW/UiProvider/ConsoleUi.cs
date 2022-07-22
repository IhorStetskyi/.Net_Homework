using OOP_HW.Interfaces;
using System;
using System.Collections.Generic;

namespace OOP_HW.UiProvider
{
    class ConsoleUi : IUiProvider
    {
        public void DisplayResult(List<IDocument> enumerable)
        {
            Console.Clear();
            if (enumerable.Count > 0)
            {
                foreach (IDocument doc in enumerable)
                {
                    Console.WriteLine("======================");
                    Console.WriteLine($"Document type: {doc.DocumentType} \nDocument# {doc.DocumentNumber} \nStringType: {doc.DocumentTypeString}\n-----------PropertiesList-----------");
                    foreach (var propertyInfo in doc.GetType().GetProperties())
                    {
                        Console.WriteLine(propertyInfo.Name);
                    }
                    Console.WriteLine("======================\n");
                }
            }
            else
            {
                Console.WriteLine("No Documents Found");
            }
            
        }
        public int AskForDocumentNumber()
        {
            Console.WriteLine("Please enter Document Number");
            int result = 0;
            int.TryParse(Console.ReadLine(), out result);
            if (result != 0)
            {
                return result;
            }
            Console.Clear();
            Console.WriteLine("Please Enter only Number");
            result = AskForDocumentNumber();
            return result;
        }
    }
}
