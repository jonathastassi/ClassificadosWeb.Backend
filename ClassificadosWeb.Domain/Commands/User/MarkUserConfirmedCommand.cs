using System;
using ClassificadosWeb.Domain.Commands.Base;
using Flunt.Validations;
using MediatR;

namespace ClassificadosWeb.Domain.Commands.User
{
    public class MarkUserConfirmedCommand : BaseCommand, IRequest<GenericCommandResult>
    {
        public Guid Id { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Id.ToString(), "Id", "Por favor, informe o seu id!")
            );
        }
    }
}