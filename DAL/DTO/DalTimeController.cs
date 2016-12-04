using System;
using DAL.DTO;

namespace DAL
{
    public class DalTimeController : IEntity
    {
        public int Id { get; set; }

        public DateTime WorkStart { get; set; }

        public DateTime WorkEnd { get; set; }

        public int? SellerID { get; set; }
    }
}