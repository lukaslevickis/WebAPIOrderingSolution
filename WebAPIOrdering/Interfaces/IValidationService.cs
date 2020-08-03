namespace WebAPIOrdering.Interfaces
{
    public interface IValidationService
    {
        bool TryValidateData(int[] intArr);
    }
}
