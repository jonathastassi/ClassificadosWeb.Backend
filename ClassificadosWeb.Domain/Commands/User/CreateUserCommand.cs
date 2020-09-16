using ClassificadosWeb.Domain.Commands.Base;
using Flunt.Validations;
using MediatR;

namespace ClassificadosWeb.Domain.Commands.User
{
    public class CreateUserCommand : BaseCommand, IRequest<GenericCommandResult>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public bool IsWhatsapp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public CreateUserCommand()
        {
            
        }

        public CreateUserCommand(string name, string city, string state, string telephone, string cellphone, bool isWhatsapp, string email, string password, string confirmPassword)
        {
            Name = name;
            City = city;
            State = state;
            Telephone = telephone;
            Cellphone = cellphone;
            IsWhatsapp = isWhatsapp;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Name, "Nome", "Por favor, informe o seu nome!")
                    .IsNotNullOrEmpty(City, "Cidade", "Por favor, informe a cidade!")
                    .IsNotNullOrEmpty(State, "Estado", "Por favor, informe o estado!")
                    .IsNotNullOrEmpty(Cellphone, "Celular", "Por favor, informe seu número de celular!")
                    .IsNotNull(IsWhatsapp, "Whatsapp", "Por favor, informe se o número é Whatsapp!")
                    .IsNotNullOrEmpty(Email, "E-mail", "Por favor, informe seu e-mail!")
                    .IsEmail(Email, "E-mail", "Por favor, informe um e-mail válido!")
                    .IsNotNullOrEmpty(Password, "Senha", "Por favor, informe a senha!")
                    .IsNotNullOrEmpty(ConfirmPassword, "Confirmação de Senha", "Por favor, informe novamente a senha!")

                    .HasMinLen(Password, 6, "Senha", "A senha deve conter no mínimo 6 caracteres!")
                    .HasMinLen(ConfirmPassword, 6, "Confirmação de Senha", "A confirmação da senha deve conter no mínimo 6 caracteres!")

                    .HasMaxLen(Name, 200, "Nome", "O nome deve conter no máximo 200 caracteres!")
                    .HasMaxLen(City, 200, "Cidade", "A cidade deve conter no máximo 200 caracteres!")
                    .HasExactLengthIfNotNullOrEmpty(State, 2, "Estado", "O estado deve conter 2 caracteres!")
                    .HasMaxLen(Telephone, 50, "Telefone", "O telefone deve conter no máximo 50 caracteres!")
                    .HasMaxLen(Cellphone, 50, "Celular", "O celular deve conter no máximo 50 caracteres!")
                    .HasMaxLen(Email, 50, "E-mail", "O e-mail deve conter no máximo 500 caracteres!")
                    .HasMaxLen(Password, 20, "Senha", "A senha deve conter no máximo 20 caracteres!")
            );
        }

        public bool IsConfirmedPassword() 
        {
            return this.Password == this.ConfirmPassword;
        }
    }
}