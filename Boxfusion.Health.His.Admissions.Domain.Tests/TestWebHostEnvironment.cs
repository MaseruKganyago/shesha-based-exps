using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Boxfusion.Health.His.Admissions.Tests
{
    public class TestWebHostEnvironment : IWebHostEnvironment
    {
        public string ApplicationName { get; set; } = "Test Application3";
        public string WebRootPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "wwwroot");
        public string EnvironmentName { get; set; } = "Test3";
        public string ContentRootPath { get; set; } = Environment.CurrentDirectory;

        public IFileProvider ContentRootFileProvider
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IFileProvider WebRootFileProvider
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
