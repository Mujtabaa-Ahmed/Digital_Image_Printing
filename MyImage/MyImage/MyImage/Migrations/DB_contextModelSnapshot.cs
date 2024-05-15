﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyImage.DB_Context;

#nullable disable

namespace MyImage.Migrations
{
    [DbContext(typeof(DB_context))]
    partial class DB_contextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyImage.Models.class_accounts", b =>
                {
                    b.Property<int>("signin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("signin_id"), 1L, 1);

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roles_id")
                        .HasColumnType("int");

                    b.HasKey("signin_id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MyImage.Models.class_categeory", b =>
                {
                    b.Property<int>("cat_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cat_id"), 1L, 1);

                    b.Property<string>("cat_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cat_status")
                        .HasColumnType("int");

                    b.HasKey("cat_id");

                    b.ToTable("categeories");
                });

            modelBuilder.Entity("MyImage.Models.class_prices", b =>
                {
                    b.Property<int>("price_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("price_id"), 1L, 1);

                    b.Property<int>("cancleed_prices")
                        .HasColumnType("int");

                    b.Property<string>("material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("prices")
                        .HasColumnType("int");

                    b.Property<int>("service_id")
                        .HasColumnType("int");

                    b.Property<int>("size_id")
                        .HasColumnType("int");

                    b.HasKey("price_id");

                    b.ToTable("prices");
                });

            modelBuilder.Entity("MyImage.Models.class_roles", b =>
                {
                    b.Property<int>("roles_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roles_id"), 1L, 1);

                    b.Property<string>("roles_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roles_id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("MyImage.Models.class_services", b =>
                {
                    b.Property<int>("service_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("service_id"), 1L, 1);

                    b.Property<int>("cat_id")
                        .HasColumnType("int");

                    b.Property<int>("prices")
                        .HasColumnType("int");

                    b.Property<string>("service_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("service_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("service_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subCat_id")
                        .HasColumnType("int");

                    b.HasKey("service_id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("MyImage.Models.class_sizes", b =>
                {
                    b.Property<int>("size_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("size_id"), 1L, 1);

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("size_id");

                    b.ToTable("sizes");
                });

            modelBuilder.Entity("MyImage.Models.class_subCategeory", b =>
                {
                    b.Property<int>("subCat_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subCat_id"), 1L, 1);

                    b.Property<int>("cat_id")
                        .HasColumnType("int");

                    b.Property<string>("subCat_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subCat_status")
                        .HasColumnType("int");

                    b.HasKey("subCat_id");

                    b.ToTable("subCategeories");
                });

            modelBuilder.Entity("MyImage.Models.class_user_table", b =>
                {
                    b.Property<int>("costumer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("costumer_id"), 1L, 1);

                    b.Property<string>("Profile_photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("addres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dob")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("e_mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("f_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gander")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("l_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("p_number")
                        .HasColumnType("bigint");

                    b.HasKey("costumer_id");

                    b.ToTable("user_tables");
                });
#pragma warning restore 612, 618
        }
    }
}
