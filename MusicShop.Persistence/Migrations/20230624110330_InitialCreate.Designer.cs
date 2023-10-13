﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicShop.Persistance.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicShop.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230624110330_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MusicShop.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.BasketEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.FileInfoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ParentEntityId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FileInfos");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ManyToManyTables.CategoryProductProperty", b =>
                {
                    b.Property<Guid>("ProductPropertyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductPropertyId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryProductProperties", (string)null);
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ManyToManyTables.ProductBasket", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BasketId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId", "BasketId");

                    b.HasIndex("BasketId");

                    b.ToTable("BasketsProducts", (string)null);
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ManyToManyTables.UserFavoriteProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId", "UserId");

                    b.ToTable("UsersFavorites", (string)null);
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("Discount")
                        .HasColumnType("double precision");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductStatus")
                        .HasColumnType("integer");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ValueType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProductsProperties");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertySetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductPropertyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductPropertyId");

                    b.ToTable("ProductPropertiesSets");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertyValueEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uuid");

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("boolean");

                    b.Property<double?>("NumericValue")
                        .HasColumnType("double precision");

                    b.Property<string>("TextValue")
                        .HasColumnType("text");

                    b.Property<Guid?>("ValueFromSetId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId", "PropertyId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("ValueFromSetId");

                    b.ToTable("ProductsPropertiesValues", (string)null);
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ReviewEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("ProductScore")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.BasketEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.UserEntity", "User")
                        .WithOne("Basket")
                        .HasForeignKey("MusicShop.Domain.Entities.BasketEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.CategoryEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.CategoryEntity", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ManyToManyTables.CategoryProductProperty", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.CategoryEntity", "Category")
                        .WithMany("CategoryProductProperties")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.ProductPropertyEntity", "ProductProperty")
                        .WithMany("CategoryProductProperties")
                        .HasForeignKey("ProductPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ProductProperty");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ManyToManyTables.ProductBasket", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.BasketEntity", "Basket")
                        .WithMany("BasketProducts")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.ProductEntity", "Product")
                        .WithMany("BasketProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ManyToManyTables.UserFavoriteProduct", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.ProductEntity", "Product")
                        .WithMany("UsersFavoriteProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.UserEntity", "User")
                        .WithMany("UsersFavoriteProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.OrderEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.AddressEntity", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.ProductEntity", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertySetEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.ProductPropertyEntity", "ProductProperty")
                        .WithMany("ProductPropertySet")
                        .HasForeignKey("ProductPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductProperty");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertyValueEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.ProductEntity", "Product")
                        .WithMany("ProductPropertiesValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.ProductPropertyEntity", "Property")
                        .WithMany("ProductPropertiesValues")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.ProductPropertySetEntity", "ProductPropertySetValue")
                        .WithMany("ProductPropertyValues")
                        .HasForeignKey("ValueFromSetId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Product");

                    b.Navigation("ProductPropertySetValue");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ReviewEntity", b =>
                {
                    b.HasOne("MusicShop.Domain.Entities.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Domain.Entities.UserEntity", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.AddressEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.BasketEntity", b =>
                {
                    b.Navigation("BasketProducts");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("CategoryProductProperties");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductEntity", b =>
                {
                    b.Navigation("BasketProducts");

                    b.Navigation("Orders");

                    b.Navigation("ProductPropertiesValues");

                    b.Navigation("UsersFavoriteProducts");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertyEntity", b =>
                {
                    b.Navigation("CategoryProductProperties");

                    b.Navigation("ProductPropertiesValues");

                    b.Navigation("ProductPropertySet");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.ProductPropertySetEntity", b =>
                {
                    b.Navigation("ProductPropertyValues");
                });

            modelBuilder.Entity("MusicShop.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("UsersFavoriteProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
