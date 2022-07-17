using OOP_HW.Enums;

namespace OOP_HW.Interfaces
{
    public interface IDocument
    {
        public DocumentTypeEnum DocumentType { get; set; }
        string DocumentTypeString { get; set; }
        public int DocumentNumber { get; set; }
        public string Title { get; set; }
    }
}
