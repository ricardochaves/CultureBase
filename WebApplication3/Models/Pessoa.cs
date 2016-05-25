using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Pessoa
    {

        [Display(Name = "NomePessoa", ResourceType = typeof(Resources.Resources))]
        public string NomePessoa { get; set; }

    }
}