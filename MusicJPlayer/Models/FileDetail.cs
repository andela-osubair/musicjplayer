using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicJPlayer.Models
{
    public class FileDetail
    {
        public Guid Id { get; set; }

        [FileExtensions(Extensions = ".mp3", ErrorMessage = "Incorrect File Format")]
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int MusicInfoId { get; set; }
        public virtual MusicInfo MusicInfo { get; set; }
    }
}