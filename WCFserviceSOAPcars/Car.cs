namespace WCFserviceSOAPcars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        public int? Price { get; set; }

        public int? Year { get; set; }
    }
}
