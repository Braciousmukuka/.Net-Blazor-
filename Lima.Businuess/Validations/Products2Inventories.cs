﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lima.Businuess.Validations
{
    internal class Products2Inventories : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;   
            if(product != null)
            {
                if (!product.ValidatePricing())
                    return new ValidationResult($"The product price is less than the summary  of its inventories's price: {product.TotalInventoryCost()} !"
                        ,new[] {validationContext.MemberName});
            }
            return ValidationResult.Success;    
        }
    }
}