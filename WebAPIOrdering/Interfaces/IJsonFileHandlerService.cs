using System;
namespace WebAPIOrdering.Interfaces
{
    public interface IJsonFileHandlerService
    {
        void TryWriteToFile(int[] data);
        bool TryReadFromFile(out string data);
    }
}
