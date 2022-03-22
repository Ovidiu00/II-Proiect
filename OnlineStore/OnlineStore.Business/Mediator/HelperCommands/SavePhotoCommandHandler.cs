using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.HelperCommands
{
    public class SavePhotoCommandHandler : IRequestHandler<SavePhotoCommand, string>
    {
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;

        public SavePhotoCommandHandler(IWebHostEnvironment environment,IConfiguration configuration)
        {
            this.environment = environment;
            this.configuration = configuration;
        }
        public Task<string> Handle(SavePhotoCommand request, CancellationToken cancellationToken)
        {
            var uploadDirectory = GetDirectoryToUpload();
            var isValid = IsFileItemValid(request.formFile);

            if (!isValid)
                return null;
            var uniqueFileName = CreateUniqueFileNameForFile(request.formFile);

            SaveToDisk(request.formFile, uploadDirectory,uniqueFileName);
            return Task.FromResult(uniqueFileName);
        }

        private string GetDirectoryToUpload()
        {
            var apiDirectory = environment.ContentRootPath;
            var frontEndRelativePath = configuration.GetValue<string>("FrontendProjectRelativePath");

            var frontendUploadsDirectory = Path.GetFullPath(Path.Combine(apiDirectory, @"..\" + frontEndRelativePath));

            return frontendUploadsDirectory;
        }

        private bool IsFileItemValid(IFormFile file)
        {
            if (file is null)
                return false;

            if (file.Length == 0)
                return false;

            return true;
        }

        private string CreateUniqueFileNameForFile(IFormFile file)
        {
            var uniqueFileName = new Guid().ToString() + "_" + file.Name;

            return uniqueFileName;
        }
        private void SaveToDisk(IFormFile file,string uploadDirectory,string fileName)
        {
            string filePath = Path.Combine(uploadDirectory, file.FileName);

            using (Stream fileStream = new FileStream(uploadDirectory, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
