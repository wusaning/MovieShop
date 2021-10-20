using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Cast")]
    public class Cast
    {
        public int Id { get; set; }
       
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string TmdbUrl { get; set; }
        [MaxLength(120)]
        public string ProfilePath { get; set; }
    }
}


