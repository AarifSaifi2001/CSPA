using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Repository
{
    public interface IBodyTypeRepository
    {
        Task<List<BodyType>> GetAllBodyTypesAsync();
    }
}