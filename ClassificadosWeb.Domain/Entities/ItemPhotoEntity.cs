namespace ClassificadosWeb.Domain.Entities
{
    public class ItemPhotoEntity : BaseEntity
    {
        public string Path { get; private set; }
        public int Ordem { get; private set; }

        public ItemPhotoEntity()
        {
            
        }

        public ItemPhotoEntity(string path, int ordem)
        {
            Path = path;
            Ordem = ordem;
        }

        public void SetOrdem(int ordem)
        {
            this.Ordem = ordem;
        }        
    }
}