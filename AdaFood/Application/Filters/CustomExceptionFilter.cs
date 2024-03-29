﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using AdaFood.Application.Responses;

namespace AdaFood.Application.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;
            var erroResult = new ErroResponse(context.Exception.Message, context.HttpContext.Response.StatusCode);
            var result = new JsonResult(erroResult);

            context.Result = result;
        }
    }
}
