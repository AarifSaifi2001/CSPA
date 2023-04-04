using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly CityContext _context;
        private readonly IMapper _mapper;
        public CityRepository(CityContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CityModel>> GetAllCitiesAsync(){
            // Without AutoMapper 
            // var records = await _context.Cities.Select(x => new CityModel(){
            //     id = x.id,
            //     name = x.name
            // }).ToListAsync();

            // return records;

            // With AutoMapper
            var records = await _context.Cities.ToListAsync();
            return _mapper.Map<List<CityModel>>(records);
        }

        public async Task<CityModel> GetCityByIdAsync(int id){

            // var record = await _context.Cities.FindAsync(id);

            // var city = new CityModel(){
            //     // id = record.id,
            //     name = record.name
            // };

            // Without AutoMapper
            // var record = await _context.Cities.Where(x => x.id == id).Select(x => new CityModel(){
            //     id = x.id,
            //     name = x.name
            // }).FirstOrDefaultAsync();

            // return record;

            // With AutoMapper
            var record = await _context.Cities.FindAsync(id);
            return _mapper.Map<CityModel>(record);
        }

        public async Task<int> AddCityAsync(CityModel cityModel){

            // Without AutoMapper
            // var city = new Cities(){
            //     name = cityModel.name
            // };

            // With AutoMapper
            var city = _mapper.Map<Cities>(cityModel);

            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city.id;
        }

        public async Task DeleteCityAsync(int id){

            var result = await _context.Cities.FindAsync(id);

            if(result!=null){
                _context.Cities.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCityAsync(CityModel cityModel, int id){

            var record = await _context.Cities.FindAsync(id);

            if(record!=null){

                record.name = cityModel.name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCityPatchAsync(JsonPatchDocument jsonPatchDocument, int id){
            var record = await _context.Cities.FindAsync(id);

            if(record!=null){
                jsonPatchDocument.ApplyTo(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}