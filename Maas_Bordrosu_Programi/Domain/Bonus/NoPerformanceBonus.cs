using Maas_Bordrosu_Programi.Domain.Bonus;
using Maas_Bordrosu_Programi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Maas_Bordrosu_Programi.Domain.Bonuses
{
    public sealed class NoPerformanceBonus : IPerformanceBonusPolicy
    {
        public NoPerformanceBonus(EmployeeContext ctx, decimal basePay) { }
        public decimal Bonus => 0m;
    }
}
