using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Embedded;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reminder.Storage.SQLServer
{
    public static class SQL
    {
        public static string CreateContactTable =>
            ReadScript(nameof(CreateContactTable));


        private static string ReadScript(string name)
        {
            var provider = new EmbeddedFileProvider(typeof(SQL).Assembly, "");
            var info = provider.GetFileInfo($"Scripts\\{name}.sql");

            using var stream = info.CreateReadStream();
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
