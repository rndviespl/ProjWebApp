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

    public virtual DbSet<Bro2testAttribute> Bro2testAttributes { get; set; }

    public virtual DbSet<Bro2testCart> Bro2testCarts { get; set; }

    public virtual DbSet<Bro2testCartItem> Bro2testCartItems { get; set; }

    public virtual DbSet<Bro2testCategory> Bro2testCategories { get; set; }

    public virtual DbSet<Bro2testDiscount> Bro2testDiscounts { get; set; }

    public virtual DbSet<Bro2testImage> Bro2testImages { get; set; }

    public virtual DbSet<Bro2testNotification> Bro2testNotifications { get; set; }

    public virtual DbSet<Bro2testOrder> Bro2testOrders { get; set; }

    public virtual DbSet<Bro2testOrderComposition> Bro2testOrderCompositions { get; set; }

    public virtual DbSet<Bro2testOrderHistory> Bro2testOrderHistories { get; set; }

    public virtual DbSet<Bro2testProduct> Bro2testProducts { get; set; }

    public virtual DbSet<Bro2testProductAttribute> Bro2testProductAttributes { get; set; }

    public virtual DbSet<Bro2testReturn> Bro2testReturns { get; set; }

    public virtual DbSet<Bro2testReview> Bro2testReviews { get; set; }

    public virtual DbSet<Bro2testUser> Bro2testUsers { get; set; }

    public virtual DbSet<Bro2testViewHistory> Bro2testViewHistories { get; set; }

    public virtual DbSet<Bro2testWishlist> Bro2testWishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("data source=166.1.201.241;uid=BrosShopAdm;pwd=BrosShopAdmin;database=bro2test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bro2testAttribute>(entity =>
        {
            entity.HasKey(e => e.Bro2testAttributesId).HasName("PRIMARY");

            entity.ToTable("bro2test_Attributes");

            entity.HasIndex(e => e.Bro2testColor, "idx_Attributes_Color");

            entity.HasIndex(e => e.Bro2testSize, "idx_Attributes_Size");

            entity.Property(e => e.Bro2testAttributesId).HasColumnName("bro2test_AttributesId");
            entity.Property(e => e.Bro2testColor)
                .HasMaxLength(20)
                .HasColumnName("bro2test_Color");
            entity.Property(e => e.Bro2testDescription)
                .HasMaxLength(255)
                .HasColumnName("bro2test_Description");
            entity.Property(e => e.Bro2testSize)
                .HasMaxLength(10)
                .HasColumnName("bro2test_Size");
        });

        modelBuilder.Entity<Bro2testCart>(entity =>
        {
            entity.HasKey(e => e.Bro2testCartId).HasName("PRIMARY");

            entity.ToTable("bro2test_Cart");

            entity.HasIndex(e => e.Bro2testUserId, "idx_Cart_UserId");

            entity.Property(e => e.Bro2testCartId).HasColumnName("bro2test_CartId");
            entity.Property(e => e.Bro2testCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_CreatedAt");
            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");

            entity.HasOne(d => d.Bro2testUser).WithMany(p => p.Bro2testCarts)
                .HasForeignKey(d => d.Bro2testUserId)
                .HasConstraintName("fk_Cart_User");
        });

        modelBuilder.Entity<Bro2testCartItem>(entity =>
        {
            entity.HasKey(e => e.Bro2testCartItemId).HasName("PRIMARY");

            entity.ToTable("bro2test_CartItem");

            entity.HasIndex(e => e.Bro2testCartId, "idx_CartItem_CartId");

            entity.HasIndex(e => e.Bro2testProductId, "idx_CartItem_ProductId");

            entity.Property(e => e.Bro2testCartItemId).HasColumnName("bro2test_CartItemId");
            entity.Property(e => e.Bro2testCartId).HasColumnName("bro2test_CartId");
            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testQuantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("bro2test_Quantity");

            entity.HasOne(d => d.Bro2testCart).WithMany(p => p.Bro2testCartItems)
                .HasForeignKey(d => d.Bro2testCartId)
                .HasConstraintName("fk_CartItem_Cart");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testCartItems)
                .HasForeignKey(d => d.Bro2testProductId)
                .HasConstraintName("fk_CartItem_Product");
        });

        modelBuilder.Entity<Bro2testCategory>(entity =>
        {
            entity.HasKey(e => e.Bro2testCategoryId).HasName("PRIMARY");

            entity.ToTable("bro2test_Category");

            entity.HasIndex(e => e.ParentCategoryId, "fk_ParentCategory");

            entity.HasIndex(e => e.Bro2testCategoryTitle, "idx_Category_Title");

            entity.Property(e => e.Bro2testCategoryId).HasColumnName("bro2test_CategoryId");
            entity.Property(e => e.Bro2testCategoryTitle)
                .HasMaxLength(45)
                .HasColumnName("bro2test_CategoryTitle");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_ParentCategory");
        });

        modelBuilder.Entity<Bro2testDiscount>(entity =>
        {
            entity.HasKey(e => e.Bro2testDiscountId).HasName("PRIMARY");

            entity.ToTable("bro2test_Discount");

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

        modelBuilder.Entity<Bro2testImage>(entity =>
        {
            entity.HasKey(e => e.Bro2testImageId).HasName("PRIMARY");

            entity.ToTable("bro2test_Image");

            entity.HasIndex(e => e.Bro2testProductId, "fk_bro2test_Image_bro2test_Product1_idx");

            entity.Property(e => e.Bro2testImageId).HasColumnName("bro2test_ImageId");
            entity.Property(e => e.Bro2testImage1)
                .HasColumnType("blob")
                .HasColumnName("bro2test_Image");
            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testImages)
                .HasForeignKey(d => d.Bro2testProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_Product");
        });

        modelBuilder.Entity<Bro2testNotification>(entity =>
        {
            entity.HasKey(e => e.Bro2testNotificationId).HasName("PRIMARY");

            entity.ToTable("bro2test_Notification");

            entity.HasIndex(e => e.Bro2testUserId, "idx_Notification_UserId");

            entity.Property(e => e.Bro2testNotificationId).HasColumnName("bro2test_NotificationId");
            entity.Property(e => e.Bro2testCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_CreatedAt");
            entity.Property(e => e.Bro2testIsRead).HasColumnName("bro2test_IsRead");
            entity.Property(e => e.Bro2testMessage)
                .HasMaxLength(255)
                .HasColumnName("bro2test_Message");
            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");

            entity.HasOne(d => d.Bro2testUser).WithMany(p => p.Bro2testNotifications)
                .HasForeignKey(d => d.Bro2testUserId)
                .HasConstraintName("fk_Notification_User");
        });

        modelBuilder.Entity<Bro2testOrder>(entity =>
        {
            entity.HasKey(e => e.Bro2testOrderId).HasName("PRIMARY");

            entity.ToTable("bro2test_Order");

            entity.HasIndex(e => e.Bro2testUserId, "idx_Order_UserId");

            entity.Property(e => e.Bro2testOrderId).HasColumnName("bro2test_OrderId");
            entity.Property(e => e.Bro2testDateTimeOrder)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_DateTimeOrder");
            entity.Property(e => e.Bro2testStatus)
                .HasDefaultValueSql("'новый'")
                .HasColumnType("enum('новый','в обработке','завершен','отменен')")
                .HasColumnName("bro2test_Status");
            entity.Property(e => e.Bro2testTypeOrder)
                .HasDefaultValueSql("'касса'")
                .HasColumnType("enum('веб-сайт','касса','WB')")
                .HasColumnName("bro2test_TypeOrder");
            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");
        });

        modelBuilder.Entity<Bro2testOrderComposition>(entity =>
        {
            entity.HasKey(e => new { e.Bro2testProductId, e.Bro2testOrderId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("bro2test_OrderComposition");

            entity.HasIndex(e => e.Bro2testOrderId, "idx_OrderComposition_OrderId");

            entity.HasIndex(e => e.Bro2testProductId, "idx_OrderComposition_ProductId");

            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testOrderId).HasColumnName("bro2test_OrderId");
            entity.Property(e => e.Bro2testPriceAtOrder)
                .HasPrecision(10, 2)
                .HasColumnName("bro2test_PriceAtOrder");
            entity.Property(e => e.Bro2testQuantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("bro2test_Quantity");

            entity.HasOne(d => d.Bro2testOrder).WithMany(p => p.Bro2testOrderCompositions)
                .HasForeignKey(d => d.Bro2testOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_OrderComposition_ibfk_2");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testOrderCompositions)
                .HasForeignKey(d => d.Bro2testProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_OrderComposition_ibfk_1");
        });

        modelBuilder.Entity<Bro2testOrderHistory>(entity =>
        {
            entity.HasKey(e => e.Bro2testOrderHistoryId).HasName("PRIMARY");

            entity.ToTable("bro2test_OrderHistory");

            entity.HasIndex(e => e.Bro2testOrderId, "idx_OrderHistory_OrderId");

            entity.Property(e => e.Bro2testOrderHistoryId).HasColumnName("bro2test_OrderHistoryId");
            entity.Property(e => e.Bro2testOrderId).HasColumnName("bro2test_OrderId");
            entity.Property(e => e.Bro2testStatus)
                .HasColumnType("enum('новый','в обработке','завершен','отменен')")
                .HasColumnName("bro2test_Status");
            entity.Property(e => e.Bro2testUpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_UpdatedAt");

            entity.HasOne(d => d.Bro2testOrder).WithMany(p => p.Bro2testOrderHistories)
                .HasForeignKey(d => d.Bro2testOrderId)
                .HasConstraintName("fk_OrderHistory_Order");
        });

        modelBuilder.Entity<Bro2testProduct>(entity =>
        {
            entity.HasKey(e => e.Bro2testProductId).HasName("PRIMARY");

            entity.ToTable("bro2test_Product");

            entity.HasIndex(e => e.Bro2testCategoryId, "idx_Product_CategoryId");

            entity.HasIndex(e => e.Bro2testTitle, "idx_Product_Title");

            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testCategoryId).HasColumnName("bro2test_CategoryId");
            entity.Property(e => e.Bro2testDateAdded)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_DateAdded");
            entity.Property(e => e.Bro2testDescription)
                .HasMaxLength(500)
                .HasColumnName("bro2test_Description");
            entity.Property(e => e.Bro2testDiscountPercent)
                .HasDefaultValueSql("'0'")
                .HasColumnName("bro2test_DiscountPercent");
            entity.Property(e => e.Bro2testPrice)
                .HasPrecision(10, 2)
                .HasColumnName("bro2test_Price");
            entity.Property(e => e.Bro2testTitle)
                .HasMaxLength(100)
                .HasColumnName("bro2test_Title");
            entity.Property(e => e.Bro2testWbarticul).HasColumnName("bro2test_WBArticul");

            entity.HasOne(d => d.Bro2testCategory).WithMany(p => p.Bro2testProducts)
                .HasForeignKey(d => d.Bro2testCategoryId)
                .HasConstraintName("bro2test_FK_Category");
        });

        modelBuilder.Entity<Bro2testProductAttribute>(entity =>
        {
            entity.HasKey(e => new { e.Bro2testProductId, e.Bro2testAttributesId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("bro2test_Product_Attributes");

            entity.HasIndex(e => e.Bro2testAttributesId, "idx_Product_Attributes_AttributesId");

            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testAttributesId).HasColumnName("bro2test_AttributesId");
            entity.Property(e => e.Bro2testCount)
                .HasDefaultValueSql("'1'")
                .HasColumnName("bro2test_Count");
            entity.Property(e => e.Bro2testDescription)
                .HasMaxLength(255)
                .HasColumnName("bro2test_Description");

            entity.HasOne(d => d.Bro2testAttributes).WithMany(p => p.Bro2testProductAttributes)
                .HasForeignKey(d => d.Bro2testAttributesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_Product_Attributes_ibfk_2");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testProductAttributes)
                .HasForeignKey(d => d.Bro2testProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_Product_Attributes_ibfk_1");
        });

        modelBuilder.Entity<Bro2testReturn>(entity =>
        {
            entity.HasKey(e => e.Bro2testReturnId).HasName("PRIMARY");

            entity.ToTable("bro2test_Return");

            entity.HasIndex(e => e.Bro2testOrderId, "idx_Return_OrderId");

            entity.HasIndex(e => e.Bro2testProductId, "idx_Return_ProductId");

            entity.Property(e => e.Bro2testReturnId).HasColumnName("bro2test_ReturnId");
            entity.Property(e => e.Bro2testOrderId).HasColumnName("bro2test_OrderId");
            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testQuantity).HasColumnName("bro2test_Quantity");
            entity.Property(e => e.Bro2testReason)
                .HasMaxLength(255)
                .HasColumnName("bro2test_Reason");
            entity.Property(e => e.Bro2testReturnDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_ReturnDate");

            entity.HasOne(d => d.Bro2testOrder).WithMany(p => p.Bro2testReturns)
                .HasForeignKey(d => d.Bro2testOrderId)
                .HasConstraintName("fk_Return_Order");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testReturns)
                .HasForeignKey(d => d.Bro2testProductId)
                .HasConstraintName("fk_Return_Product");
        });

        modelBuilder.Entity<Bro2testReview>(entity =>
        {
            entity.HasKey(e => e.Bro2testReviewId).HasName("PRIMARY");

            entity.ToTable("bro2test_Review");

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

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testReviews)
                .HasForeignKey(d => d.Bro2testProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_Review_ibfk_1");

            entity.HasOne(d => d.Bro2testUser).WithMany(p => p.Bro2testReviews)
                .HasForeignKey(d => d.Bro2testUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bro2test_Review_ibfk_2");
        });

        modelBuilder.Entity<Bro2testUser>(entity =>
        {
            entity.HasKey(e => e.Bro2testUserId).HasName("PRIMARY");

            entity.ToTable("bro2test_User");

            entity.HasIndex(e => e.Bro2testEmail, "bro2test_Email").IsUnique();

            entity.HasIndex(e => e.Bro2testUsername, "bro2test_Username").IsUnique();

            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");
            entity.Property(e => e.Bro2testEmail)
                .HasMaxLength(100)
                .HasColumnName("bro2test_Email");
            entity.Property(e => e.Bro2testFullName)
                .HasMaxLength(100)
                .HasColumnName("bro2test_FullName");
            entity.Property(e => e.Bro2testPassword)
                .HasMaxLength(255)
                .HasColumnName("bro2test_Password");
            entity.Property(e => e.Bro2testRegistrationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_RegistrationDate");
            entity.Property(e => e.Bro2testUsername)
                .HasMaxLength(50)
                .HasColumnName("bro2test_Username");
        });

        modelBuilder.Entity<Bro2testViewHistory>(entity =>
        {
            entity.HasKey(e => e.Bro2testViewId).HasName("PRIMARY");

            entity.ToTable("bro2test_ViewHistory");

            entity.HasIndex(e => e.Bro2testProductId, "idx_ViewHistory_ProductId");

            entity.HasIndex(e => e.Bro2testUserId, "idx_ViewHistory_UserId");

            entity.Property(e => e.Bro2testViewId).HasColumnName("bro2test_ViewId");
            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");
            entity.Property(e => e.Bro2testViewDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_ViewDate");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testViewHistories)
                .HasForeignKey(d => d.Bro2testProductId)
                .HasConstraintName("fk_ViewHistory_Product");

            entity.HasOne(d => d.Bro2testUser).WithMany(p => p.Bro2testViewHistories)
                .HasForeignKey(d => d.Bro2testUserId)
                .HasConstraintName("fk_ViewHistory_User");
        });

        modelBuilder.Entity<Bro2testWishlist>(entity =>
        {
            entity.HasKey(e => e.Bro2testWishlistId).HasName("PRIMARY");

            entity.ToTable("bro2test_Wishlist");

            entity.HasIndex(e => e.Bro2testProductId, "idx_Wishlist_ProductId");

            entity.HasIndex(e => e.Bro2testUserId, "idx_Wishlist_UserId");

            entity.Property(e => e.Bro2testWishlistId).HasColumnName("bro2test_WishlistId");
            entity.Property(e => e.Bro2testCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("bro2test_CreatedAt");
            entity.Property(e => e.Bro2testProductId).HasColumnName("bro2test_ProductId");
            entity.Property(e => e.Bro2testUserId).HasColumnName("bro2test_UserId");

            entity.HasOne(d => d.Bro2testProduct).WithMany(p => p.Bro2testWishlists)
                .HasForeignKey(d => d.Bro2testProductId)
                .HasConstraintName("fk_Wishlist_Product");

            entity.HasOne(d => d.Bro2testUser).WithMany(p => p.Bro2testWishlists)
                .HasForeignKey(d => d.Bro2testUserId)
                .HasConstraintName("fk_Wishlist_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
