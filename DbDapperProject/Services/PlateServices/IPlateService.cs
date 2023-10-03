using DbDapperProject.Dtos;


namespace DbDapperProject.Services.PlateServices

{
    public interface IPlateService
    {
        Task<List<ResultCarPlatesDto>> GetListAll();
        Task<ResultCarPlatesDto> GetById(int id);
        Task<ResultMostPlateByCityDto> MostPlateByCityList();
        Task<List<ResultMostBrandAndModelDto>> MostBrandAndModelList();
        Task<List<ResultColorCountDto>> ColorCountList();
        Task<ResultShiftTypeCount> ShiftTypeCount();
        Task<List<ResultFuelCountDto>> FuelList();
        Task<List<ResultSearchedPlateDto>> PlateSearch(string searchedPlate);
        List<ResultSearchedPlateEFDto> PlateSearchEf(string searchedPlate);
    }
}
