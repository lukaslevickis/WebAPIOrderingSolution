using WebAPIOrdering.Services;
using Xunit;

namespace WebAPIOrdering.Tests
{
    public class ValidationServiceTests
    {
        [Fact]
        public void ValidationServiceTests_WithCorrectNumbers_ShouldReturnTrue()
        {
            ValidationService validationService = new ValidationService();
            Assert.True(validationService.TryValidateData(new int[] { 1, 2, 5, 8, 10 }));
        }

        [Fact]
        public void ValidationServiceTests_WithIncorrectNumbers_ShouldReturnFalse()
        {
            ValidationService validationService = new ValidationService();
            Assert.False(validationService.TryValidateData(new int[] { 100, 2, 11, 8, 10 }));
        }
    }
}
