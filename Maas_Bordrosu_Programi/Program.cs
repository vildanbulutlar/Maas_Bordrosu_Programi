using Maas_Bordrosu_Programi.Application;
using Maas_Bordrosu_Programi.Application.Web; // <-- eklendi
using Maas_Bordrosu_Programi.Domain.Helpers;
using Maas_Bordrosu_Programi.Validations;

namespace Maas_Bordrosu_Programi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            EmployeeManager.LoadEmployees();

            while (true)
            {
                ShowMenu();
                Console.Write("Seçiminiz: ");
                var secim = Console.ReadLine();

                if (!MenuValidation.IsValidChoice(secim))
                {
                    Console.WriteLine("❌ Geçersiz seçim! (0-6 arası olmalı)");
                    continue;
                }

                switch (secim)
                {
                    case "1": EmployeeManager.ListEmployees(); break;
                    case "2": PayrollManager.CalculatePayslipForOne(); break;
                    case "3": EmployeeManager.PromoteEmployee(); break;
                    case "4": EmployeeManager.RemoveEmployee(); break;
                    case "5": ReportManager.GenerateDailySummary(); break;
                    case "6": WebServer.Start(); break;              // <-- Web'i aç
                    case "0":
                        WebServer.Stop();                           // <-- Çıkarken kapat
                        Console.WriteLine("👋 Programdan çıkılıyor...");
                        return;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n=== Maaş Bordro Programı ===");
            Console.WriteLine("1 - Personelleri Listele");
            Console.WriteLine("2 - Maaş Hesapla (tek personel)");
            Console.WriteLine("3 - Terfi İşlemi");
            Console.WriteLine("4 - Çalışan Çıkar");
            Console.WriteLine("5 - Gün Sonu Raporu");
            Console.WriteLine("6 - Web Arayüzünü Aç");
            Console.WriteLine("0 - Çıkış");
        }
    }
}