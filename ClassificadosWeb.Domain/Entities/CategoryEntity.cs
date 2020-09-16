using ClassificadosWeb.Domain.Enums;

namespace ClassificadosWeb.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public CategoryEntity ParentCategory { get; private set; }

        public CategoryEntity()
        {
            
        }

        public CategoryEntity(string name, string image, CategoryEntity parentCategory)
        {
            Name = name;
            Image = image;
            ParentCategory = parentCategory;
        }
    }
}