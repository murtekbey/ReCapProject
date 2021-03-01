using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(string path, IFormFile file)
        {
            try
            {
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                using (FileStream fileStream = System.IO.File.Create(path + newFileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

                return newFileName;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public static string Update(string oldPath, string newPath, IFormFile file)
        {
            try
            {
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                using (FileStream fileStream = System.IO.File.Create(newPath + newFileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

                File.Delete(oldPath);

                return newFileName;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
