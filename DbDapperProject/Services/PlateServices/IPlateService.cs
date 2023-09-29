using DbDapperProject.Dtos;


namespace DbDapperProject.Services.PlateServices

{
    public interface IPlateService
    {
        Task<List<ResultCarPlatesDto>> GetListAll();
        Task<ResultCarPlatesDto> GetById(int id);
        Task<List<ResultMostPlateByCityDto>> MostPlateByCityList();
        Task<List<ResultMostBrandAndModelDto>> MostBrandAndModelList();
        Task<List<ResultColorCountDto>> ColorCountList();
    }
}
