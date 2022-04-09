using Core.Constants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FormFileHelpers
{
    public class ImageHelper : IFileHelper
    {
        private readonly static string _basePath = Directory.GetCurrentDirectory() + "/wwwroot/";
        private readonly static string _imageFolder = "images/";
        private readonly static string _fullPath = _basePath + _imageFolder;

        public string Add(IFormFile file)
        {
            Directory.CreateDirectory(_fullPath);

            CheckIfImage(file);

            var name = CreateName(file);
            CreateFile(_fullPath + name, file);
            return _imageFolder + name;
        }

        public void Delete(string filePath)
        {
            File.Delete(_basePath + filePath);
        }

        public string Update(IFormFile file, string oldFilePath)
        {
            string newPath = Add(file);
            Delete(oldFilePath);
            return newPath;
        }

        private static void CheckIfImage(IFormFile file)
        {
            var extentions = new string[] { ".jpg", ".jpeg", ".png" };
            var ext = Path.GetExtension(file.FileName);

            if (!extentions.Contains(ext))
                throw new Exception(Messages.NotSupportedFileType);
        }

        private static string CreateName(IFormFile file)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        }

        private static void CreateFile(string path, IFormFile file)
        {
            using FileStream stream = File.Create(path);
            file.CopyTo(stream);
        }
    }
}
