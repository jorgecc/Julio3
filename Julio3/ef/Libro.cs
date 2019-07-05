namespace Julio3.ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Libro")]
    public partial class Libro
    {
        public int LibroId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public decimal? Precio { get; set; }

        public int? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
