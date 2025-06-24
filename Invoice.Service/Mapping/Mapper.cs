using Invoice.Data.Entities;
using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Invoice.Service.Mapping
{
    public  class Mapper
    {
        public  ApplicationUserDto MapToDto(ApplicationUser user)
        {
            return new ApplicationUserDto
            {
                DisplayName = user.DisplayName,
                TaxID = user.TaxID,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CommercialRegistration = user.CommercialRegistration
            };
        }

        public  ApplicationUser MapToEntity(ApplicationUserDto userDto)
        {
            return new ApplicationUser
            {

                DisplayName = userDto.DisplayName,
                TaxID = userDto.TaxID,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                CommercialRegistration = userDto.CommercialRegistration
            };
        }


        public  CompanyDto MapToDto(Company company)
        {
            return new CompanyDto
            {
                
                CompanyName = company.CompanyName,
                DisplayName = company.AppUser?.DisplayName,
              PhoneNumber = company.AppUser?.PhoneNumber,
           
              
            };
        }

        public  Company MapToEntity(CompanyDto companyDto)
        {
            return new Company
            {
                CompanyName = companyDto.CompanyName,
                
                AppUser = new ApplicationUser
                {
                    DisplayName = companyDto.DisplayName,
                    TaxID = companyDto.TaxID,
                    CommercialRegistration = companyDto.CommercialRegistration,
                    UserName=companyDto.username,
                    Email=companyDto.Email
                    
                    
                }
            };
        }

        public  CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto
            {
                DisplayName = customer.AppUser?.DisplayName,
                TaxID = customer.AppUser?.TaxID,
                PhoneNumber = customer.AppUser?.PhoneNumber,
                CommercialRegistration = customer.AppUser?.CommercialRegistration,
                UserName = customer.AppUser?.UserName,
                Email = customer.AppUser?.Email
                
            };
        }

        public  Customer MapToEntity(CustomerDto customerDto)
        {
            return new Customer
            {
                
               
                AppUser = new ApplicationUser
                {
                    DisplayName = customerDto.DisplayName,
                    TaxID = customerDto.TaxID,
                    PhoneNumber = customerDto.PhoneNumber,
                    CommercialRegistration = customerDto.CommercialRegistration,
                    UserName = customerDto.UserName,
                    Email = customerDto.Email,
                    PasswordHash = customerDto.password
                }
            };
        }


        public  DiscountDto MapToDto(Discount discount)
        {
            return new DiscountDto
            {
                Description = discount.Description,
                DiscountRate = discount.DiscountRate,
                DiscountAmount = discount.DiscountAmount
            };
        }

        public  Discount MapToEntity(DiscountDto discountDto)
        {
            return new Discount
            {
                Description = discountDto.Description,
                DiscountRate = discountDto.DiscountRate,
                DiscountAmount = discountDto.DiscountAmount
              
            };
        }
        public InvoiceDto MapToDto(Invoice.Data.Entities.Invoice invoice)
        {

            return new InvoiceDto
            {
                InvoiceNumber = invoice.InvoiceNumber,
                CustomerID = invoice.CustomerID,
                Date = invoice.CreatedAt, 
                DueDate = invoice.UpdatedAt, 
                TotalAmount = invoice.TotalAmount,
                CompanyID = invoice.CompanyID,
                Status = invoice.Status,
                Discount = invoice.Discount != null ? MapToDto(invoice.Discount) : null,
                Tax = invoice.Tax != null ? MapToDto(invoice.Tax) : null,
                InvoiceItems = invoice.InvoiceItems?.Select(MapToDto).ToList()
            };
        }

        public  Invoice.Data.Entities.Invoice MapToEntity(InvoiceDto invoiceDto)
        {
            return new Invoice.Data.Entities.Invoice
            {
                InvoiceNumber = invoiceDto.InvoiceNumber,
                CustomerID = invoiceDto.CustomerID,
                TotalAmount = invoiceDto.TotalAmount,
                CompanyID = invoiceDto.CompanyID,
                Status = invoiceDto.Status,
                Discount = invoiceDto.Discount != null ? MapToEntity(invoiceDto.Discount) : null,
                Tax = invoiceDto.Tax != null ? MapToEntity(invoiceDto.Tax) : null,
                 InvoiceItems = invoiceDto.InvoiceItems != null && invoiceDto.InvoiceItems.Any() 
            ? invoiceDto.InvoiceItems.Select(item => MapToEntity(item)).ToList() 
            : new List<InvoiceItem>()
            };
        }
        public  InvoiceItem MapToEntity(InvoiceItemDto invoiceItemDto)
        {
            return new InvoiceItem
            {
                ProductID = invoiceItemDto.ProductID,
                Quantity = invoiceItemDto.Quantity,
                UnitPrice = invoiceItemDto.UnitPrice,
                TotalPrice = invoiceItemDto.TotalPrice
            };
        }

        public  InvoiceItemDto MapToDto(InvoiceItem invoiceItem)
        {
            return new InvoiceItemDto
            {
                ProductID = invoiceItem.ProductID,
                Quantity = invoiceItem.Quantity,
                UnitPrice = invoiceItem.UnitPrice,
                TotalPrice = invoiceItem.TotalPrice
            };
        }


        public  Payment MapToEntity(PaymentDto paymentDto)
        {
            return new Payment
            {
                PaymentDate = paymentDto.PaymentDate,
                AmountPaid = paymentDto.AmountPaid,
                PaymentMethod = paymentDto.PaymentMethod,
                PaymentStatus = paymentDto.PaymentStatus,
                InvoiceID = paymentDto.InvoiceID
            };
        }

        public  PaymentDto MapToDto(Payment payment)
        {
            return new PaymentDto
            {
                PaymentDate = payment.PaymentDate,
                AmountPaid = payment.AmountPaid,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                InvoiceID = payment.InvoiceID
            };
        }

        public  Product MapToEntity(ProductDto productDto)
        {
            return new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                Description = productDto.Description,
                StockQuantity = productDto.StockQuantity
            };
        }

        public  ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                StockQuantity = product.StockQuantity
            };
        }
        public  Tax MapToEntity(TaxDto taxDto)
        {
            return new Tax
            {
                TaxName = taxDto.TaxName,
                TaxRate = taxDto.TaxRate,
                Description = taxDto.Description
            };
        }

        public  TaxDto MapToDto(Tax tax)
        {
            return new TaxDto
            {
                TaxName = tax.TaxName,
                TaxRate = tax.TaxRate,
                Description = tax.Description
            };
        }
       
    }
    
}
