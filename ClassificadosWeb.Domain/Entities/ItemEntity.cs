using System;
using System.Collections.Generic;
using System.Linq;
using ClassificadosWeb.Domain.Enums;

namespace ClassificadosWeb.Domain.Entities
{
    public class ItemEntity : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Visible { get; private set; }
        public DateTime? VisibleAt { get; private set; }     
        public CategoryEntity Category { get; private set; }   
        public UserEntity User { get; private set; }

        public EStatusItem Status { get; private set; }
        public DateTime? ChangedStatusAt { get; private set; }     
        public UserEntity ChangedStatusBy { get; private set; }

        private readonly IList<ItemPhotoEntity> _photos;
        public IReadOnlyCollection<ItemPhotoEntity> Photos => _photos.ToArray();
        public void AddPhoto(ItemPhotoEntity photo)
        {
            photo.SetOrdem(_photos.Count()+1);
            _photos.Add(photo);
        }

        public ItemEntity()
        {
            
        }

        public ItemEntity(string title, string description, decimal price, bool visible, DateTime? visibleAt, CategoryEntity category, UserEntity user)
        {
            Title = title;
            Description = description;
            Price = price;
            Visible = visible;
            VisibleAt = visibleAt;
            Category = category;
            User = user;
            _photos = new List<ItemPhotoEntity>();
        }
    }
}