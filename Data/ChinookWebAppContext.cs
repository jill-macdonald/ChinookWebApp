using Microsoft.EntityFrameworkCore;
using ChinookWebApp.Models;


namespace ChinookWebApp.Data
{
    public class ChinookWebAppContext : DbContext
    {
        public ChinookWebAppContext (
            DbContextOptions<ChinookWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ChinookWebApp.Models.Album> albums { get; set; }
        public DbSet<ChinookWebApp.Models.Artist> artists {get; set;}
        public DbSet<ChinookWebApp.Models.Track> tracks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("albums");
            modelBuilder.Entity<Artist>().ToTable("artists");
            modelBuilder.Entity<Track>().ToTable("tracks");
/* 
            modelBuilder.Entity<Album>()
                .HasKey(a => new { a.ArtistId});  */

/*             modelBuilder.Entity<Track>()
                .HasKey(t => new {t.AlbumId}); */
        
    }
}
}