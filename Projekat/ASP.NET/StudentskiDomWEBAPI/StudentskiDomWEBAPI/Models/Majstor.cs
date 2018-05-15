namespace StudentskiDomWEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Majstor")]
    public partial class Majstor
    {
        [StringLength(255)]
        public string id { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset? updatedAt { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public bool? deleted { get; set; }

        public string ime { get; set; }

        public string prezime { get; set; }

        public string datumRodjenja { get; set; }

        public string pol { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public double? plata { get; set; }

        public string bankovniRacun { get; set; }

        public string tip { get; set; }

        public string jmbg { get; set; }

        public string majstorId { get; set; }
    }
}
