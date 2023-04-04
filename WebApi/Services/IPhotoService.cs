using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace WebApi.Services
{
    public interface IPhotoService
    {
         Task<ImageUploadResult> UploadImageAsync(IFormFile photo);
        //  Will add one more method to delete the photo 

         Task<DeletionResult> DeletePhotoAsync(string photoPublicId);
    }
}