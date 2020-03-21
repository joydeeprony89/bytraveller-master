namespace ByTraveller.EntityFramework
{
    using ByTraveller.Model.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {}

        public DbSet<HeaderMainMenu> HeaderMainMenus { get; set; }
        public DbSet<HeaderSubMenu> HeaderSubMenus { get; set; }
        public DbSet<SubMenuItem> SubMenuItems { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryState> CountryStates { get; set; }
        public DbSet<StateCity> StateCities{ get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<SocialWebSite> SocialWebSites { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
