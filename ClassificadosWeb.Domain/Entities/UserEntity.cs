using ClassificadosWeb.Domain.Extensions;

namespace ClassificadosWeb.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Telephone { get; private set; }        
        public string Cellphone { get; private set; }        
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Confirmed { get; private set; }
        public string Photo { get; private set; }

        public UserEntity()
        {
            
        }

        public UserEntity(string name, string city, string state, string telephone, string cellphone, string email, string password, string photo)
        {
            Name = name;
            City = city;
            State = state;
            Telephone = telephone;
            Cellphone = cellphone;
            Email = email;
            Password = password;
            Confirmed = false;
            Photo = photo;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public void HashPassword()
        {
            this.SetPassword(this.Password.HashString());
        }

        public bool ComparePasswordHash(string pass)
        {
            return this.Password.CompareHash(pass);
        }
    }
}