using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Helpers
{
    public static class RateValidation
    {
        public static decimal Validate(decimal rate, decimal min = 1m)
        {
            if (rate < min)
                throw new ArgumentException($"Saatlik ücret {min} TL'den düşük olamaz!");
            return rate;
        }
    }
}