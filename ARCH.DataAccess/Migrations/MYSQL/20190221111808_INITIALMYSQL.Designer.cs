﻿// <auto-generated />
using System;
using ARCH.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ARCH.DataAccess.Migrations.MYSQL
{
    [DbContext(typeof(MYSQLContext))]
    [Migration("20190221111808_INITIALMYSQL")]
    partial class INITIALMYSQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ARCH.Entities.Concrete.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChangedBy");

                    b.Property<DateTime?>("ChangedOn");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("VARCHAR(13)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ARCH.Entities.Concrete.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<Guid?>("ChangedBy");

                    b.Property<DateTime?>("ChangedOn");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("DepartmentId");

                    b.Property<string>("FirstName")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<int?>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("TCKN")
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ARCH.Entities.Concrete.Person", b =>
                {
                    b.HasOne("ARCH.Entities.Concrete.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
