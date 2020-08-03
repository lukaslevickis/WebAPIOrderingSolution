using System;
using System.IO;
using System.IO.Abstractions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebAPIOrdering.Interfaces;
using WebAPIOrdering.Models;

namespace WebAPIOrdering.Services
{
    public class JsonFileHandlerService: IJsonFileHandlerService
    {
        private readonly JsonFile _jsonFile;
        private readonly IFileSystem _fileSystem;

        public JsonFileHandlerService(IFileSystem fileSystem, IOptions<JsonFile> jsonFile)
        {
            _fileSystem = fileSystem;
            _jsonFile = jsonFile.Value;
        }

        public void TryWriteToFile(int[] data)
        {
            if (!_fileSystem.Directory.Exists(_jsonFile.Path))
            {
                _fileSystem.Directory.CreateDirectory(_jsonFile.Path);
            }

            _jsonFile.Path = string.IsNullOrEmpty(_jsonFile.Path) ? Path.Combine(Directory.GetCurrentDirectory(), "JsonFiles"): _jsonFile.Path;
            _jsonFile.Name = string.IsNullOrEmpty(_jsonFile.Name) ? Guid.NewGuid().ToString() + ".json" : _jsonFile.Name;
            string filePath = _fileSystem.Path.Combine(_jsonFile.Path, _jsonFile.Name);
            _fileSystem.File.WriteAllText(filePath, JsonConvert.SerializeObject(data));
        }

        public bool TryReadFromFile(out string data)
        {
            data = string.Empty;
            if (string.IsNullOrEmpty(_jsonFile.Path) || string.IsNullOrEmpty(_jsonFile.Name))
            {
                return false;
            }

            string filePath = _fileSystem.Path.Combine(_jsonFile.Path, _jsonFile.Name);
            data = _fileSystem.File.ReadAllText(filePath);
            return true;
        }
    }
}
