﻿using Home_Central.Data.Entities;
using Home_Central.Models;
using Home_Central.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Home_Central.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger,IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _homeService.GetHomeTextsAsync();
            return View(result);
        }
        [Authorize]
        public IActionResult NieuweText()
        {
            var value = new HomeText();
            return View(value);        
        }
        [HttpPost]
        public async Task<IActionResult> SetNieuweText(HomeText value)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (value.Id == 0)
                        await _homeService.PostHomeText(value);
                    else
                        await _homeService.UpdateHomeText(value);
                    var nieuw = new HomeText();
                    return View(nameof(Index));
                }
                catch (Exception)
                {
                    return Problem();
                }
            }
            return View(nameof(NieuweText),value);            
        }
        [Authorize]
        public  IActionResult EditText(HomeText homeText)
        {            
            return View(nameof(NieuweText),homeText);
        }
        [Authorize]
        public IActionResult DeleteText(HomeText homeText)
        {
            return View(nameof(DeleteText),homeText);
        }
        [Authorize,HttpPost]
        public async Task<IActionResult> DeleteOldText(HomeText homeText)
        {
            if (ModelState.IsValid)
            {
                if(homeText.Id != 0)
                {
                    await _homeService.DeleteHomeText(homeText);
                }
            }
            return View(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}