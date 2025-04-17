﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Web.DATA;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250417085008_AddEnrollmentDetailFile")]
    partial class AddEnrollmentDetailFile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.EnrollmentDetailFile", b =>
                {
                    b.Property<long>("ENRDFSTUDID")
                        .HasColumnType("bigint");

                    b.Property<string>("ENRDFSTUDEDPCODE")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("ENRDFSTUDSTATUS")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("ENRDFSTUDSUBJCDE")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ENRDFSTUDID", "ENRDFSTUDEDPCODE");

                    b.ToTable("EnrollmentDetailFile");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.EnrollmentHeaderFile", b =>
                {
                    b.Property<long>("ENRHFSTUDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ENRHFSTUDID"));

                    b.Property<DateTime>("ENRHFSTUDDATEENROLL")
                        .HasColumnType("datetime2");

                    b.Property<string>("ENRHFSTUDENCODER")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ENRHFSTUDSCHLYR")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ENRHFSTUDSTATUS")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<double>("ENRHFSTUDTOTALUNITS")
                        .HasColumnType("float");

                    b.HasKey("ENRHFSTUDID");

                    b.ToTable("EnrollmentHeaderFiles");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.StudentFile", b =>
                {
                    b.Property<long>("STFSTUDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("STFSTUDID"));

                    b.Property<string>("STFSTUDCOURSE")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("STFSTUDFNAME")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("STFSTUDLNAME")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("STFSTUDMNAME")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("STFSTUDREMARKS")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("STFSTUDSTATUS")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("STFSTUDYEAR")
                        .HasColumnType("int");

                    b.HasKey("STFSTUDID");

                    b.ToTable("StudentFiles");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.StudentGradeFile", b =>
                {
                    b.Property<long>("SGFSTUDID")
                        .HasColumnType("bigint");

                    b.Property<string>("SGFSTUDEDPCODE")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("SGFSTUDREMARKS")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SGFSTUDSUBJCODE")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<double>("SGFSTUDSUBJGRADE")
                        .HasColumnType("float");

                    b.HasKey("SGFSTUDID", "SGFSTUDEDPCODE");

                    b.ToTable("studentGradeFiles");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.SubjectFile", b =>
                {
                    b.Property<string>("SFSUBJCODE")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SFSUBJCOURSECODE")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("SFSUBJCATEGORY")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("SFSUBJCURRCODE")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SFSUBJDESC")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("SFSUBJREGOFRNG")
                        .HasColumnType("int");

                    b.Property<string>("SFSUBJSTATUS")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<float>("SFSUBJUNITS")
                        .HasColumnType("real");

                    b.HasKey("SFSUBJCODE", "SFSUBJCOURSECODE");

                    b.ToTable("SubjectFiles");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.SubjectPreqFile", b =>
                {
                    b.Property<string>("SUBJCODE")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SUBJPRECODE")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SUBJCATEGORY")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("SUBJCODE", "SUBJPRECODE");

                    b.ToTable("SubjectPreqFiles");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.SubjectSchedFile", b =>
                {
                    b.Property<string>("SSFEDPCODE")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("SSFCLASSSIZE")
                        .HasColumnType("int");

                    b.Property<string>("SSFDAYS")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("SSFENDTIME")
                        .HasColumnType("datetime2");

                    b.Property<int>("SSFMAXSIZE")
                        .HasColumnType("int");

                    b.Property<string>("SSFROOM")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("SSFSCHOOLYEAR")
                        .HasColumnType("int");

                    b.Property<string>("SSFSECTION")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("SSFSTARTTIME")
                        .HasColumnType("datetime2");

                    b.Property<string>("SSFSTATUS")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("SSFSUBJCODE")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SSFXM")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("SSFEDPCODE");

                    b.ToTable("SubjectSchedFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
