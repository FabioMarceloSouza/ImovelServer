using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entrevistaServer.Dtos.ClienteDtos;
using FluentValidation;

namespace entrevistaServer.Validators
{
    public class ClienteRequestValidator :  AbstractValidator<ClienteRequest> 
    {
       public ClienteRequestValidator()
       {
        RuleFor(p => p.Email)
        .EmailAddress()
        .NotEmpty()
        .NotNull();

        RuleFor(p => p.Name)
        .MinimumLength(2)
        .NotEmpty()
        .NotNull();

        RuleFor(p => p.CpfOuCnpj)
        .NotEmpty()
        .NotNull();
       }
    }
}