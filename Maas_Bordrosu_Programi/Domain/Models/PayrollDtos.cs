namespace Maas_Bordrosu_Programi.Application.Models
{
    // Frontend'den gelecek istek
    public record PayrollRequest(
        string Name,
        string Title,     // "Memur" | "Yonetici"
        int WorkHours,
        decimal HourlyRate,
        int Performance   // 0-100
    );

    // API'nin döndüğü yanıt
    public record PayrollResponse(
        string EmployeeName,
        string Title,
        int WorkHours,
        decimal BasePay,
        decimal OvertimePay,
        decimal Bonus,
        decimal TotalPay
    );
}