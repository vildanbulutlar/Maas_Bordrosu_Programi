using Maas_Bordrosu_Programi.Domain.Bonus;
using Maas_Bordrosu_Programi.Domain.Bonuses;
using Maas_Bordrosu_Programi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Validations

{
    public static class PayrollValidation
    {
        public static int GetWorkHours()
        {
            while (true)
            {
                Console.Write("Toplam çalışma saati (0-600): ");
                if (int.TryParse(Console.ReadLine(), out var h) && h >= 0 && h <= 600)
                    return h;
                Console.WriteLine("❌ Geçerli bir değer giriniz.");
            }
        }

        public static decimal GetHourlyRate(string title)
        {
            if (title.Equals("Yonetici", StringComparison.OrdinalIgnoreCase))
            {
                // Yöneticide minimum 500 kuralını uygula
                var v = AskDec("Saatlik ücret (>= 500)", 500m);
                return v;
            }

            // Memur/diğer
            var def = AskYesNo("Saatlik ücret 500 TL varsayılan olsun mu") ? 500m : 1m;
            var r = AskDec("Saatlik ücret (TL)", def);
            return r;
        }

        public static int GetPerformanceScore()
        {
            while (true)
            {
                Console.Write("Performans puanı (0-100): ");
                if (int.TryParse(Console.ReadLine(), out var p) && p >= 0 && p <= 100)
                    return p;
                Console.WriteLine("❌ Geçerli değer giriniz.");
            }
        }

        public static decimal GetPerformanceBonus(string title, EmployeeContext ctx, decimal basePay)
        {
            IPerformanceBonusPolicy perfPolicy =
                title.Equals("Yonetici", StringComparison.OrdinalIgnoreCase) ? new ManagerPerformanceBonus(ctx, basePay) :
                title.Equals("Memur", StringComparison.OrdinalIgnoreCase) ? new ClerkPerformanceBonus(ctx, basePay) :
                new NoPerformanceBonus(ctx, basePay);

            return perfPolicy.Bonus;
        }

        // küçük yardımcılar
        private static decimal AskDec(string msg, decimal min)
        {
            while (true)
            {
                Console.Write($"{msg}: ");
                if (decimal.TryParse(Console.ReadLine(), out var v) && v >= min)
                    return v;
                Console.WriteLine($"❌ Geçerli tutar giriniz (min {min}).");
            }
        }

        private static bool AskYesNo(string msg)
        {
            while (true)
            {
                Console.Write($"{msg} (E/H): ");
                var s = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                if (s == "E") return true;
                if (s == "H") return false;
            }
        }
    }

}