using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIBKMNET_WebApplication.Models
{
    public class Province
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public Region Region { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }




    }
}
