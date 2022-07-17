using System.Collections.Generic;

namespace OOP_HW.Interfaces
{
    public interface IUiProvider
    {
        public void DisplayResult(List<IDocument> enumerable);
        public int AskForDocumentNumber();
    }
}
