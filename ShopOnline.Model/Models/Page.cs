using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Model.Models
{
    [Table("Pages")]
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

       
        public string Name { get; set; }

        [Column(TypeName ="varchar")]
        [Required]
        [MaxLength(256)]
        public string Alias { get; set; }

        public string Content { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}