using OOP_HW.Attributes;
using OOP_HW.Enums;
using OOP_HW.Interfaces;

namespace OOP_HW.Documents
{
    [Cacheable(false)]
    class DummyDocument : IDocument
    {
        public DocumentTypeEnum DocumentType { get; set; } = DocumentTypeEnum.NotExistingType;
        public string DocumentTypeString { get; set; }
        public int DocumentNumber { get; set; }
        public string Title { get; set; }
    }
}
