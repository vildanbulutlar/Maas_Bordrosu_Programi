using Maas_Bordrosu_Programi.Domain.Employess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Core
{
    public interface IReportingService
    {
        // varsayılan eşik: 10 saat
        IReadOnlyList<(IEmployee Employee, decimal Hours)> GetUnderMonthlyHours(
            IEnumerable<IEmployee> source, decimal threshold = 10m);
    }
}
