using OOP_HW.Attributes;
using OOP_HW.Enums;
using OOP_HW.Interfaces;
using System;
using System.Collections.Generic;

namespace OOP_HW.Documents
{
    [Cacheable(true)]
    class Patent : IDocument
    {
        public DocumentTypeEnum DocumentType { get; set; } = DocumentTypeEnum.Patent;
        public string DocumentTypeString { get; set; }
        public int DocumentNumber { get; set; }
        public string Title { get; set; }

        public int UniqueId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<string> Authors { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
