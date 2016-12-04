using System;
using DAL.DTO;

namespace DAL
{
    public class DalOrderHeader : IEntity
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int? SellerID { get; set; }
    }
}