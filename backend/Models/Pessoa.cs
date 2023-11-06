using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models
{
    public class Pessoa
    {
        public int Id { get; set; } 
        public string nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}