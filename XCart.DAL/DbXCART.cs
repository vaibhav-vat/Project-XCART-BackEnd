namespace XCart.DAL
{
    using Microsoft.EntityFrameworkCore;
    using XCart.DBEntities;

    public class DbXCART : DbContext
    {
        public DbXCART(DbContextOptions options) : base(options)
        { }
        public DbXCART() : base()
        { }

        public static object ConfigurationManager { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new MyCategoryMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=XIPL9389\SQLEXPRESS;Database=XCartDB;Trusted_Connection=True;");

        public virtual DbSet<ADDRESSES> ADDRESSES { get; set; }
        public virtual DbSet<PLACEDORDERADDRESS> PLACEDORDERADDRESS { get; set; }
        public virtual DbSet<ADMINS> ADMINS { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CITIES> CITIES { get; set; }
        public virtual DbSet<FEEDBACKS> FEEDBACKS { get; set; }
        public virtual DbSet<ORDERPLACED> ORDERPLACED { get; set; }
        public virtual DbSet<ORDERSHISTORY> ORDERSHISTORY { get; set; }
        public virtual DbSet<PREVISIT> PREVISIT { get; set; }
        public virtual DbSet<PRODUCTDESCRIPTION> PRODUCTDESCRIPTION { get; set; }
        public virtual DbSet<PRODUCTS> PRODUCTS { get; set; }
        public virtual DbSet<SEARCHHISTORY> SEARCHHISTORY { get; set; }
        public virtual DbSet<STATES> STATES { get; set; }
        public virtual DbSet<SUPPLIERS> SUPPLIERS { get; set; }
        // public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<WISHLISTS> WISHLISTS { get; set; }


    }
}
