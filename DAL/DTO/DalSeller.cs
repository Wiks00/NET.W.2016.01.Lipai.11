using DAL.DTO;

namespace DAL
{
    public class DalSeller : IEntity
    {
        public int Id { get; set; }

        public string SellerName { get; set; }

        public int? SellingPointID { get; set; }
    }
}