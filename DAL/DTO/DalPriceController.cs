using DAL.DTO;

namespace DAL
{
    public class DalPriceController : IEntity
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public string Comment { get; set; }

        public int? ShawarmaID { get; set; }

        public int? SellingPointID { get; set; }
    }
}