using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Helpers
{
    public static class MenuValidation
    {
        public static bool IsValidChoice(string? input)
            => input is "0" or "1" or "2" or "3" or "4" or "5" or "6";
    }
}