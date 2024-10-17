using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using ProjWebApp.Models;

namespace ProjWebApp.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attribute1> Attributes { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderComposition> OrderCompositions { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<Return> Returns { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ViewHistory> ViewHistories { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("data source=166.1.201.241;uid=BrosShopAdm;pwd=BrosShopAdmin;database=bro2test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attribute1>(entity =>
        {
            entity.HasKey(e => e.AttributesId).HasName("PRIMARY");

            entity.HasIndex(e => e.Color, "idx_Attributes_Color");

            entity.HasIndex(e => e.Size, "idx_Attributes_Size");

            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Size).HasMaxLength(10);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PRIMARY");

            entity.ToTable("Cart");

            entity.HasIndex(e => e.UserId, "idx_Cart_UserId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_Cart_User");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PRIMARY");

            entity.ToTable("CartItem");

            entity.HasIndex(e => e.CartId, "idx_CartItem_CartId");

            entity.HasIndex(e => e.ProductId, "idx_CartItem_ProductId");

            entity.Property(e => e.Quantity).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("fk_CartItem_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_CartItem_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("Category");

            entity.HasIndex(e => e.ParentCategoryId, "fk_ParentCategory");

            entity.HasIndex(e => e.CategoryTitle, "idx_Category_Title");

            entity.Property(e => e.CategoryTitle).HasMaxLength(45);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Bro2testDiscountId).HasName("PRIMARY");

            entity.ToTable("Discount");

            entity.HasIndex(e => e.Bro2testDiscountCode, "bro2test_DiscountCode").IsUnique();

            entity.Property(e => e.Bro2testDiscountId).HasColumnName("bro2test_DiscountId");
            entity.Property(e => e.Bro2testDiscountCode)
                .HasMaxLength(50)
                .HasColumnName("bro2test_DiscountCode");
            entity.Property(e => e.Bro2testDiscountPercent).HasColumnName("bro2test_DiscountPercent");
            entity.Property(e => e.Bro2testEndDate)
                .HasColumnType("datetime")
                .HasColumnName("bro2test_EndDate");
            entity.Property(e => e.Bro2testStartDate)
                .HasColumnType("datetime")
                .HasColumnName("bro2test_StartDate");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PRIMARY");

            entity.ToTable("Image");

            entity.HasIndex(e => e.ProductId, "fk_bro2test_Image_bro2test_Product1_idx");

            entity.Property(e => e.ImagePath).HasColumnType("blob");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_Product");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PRIMARY");

            entity.ToTable("Notification");

            entity.HasIndex(e => e.UserId, "idx_Notification_UserId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Message).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_Notification_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("Order");

            entity.HasIndex(e => e.UserId, "idx_Order_UserId");

            entity.Property(e => e.DateTimeOrder)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'новый'")
                .HasColumnType("enum('новый','в обработке','завершен','отменен')");
            entity.Property(e => e.TypeOrder)
                .HasDefaultValueSql("'касса'")
                .HasColumnType("enum('веб-сайт','касса','WB')");
        });

        modelBuilder.Entity<OrderComposition>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.OrderId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("OrderComposition");

            entity.HasIndex(e => e.OrderId, "idx_OrderComposition_OrderId");

            entity.HasIndex(e => e.ProductId, "idx_OrderComposition_ProductId");

            entity.Property(e => e.PriceAtOrder).HasPrecision(10, 2);
            entity.Property(e => e.Quantity).HasDefaultValueSql("'1'");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderCompositions)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderComposition_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderCompositions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderComposition_ibfk_1");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.HasKey(e => e.OrderHistoryId).HasName("PRIMARY");

            entity.ToTable("OrderHistory");

            entity.HasIndex(e => e.OrderId, "idx_OrderHistory_OrderId");

            entity.Property(e => e.Status).HasColumnType("enum('новый','в обработке','завершен','отменен')");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_OrderHistory_Order");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("Product");

            entity.HasIndex(e => e.CategoryId, "idx_Product_CategoryId");

            entity.HasIndex(e => e.Title, "idx_Product_Title");

            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DiscountPercent).HasDefaultValueSql("'0'");
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.Wbarticul).HasColumnName("WBArticul");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("bro2test_FK_Category");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.AttributesId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("Product_Attributes");

            entity.HasIndex(e => e.AttributesId, "idx_Product_Attributes_AttributesId");

            entity.Property(e => e.Count).HasDefaultValueSql("'1'");
            entity.Property(e => e.Description).HasMaxLength(255);

            entity.HasOne(d => d.Attributes).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.AttributesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Attributes_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Attributes_ibfk_1");
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PRIMARY");

            entity.ToTable("Return");

            entity.HasIndex(e => e.OrderId, "idx_Return_OrderId");

            entity.HasIndex(e => e.ProductId, "idx_Return_ProductId");

            entity.Property(e => e.Reason).HasMaxLength(255);
            entity.Property(e => e.ReturnDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.Returns)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_Return_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.Returns)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_Return_Product");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Bro2testReviewId).HasName("PRIMARY");

            entity.ToTable("Review");

            entity.HasIndex(e => e.Bro2testProductId, "idx_Review_ProductId");

            entity.HasIndex(e => e.Bro2testUserId, "idx_Review_UserId");

            entity.Property(e => e.Bro2testReviewId).HasColumnName("bro2test_ReviewId");
            entity.Property(e => e.Bro2testComment)
                .HasColumnType("text")
                .HasColumnName("bro2test_Comment");
            entity.Property(e => e.Bro2testDateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_DateTime");
            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testRating).HasColumnName("bro2test_Rating");
            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "bro2test_Email").IsUnique();

            entity.HasIndex(e => e.Username, "bro2test_Username").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<ViewHistory>(entity =>
        {
            entity.HasKey(e => e.ViewId).HasName("PRIMARY");

            entity.ToTable("ViewHistory");

            entity.HasIndex(e => e.ProductId, "idx_ViewHistory_ProductId");

            entity.HasIndex(e => e.UserId, "idx_ViewHistory_UserId");

            entity.Property(e => e.ViewDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ViewHistories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_ViewHistory_Product");

            entity.HasOne(d => d.User).WithMany(p => p.ViewHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_ViewHistory_User");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PRIMARY");

            entity.ToTable("Wishlist");

            entity.HasIndex(e => e.ProductId, "idx_Wishlist_ProductId");

            entity.HasIndex(e => e.UserId, "idx_Wishlist_UserId");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_Wishlist_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_Wishlist_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
