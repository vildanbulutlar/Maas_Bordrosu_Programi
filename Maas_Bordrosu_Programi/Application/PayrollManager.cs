using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;
using Maas_Bordrosu_Programi.Domain.Policies;
using Maas_Bordrosu_Programi.Infrastructure;
using Maas_Bordrosu_Programi.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Maas_Bordrosu_Programi.Application
{
    public static class PayrollManager
    {
        // <<< SADECE BU SATIRI GÜNCELLEDİK
        private static readonly string outputRoot = JsonIo.OutputRoot;


        private static readonly List<Payslip> slips = new();

        public static void CalculatePayslipForOne()
        {
            Console.Write("Maaş hesaplanacak çalışan adı: ");
            var name = Console.ReadLine() ?? "";

            var employees = JsonIo.ReadEmployees();
            var row = employees.FirstOrDefault(e => e.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (row == null) { Console.WriteLine("❌ Çalışan bulunamadı."); return; }

            int hours = PayrollValidation.GetWorkHours();
            decimal rate = PayrollValidation.GetHourlyRate(row.title);
            int perf = PayrollValidation.GetPerformanceScore();

            var ctx = new EmployeeContext(row.name, row.title, hours, rate, 0m, perf);
            var policy = PayPolicyResolver.Resolve(row.title);
            var slip = policy.Calculate(ctx);

            slip.Bonus += PayrollValidation.GetPerformanceBonus(row.title, ctx, slip.BasePay);

            Console.WriteLine($"{slip.EmployeeName} | Ünvan: {slip.Title} | Saat: {slip.WorkHours} | " +
                              $"Ana: {slip.BasePay:C} | Mesai: {slip.OvertimePay:C} | Bonus: {slip.Bonus:C} | Toplam: {slip.TotalPay:C}");

            Directory.CreateDirectory(outputRoot);
            JsonIo.WritePayslip(outputRoot, slip);
            slips.Add(slip);
        }

        public static List<Payslip> GetSlips() => slips;
    }
}