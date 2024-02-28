﻿using HouseRentingSystem.Infrastucture.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRentingSystem.Infrastucture.Data.Models
{
    [Comment("House to rent")]
    public class House
    {
        [Key]
        [Comment("House Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TitleMaxLength)]
        [Comment("Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.AddressMaxLength)]
        [Comment("Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.DescriptionMaxLength)]
        [Comment("Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("House image url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Monthly price")]
        [Column(TypeName = "decimal(18,2)")]
        //[Range(typeof(decimal), DataConstants.RentingPriceMin, DataConstants.RentingPriceMax, ConvertValueInInvariantCulture = true)]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [Required]
        [Comment("Agent identifier")]
        public int AgentId { get; set; }

        [Comment("User id of the renterer")]
        public string? RenterId { get; set; }

        public Category Category { get; set; } = null!;

        public Agent Agent { get; set; } = null!;
    }
}