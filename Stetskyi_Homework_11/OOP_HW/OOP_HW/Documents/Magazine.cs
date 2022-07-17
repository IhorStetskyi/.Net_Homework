using OOP_HW.Attributes;
using OOP_HW.Enums;
using OOP_HW.Interfaces;
using System;

namespace OOP_HW.Documents
{
    [Cacheable(true)]
    class Magazine : IDocument
    {
        public DocumentTypeEnum DocumentType { get; set; } = DocumentTypeEnum.Magazine;
        public string DocumentTypeString { get; set; }
        public int DocumentNumber { get; set; }
        public string Title { get; set; }

        public int ReleaseNumber { get; set; }
        public string Publisher { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
