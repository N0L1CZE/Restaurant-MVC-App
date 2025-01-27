using Microsoft.AspNetCore.Http;

namespace UTB.Restaurant.Application.Abstraction
{
    public interface IFileUploadService
    {
        string FileUpload(IFormFile fileToUpload, string folderNameOnServer);
    }
}
