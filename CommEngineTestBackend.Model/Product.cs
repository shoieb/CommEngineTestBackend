using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommEngineTestBackend.Model
{
    public class Product
    {
        public Product()
        {
            this.Id = new Guid();
            this.CreateDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }

    }
}
