using ClassificadosWeb.Domain.Commands.Base;
using Flunt.Validations;
using MediatR;

namespace ClassificadosWeb.Domain.Commands.User
{
    public class LoginUserCommand : BaseCommand, IRequest<GenericCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand()
        {
            
        }

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Email, "E-mail", "Por favor, informe seu e-mail!")
                    .IsNotNullOrEmpty(Password, "Senha", "Por favor, informe a senha!")

                    .IsEmail(Email, "E-mail", "Por favor, informe um e-mail válido!")

                    .HasMinLen(Password, 6, "Senha", "A senha deve conter no mínimo 6 caracteres!")

                    .HasMaxLen(Email, 50, "E-mail", "O e-mail deve conter no máximo 500 caracteres!")
                    .HasMaxLen(Password, 20, "Senha", "A senha deve conter no máximo 20 caracteres!")
            );
        }
    }
}