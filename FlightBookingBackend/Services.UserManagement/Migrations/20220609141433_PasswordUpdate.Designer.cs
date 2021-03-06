// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.UserManagement.DbContexts;

namespace Services.UserManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220609141433_PasswordUpdate")]
    partial class PasswordUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Services.UserManagement.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("IsAdminUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
