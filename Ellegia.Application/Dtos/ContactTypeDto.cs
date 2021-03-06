﻿using System.ComponentModel.DataAnnotations;

namespace Ellegia.Application.Dtos
{
    public class ContactTypeDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string InputMask { get; set; }
    }
}