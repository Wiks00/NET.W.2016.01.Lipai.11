using DAL.DTO;

namespace DAL
{
    public class DalOrderDetails : IEntity
    {
        public int? OrderHeaderID { get; set; }

        public int Quantity { get; set; }

        public int? ShawarmaID { get; set; }

        public int Id { get; set; }
    }
}