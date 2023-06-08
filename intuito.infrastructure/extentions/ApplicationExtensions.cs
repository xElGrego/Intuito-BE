﻿using intuito.application.models.DTOs;
using intuito.application.models.exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Prometheus;
using System.Text.Json;

namespace intuito.infrastructure.extentions
{
    public static class ApplicationsExtentions
    {
        public static IApplicationBuilder ConfigureMetricServer(this IApplicationBuilder app)
        {
            app.UseMetricServer();
            app.UseHttpMetrics();
            return app;
        }


        //Configura las repuestas erroneas de las peticiones http
        public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    int _code = context.Response.StatusCode;
                    int _codeAPP = 0;
                    string _message = exceptionHandlerPathFeature.Error.Message;
                    string _stackTrace = null;

                    try
                    {
                        _codeAPP = ((BaseCustomException)((ExceptionHandlerFeature)exceptionHandlerPathFeature).Error).Code;
                        _message = ((BaseCustomException)((ExceptionHandlerFeature)exceptionHandlerPathFeature).Error).Message;
                        _stackTrace = ((BaseCustomException)((ExceptionHandlerFeature)exceptionHandlerPathFeature).Error).StackTrace;

                        switch (_codeAPP)
                        {
                            case 500:
                                context.Response.StatusCode = _codeAPP;
                                _code = _codeAPP;
                                break;
                            case 401:
                                switch (_stackTrace)
                                {
                                    case "SecurityTokenExpiredException":
                                        context.Response.Headers.Add("Token-Expirerd", "true");
                                        break;
                                    case "ArgumentException":
                                    case "invalid_token":
                                        context.Response.Headers.Add("Token-Valid", "false");
                                        break;

                                }
                                context.Response.StatusCode = _codeAPP;
                                _code = _codeAPP;
                                break;
                            default:
                                context.Response.StatusCode = 400;
                                _code = _codeAPP;
                                break;
                        }


                    }
                    catch (InvalidCastException)
                    {

                    }
                    DtoResponseError _response = new DtoResponseError
                    {
                        code = _code,
                        message = _message,
                        error = true,

                    };


                    string sjon = JsonSerializer.Serialize(_response);
                    await context.Response.WriteAsync(sjon);
                    await context.Response.Body.FlushAsync();
                });
            });


            return app;
        }
    }
}
