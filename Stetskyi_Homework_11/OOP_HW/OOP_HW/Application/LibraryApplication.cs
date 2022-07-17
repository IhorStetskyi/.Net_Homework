using System;
using System.Collections.Generic;
using OOP_HW.Interfaces;

namespace OOP_HW.Application
{
    class LibraryApplication : IApplication
    {
        private readonly IUiProvider uiProvider;
        private readonly ISource filesource;
        private List<IDocument> fullLibrary { get; set; }
        public LibraryApplication(ISource filesource, IUiProvider uiProvider)
        {
            this.filesource = filesource;
            this.uiProvider = uiProvider;
        }

        public void GetAllDocumentsFromSource()
        {
            fullLibrary = filesource.RetrieveAllDocuments();
        }
        public void GetAndShowDocuments(int number)
        {
            GetAllDocumentsFromSource();
            if (fullLibrary != null && fullLibrary.Count > 0)
            {
                List<IDocument> temp = new List<IDocument>();
                foreach (IDocument doc in fullLibrary)
                {
                    if (doc.DocumentNumber == number)
                    {
                        temp.Add(doc);
                    }
                }
                uiProvider.DisplayResult(temp);
            }
            else
            {
                throw new ArgumentNullException("Library is Empty");
            }
        }
        public int AskForDocumentNumber()
        {
            return uiProvider.AskForDocumentNumber();
        }
    }
}
