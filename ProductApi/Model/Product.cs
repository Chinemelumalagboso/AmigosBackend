using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace ProductApi.Model
{
  public class Product
    {
        [Key]
        public int Id {get; set;}
        public string Name{get; set;}
        [Column(TypeName ="decimal(18,2)")]
        public Decimal Price {get; set;}
        public string description{ get; set;}

    }
}