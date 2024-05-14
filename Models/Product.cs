﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace SkoButik_Client.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Productname must be between 2 and 20 characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [StringLength(60, MinimumLength = 10 )]
        public string? Description { get; set; }

        [StringLength (60, MinimumLength = 20 )]
        public string ImageUrl { get; set; } //ändra till Byte[]???
       
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }


        //One to many = Size 1---[ Products
        [ForeignKey("Size")]
        public int FkSizeId { get; set; }
        public Size? Size { get; set; }

        // One to many = Brand 1---[ Products
        [ForeignKey("Brand")]
        public int FkBrandId { get; set; }
        public Brand Brand { get; set; }


    }
}
