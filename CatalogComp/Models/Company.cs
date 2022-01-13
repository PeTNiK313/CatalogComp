using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CatalogComp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Site { get; set; }
        public string CompanyType { get; set; }
        public string Logo { get; set; }
        public List<Director> DirectorsId { get; set; }
       // public List<Sponser> Sponsers { get; set; } = new List<Sponser>();
    }
    public class Director
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int PhoneNumber { get; set; }
        public string Education { get; set; }
        public int CompanyId { get; set; }   
        public Company Company { get; set; }
    }
    public class Sponser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Company> Companies { get; set; } = new List<Company>();
    }
}
