﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Clutchlit.Data;
using Clutchlit.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clutchlit.Controllers
{


    [Authorize]
    public class OrdersController : Controller
    {
        private readonly MysqlContext _contextSp24;
        private readonly AMysqlContext _contextSp;

        public OrdersController(MysqlContext contextSp24, AMysqlContext contextSp)
        {
            _contextSp24 = contextSp24;
            _contextSp = contextSp; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return View();
        }
        public IActionResult GetCartProducts(int Cart_id, string Shop_id)
        {
            var result = "";
            if (Shop_id == "Sp1")
            {
                var cart_products = _contextSp.Carts_spcom.Where(c => c.Id_cart == Cart_id);
                var products = _contextSp.Products_spcom;
                var price = _contextSp24.Products_prices_sp24;

                var results = from cp in cart_products
                          join p in products on cp.Id_product equals p.Id_product
                              join pp in price on cp.Id_product equals pp.Id_product
                              select new A_products { Cart_Quantity = cp.Quantity, Id_product = p.Id_product, Name = p.Name, Cart_price = Math.Round((pp.Price * (decimal)1.23), 0) };

                foreach (A_products s in results)
                {
                    result = result + "<tr><td><b>"+s.Name+"</b></td><td>" + s.Cart_price + "</td><td>" + s.Cart_Quantity + "</td><td>"+s.Id_product+"</td></tr>";
                }
                return Json(result);
            }
            else if (Shop_id == "Sp2")
            {
                var cart_products = _contextSp24.Carts_sp24.Where(c => c.Id_cart == Cart_id);
                var products = _contextSp24.Products_sp24;
                var price = _contextSp24.Products_prices_sp24;
                var results = from cp in cart_products
                              join p in products on cp.Id_product equals p.Id_product
                              join pp in price on cp.Id_product equals pp.Id_product
                              select new A_products { Cart_Quantity = cp.Quantity, Id_product = p.Id_product, Name = p.Name, Cart_price= Math.Round((pp.Price * (decimal)1.23),0) };

                foreach (A_products s in results)
                {
                    result = result + "<tr><td><b>" + s.Name + "</b></td><td>" + s.Cart_price + "</td><td>" + s.Cart_Quantity + "</td><td>" + s.Id_product + "</td></tr>";
                }
                return Json(result);
            }
            else
            {
                return Json("<tr><td><b>Brak danych. Błędny sklep</b></td><td></td><td></td></tr>");
            }
            
        }
        public IActionResult GetAllSp24()
        {

            var sp24 = _contextSp24.Orders_sp24;
            var spC = _contextSp.Orders_spcom;
            
            var res_sp24 = (from orders in sp24
                            join states in _contextSp24.Orders_states on orders.Current_state equals states.Id
                            join customers in _contextSp24.Customers_sp24 on orders.Id_customer equals customers.Id_customer
                            join addresses in _contextSp24.Addresses_sp24 on orders.Id_address_d equals addresses.Id_address
                            join invoice in _contextSp24.Addresses_sp24 on orders.Id_address_i equals invoice.Id_address
                            join msg in _contextSp24.Messages_sp24 on orders.Id_order equals msg.Id_order into gh
                            from msg1 in gh.DefaultIfEmpty()
                            select new A_orders_display()
                            {
                                Shop = "Sp2",
                                Created = orders.Created,
                                Id_carrier = orders.Id_carrier,
                                Id_address_i = string.Format("{0} {1} <br /> {2} {3} <br/><b>NIP:</b> {4}", invoice.Address1, invoice.Address2, invoice.ZipCode, invoice.City, invoice.Nip),
                                Id_order = orders.Id_order,
                                Current_state = states.Name,
                                Id_address_d = string.Format("{0} {1} {2} {3}", addresses.Address1, addresses.Address2, addresses.ZipCode, addresses.City),
                                Id_cart = orders.Id_cart,
                                Id_customer = string.Format("{0} {1} <br/><b>{2}</b> ", customers.FirstName, customers.LastName, customers.Company),
                                Payment = orders.Payment,
                                Reference = orders.Reference,
                                Total_paid = orders.Total_paid,
                                Total_paid_products = orders.Total_paid_products,
                                Total_shipping = orders.Total_shipping,
                                AdditionalInfo = string.Format("<b>Uwagi:</b> {0} <br /> <b>VIN:</b> {1}", addresses.AdditionalInfo, msg1.Message)
                            });
            var res_spC = (from orders in spC
                           join states in _contextSp.Orders_states_spcom on orders.Current_state equals states.Id
                           join customers in _contextSp.Customers_spcom on orders.Id_customer equals customers.Id_customer
                           join addresses in _contextSp.Addresses_spcom on orders.Id_address_d equals addresses.Id_address
                           join invoice in _contextSp.Addresses_spcom on orders.Id_address_i equals invoice.Id_address
                           join msg in _contextSp.Messages_spcom on orders.Id_order equals msg.Id_order into gh
                           from msg1 in gh.DefaultIfEmpty()
                           select new A_orders_display()
                           {
                               Shop = "Sp1",
                               Created = orders.Created,
                               Id_carrier = orders.Id_carrier,
                               Id_address_i = string.Format("{0} {1} <br /> {2} {3} <br/><b>NIP:</b> {4}", invoice.Address1, invoice.Address2, invoice.ZipCode, invoice.City, invoice.Nip),
                               Id_order = orders.Id_order,
                               Current_state = states.Name,
                               Id_address_d = string.Format("{0} {1} {2} {3}", addresses.Address1, addresses.Address2, addresses.ZipCode, addresses.City),
                               Id_cart = orders.Id_cart,
                               Id_customer = string.Format("{0} {1} <br/><b>{2}</b> ", customers.FirstName, customers.LastName, customers.Company),
                               Payment = orders.Payment,
                               Reference = orders.Reference,
                               Total_paid = orders.Total_paid,
                               Total_paid_products = orders.Total_paid_products,
                               Total_shipping = orders.Total_shipping,
                               AdditionalInfo = string.Format("<b>Uwagi:</b> {0} <br /> <b>VIN:</b> {1}", addresses.AdditionalInfo, msg1.Message)
                           });

            // przed połączeniem musimy utworzyć ostateczne listy 
            // łączymy dwie listy
            
            var concat = res_sp24.ToList().Union(res_spC.ToList());
            // porządkujemy liste
            var concat_sorted = concat.OrderByDescending(o => o.Created);

            
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 10;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsTotal = 0;
            IQueryable<A_orders_display> result = null;
            result = concat_sorted.AsQueryable();
            var customerData = result;
            //Sorting  
            
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = customerData.Where(m => m.Reference.ToUpper().Contains(searchValue.ToUpper()));
            }
            //Paging   
            recordsTotal = customerData.Count();
            //Paging   
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            Response.StatusCode = 200;
            return new JsonResult(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }
        public IActionResult AddOrder()
        {

            return View();
        }
    }
}