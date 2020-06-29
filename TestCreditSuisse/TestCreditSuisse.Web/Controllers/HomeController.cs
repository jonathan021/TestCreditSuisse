using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestCreditSuisse.Web.Data.Entities;
using TestCreditSuisse.Web.Models;

namespace TestCreditSuisse.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Statistics()
        {
            //List<Rootobject> reservationList = new List<Rootobject>();
            
            Rootobject reservationList = new Rootobject();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.banxico.org.mx/SieAPIRest/service/v1/series/SP74665/datos?incremento=PorcAnual&token=0feef5a94a3e9b87695e8243b86eea7b04b0c3b44880161b11a63a0b0605f206"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<Rootobject>(apiResponse);
                }                              

            }
            
            return View(reservationList.bmx.series[0].datos);           
        }

        public async Task<IActionResult> PorcObsAnt()
        {
            //List<Rootobject> reservationList = new List<Rootobject>();

            Rootobject reservationList = new Rootobject();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.banxico.org.mx/SieAPIRest/service/v1/series/SP74665/datos?incremento=PorcObsAnt&token=0feef5a94a3e9b87695e8243b86eea7b04b0c3b44880161b11a63a0b0605f206"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<Rootobject>(apiResponse);
                }

            }

            return View(reservationList.bmx.series[0].datos);
        }

        public async Task<IActionResult> PorcAcumAnual()
        {
            //List<Rootobject> reservationList = new List<Rootobject>();

            Rootobject reservationList = new Rootobject();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.banxico.org.mx/SieAPIRest/service/v1/series/SP74665/datos?incremento=PorcAcumAnual&token=0feef5a94a3e9b87695e8243b86eea7b04b0c3b44880161b11a63a0b0605f206"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<Rootobject>(apiResponse);
                }

            }

            return View(reservationList.bmx.series[0].datos);
        }

        public async Task<IActionResult> PorcAnual()
        {
            //List<Rootobject> reservationList = new List<Rootobject>();

            Rootobject reservationList = new Rootobject();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://www.banxico.org.mx/SieAPIRest/service/v1/series/SP74665/datos?incremento=PorcAnual&token=0feef5a94a3e9b87695e8243b86eea7b04b0c3b44880161b11a63a0b0605f206"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<Rootobject>(apiResponse);
                }

            }

            return View(reservationList.bmx.series[0].datos);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
