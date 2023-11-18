﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public sealed class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
