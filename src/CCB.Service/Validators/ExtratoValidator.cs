using CCB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CCB.Service.Validators
{
    public class ExtratoValidator : AbstractValidator<Extrato>
    {
        public ExtratoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o objeto.");
                });

            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("É necessário informar a data.")
                .NotNull().WithMessage("É necessário informar a data.");

            RuleFor(c => c.Historico)
                .NotEmpty().WithMessage("É necessário informar o histórico.")
                .NotNull().WithMessage("É necessário informar o histórico.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("É necessário informar o valor.")
                .NotNull().WithMessage("É necessário informar o valor.");

            RuleFor(c => c.Tipo)
                .NotEmpty().WithMessage("É necessário informar o tipo.")
                .NotNull().WithMessage("É necessário informar o tipo.");
        }
    }
}
