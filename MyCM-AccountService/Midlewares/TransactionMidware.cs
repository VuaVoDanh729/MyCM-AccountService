﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCM_AccountService.Midlewares
{
    public class TransactionMidware
    {
        private readonly RequestDelegate _next;

        public TransactionMidware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }

    public static class TransactionMidwareExtensions
    {
        public static IApplicationBuilder UseTransactionMidware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransactionMidware>();
        }
    }
}
