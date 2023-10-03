using AutoMapper;
using DbDapperProject.Dtos;
using DbDapperProject.Models;

namespace DbDapperProject.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultSearchedPlateEFDto, CarPlate>().ReverseMap();
        }
    }
}
