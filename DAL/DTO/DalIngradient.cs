using DAL.DTO;

namespace DAL
{
    public class DalIngradient : IEntity
    {
        public int Id { get; set; }

        public string IngradientName { get; set; }

        public int TotalWeght { get; set; }

        public int? CategoryID { get; set; }
    }
}