﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovidaBrc.Data;

#nullable disable

namespace MovidaBrc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovidaBrcSharedLibrary.Models.Fiesta", b =>
                {
                    b.Property<int>("IdFiesta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFiesta"));

                    b.Property<string>("DescripcionFiesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRealizacionFiesta")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GratisBoolFiesta")
                        .HasColumnType("bit");

                    b.Property<string>("HoraFiesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenFiesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreFiesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoFiesta")
                        .HasColumnType("int");

                    b.Property<string>("UbicacionFiesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFiesta");

                    b.ToTable("Fiestas");
                });
#pragma warning restore 612, 618
        }
    }
}
