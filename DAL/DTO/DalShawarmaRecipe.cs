using DAL.DTO;

namespace DAL
{
    public class DalShawarmaRecipe : IEntity
    {
        public int Id { get; set; }

        public int Weght { get; set; }

        public int? IngradientID { get; set; }

        public int? ShawarmaID { get; set; }
    }
}