namespace OOP_HW.Interfaces
{
    interface IApplication
    {
        public void GetAllDocumentsFromSource();
        public void GetAndShowDocuments(int number);
        public int AskForDocumentNumber();
    }
}
