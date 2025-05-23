﻿// <auto-generated />
using System;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(InvoiceDbContext))]
    [Migration("20250419190706_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Buyer", b =>
                {
                    b.Property<int>("BuyerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("buyer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuyerId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyerId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Buyers", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Form", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("form_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormId"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("FormName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("form_name");

                    b.HasKey("FormId");

                    b.ToTable("Forms", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Government", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Governments", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("GroupName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("group_name");

                    b.HasKey("GroupId");

                    b.ToTable("Groups", (string)null);
                });

            modelBuilder.Entity("Models.Entities.GroupRoleAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId1")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("RequestRoleFormId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestRoleFormId1")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupId1");

                    b.HasIndex("RequestId");

                    b.HasIndex("RequestRoleFormId");

                    b.HasIndex("RequestRoleFormId1");

                    b.HasIndex("RoleId");

                    b.ToTable("GroupRoleAuth");
                });

            modelBuilder.Entity("Models.Entities.GroupUser", b =>
                {
                    b.Property<int>("GroupUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupUserId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("group_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("GroupUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUser", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("int")
                        .HasColumnName("BuyerId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductId");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int")
                        .HasColumnName("SellerId");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellerId");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("Amount");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Price");

                    b.Property<int>("SellerId")
                        .HasColumnType("int")
                        .HasColumnName("SellerId");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("request_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<string>("RequestName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("request_name");

                    b.HasKey("RequestId");

                    b.ToTable("Requests", (string)null);
                });

            modelBuilder.Entity("Models.Entities.RequestRoleForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int?>("FormId1")
                        .HasColumnType("int");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<int?>("RequestId1")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormId");

                    b.HasIndex("FormId1");

                    b.HasIndex("RequestId");

                    b.HasIndex("RequestId1");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.ToTable("RequestRoleForms");
                });

            modelBuilder.Entity("Models.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("category");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SellerId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GovernmentId")
                        .HasColumnType("int")
                        .HasColumnName("GovernmentId");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("StoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOFProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SellerId");

                    b.HasIndex("GovernmentId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Sellers", (string)null);
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NationalId");

                    b.HasKey("UserId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[name] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Models.Entities.Admin", b =>
                {
                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("Models.Entities.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.Buyer", b =>
                {
                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Buyer")
                        .HasForeignKey("Models.Entities.Buyer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.GroupRoleAuth", b =>
                {
                    b.HasOne("Models.Entities.Form", null)
                        .WithMany("GroupRoleAuths")
                        .HasForeignKey("FormId");

                    b.HasOne("Models.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Group", null)
                        .WithMany("GroupRoleAuths")
                        .HasForeignKey("GroupId1");

                    b.HasOne("Models.Entities.Request", null)
                        .WithMany("GroupRoleAuths")
                        .HasForeignKey("RequestId");

                    b.HasOne("Models.Entities.RequestRoleForm", "RequestRoleForm")
                        .WithMany()
                        .HasForeignKey("RequestRoleFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.RequestRoleForm", null)
                        .WithMany("GroupRoleAuths")
                        .HasForeignKey("RequestRoleFormId1");

                    b.HasOne("Models.Entities.Role", null)
                        .WithMany("GroupRoleAuths")
                        .HasForeignKey("RoleId");

                    b.Navigation("Group");

                    b.Navigation("RequestRoleForm");
                });

            modelBuilder.Entity("Models.Entities.GroupUser", b =>
                {
                    b.HasOne("Models.Entities.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.Invoice", b =>
                {
                    b.HasOne("Models.Entities.Buyer", "Buyer")
                        .WithMany("Invoices")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Product", "Product")
                        .WithMany("Invoices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Seller", "Seller")
                        .WithMany("Invoices")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Product");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Models.Entities.Product", b =>
                {
                    b.HasOne("Models.Entities.Seller", "Seller")
                        .WithMany("Products")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Models.Entities.RequestRoleForm", b =>
                {
                    b.HasOne("Models.Entities.Form", "Form")
                        .WithMany()
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Form", null)
                        .WithMany("RequestRoleForms")
                        .HasForeignKey("FormId1");

                    b.HasOne("Models.Entities.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Request", null)
                        .WithMany("RequestRoleForms")
                        .HasForeignKey("RequestId1");

                    b.HasOne("Models.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.Role", null)
                        .WithMany("RequestRoleForms")
                        .HasForeignKey("RoleId1");

                    b.Navigation("Form");

                    b.Navigation("Request");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Models.Entities.Seller", b =>
                {
                    b.HasOne("Models.Entities.Government", "Government")
                        .WithMany("Sellers")
                        .HasForeignKey("GovernmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Entities.User", "User")
                        .WithOne("Seller")
                        .HasForeignKey("Models.Entities.Seller", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Government");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Entities.Buyer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Models.Entities.Form", b =>
                {
                    b.Navigation("GroupRoleAuths");

                    b.Navigation("RequestRoleForms");
                });

            modelBuilder.Entity("Models.Entities.Government", b =>
                {
                    b.Navigation("Sellers");
                });

            modelBuilder.Entity("Models.Entities.Group", b =>
                {
                    b.Navigation("GroupRoleAuths");

                    b.Navigation("GroupUsers");
                });

            modelBuilder.Entity("Models.Entities.Product", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("Models.Entities.Request", b =>
                {
                    b.Navigation("GroupRoleAuths");

                    b.Navigation("RequestRoleForms");
                });

            modelBuilder.Entity("Models.Entities.RequestRoleForm", b =>
                {
                    b.Navigation("GroupRoleAuths");
                });

            modelBuilder.Entity("Models.Entities.Role", b =>
                {
                    b.Navigation("GroupRoleAuths");

                    b.Navigation("RequestRoleForms");
                });

            modelBuilder.Entity("Models.Entities.Seller", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.Entities.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Buyer");

                    b.Navigation("GroupUsers");

                    b.Navigation("Seller");
                });
#pragma warning restore 612, 618
        }
    }
}
