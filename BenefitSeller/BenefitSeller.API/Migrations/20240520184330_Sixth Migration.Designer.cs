﻿// <auto-generated />
using System;
using BenefitSeller.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BenefitSeller.API.Migrations
{
    [DbContext(typeof(BenefitSellerDbContext))]
    [Migration("20240520184330_Sixth Migration")]
    partial class SixthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BenefitSeller.API.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.Merchant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("DiscountPercentage")
                        .HasColumnType("float");

                    b.Property<Guid>("MerchantCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MerchantCategoryId");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.MerchantCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MerchantCategoryGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MerchantCategoryGroupId");

                    b.ToTable("MerchantCategories");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.MerchantCategoryGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MerchantCategoryGroups");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.SubscriptionPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubscriptionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionPlans");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("MerchantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SubscriptionPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SubscriptionPlanId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.UserCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCards");
                });

            modelBuilder.Entity("CompanyMerchantCategoryGroup", b =>
                {
                    b.Property<Guid>("CompaniesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MerchantCategoryGroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CompaniesId", "MerchantCategoryGroupsId");

                    b.HasIndex("MerchantCategoryGroupsId");

                    b.ToTable("CompanyBenefit", (string)null);
                });

            modelBuilder.Entity("BenefitSeller.API.Models.Merchant", b =>
                {
                    b.HasOne("BenefitSeller.API.Models.MerchantCategory", "MerchantCategory")
                        .WithMany()
                        .HasForeignKey("MerchantCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MerchantCategory");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.MerchantCategory", b =>
                {
                    b.HasOne("BenefitSeller.API.Models.MerchantCategoryGroup", "MerchantCategoryGroup")
                        .WithMany()
                        .HasForeignKey("MerchantCategoryGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MerchantCategoryGroup");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.Transaction", b =>
                {
                    b.HasOne("BenefitSeller.API.Models.Merchant", "Merchant")
                        .WithMany()
                        .HasForeignKey("MerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenefitSeller.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Merchant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.User", b =>
                {
                    b.HasOne("BenefitSeller.API.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenefitSeller.API.Models.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany()
                        .HasForeignKey("SubscriptionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("SubscriptionPlan");
                });

            modelBuilder.Entity("BenefitSeller.API.Models.UserCard", b =>
                {
                    b.HasOne("BenefitSeller.API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CompanyMerchantCategoryGroup", b =>
                {
                    b.HasOne("BenefitSeller.API.Models.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BenefitSeller.API.Models.MerchantCategoryGroup", null)
                        .WithMany()
                        .HasForeignKey("MerchantCategoryGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BenefitSeller.API.Models.Company", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
