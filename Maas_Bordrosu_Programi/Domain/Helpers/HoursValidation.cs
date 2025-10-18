using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Helpers
{
    public static class HoursValidation
    {
        public static int Validate(int hours)
        {
            if (hours < 0 || hours > 600)
                throw new ArgumentException("Çalışma saati 0 ile 600 arasında olmalıdır!");
            return hours;
        }
    }
}