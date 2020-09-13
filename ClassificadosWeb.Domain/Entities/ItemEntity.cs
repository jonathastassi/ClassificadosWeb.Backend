using System;
using ClassificadosWeb.Domain.Enums;

namespace ClassificadosWeb.Domain.Entities
{
    public class ItemEntity : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public ETypeItem Type { get; private set; }
        public bool Visible { get; private set; }
        public DateTime? VisibleAt { get; private set; }        
    }
}