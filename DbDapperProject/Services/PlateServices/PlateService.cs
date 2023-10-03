using AutoMapper;
using Dapper;
using DbDapperProject.Dtos;
using DbDapperProject.EFContext;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DbDapperProject.Services.PlateServices
{
    public class PlateService : IPlateService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;


        public PlateService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _dbConnection = new SqlConnection(_configuration.GetConnectionString("connection"));
            _mapper = mapper;
        }

        public async Task<List<ResultCarPlatesDto>> GetListAll()
        {
            var values = await _dbConnection.QueryAsync<ResultCarPlatesDto>("select * from PLATES");

            return values.ToList();

        }
        public async Task<ResultCarPlatesDto> GetById(int id)
        {
            var value = await _dbConnection.QueryFirstOrDefaultAsync<ResultCarPlatesDto>("select * from PLATES where ID=" + id);

            return value;
        }
        public async Task<ResultMostPlateByCityDto> MostPlateByCityList()
        {
            var value = await _dbConnection.QueryFirstOrDefaultAsync<ResultMostPlateByCityDto>("SELECT TOP 1 CITYNR, COUNT(*) AS PlateCount FROM PLATES   GROUP BY CITYNR   ORDER BY PlateCount ASC");

            return value;
        }
        public async Task<List<ResultMostBrandAndModelDto>> MostBrandAndModelList()
        {
            var value = await _dbConnection.QueryAsync<ResultMostBrandAndModelDto>("SELECT TOP 10  BRAND, MODEL, COUNT(*) AS PlateCount  FROM PLATES  GROUP BY BRAND, MODEL ORDER BY PlateCount DESC");

            return value.ToList();
        }
        public async Task<List<ResultColorCountDto>> ColorCountList()
        {
            var value = await _dbConnection.QueryAsync<ResultColorCountDto>("select COLOR, COUNT(*) As ColorCount from PLATES  group by COLOR  order by ColorCount desc");

            return value.ToList();
        }
        public async Task<ResultShiftTypeCount> ShiftTypeCount()
        {
            var value = await _dbConnection.QueryFirstOrDefaultAsync<ResultShiftTypeCount>("SELECT TOP 1 SHIFTTYPE as ShiftType ,COUNT(*) AS CarCount FROM PLATES GROUP BY SHIFTTYPE ORDER BY CARCOUNT DESC");

            return value;
        }
        public async Task<List<ResultFuelCountDto>> FuelList()
        {
            var value = await _dbConnection.QueryAsync<ResultFuelCountDto>("SELECT FUEL, COUNT(*) AS FuelCount FROM PLATES GROUP BY FUEL ORDER BY FuelCount DESC");

            return value.ToList();
        }
        public async Task<List<ResultSearchedPlateDto>> PlateSearch(string searchedPlate)
        {

            var value = await _dbConnection.QueryAsync<ResultSearchedPlateDto>("SELECT [PLATE],[BRAND],[MODEL],[YEAR_],[FUEL],[SHIFTTYPE],[COLOR],[CASETYPE] FROM PLATES WHERE PLATE LIKE '" + searchedPlate + "%'");
            return value.ToList();

        }
        //EF

        public List<ResultSearchedPlateEFDto> PlateSearchEf(string? searchedPlate)
        {
            using (var context = new ContextEF())
            {

                var value = context.PLATES.Where(x => x.PLATE.Contains(searchedPlate)).ToList();
                return _mapper.Map<List<ResultSearchedPlateEFDto>>(value);

            }

        }

    }

}
