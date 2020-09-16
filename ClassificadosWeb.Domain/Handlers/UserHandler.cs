using System.Threading;
using System.Threading.Tasks;
using ClassificadosWeb.Domain.Commands.Base;
using ClassificadosWeb.Domain.Commands.User;
using ClassificadosWeb.Domain.Entities;
using ClassificadosWeb.Domain.Repositories;
using ClassificadosWeb.Domain.Uow;
using MediatR;

namespace ClassificadosWeb.Domain.Handlers
{
    public class UserHandler
        : IRequestHandler<CreateUserCommand, GenericCommandResult>,
          IRequestHandler<LoginUserCommand, GenericCommandResult>,
          IRequestHandler<MarkUserConfirmedCommand, GenericCommandResult>,
          IRequestHandler<UpdateUserCommand, GenericCommandResult>          
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork uow;

        public UserHandler(
            IUserRepository userRepository,
            IUnitOfWork uow
        )
        {
            this.userRepository = userRepository;
            this.uow = uow;
        }

        public async Task<GenericCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new GenericCommandResult(false, "Não foi possível salvar o usuário!", request.Notifications);

            if (request.Password != request.ConfirmPassword)
            {
                request.AddNotification("Senha", "A senha e a confirmação de senha estão incorretas!");
                return new GenericCommandResult(false, "Não foi possível salvar o usuário!", request.Notifications);
            }

            if (await this.userRepository.GetByEmail(request.Email) != null)
            {
                request.AddNotification("E-mail", "E-mail já utilizado!");
                return new GenericCommandResult(false, "Não foi possível salvar o usuário!", request.Notifications);
            }


            UserEntity user = new UserEntity(request.Name, request.City, request.State, request.Telephone, request.Cellphone, request.IsWhatsapp, request.Email, request.Password, null);
            user.HashPassword();

            this.userRepository.Add(user);

            if (await this.uow.SaveChanges() > 0)
            {
                user.SetPassword(null);
                return new GenericCommandResult(true, "Usuário salvo com sucesso!", user);
            }

            request.AddNotification("Usuário", "Erro ao concluir o registro do usuário!");
            return new GenericCommandResult(false, "Não foi possível salvar o usuário!", request.Notifications);

            // enviar e-mail de confirmação
        }

        public async Task<GenericCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            if (request.Invalid)
                return new GenericCommandResult(false, "Não foi possível efetuar o login!", request.Notifications);

            UserEntity user = await this.userRepository.GetByEmail(request.Email);
            if (user == null || !user.ComparePasswordHash(request.Password))
                return new GenericCommandResult(false, "Login incorreto!", request.Notifications);

            if (user.Confirmed == false)
                return new GenericCommandResult(false, "Conta não confirmada! Clique no e-mail recebido para ativar a conta.", request.Notifications);

            user.SetPassword(null);
            return new GenericCommandResult(true, "Login realizado com sucesso!", user);
        }

        public Task<GenericCommandResult> Handle(MarkUserConfirmedCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<GenericCommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}