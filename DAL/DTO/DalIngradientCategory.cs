using DAL.DTO;

namespace DAL
{
    public class DalIngradientCategory : IEntity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}