using System.Collections.Generic;
using System.Linq;
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
        public bool IsWhatsapp { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Confirmed { get; private set; }
        public string Photo { get; private set; }
        public bool IsAdmin { get; private set; }

        private readonly IList<ItemEntity> _items;
        public IReadOnlyCollection<ItemEntity> Items => _items?.ToArray();
        public void AddItem(ItemEntity item)
        {
            _items.Add(item);
        }

        public UserEntity()
        {
            
        }

        public UserEntity(string name, string city, string state, string telephone, string cellphone, bool isWhatsapp, string email, string password, string photo)
        {
            Name = name;
            City = city;
            State = state;
            Telephone = telephone;
            Cellphone = cellphone;
            IsWhatsapp = isWhatsapp;
            Email = email;
            Password = password;
            Confirmed = false;
            Photo = photo;
            IsAdmin = false;
            _items = new List<ItemEntity>();
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

        public void SetConfirmed()
        {
            this.Confirmed = true;
        }
    }
}