using DbDapperProject.DapperContext;
using DbDapperProject.Dtos;
using DbDapperProject.Models;
using DbDapperProject.Services.PlateServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DbDapperProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IPlateService _plateService;

        public DashboardController(IPlateService plateService)
        {
            _plateService = plateService;
        }

        public async Task<IActionResult> Index(string? searchedPlate)
        {
            DashboardResultViewModel viewModel = new DashboardResultViewModel();

            viewModel.ResultMostPlateByCities = await _plateService.MostPlateByCityList();
            viewModel.ResultMostBrandAndModels = await _plateService.MostBrandAndModelList();
            viewModel.ResultShiftTypeCounts = await _plateService.ShiftTypeCount();

            if (searchedPlate != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var values = await _plateService.PlateSearch(searchedPlate);
                viewModel.ResultSearchedPlates = values.Take(99).ToList();

                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                ViewBag.timeSpanDapper = elapsed.TotalSeconds.ToString();
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var values = await _plateService.PlateSearch("34 ABC");
                viewModel.ResultSearchedPlates = values;

                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                ViewBag.timeSpanDapper = elapsed.TotalSeconds.ToString();
            }


            if (searchedPlate != null)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var values = _plateService.PlateSearchEf(searchedPlate);
                viewModel.ResultPlateSearchEf = values.Take(99).ToList();

                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                ViewBag.timeSpanEf = elapsed.TotalSeconds.ToString();
            }
            else
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var values = _plateService.PlateSearchEf("34 ABC");
                if (values == null) 
                {
                    List<Dtos.ResultSearchedPlateEFDto> resultSearchedPlateEFDtos = new List<Dtos.ResultSearchedPlateEFDto>() ;
                    ResultSearchedPlateEFDto eFDto = new ResultSearchedPlateEFDto
                    {
                        BRAND = "boş",
                        CASETYPE = "boş",
                        COLOR = "boş",
                        FUEL = "boş",
                        MODEL = "boş",
                        PLATE = "boş",
                        SHIFTTYPE = "boş",
                        YEAR_ = "boş"
                    };
                    viewModel.ResultPlateSearchEf = resultSearchedPlateEFDtos;
                }
                else
                {
                    viewModel.ResultPlateSearchEf = values;

                }

                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                ViewBag.timeSpanEf = elapsed.TotalSeconds.ToString();
            }

            return View(viewModel);
            
        }


        public async Task<IActionResult> ColorCount()
        {
            var list = await _plateService.ColorCountList();
            var colorCount = list.Take(15).ToList();
            return Json(new { jsonlist = colorCount });
        }

        public async Task<IActionResult> FuelCountList()
        {
            var list = await _plateService.FuelList();
            return Json(new { jsonlist = list });
        }



    }
}
