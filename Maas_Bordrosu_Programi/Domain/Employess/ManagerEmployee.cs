using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;
using Maas_Bordrosu_Programi.Domain.Policies;
using Maas_Bordrosu_Programi.Domain.Policies.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Employess
{
    public sealed class ManagerEmployee : IEmployee
    {
        public string Name { get; }
        public string Title { get; } = "Yonetici";
        public decimal MonthlyHours { get; set; }  // <-- EKLENDİ

        // Yönetici: saat, ücret, bonus sorulur
        public IReadOnlyList<InputField> RequiredFields { get; } =
            new[] { InputField.WorkHours, InputField.HourlyRate, InputField.Bonus };

        // ❌ IPayPolicy yerine ✔ BasePayPolicy kullan
        private readonly BasePayPolicy _policy = new ManagerPayPolicy();

        public ManagerEmployee(string name) => Name = name;

        // Eski imzayı bozma; performans yoksa 0 olarak geç
        public Payslip Calculate(int workHours, decimal hourlyRate, decimal bonus = 0m)
            => _policy.Calculate(new EmployeeContext(Name, Title, workHours, hourlyRate, bonus, perfScore: 0));

        // İstersen perfScore alan aşırı yükleme:
        public Payslip Calculate(int workHours, decimal hourlyRate, decimal bonus, int perfScore)
            => _policy.Calculate(new EmployeeContext(Name, Title, workHours, hourlyRate, bonus, perfScore));
    }
}

