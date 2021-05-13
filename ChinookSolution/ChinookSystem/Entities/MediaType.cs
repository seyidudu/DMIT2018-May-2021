using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace ChinookSystem.Entities
{
    internal partial class MediaType
    {
        public int MediaTypeId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }
    }
}
