using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Data.Entities
{
    [Table("url_infos")]
    public class UrlInfo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("original_url")]
        [StringLength(1000)]
        public string OriginalUrl { get; set; }

        [Required]
        [Column("abreviation")]
        [StringLength(20)]
        public string Abreviation { get; set; }

        [Required]
        [Column("added")]
        public DateTime Added { get; set; }

    }
}
