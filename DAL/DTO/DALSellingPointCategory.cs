using DAL.DTO;

namespace DAL
{
    public class DalSellingPointCategory : IEntity
    {
        public int Id { get; set; }

        public string SellingPointCategoryName { get; set; }
    }
}