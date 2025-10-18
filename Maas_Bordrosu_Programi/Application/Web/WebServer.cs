using Maas_Bordrosu_Programi.Application.Models;
using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Policies;
using Maas_Bordrosu_Programi.Validations;


namespace Maas_Bordrosu_Programi.Application.Web
{
    public static class WebServer
    {
        private static WebApplication? _app;
        private const string Url = "http://localhost:5080";

        public static void Start()
        {
            if (_app != null) { Console.WriteLine("ℹ️ Web zaten açık."); return; }

            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseUrls(Url);

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapPost("/api/payroll/calculate", (PayrollRequest req) =>
            {
                if (req.WorkHours < 0) return Results.BadRequest("Çalışma saati negatif olamaz.");
                if (req.HourlyRate < 0) return Results.BadRequest("Saatlik ücret negatif olamaz.");
                if (req.Performance is < 0 or > 100)
                    return Results.BadRequest("Performans 0-100 arası olmalı.");

                var ctx = new EmployeeContext(req.Name, req.Title, req.WorkHours, req.HourlyRate, 0m, req.Performance);
                var policy = PayPolicyResolver.Resolve(req.Title);
                var slip = policy.Calculate(ctx);
                slip.Bonus += PayrollValidation.GetPerformanceBonus(req.Title, ctx, slip.BasePay);

                return Results.Ok(slip);
            });

            _app = app;
            _ = _app.StartAsync();
            Console.WriteLine($"🌐 Web arayüzü açık: {Url}");
        }

        public static void Stop()
        {
            if (_app == null) { Console.WriteLine("ℹ️ Web zaten kapalı."); return; }
            Console.WriteLine("🛑 Web arayüzü kapanıyor...");
            try
            {
                ((IHost)_app).StopAsync(CancellationToken.None).GetAwaiter().GetResult();
                _app.DisposeAsync().AsTask().GetAwaiter().GetResult();
            }
            catch { }
            _app = null;
        }
    }
}