﻿using API2.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        
    }
}