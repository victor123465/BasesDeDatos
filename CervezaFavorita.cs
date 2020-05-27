using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    [Table("Cerveza_Favorita")]
    public partial class CervezaFavorita
    {
        [Column("ID", TypeName = "int")]
        public long? Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        public string Nombre { get; set; }
    }
}
