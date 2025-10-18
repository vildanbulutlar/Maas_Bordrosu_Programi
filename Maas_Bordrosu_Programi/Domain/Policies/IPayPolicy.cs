using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maas_Bordrosu_Programi.Domain.Policies
{//Amaç: “Maaş nasıl hesaplanır?”ın arayüzü (interface).
 //Tek metot: Payslip Calculate(EmployeeContext ctx).
 //Neden var? Farklı unvanlar için farklı hesap kuralını polimorfik yönetmek (Strategy Pattern).
 //İlişki: ManagerPayPolicy, ClerkPayPolicy, DefaultPayPolicy is-a IPayPolicy.
    public interface IPayPolicy
    {
        string Title { get; }          // Ünvan (ör: Yonetici, Memur)
        decimal MinHourlyRate { get; } // Minimum saatlik ücret
    }
}
