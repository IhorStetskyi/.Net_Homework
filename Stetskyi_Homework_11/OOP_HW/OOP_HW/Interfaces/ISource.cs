using System.Collections.Generic;

namespace OOP_HW.Interfaces
{
    public interface ISource
    {
        public List<IDocument> RetrieveAllDocuments();
    }
}
