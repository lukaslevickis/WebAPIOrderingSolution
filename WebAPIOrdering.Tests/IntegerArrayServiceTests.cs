using Moq;
using WebAPIOrdering.Interfaces;
using WebAPIOrdering.Services;
using Xunit;

namespace WebAPIOrdering.Tests
{
    public class IntegerArrayServiceTests
    {
        private IntegerArrayService IntegerArrayService
        {
            get {
                    ValidationService validationService = new ValidationService();
                    return new IntegerArrayService(validationService);
                }
        }

        [Fact]
        public void IntegerArrayService_ShouldReturnOrderedArray()
        {
            IntegerArrayService.TryOrderIntegerArray(new int[] { 8, 10, 5, 1, 2 }, out int[] orderedArray);
            int[] expected = new int[] { 1, 2, 5, 8, 10 };
            Assert.Equal(expected, orderedArray);
        }

        [Fact]
        public void IntegerArrayService_ShouldReturnSameArray()
        {
            int[] intArr = new int[] { 1, 3, 5, 7, 8 };
            IntegerArrayService.TryOrderIntegerArray(intArr, out int[] orderedArray);
            Assert.Equal(intArr, orderedArray);
        }
    }
}
