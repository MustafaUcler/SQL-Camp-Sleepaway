﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SP2;

#nullable disable

namespace SP2.Migrations
{
    [DbContext(typeof(CampDbContext))]
    partial class CampDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SP2.Models.Cabin", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinId"));

                    b.Property<string>("CabinColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CabinId");

                    b.ToTable("Cabins");

                    b.HasData(
                        new
                        {
                            CabinId = 1,
                            CabinColor = "Blue",
                            CabinName = "Cabin1"
                        },
                        new
                        {
                            CabinId = 2,
                            CabinColor = "Green",
                            CabinName = "Cabin2"
                        },
                        new
                        {
                            CabinId = 3,
                            CabinColor = "Red",
                            CabinName = "Cabin3"
                        },
                        new
                        {
                            CabinId = 4,
                            CabinColor = "Yellow",
                            CabinName = "Cabin4"
                        },
                        new
                        {
                            CabinId = 5,
                            CabinColor = "White",
                            CabinName = "Cabin5"
                        },
                        new
                        {
                            CabinId = 6,
                            CabinColor = "Black",
                            CabinName = "Cabin6"
                        },
                        new
                        {
                            CabinId = 7,
                            CabinColor = "Brown",
                            CabinName = "Cabin7"
                        },
                        new
                        {
                            CabinId = 8,
                            CabinColor = "Orange",
                            CabinName = "Cabin8"
                        });
                });

            modelBuilder.Entity("SP2.Models.Camper", b =>
                {
                    b.Property<int>("CamperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CamperId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CabinId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MoveInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MoveOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CamperId");

                    b.HasIndex("CabinId");

                    b.ToTable("Campers");

                    b.HasData(
                        new
                        {
                            CamperId = 1,
                            Age = 18,
                            CabinId = 1,
                            FirstName = "Camper1",
                            Gender = "Female",
                            LastName = "Last1",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "4444444444"
                        },
                        new
                        {
                            CamperId = 2,
                            Age = 18,
                            CabinId = 1,
                            FirstName = "Camper2",
                            Gender = "Male",
                            LastName = "Last2",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "5555555555"
                        },
                        new
                        {
                            CamperId = 3,
                            Age = 18,
                            CabinId = 1,
                            FirstName = "Camper3",
                            Gender = "Female",
                            LastName = "Last3",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "6666666666"
                        },
                        new
                        {
                            CamperId = 4,
                            Age = 18,
                            CabinId = 1,
                            FirstName = "Camper4",
                            Gender = "Male",
                            LastName = "Last4",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "7777777777"
                        },
                        new
                        {
                            CamperId = 5,
                            Age = 18,
                            CabinId = 2,
                            FirstName = "Camper5",
                            Gender = "Female",
                            LastName = "Last5",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "8888888888"
                        },
                        new
                        {
                            CamperId = 6,
                            Age = 18,
                            CabinId = 2,
                            FirstName = "Camper6",
                            Gender = "Male",
                            LastName = "Last6",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "9999999999"
                        },
                        new
                        {
                            CamperId = 7,
                            Age = 18,
                            CabinId = 2,
                            FirstName = "Camper7",
                            Gender = "Female",
                            LastName = "Last7",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1010101010"
                        },
                        new
                        {
                            CamperId = 8,
                            Age = 18,
                            CabinId = 2,
                            FirstName = "Camper8",
                            Gender = "Male",
                            LastName = "Last8",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1111111111"
                        },
                        new
                        {
                            CamperId = 9,
                            Age = 18,
                            CabinId = 3,
                            FirstName = "Camper9",
                            Gender = "Female",
                            LastName = "Last9",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1212121212"
                        },
                        new
                        {
                            CamperId = 10,
                            Age = 18,
                            CabinId = 3,
                            FirstName = "Camper10",
                            Gender = "Male",
                            LastName = "Last10",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1313131313"
                        },
                        new
                        {
                            CamperId = 11,
                            Age = 18,
                            CabinId = 3,
                            FirstName = "Camper11",
                            Gender = "Female",
                            LastName = "Last11",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1414141414"
                        },
                        new
                        {
                            CamperId = 12,
                            Age = 18,
                            CabinId = 3,
                            FirstName = "Camper12",
                            Gender = "Male",
                            LastName = "Last12",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1515151515"
                        },
                        new
                        {
                            CamperId = 13,
                            Age = 18,
                            CabinId = 4,
                            FirstName = "Camper13",
                            Gender = "Female",
                            LastName = "Last13",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1616161616"
                        },
                        new
                        {
                            CamperId = 14,
                            Age = 18,
                            CabinId = 4,
                            FirstName = "Camper14",
                            Gender = "Male",
                            LastName = "Last14",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1717171717"
                        },
                        new
                        {
                            CamperId = 15,
                            Age = 18,
                            CabinId = 4,
                            FirstName = "Camper15",
                            Gender = "Female",
                            LastName = "Last15",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1818181818"
                        },
                        new
                        {
                            CamperId = 16,
                            Age = 0,
                            CabinId = 4,
                            FirstName = "Camper16",
                            Gender = "Male",
                            LastName = "Last16",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "1919191919"
                        },
                        new
                        {
                            CamperId = 17,
                            Age = 0,
                            CabinId = 5,
                            FirstName = "Camper17",
                            Gender = "Male",
                            LastName = "Last17",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "2020202020"
                        },
                        new
                        {
                            CamperId = 18,
                            Age = 0,
                            CabinId = 5,
                            FirstName = "Camper18",
                            Gender = "Female",
                            LastName = "Last18",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "2121212121"
                        });
                });

            modelBuilder.Entity("SP2.Models.Counselor", b =>
                {
                    b.Property<int>("CounselorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CounselorId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CabinId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResponsibilityEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ResponsibilityStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("YearsExperience")
                        .HasColumnType("int");

                    b.HasKey("CounselorId");

                    b.HasIndex("CabinId")
                        .IsUnique()
                        .HasFilter("[CabinId] IS NOT NULL");

                    b.ToTable("Counselors");

                    b.HasData(
                        new
                        {
                            CounselorId = 1,
                            Age = 18,
                            CabinId = 1,
                            FirstName = "Counselor1",
                            LastName = "Last1",
                            ResponsibilityEndDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            ResponsibilityStartDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            YearsExperience = 2
                        },
                        new
                        {
                            CounselorId = 2,
                            Age = 18,
                            CabinId = 2,
                            FirstName = "Counselor2",
                            LastName = "Last2",
                            ResponsibilityEndDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            ResponsibilityStartDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            YearsExperience = 3
                        },
                        new
                        {
                            CounselorId = 3,
                            Age = 18,
                            CabinId = 3,
                            FirstName = "Counselor3",
                            LastName = "Last3",
                            ResponsibilityEndDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            ResponsibilityStartDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            YearsExperience = 1
                        },
                        new
                        {
                            CounselorId = 4,
                            Age = 18,
                            CabinId = 4,
                            FirstName = "Counselor4",
                            LastName = "Last4",
                            ResponsibilityEndDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            ResponsibilityStartDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            YearsExperience = 2
                        },
                        new
                        {
                            CounselorId = 5,
                            Age = 18,
                            CabinId = 5,
                            FirstName = "Counselor5",
                            LastName = "Last5",
                            ResponsibilityEndDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            ResponsibilityStartDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            YearsExperience = 3
                        },
                        new
                        {
                            CounselorId = 6,
                            Age = 18,
                            CabinId = 6,
                            FirstName = "Counselor6",
                            LastName = "Last6",
                            ResponsibilityEndDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            ResponsibilityStartDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            YearsExperience = 1
                        });
                });

            modelBuilder.Entity("SP2.Models.NextOfKin", b =>
                {
                    b.Property<int>("NextOfKinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NextOfKinId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CamperId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MoveInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("MoveOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationToCamper")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NextOfKinId");

                    b.HasIndex("CamperId");

                    b.ToTable("NextOfKins");

                    b.HasData(
                        new
                        {
                            NextOfKinId = 1,
                            Age = 40,
                            CamperId = 1,
                            FirstName = "Parent1",
                            Gender = "Female",
                            LastName = "Last1",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "4567890123",
                            RelationToCamper = "Parent"
                        },
                        new
                        {
                            NextOfKinId = 2,
                            Age = 40,
                            CamperId = 2,
                            FirstName = "Parent2",
                            Gender = "Male",
                            LastName = "Last2",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "5678901234",
                            RelationToCamper = "Parent"
                        },
                        new
                        {
                            NextOfKinId = 3,
                            Age = 40,
                            CamperId = 3,
                            FirstName = "Parent3",
                            Gender = "Female",
                            LastName = "Last3",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "6789012345",
                            RelationToCamper = "Parent"
                        },
                        new
                        {
                            NextOfKinId = 4,
                            Age = 40,
                            CamperId = 4,
                            FirstName = "Parent4",
                            Gender = "Male",
                            LastName = "Last4",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "7890123456",
                            RelationToCamper = "Parent"
                        },
                        new
                        {
                            NextOfKinId = 5,
                            Age = 40,
                            CamperId = 5,
                            FirstName = "Parent5",
                            Gender = "Male",
                            LastName = "Last5",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "8901234567",
                            RelationToCamper = "Parent"
                        },
                        new
                        {
                            NextOfKinId = 6,
                            Age = 40,
                            CamperId = 6,
                            FirstName = "Parent6",
                            Gender = "Female",
                            LastName = "Last6",
                            MoveInDate = new DateTime(2024, 1, 5, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            MoveOutDate = new DateTime(2024, 1, 12, 14, 22, 58, 132, DateTimeKind.Local).AddTicks(6974),
                            PhoneNumber = "9012345678",
                            RelationToCamper = "Parent"
                        });
                });

            modelBuilder.Entity("SP2.Models.Camper", b =>
                {
                    b.HasOne("SP2.Models.Cabin", "Cabin")
                        .WithMany("Campers")
                        .HasForeignKey("CabinId");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("SP2.Models.Counselor", b =>
                {
                    b.HasOne("SP2.Models.Cabin", "Cabin")
                        .WithOne("Counselor")
                        .HasForeignKey("SP2.Models.Counselor", "CabinId");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("SP2.Models.NextOfKin", b =>
                {
                    b.HasOne("SP2.Models.Camper", "Camper")
                        .WithMany("NextOfKins")
                        .HasForeignKey("CamperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camper");
                });

            modelBuilder.Entity("SP2.Models.Cabin", b =>
                {
                    b.Navigation("Campers");

                    b.Navigation("Counselor")
                        .IsRequired();
                });

            modelBuilder.Entity("SP2.Models.Camper", b =>
                {
                    b.Navigation("NextOfKins");
                });
#pragma warning restore 612, 618
        }
    }
}
