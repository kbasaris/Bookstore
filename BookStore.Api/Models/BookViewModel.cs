using BookStore.Api.Infrastracture.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Api.Models
{
    public class BookViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal? Price { get; set; }
        public int? Barcode { get; set; }
        public bool? Reorder { get; set; }
        public int? ReorderAmount { get; set; }
        public int? NumOfStocks { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new BookViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}