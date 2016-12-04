using DAL.DTO;

namespace DAL
{
    public class DalSellingPoint : IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string ShawarmaTitile { get; set; }

        public int? SellingPointCategoryID { get; set; }
    }
}