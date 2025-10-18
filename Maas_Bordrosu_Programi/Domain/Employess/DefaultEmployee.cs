using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;
using Maas_Bordrosu_Programi.Domain.Policies;
using Maas_Bordrosu_Programi.Domain.Policies.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Employess
{
    public sealed class DefaultPayPolicy : BasePayPolicy
    {
        public override string Title => "Default";
        public override decimal MinHourlyRate => 0m; // istersen 500m gibi bir zemin verebilirsin

        protected override (decimal basePay, decimal overtime, decimal bonus, string message)
            ComputeCore(EmployeeContext ctx)
        {
            // MinHourlyRate zeminini uygula + bonus’u da kat
            var rate = Math.Max(ctx.HourlyRate, MinHourlyRate);
            var basePay = rate * ctx.WorkHours;
            var bonus = Math.Max(0m, ctx.Bonus);

            var msg = $"Varsayılan politika. Saatlik: {rate:N2}, Bonus: {bonus:N2}";
            return (basePay, 0m, bonus, msg);
        }
    }
}
