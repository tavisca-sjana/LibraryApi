using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FluentValidation;
using LibraryApi.Models;

namespace LibraryApi.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Id)
                .NotEmpty()
                .WithMessage("Id cannot be empty")
                .GreaterThan(0)
                .WithMessage("Id must be positive");

            RuleFor(book => book.Name)
                .NotEmpty()
                .WithMessage("Book Name must not be empty")
                .Must(name => StringContainsOnlyAlphabets(name))
                .WithMessage("Book Name must contain only alphabets");

            RuleFor(book => book.AuthorName)
                .NotEmpty()
                .WithMessage("Author Name must not be empty")
                .Must(name => StringContainsOnlyAlphabets(name))
                .WithMessage("Author Name must contain only alphabets");

            RuleFor(book => book.Category)
                .NotEmpty()
                .WithMessage("Author Name must not be empty")
                .Must(name => StringContainsOnlyAlphabets(name))
                .WithMessage("Category must contain only alphabets");

            RuleFor(book => book.Price)
                .NotEmpty()
                .WithMessage("Price must not be empty")
                .GreaterThan(0)
                .WithMessage("Price must be positive");

        }

        public bool StringContainsOnlyAlphabets(string input)
        {
            input = input.Replace(" ", "");
            //Regex.Matches(param).Count returns the number of characters matching the regex string 
            if (Regex.Matches(input, @"[a-zA-Z]").Count == input.Length)
                return true;
            return false;
        }
    }
}
