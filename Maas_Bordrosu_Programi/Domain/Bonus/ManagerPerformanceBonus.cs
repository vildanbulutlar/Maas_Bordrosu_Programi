
using Maas_Bordrosu_Programi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Maas_Bordrosu_Programi.Domain.Bonus
{
    public sealed class ManagerPerformanceBonus : IPerformanceBonusPolicy
    {
        private readonly int _perf;
        public ManagerPerformanceBonus(EmployeeContext ctx, decimal basePay) { _perf = ctx.PerformanceScore; }
        public decimal Bonus => _perf >= 80 ? 3000m : _perf >= 60 ? 1500m : 0m;
    }
}