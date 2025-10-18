using Maas_Bordrosu_Programi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Employess
{
    // Hangi girdiler istenecek? (Required input fields)
    // Girdi alanları (Input fields)
    public enum InputField { WorkHours, HourlyRate, Bonus }

    public interface IEmployee
    {
        string Name { get; }
        string Title { get; }
        decimal MonthlyHours { get; set; }
        IReadOnlyList<InputField> RequiredFields { get; }

        // Maaş hesapla (calculate payslip)
        Payslip Calculate(int workHours, decimal hourlyRate, decimal bonus = 0m);
    }
}

