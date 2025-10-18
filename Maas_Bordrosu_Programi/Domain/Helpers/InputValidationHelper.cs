using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Helpers
{
    namespace Maas_Bordrosu_Programi.Domain.Helpers
    {
        public static class InputValidationHelper
        {
            public static string AskText(string message)
            {
                while (true)
                {
                    Console.Write($"{message}: ");
                    var input = (Console.ReadLine() ?? "").Trim();
                    if (!string.IsNullOrWhiteSpace(input))
                        return input;
                    Console.WriteLine("❌ Boş değer girilemez!");
                }
            }

            public static int AskInt(string message, int min, int max)
            {
                while (true)
                {
                    Console.Write($"{message}: ");
                    if (int.TryParse(Console.ReadLine(), out var v) && v >= min && v <= max)
                        return v;
                    Console.WriteLine($"❌ Geçerli sayı giriniz (min {min}, max {max}).");
                }
            }

            public static decimal AskDec(string message, decimal min)
            {
                while (true)
                {
                    Console.Write($"{message}: ");
                    if (decimal.TryParse(Console.ReadLine(), out var v) && v >= min)
                        return v;
                    Console.WriteLine($"❌ Geçerli tutar giriniz (min {min}).");
                }
            }

            public static bool AskYesNo(string message)
            {
                while (true)
                {
                    Console.Write($"{message} (E/H): ");
                    var s = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                    if (s == "E") return true;
                    if (s == "H") return false;
                }
            }
        }
    } }
