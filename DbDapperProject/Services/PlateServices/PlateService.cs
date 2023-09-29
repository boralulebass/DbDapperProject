using Dapper;
using DbDapperProject.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DbDapperProject.Services.PlateServices
{
    public class PlateService : IPlateService 
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public PlateService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new SqlConnection(_configuration.GetConnectionString("connection"));
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
        public async Task<List<ResultMostPlateByCityDto>> MostPlateByCityList()
        {
            var value = await _dbConnection.QueryAsync<ResultMostPlateByCityDto>("SELECT TOP 5 CITYNR, COUNT(*) AS PlateCount FROM PLATES   GROUP BY CITYNR   ORDER BY PlateCount DESC");

            return value.ToList();
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
        public async Task<List<ResultShiftTypeCount>> ShiftTypeCount()
        {
            var value = await _dbConnection.QueryAsync<ResultShiftTypeCount>("select COLOR, COUNT(*) As ColorCount from PLATES  group by COLOR  order by ColorCount desc");

            return value.ToList();
        }



    }
}
