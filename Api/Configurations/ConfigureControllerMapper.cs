﻿using Application.AppConfig;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Api.Configurations
{
    public static class ConfigureControllerMapper
    {
        private static class NonSpaPath
        {
            public const string Api = "/server/api";
            public const string OData = "/server/odata";
        }

        private static string[] GetNonSpaPaths()
        {
            Type type = typeof(NonSpaPath);
            return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(e => e.GetValue(null).ToString())
                .ToArray();
        }
        private static void AddMappingSpa(this WebApplication app)
        {
            var spaDevServer = app.Services.GetService<IOptions<AppSettings>>().Value.SpaDevServer;
            var nonSpaPaths = GetNonSpaPaths();
            app.MapWhen(
                ctx =>
                    Array.TrueForAll(nonSpaPaths, e => !ctx.Request.Path.StartsWithSegments(e)),
                config =>
                    {
                        config.UseStaticFiles();
                        config.UseEndpoints(endpoints =>
                        {
                            endpoints.MapFallbackToFile("index.html");
                        });
                    });
        }

        private static void AddMappingApiAndOData(this WebApplication app)
        {
            app.MapWhen(ctx =>
                ctx.Request.Path.StartsWithSegments(NonSpaPath.Api)
                || ctx.Request.Path.StartsWithSegments(NonSpaPath.OData), config =>
                    {
                        config.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
        }

        public static void AddControllerMapper(this WebApplication app)
        {
            app.AddMappingSpa();
            app.AddMappingApiAndOData();
        }
    }
}
