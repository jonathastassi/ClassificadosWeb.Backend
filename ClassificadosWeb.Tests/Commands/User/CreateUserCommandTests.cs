using System.Collections.Generic;
using System.Linq;
using ClassificadosWeb.Domain.Commands.User;
using ClassificadosWeb.Domain.Entities;
using Xunit;

namespace ClassificadosWeb.Tests.Commands
{
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommand validCommand = new CreateUserCommand("Nome valido", "cidade valida", "SP", "11 3333-1111", "11 99999-9999", "email@email.com", "123456", "123456");
        private readonly CreateUserCommand invalidEmailCommand = new CreateUserCommand("Nome valido", "cidade valida", "SP", "11 3333-1111", "11 99999-9999", "e@mail", "123456", "123456");
        private readonly CreateUserCommand invalidCommand = new CreateUserCommand("wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "SSP", "11 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-1111", "11 99999-9999", "email@email.com", "123456553445345345345345345345354345354534534345", "123456");

        [Fact]
        public void Nao_permitir_email_invalido()
        {
            invalidEmailCommand.Validate();

            Assert.False(invalidEmailCommand.Valid);
        }

        [Fact]
        public void Dado_um_usuario_valido_retornar_valido()
        {
            validCommand.Validate();
            Assert.True(validCommand.Valid);
        }

        public static IEnumerable<object[]> CommandsInvalids()
        {
            yield return new object[] { new CreateUserCommand("wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "cidade valida", "SP", "11 3333-1111", "11 99999-1234", "email@email.com", "123456", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "SP", "11 3333-1111", "11 99999-1234", "email@email.com", "123456", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "cidade valida", "SPS", "11 3333-1111", "11 99999-1234", "email@email.com", "123456", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "cidade valida", "SPS", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "11 99999-1234", "email@email.com", "123456", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "cidade valida", "SPS", "11 3333-1111", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "email@email.com", "123456", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "cidade valida", "SPS", "11 3333-1111", "11 99999-1234", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "123456", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "cidade valida", "SPS", "11 3333-1111", "11 99999-1234", "email@email.com", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "123456") };
            yield return new object[] { new CreateUserCommand("nome válido", "cidade valida", "SPS", "11 3333-1111", "11 99999-1234", "email@email.com", "123456", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff") };
        }

        [Theory]
        [MemberData(nameof(CommandsInvalids))]
        public void Dados_objetos_invalidos_retornar_nao_valido_de_acordo_com_regras_de_validacao(CreateUserCommand commands)
        {
            commands.Validate();
            Assert.False(commands.Valid);
        }
    }
}