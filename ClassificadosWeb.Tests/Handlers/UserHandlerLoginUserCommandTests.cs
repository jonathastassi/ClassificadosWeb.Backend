using System.Threading;
using ClassificadosWeb.Domain.Commands.Base;
using ClassificadosWeb.Domain.Commands.User;
using ClassificadosWeb.Domain.Entities;
using ClassificadosWeb.Domain.Handlers;
using ClassificadosWeb.Domain.Repositories;
using ClassificadosWeb.Domain.Uow;
using Moq;
using Xunit;

namespace ClassificadosWeb.Tests.Handlers
{
    public class UserHandlerLoginUserCommandTests
    {
        private readonly LoginUserCommand validCommand = new LoginUserCommand("email@email.com", "123456");
        private readonly LoginUserCommand invalidCommand = new LoginUserCommand("emaemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comemail.comil.com", "12"); 

        [Fact]
        public async void Deve_retornar_true_ao_executar_um_command_valido()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByEmail("email@email.com")).ReturnsAsync(() => {
                var user = new UserEntity("Usuário Logado", "cidade valido", "SP", "11 989907", "1123123123", "email@email.com",  "123456", null);
                user.HashPassword();
                user.SetConfirmed();
                return user;
            });

            var mockUow = new Mock<IUnitOfWork>();

            UserHandler handler = new UserHandler(mockUserRepository.Object, mockUow.Object);

            var tcs = new CancellationTokenSource(1000);
            GenericCommandResult result = (GenericCommandResult)await handler.Handle(this.validCommand, tcs.Token);

            Assert.True(result.Success);
        }

        [Fact]
        public async void Deve_retornar_false_ao_executar_um_command_invalido()
        {
            
        }

        [Fact]
        public async void Nao_permitir_login_se_usuario_nao_estiver_confirmado()
        {

        }

        [Fact]
        public async void Validar_se_usuario_esta_sendo_retornado_sem_password()
        {

        }
    }
}