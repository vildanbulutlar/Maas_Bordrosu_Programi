using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Policies.Implementations
{ /// <summary>
  /// Yönetici: Saatlik en az 500; mesai yok; bonus eklenir.
  /// </summary>
    public sealed class ManagerPayPolicy : BasePayPolicy
    {
        public override string Title => "Yonetici";
        public override decimal MinHourlyRate => 500m;

        protected override (decimal basePay, decimal overtime, decimal bonus, string message)
            ComputeCore(EmployeeContext ctx)
        {
            var basePay = ctx.HourlyRate * ctx.WorkHours;
            return (basePay, 0m, ctx.Bonus, "Yönetici maaşı hesaplandı.");
        }
    }
}


 