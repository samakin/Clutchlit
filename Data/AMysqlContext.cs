﻿using System;
using System.Collections.Generic;
using System.Text;
using Clutchlit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Clutchlit.Data
{
    public class AMysqlContext : DbContext
    {
        public AMysqlContext(DbContextOptions<AMysqlContext> options)
            : base(options)
        {
        }
        //
        //
        //
        //
        //
        //
        //public DbSet<Product> Products { get; set; }
        public DbSet<B_orders> Orders_spcom { get; set; }
        public DbSet<B_order_state> Orders_states_spcom { get; set; }
        public DbSet<B_customer> Customers_spcom { get; set; }
        public DbSet<B_address> Addresses_spcom { get; set; }
        public DbSet<B_message> Messages_spcom { get; set; }
        public DbSet<A_cart> Carts_spcom { get; set; }
        public DbSet<A_cart_main> Cart_main { get; set; }
        public DbSet<A_products> Products_spcom { get; set; }
        public DbSet<A_product_price> Products_prices_spcom { get; set; }
        public DbSet<A_Cart_ip> Ip_cart_spcom { get; set; }
        public DbSet<AllegroAuction> Allegro_auctions { get; set; }
        public DbSet<A_product_display> ProductDisplay { get; set; }
        public DbSet<A_stock> ProductsStock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Host=mysql-sprzegla.nano.pl;Database=db100008757;Username=db100008757_apli;Password=8ZAYsiU1");
        }
    }
}
