using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.Context
{
    public partial class UniqloContext : DbContext
    {
        public UniqloContext() { }

        public UniqloContext(DbContextOptions<UniqloContext> options) : base(options) { }

        #region DbSet
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<CollectionPost> CollectionPosts { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<GenderType> GenderTypes { get; set; }
        public virtual DbSet<ImportBill> ImportBills { get; set; }
        public virtual DbSet<ImportBillItem> ImportBillItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<UserCoupon> UserCoupons { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<AdministrativeRegion> AdministrativeRegions { get; set; }
        public virtual DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.Carts).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasOne(d => d.Cart).WithMany(p => p.CartItems).HasForeignKey(d => d.CartId);
                entity.HasOne(d => d.ProductDetail).WithMany(p => p.CartItems).HasForeignKey(d => d.ProductDetailId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(d => d.GenderType).WithMany(p => p.Categories).HasForeignKey(d => d.GenderTypeId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CollectionPost>(entity =>
            {
                entity.HasOne(d => d.Collection).WithMany(p => p.CollectionPosts).HasForeignKey(d => d.CollectionId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ImportBill>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.ImportBills).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ImportBillItem>(entity =>
            {
                entity.HasOne(d => d.ImportBill).WithMany(p => p.ImportBillItems).HasForeignKey(d => d.ImportBillId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ProductDetail).WithMany(p => p.ImportBillItems).HasForeignKey(d => d.ProductDetailId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.Orders).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Coupon).WithMany(p => p.Orders).HasForeignKey(d => d.CouponId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems).HasForeignKey(d => d.OrderId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ProductDetail).WithMany(p => p.OrderItems).HasForeignKey(d => d.ProductDetailId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.Payments).HasForeignKey(d => d.OrderId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Unit).WithMany(p => p.Products).HasForeignKey(d => d.UnitId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.GenderType).WithMany(p => p.Products).HasForeignKey(d => d.GenderTypeId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ProductPrice).WithMany(p => p.Products).HasForeignKey(d => d.ProductPriceId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ProductReview).WithMany(p => p.Products).HasForeignKey(d => d.ProductReviewId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Collection).WithMany(p => p.Products).HasForeignKey(d => d.CollectionId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.ProductCategories).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Category).WithMany(p => p.ProductCategories).HasForeignKey(d => d.CategoryId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.ProductColors).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Color).WithMany(p => p.ProductColors).HasForeignKey(d => d.ColorId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Size).WithMany(p => p.ProductDetails).HasForeignKey(d => d.SizeId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Color).WithMany(p => p.ProductDetails).HasForeignKey(d => d.ColorId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes).HasForeignKey(d => d.SizeId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(d => d.Product).WithMany(p => p.Reviews).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.User).WithMany(p => p.Reviews).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Size).WithMany(p => p.Reviews).HasForeignKey(d => d.SizeId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany(p => p.Shipments).HasForeignKey(d => d.OrderId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.UserAddress).WithMany(p => p.Shipments).HasForeignKey(d => d.UserAddressId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasOne(d => d.GenderType).WithMany(p => p.Sizes).HasForeignKey(d => d.GenderTypeId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.UserAddresses).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Province).WithMany(p => p.UserAddresses).HasForeignKey(d => d.ProvinceCode).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.District).WithMany(p => p.UserAddresses).HasForeignKey(d => d.DistrictCode).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Ward).WithMany(p => p.UserAddresses).HasForeignKey(d => d.WardCode).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserCoupon>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.UserCoupons).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Coupon).WithMany(p => p.UserCoupons).HasForeignKey(d => d.CouponId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.WishLists).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Product).WithMany(p => p.WishLists).HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasOne(d => d.AdministrativeUnit).WithMany(p => p.Provinces).HasForeignKey(d => d.AdministrativeUnitId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.AdministrativeRegion).WithMany(p => p.Provinces).HasForeignKey(d => d.AdministrativeRegionId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasOne(d => d.Province).WithMany(p => p.Districts).HasForeignKey(d => d.ProvinceCode).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.AdministrativeUnit).WithMany(p => p.Districts).HasForeignKey(d => d.AdministrativeUnitId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.HasOne(d => d.District).WithMany(p => p.Wards).HasForeignKey(d => d.DistrictCode).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.AdministrativeUnit).WithMany(p => p.Wards).HasForeignKey(d => d.AdministrativeUnitId).OnDelete(DeleteBehavior.ClientSetNull);
            });


        }
    }
}
