using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Bonus
{
    public interface IPerformanceBonusPolicy
    {
        decimal Bonus { get; }
    }
}