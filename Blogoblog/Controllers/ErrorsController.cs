﻿using Microsoft.AspNetCore.Mvc;

namespace BlogPLL.Controllers;

public class ErrorsController : Controller
{    
    public IActionResult Forbidden()
    {
        return View();
    }

    public IActionResult Resource()
    {
        return View();
    }

    public IActionResult GoWrong()
    {
        return View();
    }
}