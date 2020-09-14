using System.Threading;
using System.Threading.Tasks;
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
    public class UserHandlerCreateUserCommandTests
    {
        private readonly CreateUserCommand validCommand = new CreateUserCommand("Nome valido", "cidade valida", "SP", "11 3333-1111", "11 99999-9999", "email@email.com", "123456", "123456");
        private readonly CreateUserCommand invalidCommand = new CreateUserCommand("wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "wwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffwwwefffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff", "SSP", "11 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-111111 3333-1111", "11 99999-9999", "email@email.com", "123456553445345345345345345345354345354534534345", "123456");

        [Fact]
        public async void Dado_um_command_valido_o_handler_deve_retornar_positivo_e_sem_senha()
        {            
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);                

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.SaveChanges())
                .ReturnsAsync(() => 1);

            UserHandler handler= new UserHandler(mockUserRepository.Object, mockUow.Object);

            var tcs = new CancellationTokenSource(1000);
            GenericCommandResult result = await handler.Handle(this.validCommand, tcs.Token);
            

            Assert.True(result.Success);
        }

        [Fact]
        public async void Dado_um_comand_valido_verificar_se_o_password_esta_ocultado()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);                

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.SaveChanges())
                .ReturnsAsync(() => 1);

            UserHandler handler= new UserHandler(mockUserRepository.Object, mockUow.Object);

            var tcs = new CancellationTokenSource(1000);
            GenericCommandResult result = await handler.Handle(this.validCommand, tcs.Token);

            mockUserRepository.Verify(x => x.Add(It.IsAny<UserEntity>()), Times.Once());
            mockUow.Verify(x => x.SaveChanges(), Times.Once());
            Assert.Null(((UserEntity)result.Data).Password);
        }

        [Fact]
        public async void Dado_um_command_invalido_o_handler_deve_retornar_negativo()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);                

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.SaveChanges())
                .ReturnsAsync(() => 0);

            UserHandler handler= new UserHandler(mockUserRepository.Object, mockUow.Object);

            var tcs = new CancellationTokenSource(1000);
            GenericCommandResult result = await handler.Handle(this.invalidCommand, tcs.Token);
            

            Assert.False(result.Success);
        }

        [Fact]
        public async void Dado_um_email_em_uso_retornar_negativo()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByEmail("email@email.com"))
                .ReturnsAsync(() => new UserEntity("Nome Valido", "cidade valida", "SP", "11 3333-1212", "11 98212-1212", "email@email.com", "123456", null));                

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.SaveChanges())
                .ReturnsAsync(() => 0);

            UserHandler handler= new UserHandler(mockUserRepository.Object, mockUow.Object);

            var tcs = new CancellationTokenSource(1000);
            GenericCommandResult result = await handler.Handle(this.validCommand, tcs.Token);
            

            Assert.False(result.Success);
        }

        [Fact]
        public async void Dado_uma_confirmacao_de_senha_diferente_da_senha_retornar_regativo()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(x => x.GetByEmail(It.IsAny<string>()))
                .ReturnsAsync(() => null);                

            var mockUow = new Mock<IUnitOfWork>();
            mockUow.Setup(x => x.SaveChanges())
                .ReturnsAsync(() => 0);

            UserHandler handler= new UserHandler(mockUserRepository.Object, mockUow.Object);

            var tcs = new CancellationTokenSource(1000);
            GenericCommandResult result = await handler.Handle(this.invalidCommand, tcs.Token);
            
            Assert.False(result.Success);
        }
    }
}