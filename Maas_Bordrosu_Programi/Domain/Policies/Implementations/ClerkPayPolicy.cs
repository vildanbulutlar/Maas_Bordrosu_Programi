using System;
using Maas_Bordrosu_Programi.Domain.Core;    // EmployeeContext
using Maas_Bordrosu_Programi.Domain.Models;  // Payslip

namespace Maas_Bordrosu_Programi.Domain.Policies.Implementations
{
    // Memur: İlk 180 saat normal; üstü 1.5x mesai.
    // Saatlik 0 girilirse varsayılan 500 TL kabul edilir.
    public sealed class ClerkPayPolicy : BasePayPolicy
    {
        public override string Title => "Memur";
        public override decimal MinHourlyRate => 0m;   // memur için alt sınır yok
        private const decimal RegularHours = 180m;
        private const decimal OvertimeFactor = 1.5m;
        private const decimal DefaultRate = 500m;

        // Hesaplama gövdesi burada; Calculate() BasePayPolicy'de
        protected override (decimal basePay, decimal overtime, decimal bonus, string message)
            ComputeCore(EmployeeContext ctx)
        {
            var rate = ctx.HourlyRate <= 0 ? DefaultRate : ctx.HourlyRate;

            var regularHours = Math.Min(ctx.WorkHours, RegularHours);
            var overtimeHrs = Math.Max(0m, ctx.WorkHours - RegularHours);

            var basePay = rate * regularHours;
            var overtime = rate * OvertimeFactor * overtimeHrs;

            var msg = overtimeHrs > 0
                ? $"{overtimeHrs} saat %50 zamlı mesai uygulandı."
                : "Mesai yok.";

            return (basePay, overtime, 0m, msg);
        }
    }
}

