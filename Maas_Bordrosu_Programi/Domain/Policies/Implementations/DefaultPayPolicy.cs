using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Policies.Implementations
{
    /// <summary>
    /// Varsayılan: Sadece saatlik * saat; bonus ve mesai yok.
    /// </summary>
    public sealed class DefaultPayPolicy : BasePayPolicy
    {
        public override string Title => "Default";
        public override decimal MinHourlyRate => 0m;

        protected override (decimal basePay, decimal overtime, decimal bonus, string message)
            ComputeCore(EmployeeContext ctx)
        {
            var basePay = ctx.HourlyRate * ctx.WorkHours;
            return (basePay, 0m, 0m, "Varsayılan politika uygulandı.");
        }
    }
}
