using System;
using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Model.Models
{
    public abstract class AuditTable : IAuditable
    {
        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [MaxLength(256)]
        public string UpdateBy { get; set; }

        public string MetaKeyWork { get; set; }
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}