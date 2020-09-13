using Flunt.Notifications;
using Flunt.Validations;

namespace ClassificadosWeb.Domain.Commands.Base
{
    public abstract class BaseCommand : Notifiable, IValidatable
    {
        public abstract void Validate();
    }
}