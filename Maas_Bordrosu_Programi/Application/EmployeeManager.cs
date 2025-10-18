// Application/EmployeeManager.cs
using Maas_Bordrosu_Programi.Domain.Helpers.Maas_Bordrosu_Programi.Domain.Helpers;
using Maas_Bordrosu_Programi.Infrastructure;   // JsonIo, EmployeeRow
using Maas_Bordrosu_Programi.Validations;      // EmployeeValidationHelper
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maas_Bordrosu_Programi.Application
{
    public static class EmployeeManager
    {
        private static List<EmployeeRow> employees = new();
        private static Dictionary<string, EmployeeRow> map =
            new(StringComparer.OrdinalIgnoreCase);

        public static void LoadEmployees()
        {
            employees = JsonIo.ReadEmployees(); // personel.json JsonIo’dan
            map = employees.ToDictionary(e => e.name, e => e, StringComparer.OrdinalIgnoreCase);
        }

        public static void ListEmployees()
        {
            Console.WriteLine("\n=== Personellerim ===");
            foreach (var e in employees)
                Console.WriteLine($"- {e.name} ({e.title})");
        }

        public static void PromoteEmployee()
        {
            Console.Write("Terfi ettirilecek çalışan adı: ");
            var name = Console.ReadLine() ?? "";

            if (!EmployeeValidationHelper.Exists(map, name))
            {
                Console.WriteLine("❌ Çalışan bulunamadı.");
                return;
            }

            Console.Write("Yeni ünvan (Memur/Yonetici): ");
            var newTitle = Console.ReadLine() ?? "";

            if (!EmployeeValidationHelper.IsValidTitle(newTitle))
            {
                Console.WriteLine("❌ Geçersiz ünvan.");
                return;
            }

            var idx = employees.FindIndex(e => e.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            employees[idx] = new EmployeeRow(employees[idx].name, newTitle);
            map[employees[idx].name] = employees[idx];

            JsonIo.SaveEmployees(employees);   // json\personel.json’a yazar
            Console.WriteLine($"✅ {employees[idx].name} artık '{newTitle}' ünvanında.");
        }

        public static void RemoveEmployee()
        {
            Console.Write("Çıkarılacak çalışan adı: ");
            var name = Console.ReadLine() ?? "";

            if (!EmployeeValidationHelper.Exists(map, name))
            {
                Console.WriteLine("❌ Çalışan bulunamadı.");
                return;
            }

            employees.RemoveAll(e => e.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            map.Remove(name);                   // OrdinalIgnoreCase sözlük → case farkı sorun olmaz

            JsonIo.SaveEmployees(employees);
            Console.WriteLine($"✅ {name} listeden çıkarıldı.");
        }
    }
}