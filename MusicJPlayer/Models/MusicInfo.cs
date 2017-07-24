using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicJPlayer.Models
{
    public class MusicInfo
    {
        public int MusicInfoId { get; set; }

        [Required(ErrorMessage = "Please Enter Music Title")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Artist Name")]
        [Display(Name = "Artist")]
        [MaxLength(100)]
        public string Artist { get; set; }

        [Display(Name = "Cover Art")]
        [FileExtensions(Extensions = ".jpg, .png, .gif, .jpeg", ErrorMessage = "Incorrect File Format")]
        public string CoverArt { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Description")]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<FileDetail> FileDetails { get; set; }
    }
}