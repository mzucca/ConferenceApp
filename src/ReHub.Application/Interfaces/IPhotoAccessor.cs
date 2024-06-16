using Microsoft.AspNetCore.Http;
using ReHub.Application.Photos;

namespace ReHub.Application.Interfaces;

public interface IPhotoAccessor
{
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<string> DeletePhoto(string publicId);
}
