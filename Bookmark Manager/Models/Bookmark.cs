using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bookmark_Manager.Models
{
    public class Bookmark
    {
        public int Id { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateModified { get; set; }
        
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }

        //public virtual ICollection<Tag> Tags { get; set; }
    }
}