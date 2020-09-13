 using System;

namespace ClassificadosWeb.Domain.Entities
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public bool Equals(BaseEntity other)
        {
            return Id == other.Id;
        }
    }

}