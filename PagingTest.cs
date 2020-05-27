using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class PagingTest
    {
        [Key]
        public long Id { get; set; }
        public long Row { get; set; }
        public DateTime FechaYHora{get;set;}
    }
}
