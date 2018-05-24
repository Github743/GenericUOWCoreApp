using System;
using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models.Models.Abstract
{
    public abstract class BaseEntityModel
    {
        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public int? UpdateBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

    }
}
