using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BookStore.Api.Infrastracture.Extensions
{
    public static class FileExtensions
    {
        public static byte[] GetBytesFromFilePath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }
    }
}