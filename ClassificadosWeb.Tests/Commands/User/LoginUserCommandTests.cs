using System.Collections.Generic;
using ClassificadosWeb.Domain.Commands.User;
using Xunit;

namespace ClassificadosWeb.Tests.Commands.User
{
    public class LoginUserCommandTests
    {
        private readonly LoginUserCommand validCommand = new LoginUserCommand("email@email.com", "123456");
        private readonly LoginUserCommand invalidCommand = new LoginUserCommand("emaemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comil.com", "12"); 

        [Fact]
        public void Nao_permitir_email_invalido()
        {
            invalidCommand.Validate();

            Assert.False(invalidCommand.Valid);
        }

        [Fact]
        public void Validar_login_valido()
        {
            validCommand.Validate();
            Assert.True(validCommand.Valid);
        }

        [Fact]
        public void Validar_login_invalido()
        {
            invalidCommand.Validate();
            Assert.False(invalidCommand.Valid);
        }

        public static IEnumerable<object[]> CommandsInvalids()
        {
            yield return new object[] { new LoginUserCommand("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww", "123456") };
            yield return new object[] { new LoginUserCommand("email@email.com", "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww") };
        }

        [Theory]
        [MemberData(nameof(CommandsInvalids))]
        public void Dados_objetos_invalidos_retornar_nao_valido_de_acordo_com_regras_de_validacao(LoginUserCommand commands)
        {
            commands.Validate();
            Assert.False(commands.Valid);
        }
    }
}