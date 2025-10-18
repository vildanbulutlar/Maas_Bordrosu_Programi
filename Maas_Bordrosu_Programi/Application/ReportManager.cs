using Maas_Bordrosu_Programi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Application
{
    public static class ReportManager
    {
        private static readonly string outputRoot = JsonIo.OutputRoot; 

        public static void GenerateDailySummary()
        {
            var slips = PayrollManager.GetSlips();
            if (!slips.Any())
            {
                Console.WriteLine("⚠ Henüz hesaplama yapılmadı.");
                return;
            }

            JsonIo.WriteDailySummary(JsonIo.OutputRoot, slips); // << değişiklik


            Console.WriteLine("\n=== Gün Özeti ===");
            foreach (var s in slips)
            {
                Console.WriteLine(
                    $"{s.EmployeeName} | Ünvan: {s.Title} | Saat: {s.WorkHours} | " +
                    $"Ana: {s.BasePay:C} | Mesai: {s.OvertimePay:C} | Bonus: {s.Bonus:C} | Toplam: {s.TotalPay:C}");
            }

            var low = slips.Where(s => s.WorkHours < 150).ToList();
            if (low.Count > 0)
            {
                Console.WriteLine("\n⚠ 150 saatten az çalışanlar:");
                foreach (var s in low)
                    Console.WriteLine($"- {s.EmployeeName} ({s.WorkHours} saat)");
            }
            else
            {
                Console.WriteLine("\n(150 saat altı çalışan yok.)");
            }
        }
    }
}