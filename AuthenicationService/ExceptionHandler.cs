﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenicationService
{
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string message = "Произошла непредвиденная ошибка";
            if (context.Exception is CustomExeption)
            {
                message = context.Exception.Message;
            }
            context.Result = new BadRequestObjectResult(message);
        }
    }
}
