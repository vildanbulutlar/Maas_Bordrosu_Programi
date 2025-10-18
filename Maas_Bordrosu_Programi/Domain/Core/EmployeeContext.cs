using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Core
{
    public sealed class EmployeeContext
    {
        public string Name { get; init; } = "";
        public string Title { get; init; } = "";
        public int WorkHours { get; init; }
        public decimal HourlyRate { get; init; }
        public decimal Bonus { get; init; }
        public int PerformanceScore { get; init; }

        public EmployeeContext(string name, string title, int workHours, decimal hourlyRate, decimal bonus, int perfScore)
        {
            Name = name; Title = title; WorkHours = workHours;
            HourlyRate = hourlyRate; Bonus = bonus; PerformanceScore = perfScore;
        }
    }
}


