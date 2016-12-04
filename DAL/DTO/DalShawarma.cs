using DAL.DTO;

namespace DAL
{
    public class DalShawarma : IEntity
    {
        public int Id { get; set; }

        public string ShawarmaName { get; set; }

        public int CookingTime { get; set; }
    }
}