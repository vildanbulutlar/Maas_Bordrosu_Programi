using Maas_Bordrosu_Programi.Domain.Core;
using Maas_Bordrosu_Programi.Domain.Models;

namespace Maas_Bordrosu_Programi.Domain.Policies
{
    public abstract class BasePayPolicy : IPayPolicy
    {
        public abstract string Title { get; }
        public abstract decimal MinHourlyRate { get; }


        public Payslip Calculate(EmployeeContext ctx)
        {
            ValidateCommon(ctx);
            ValidateCore(ctx);
            var (basePay, overtime, bonus, message) = ComputeCore(ctx);

            return new Payslip
            {
                EmployeeName = ctx.Name,
                Title = Title,
                WorkHours = ctx.WorkHours,
                HourlyRate = ctx.HourlyRate,
                BasePay = basePay,
                OvertimePay = overtime,
                Bonus = bonus,
                Message = message
            };
        }

        protected virtual void ValidateCommon(EmployeeContext ctx)
        {
            if (ctx.WorkHours < 0 || ctx.HourlyRate < 0) throw new ArgumentOutOfRangeException();
            if (ctx.HourlyRate < MinHourlyRate)
                throw new InvalidOperationException($"{Title} için saatlik en az {MinHourlyRate} TL olmalı.");
        }

        protected virtual void ValidateCore(EmployeeContext ctx) { }

        protected abstract (decimal basePay, decimal overtime, decimal bonus, string message)
        ComputeCore(EmployeeContext ctx);
    }
}