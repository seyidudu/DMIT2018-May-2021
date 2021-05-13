using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace ChinookSystem.Entities
{
    internal partial class Album
    {

        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album Title is required")]
        [StringLength(160, ErrorMessage = "Album Title is limited to 160 Characters.")]
        public string Title { get; set; }

        public int ArtistId { get; set; }

        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Album Release label is limited to 50 Characters.")]
        public string ReleaseLabel { get; set; }

        //Navigational properties
        //Navigational properties create a virtual
        public virtual Artist Artist { get; set; }// parent

    }
}
