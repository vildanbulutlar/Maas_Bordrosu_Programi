using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Helpers
{
    public static class TitleValidation
    {
        private static readonly string[] validTitles = { "Yonetici", "Memur" };

        public static string Validate(string title)
        {
            if (!validTitles.Contains(title, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException($"Geçersiz ünvan: {title}. Sadece {string.Join("/", validTitles)} olabilir.");
            return title;
        }
    }
}