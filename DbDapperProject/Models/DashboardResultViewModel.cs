using DbDapperProject.Dtos;

namespace DbDapperProject.Models
{
    public class DashboardResultViewModel
    {
       public List<ResultCarPlatesDto> ResultCarPlates {get; set;}
       public ResultMostPlateByCityDto ResultMostPlateByCities { get; set;}
       public List<ResultMostBrandAndModelDto> ResultMostBrandAndModels { get; set;}
       public List<ResultColorCountDto> ResultColorCounts { get; set;}
       public List<ResultFuelCountDto> ResultFuelCounts { get; set;}
       public ResultShiftTypeCount ResultShiftTypeCounts { get; set;}
       public List<ResultSearchedPlateDto> ResultSearchedPlates { get; set;}
       public List<ResultSearchedPlateEFDto> ResultPlateSearchEf {  get; set;}
    }
}
