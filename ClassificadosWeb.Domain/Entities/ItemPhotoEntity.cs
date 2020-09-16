namespace ClassificadosWeb.Domain.Entities
{
    public class ItemPhotoEntity : BaseEntity
    {
        public string Path { get; private set; }
        public int Ordem { get; private set; }
        public bool Cover { get; private set; }

        public ItemPhotoEntity()
        {
            
        }

        public ItemPhotoEntity(string path, int ordem, bool cover)
        {
            Path = path;
            Ordem = ordem;
            Cover = cover;
        }

        public void SetOrdem(int ordem)
        {
            this.Ordem = ordem;
        }        
    }
}