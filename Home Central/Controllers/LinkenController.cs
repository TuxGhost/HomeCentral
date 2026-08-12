using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HomeCentral.Services;
using HomeCentral.Data.Entities;

namespace HomeCentral.Controllers;

[Authorize]
public class LinkenController : Controller
{
    private readonly IUrlService _urlService;
    public LinkenController(IUrlService urlService)
    {
        _urlService = urlService;
    }
    // GET: LinkenController
    public async Task<ActionResult> Index()
    {
        var list = await _urlService.GetURLAsync();
        return View(list);
    }

    // GET: LinkenController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: LinkenController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: LinkenController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create_old(IFormCollection collection)
    {
        if(ModelState.IsValid)
        {
            var url = collection["Url"];
            var name = collection["Name"];
            Linken link = new Linken()
            {
                Name = name,
                Url = url,
            };
            _urlService.Post(link);
        }
        return View("Create");        
        /*try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View("Index");
        }*/
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Linken link)
    {
        if (ModelState.IsValid)
        {           
            _urlService.Post(link);
        }
        return View("Create");
    }

    // GET: LinkenController/Edit/5
    public ActionResult Edit(Linken link)
    {
        //Linken link = _urlService.GetUrlAsync(id).Result!;        
        return View(nameof(Create),link);
    }

    // POST: LinkenController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: LinkenController/Delete/5
    public ActionResult Delete(int id)
    {
        try
        {
            _urlService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // POST: LinkenController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
