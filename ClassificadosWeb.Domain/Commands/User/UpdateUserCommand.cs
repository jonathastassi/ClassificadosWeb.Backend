using System;
using ClassificadosWeb.Domain.Commands.Base;
using Flunt.Validations;
using MediatR;

namespace ClassificadosWeb.Domain.Commands.User
{
    public class UpdateUserCommand : CreateUserCommand, IRequest<GenericCommandResult>
    {
        public Guid Id { get; set; }

        public UpdateUserCommand(Guid id, string name, string city, string state, string telephone, string cellphone, bool isWhatsapp,string email, string password, string confirmPassword) : base(name, city, state, telephone, cellphone, isWhatsapp, email, password, confirmPassword)
        {
            this.Id = id;
        }

        public override void Validate()
        {
            AddNotifications(
               new Contract()
                   .Requires()
                   .IsNotNullOrEmpty(Id.ToString(), "Id", "Por favor, informe o seu id!")
                   .IsNotNullOrEmpty(Name, "Nome", "Por favor, informe o seu nome!")
                   .IsNotNullOrEmpty(City, "Cidade", "Por favor, informe a cidade!")
                   .IsNotNullOrEmpty(State, "Estado", "Por favor, informe o estado!")
                   .IsNotNullOrEmpty(Cellphone, "Celular", "Por favor, informe seu número de celular!")
                   .IsNotNull(IsWhatsapp, "Whatsapp", "Por favor, informe se o número é Whatsapp!")
                   .IsNotNullOrEmpty(Email, "E-mail", "Por favor, informe seu e-mail!")

                   .HasMinLengthIfNotNullOrEmpty(Password, 6, "Senha", "A senha deve conter no mínimo 6 caracteres!")
                   .HasMinLengthIfNotNullOrEmpty(ConfirmPassword, 6, "Confirmação de Senha", "A confirmação da senha deve conter no mínimo 6 caracteres!")

                   .HasMaxLen(Name, 200, "Nome", "O nome deve conter no máximo 200 caracteres!")
                   .HasMaxLen(City, 200, "Cidade", "A cidade deve conter no máximo 200 caracteres!")
                   .HasLen(State, 2, "Estado", "O estado deve conter 2 caracteres!")
                   .HasMaxLen(Telephone, 50, "Telefone", "O telefone deve conter no máximo 50 caracteres!")
                   .HasMaxLen(Cellphone, 50, "Celular", "O celular deve conter no máximo 50 caracteres!")
                   .HasMaxLen(Email, 50, "E-mail", "O e-mail deve conter no máximo 500 caracteres!")
                   .HasMaxLen(Email, 20, "Senha", "A senha deve conter no máximo 20 caracteres!")
           );
        }
    }
}