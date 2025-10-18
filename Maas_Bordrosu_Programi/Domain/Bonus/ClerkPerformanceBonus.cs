using Maas_Bordrosu_Programi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Maas_Bordrosu_Programi.Domain.Bonus
{
    public sealed class ClerkPerformanceBonus : IPerformanceBonusPolicy
    {
        private readonly int _perf;
        private readonly decimal _basePay;
        public ClerkPerformanceBonus(EmployeeContext ctx, decimal basePay)
        { _perf = ctx.PerformanceScore; _basePay = basePay; }

        public decimal Bonus => _perf >= 85 ? _basePay * 0.05m :
                                _perf >= 70 ? _basePay * 0.02m : 0m;
    }
}