using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMH60Store.Models;

public partial class H60AssignmentDbSmContext : DbContext
{
    private DbSet<Product> _products;
    private DbSet<ProductCategory> _productCategories;
    private DbSet<Customer> _customers;
    private DbSet<Order> _orders;
    private DbSet<OrderItem> _orderItems;
    private DbSet<ShoppingCart> _shoppingCarts;
    private DbSet<CartItem> _cartItems;

    public H60AssignmentDbSmContext()
    {
    }

    public H60AssignmentDbSmContext(DbContextOptions<H60AssignmentDbSmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products
    {
        get => _products;
        set => _products = value;
    }

    public virtual DbSet<ProductCategory> ProductCategories
    {
        get => _productCategories;
        set => _productCategories = value;
    }
    public virtual DbSet<Customer> Customers
    {
        get => _customers;
        set => _customers = value;
    }
    public virtual DbSet<Order> Orders
    {
        get => _orders;
        set => _orders = value;
    }
    public virtual DbSet<OrderItem> OrderItems
    {
        get => _orderItems;
        set => _orderItems = value;
    }
    public virtual DbSet<ShoppingCart> ShoppingCarts
    {
        get => _shoppingCarts;
        set => _shoppingCarts = value;
    }
    public virtual DbSet<CartItem> CartItems
    {
        get => _cartItems;
        set => _cartItems = value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:csdevdb-heritagecs.database.windows.net,1433; Database=H60_AssignmentDB_SM;Authentication=Active Directory Interactive; Encrypt=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProdCatId, "Product_ProdCatId");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BuyPrice).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.ProdCatId).HasColumnName("ProdCatId");
            entity.Property(e => e.SellPrice).HasColumnType("numeric(8, 2)");

            entity.HasOne(d => d.ProdCat).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProdCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProdCatId);

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProdCatId).HasColumnName("ProdCatId");
            entity.Property(e => e.ProdCat)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
            
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.CreditCard)
                .HasMaxLength(16)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "Order_CustomerId");

            entity.Property(e => e.OrderId).HasColumnName("OrderId");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateFufilled).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");
            entity.Property(e => e.Taxes).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);

            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderId, "OrderItem_OrderId");
            entity.HasIndex(e => e.ProductId, "OrderItem_ProductId");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemId");
            entity.Property(e => e.OrderId).HasColumnName("OrderId");
            entity.Property(e => e.ProductId).HasColumnName("ProductId");
            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Order");
            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Product");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.ShoppingCartId);

            entity.ToTable("ShoppingCart");

            entity.HasIndex(e => e.CustomerId, "ShoppingCart_CustomerId");

            entity.Property(e => e.ShoppingCartId).HasColumnName("ShoppingCartID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithOne(p => p.ShoppingCart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCart_Customer");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId);

            entity.ToTable("CartItem");

            entity.HasIndex(e => e.ShoppingCartId, "CartItem_ShoppingCartId");
            entity.HasIndex(e => e.ProductId, "CartItem_ProductId");

           	entity.Property( e=>	e.CartItemId).HasColumnName("CartItemId");
        	entity.Property(e=>e.ShoppingCartId).HasColumnName("ShoppingCartID");
        	entity.Property(e=>e.ProductId).HasColumnName("ProductId");

        	entity.HasOne(d => d.ShoppingCart).WithMany(p => p.CartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItem_ShoppingCart");
            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartItem_Product");
        });

        modelBuilder.Entity<Customer>().HasData(
                new Customer() { CustomerId = 1, FirstName = "Schmingus", LastName = "McBingus", Email = "schmingbing@gmail.com", PhoneNumber = "1234567890", Province = "QC", CreditCard = "1234567890123456" },
                new Customer() { CustomerId = 2, FirstName = "Oingus", LastName = "Boingus", Email = "oingboing@gmail.com", PhoneNumber = "1234567890", Province = "NS", CreditCard = "1234567890123456" },
                new Customer() { CustomerId = 3, FirstName = "Quandale", LastName = "Dingle", Email = "QuandaleDingle@gmail.com", PhoneNumber = "1234567890", Province = "BC", CreditCard = "1234567890123456" }
            );
        modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart() { ShoppingCartId = 1, CustomerId = 1, DateCreated = DateTime.Now }
            );
        modelBuilder.Entity<CartItem>().HasData(
                new CartItem() { CartItemId = 1, ShoppingCartId = 1, ProductId = 3, Quantity = 1, Price = 25.00m },
                new CartItem() { CartItemId = 2, ShoppingCartId = 1, ProductId = 2, Quantity = 3, Price = 780.00m }
            );
        modelBuilder.Entity<Order>().HasData(
                new Order() { OrderId = 1, CustomerId = 3, DateCreated = DateTime.Now, DateFufilled = DateTime.Now }
            );
        modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem() { OrderItemId = 1, OrderId = 1, ProductId = 3, Quantity = 1, Price = 25.00m },
                new OrderItem() { OrderItemId = 2, OrderId = 1, ProductId = 4, Quantity = 1, Price = 80.00m },
                new OrderItem() { OrderItemId = 3, OrderId = 1, ProductId = 6, Quantity = 2, Price = 40.00m }
            );
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
