using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MusicJPlayer.Models
{
    public class MusicJPlayerContext : DbContext
    {
        public MusicJPlayerContext()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<MusicInfo> MusicInfos { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}