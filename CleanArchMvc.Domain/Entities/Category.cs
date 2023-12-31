﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name, too short, minimum 3 caracters");
            Name = name;
        }
    }
}
