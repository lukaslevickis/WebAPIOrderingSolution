using System;
using System.IO.Abstractions.TestingHelpers;
using Microsoft.Extensions.Options;
using Moq;
using WebAPIOrdering.Models;
using WebAPIOrdering.Services;
using Xunit;

namespace WebAPIOrdering.Tests
{
    public class JsonFileHandlerServiceTests
    {
        [Fact]
        public void TryWriteToFile_ReadFromFile_ShouldReturnTrue()
        {
            MockFileSystem mockFileSystem = new MockFileSystem();
            Mock<IOptions<JsonFile>> jsonFileMock = new Mock<IOptions<JsonFile>>();
            jsonFileMock.SetupGet(x => x.Value).Returns(new JsonFile
            {
                Path = "/Users/lukaslevickis/Projects/WebAPIOrdering/WebAPIOrdering/JsonFiles",
                Name = Guid.NewGuid().ToString() + ".json"
            });

            JsonFileHandlerService jsonFileHandlerService = new JsonFileHandlerService(mockFileSystem, jsonFileMock.Object);
            jsonFileHandlerService.TryWriteToFile(new int[] { 2, 4, 1, 3 });
            string filePath = mockFileSystem.Path.Combine(jsonFileMock.Object.Value.Path, jsonFileMock.Object.Value.Name);
            Assert.True(mockFileSystem.File.Exists(filePath));
            jsonFileHandlerService.TryReadFromFile(out string data);
            Assert.True(data.Equals("[2,4,1,3]"));
        }
    }
}
