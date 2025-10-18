using Maas_Bordrosu_Programi.Domain.Employess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Maas_Bordrosu_Programi.Infrastructure;

public record EmployeeRow(string name, string title);

public static class JsonIo
{
    // Tek adres: tüm JSON çıktılarının kökü
    private static readonly string ROOT =
        @"C:\Users\asus\source\repos\Maas_Bordrosu_Programi\json";

    public static string OutputRoot => ROOT;
    public static string EmployeesJson => Path.Combine(ROOT, "personel.json");

    private static readonly JsonSerializerOptions ReadOpts = new() { PropertyNameCaseInsensitive = true };
    private static readonly JsonSerializerOptions WriteOpts = new() { WriteIndented = true };

    // Sade okuma: önce ROOT\personel.json, yoksa bin\Data\personel.json, yoksa bin\Veri\personel.json
    public static List<EmployeeRow> ReadEmployees()
    {
        var baseDir = AppContext.BaseDirectory;

        foreach (var path in new[]
        {
            EmployeesJson,
            Path.Combine(baseDir, "Data", "personel.json"),
            Path.Combine(baseDir, "Veri", "personel.json"),
        }.Where(File.Exists))
        {
            var json = File.ReadAllText(path, Encoding.UTF8);
            return JsonSerializer.Deserialize<List<EmployeeRow>>(json, ReadOpts) ?? new();
        }

        // Hiçbiri yoksa boş liste (uygulama patlamasın)
        return new List<EmployeeRow>();
    }

    public static void SaveEmployees(IEnumerable<EmployeeRow> employees)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(EmployeesJson)!);
        var json = JsonSerializer.Serialize(employees, WriteOpts);
        File.WriteAllText(EmployeesJson, json, Encoding.UTF8);
        Console.WriteLine($"Personel listesi güncellendi: {EmployeesJson}");
    }

    public static void WritePayslip(string root, Maas_Bordrosu_Programi.Domain.Models.Payslip s)
    {
        var dir = Path.Combine(root, Safe(s.EmployeeName), DateTime.Now.ToString("yyyyMM"));
        Directory.CreateDirectory(dir);

        var path = Path.Combine(dir, $"{DateTime.Now:yyyyMMdd}_bordro.json");
        var json = JsonSerializer.Serialize(s, WriteOpts);
        File.WriteAllText(path, json, Encoding.UTF8);

        Console.WriteLine($"Kaydedildi: {path}");
    }

    public static void WriteDailySummary(string root, IEnumerable<Maas_Bordrosu_Programi.Domain.Models.Payslip> slips)
    {
        var dayDir = Path.Combine(root, $"bordrolar_{DateTime.Now:yyyy-MM-dd}");
        Directory.CreateDirectory(dayDir);

        File.WriteAllText(Path.Combine(dayDir, "tum_bordrolar.json"),
            JsonSerializer.Serialize(slips, WriteOpts), Encoding.UTF8);

        File.WriteAllText(Path.Combine(dayDir, "150_saat_alti.json"),
            JsonSerializer.Serialize(slips.Where(s => s.WorkHours < 150), WriteOpts), Encoding.UTF8);

        Console.WriteLine($"Gün sonu özetleri oluşturuldu: {dayDir}");
    }

    private static string Safe(string s)
    {
        foreach (var c in Path.GetInvalidFileNameChars()) s = s.Replace(c.ToString(), "");
        return s.Trim();
    }
}