using System.Linq;
using WebAPIOrdering.Interfaces;

namespace WebAPIOrdering.Services
{
    public class IntegerArrayService: IIntegerArrayService
    {
        private readonly IValidationService _validationService;

        public IntegerArrayService(IValidationService validationService)
        {
            _validationService = validationService;
        }

        public bool TryOrderIntegerArray(int[] data, out int[] orderedArray)
        {
            orderedArray = null;

            if (data == null || !data.Any())
            {
                throw new System.ArgumentException("Array is null or empty");
            }

            if (!_validationService.TryValidateData(data))
            {
                throw new System.ArgumentException("Invalid data");
            }

            int temp;
            for (int j = 0; j <= data.Length - 2; j++)
            {
                for (int i = 0; i <= data.Length - 2; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        temp = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = temp;
                    }
                }
            }

            orderedArray = data;

            return true;
        }
    }
}
