using WebAPIOrdering.Models;

namespace WebAPIOrdering.Interfaces
{
    public interface IIntegerArrayService
    {
        bool TryOrderIntegerArray(int[] data, out int[] orderedArray);
    }
}
