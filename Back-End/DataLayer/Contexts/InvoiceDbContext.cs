using Microsoft.EntityFrameworkCore;

using Models.Entities;

namespace DataLayer.Contexts
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<RequestRoleForm> RequestRoleForms { get; set; }
        public DbSet<GroupRoleAuth> GroupRoleAuth { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BlackListedTokens> BlackListedTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Name)
                .IsUnique();


            modelBuilder.Entity<Seller>()
                .HasOne(s => s.User)
                .WithOne(u => u.Seller)
                .HasForeignKey<Seller>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Buyer>()
                .HasOne(b => b.User)
                .WithOne(u => u.Buyer)
                .HasForeignKey<Buyer>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Admin)
                .WithOne(a => a.User)
                .HasForeignKey<Admin>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.Group)
                .WithMany(g => g.GroupUsers)
                .HasForeignKey(gu => gu.GroupId);

            modelBuilder.Entity<GroupUser>()
                .HasOne(gu => gu.User)
                .WithMany(u => u.GroupUsers)
                .HasForeignKey(gu => gu.UserId);

            modelBuilder.Entity<GroupRoleAuth>()
                .HasOne(gra => gra.Group)
                .WithMany(g => g.GroupRoleAuths)
                .HasForeignKey(gra => gra.GroupId);


            modelBuilder.Entity<GroupRoleAuth>()
                .HasOne(gra => gra.RequestRoleForm)
                .WithMany(g => g.GroupRoleAuths)
                .HasForeignKey(gra => gra.RequestRoleFormId);

            modelBuilder.Entity<RequestRoleForm>()
                .HasOne(rrf => rrf.Request)
                .WithMany(r => r.RequestRoleForms)
                .HasForeignKey(rrf => rrf.RequestId);

            modelBuilder.Entity<RequestRoleForm>()
                .HasOne(rrf => rrf.Role)
                .WithMany(r => r.RequestRoleForms)
                .HasForeignKey(rrf => rrf.RoleId);

            modelBuilder.Entity<RequestRoleForm>()
                .HasOne(rrf => rrf.Form)
                .WithMany(f => f.RequestRoleForms)
                .HasForeignKey(rrf => rrf.FormId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Seller)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.SellerId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Buyer)
                .WithMany(b => b.Invoices)
                .HasForeignKey(i => i.BuyerId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Seller)
               .WithMany(s => s.Products)
               .HasForeignKey(p => p.SellerId);

            modelBuilder.Entity<Seller>()
               .HasOne(s => s.Government)
               .WithMany(g => g.Sellers)
               .HasForeignKey(s => s.GovernmentId);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.NationalId).HasColumnName("NationalId");
            });
            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Sellers");
                entity.Property(e => e.SellerId).HasColumnName("seller_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.GovernmentId).HasColumnName("GovernmentId");
                entity.Property(e => e.HashedPassword).HasColumnName("Password");
            });
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyers");

                entity.HasKey(e => e.BuyerId);

                entity.Property(e => e.BuyerId)
                      .HasColumnName("buyer_id");
                entity.Property(e => e.HashedPassword)
                      .HasColumnName("Password");

                entity.Property(e => e.UserId)
                      .HasColumnName("user_id")
                      .IsRequired();
            });
            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Groups");

                entity.HasKey(e => e.GroupId);


                entity.Property(e => e.GroupId)
                      .HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                      .HasColumnName("group_name")
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .HasColumnName("description")
                      .HasColumnType("text");
            });
            modelBuilder.Entity<GroupUser>(entity =>
            {
                entity.ToTable("GroupUser");
                entity.HasKey(e => e.GroupUserId);

                entity.Property(e => e.GroupUserId)
                      .HasColumnName("group_user_id");

                entity.Property(e => e.GroupId)
                      .HasColumnName("group_id");

                entity.Property(e => e.UserId)
                      .HasColumnName("user_id");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Requests");
                entity.HasKey(e => e.RequestId);
                entity.Property(e => e.RequestId)
                      .HasColumnName("request_id");
                entity.Property(e => e.RequestName)
                      .HasColumnName("request_name")
                      .HasMaxLength(100);
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.Property(R => R.RoleId).HasColumnName("role_id");
                entity.Property(R => R.Category).HasColumnName("category");
            });
            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("Forms");

                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormId)
                      .HasColumnName("form_id");

                entity.Property(e => e.FormName)
                      .HasColumnName("form_name")
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .HasColumnName("description")
                      .HasMaxLength(255);
            });
            modelBuilder.Entity<RequestRoleForm>(entity =>
            {
                entity.ToTable("RequestRoleForm");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("Id");
                entity.Property(e => e.RequestId)
                      .HasColumnName("RequestId");
                entity.Property(e => e.RoleId)
                      .HasColumnName("RoleId");
                entity.Property(e => e.FormId)
                      .HasColumnName("FormId");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .HasColumnName("Id");
                entity.Property(e => e.Name)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(e => e.Amount)
                      .HasColumnName("Amount")
                      .IsRequired();
                entity.Property(e => e.Price)
                      .HasColumnName("Price")
                      .IsRequired()
                      .HasColumnType("decimal(10,2)");
                entity.Property(e => e.SellerId)
                      .HasColumnName("SellerId")
                      .IsRequired();
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("Id");

                entity.Property(e => e.SellerId)
                      .HasColumnName("SellerId")
                      .IsRequired();

                entity.Property(e => e.BuyerId)
                      .HasColumnName("BuyerId")
                      .IsRequired();

                entity.Property(e => e.ProductId)
                      .HasColumnName("ProductId")
                      .IsRequired();
            });

            modelBuilder.Entity<Government>(entity =>
            {
                entity.ToTable("Governments");


                entity.HasKey(e => e.Id);


                entity.Property(e => e.Id)
                       .HasColumnName("Id");

                entity.Property(e => e.Name)
                      .HasColumnName("Name")
                      .IsRequired()
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admins");
                entity.Property(e => e.UserId).HasColumnName("user_id");

            });
            //modelBuilder.Entity<GroupRoleAuth>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.Property(e => e.Action)
            //          .IsRequired()
            //          .HasMaxLength(50);

            //    entity.HasOne(e => e.Group)
            //          .WithMany()
            //          .HasForeignKey(e => e.GroupId);


            //});

            //modelBuilder.Entity<RequestRoleForm>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.HasOne(e => e.Form)
            //          .WithMany()
            //          .HasForeignKey(e => e.FormId);

            //    entity.HasOne(e => e.Role)
            //          .WithMany()
            //          .HasForeignKey(e => e.RoleId);

            //    entity.HasOne(e => e.Request)
            //          .WithMany()
            //          .HasForeignKey(e => e.RequestId);
            //});





        }

    }

}