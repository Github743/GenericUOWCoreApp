using System;

namespace CoreApp.Models.DataTransfer
{
    public class DtoBase
    {
        public int CreatedByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
        public DateTime CreatedDtUtc { get; set; }
        public DateTime? UpdatedeDtUtc { get; set; }
    }
}
