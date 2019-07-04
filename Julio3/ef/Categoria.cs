namespace Julio3.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        public int CategoriaId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
