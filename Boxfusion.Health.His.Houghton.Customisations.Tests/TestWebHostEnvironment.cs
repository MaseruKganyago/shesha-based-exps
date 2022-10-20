using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Boxfusion.Health.His.Admissions.Application.Tests
{
    public class TestWebHostEnvironment : IWebHostEnvironment
    {
        public string ApplicationName { get; set; } = "Test Application4";
        public string WebRootPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "wwwroot");
        public string EnvironmentName { get; set; } = "Test4";
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