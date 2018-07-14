using System;

namespace ShopOnline.Model.Models
{
    public interface IAuditable
    {
        DateTime? CreateDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }

        string MetaKeyWork { get; set; }
        string MetaDescription { get; set; }

        bool status { get; set; }
    }
}