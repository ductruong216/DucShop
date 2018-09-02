﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string ID { get; set; }

        [Required]
        [MaxLength(50)]

        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}