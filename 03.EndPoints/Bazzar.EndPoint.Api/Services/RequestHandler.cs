﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace Bazzar.EndPoint.Api.Services
{
    public static class RequestHandler
    {
        public static IActionResult HandleRequest<T>(T request, Action<T> handler)
        {
            try
            {
                //LogStart
                handler(request);
                return new OkResult();
            }
            catch (Exception e)
            {
                //Log Exception
                return new BadRequestObjectResult(new
                {
                    error =
                    e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
    }
}
