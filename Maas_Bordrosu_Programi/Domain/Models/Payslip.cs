using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Models;

public sealed class Payslip
{
    public string EmployeeName { get; init; } = "";
    public string Title { get; init; } = "";
    public decimal WorkHours { get; init; }
    public decimal HourlyRate { get; init; }
    public decimal BasePay { get; init; }
    public decimal OvertimePay { get; init; }
    public decimal Bonus { get; set; }      // Program/PayrollManager bunu artırıyor
    public string? Message { get; set; }    // açıklama notları
    public decimal TotalPay => BasePay + OvertimePay + Bonus;
}