using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Helpers
{
    public static class PerformanceValidation
    {
        public static int Validate(int perf)
        {
            if (perf < 0 || perf > 100)
                throw new ArgumentException("Performans puanı 0 ile 100 arasında olmalıdır!");
            return perf;
        }
    }
}