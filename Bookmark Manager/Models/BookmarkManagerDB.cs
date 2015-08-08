using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookmark_Manager.Models
{
    public class BookmarkManagerDB : DbContext
    {
        public BookmarkManagerDB() : base("name=DefaultConnection")
        {

        }

        // represent entities to query and persist
        public DbSet<Bookmark> Bookmarks { get; set; }

        public System.Data.Entity.DbSet<Bookmark_Manager.Models.Tag> Tags { get; set; }
    }
}