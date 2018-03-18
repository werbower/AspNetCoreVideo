using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Models;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVideo.Entities{
    public class Video    {
        public int Id { get; set; }
        [Required,MaxLength(80)]
        public string Title { get; set; }
        [Display(Name ="Film genre")]
        public Genres Genre { get; set; }
    }
}
