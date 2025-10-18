// Validations/EmployeeValidationHelper.cs
using Maas_Bordrosu_Programi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maas_Bordrosu_Programi.Validations
{
    public static class EmployeeValidationHelper
    {
        private static readonly string[] AllowedTitles = { "Memur", "Yonetici" };

        // İsim var mı? (List ve Dictionary için iki overload)
        public static bool Exists(List<EmployeeRow> employees, string? name) =>
            !string.IsNullOrWhiteSpace(name) &&
            employees.Any(e => e.name.Equals(name, StringComparison.OrdinalIgnoreCase));

        // Sözlüğü zaten OrdinalIgnoreCase ile kurmuştun → normalize etmeye gerek yok
        public static bool Exists(Dictionary<string, EmployeeRow> map, string? name) =>
            !string.IsNullOrWhiteSpace(name) && map.ContainsKey(name!);

        // Geçerli ünvan mı?
        public static bool IsValidTitle(string? title) =>
            !string.IsNullOrWhiteSpace(title) &&
            AllowedTitles.Contains(title.Trim(), StringComparer.OrdinalIgnoreCase);
    }
}