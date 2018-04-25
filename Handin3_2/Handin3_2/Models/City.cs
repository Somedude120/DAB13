namespace Handin3_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        public int CityId { get; set; }

        public string StreetName { get; set; }

        public int HouseNumber { get; set; }

        public int ZipCode { get; set; }

        public string CityName { get; set; }

        public int? AltAddress_AltAddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual AltAddress AltAddress { get; set; }
    }
}
