using System;
using System.Collections.Generic;

namespace BaseProdutos.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }

        public int ID_Categoria { get; set; }
        public string? Dsc_Categoria { get; set; }

        public ICollection<Produto>? Produto { get; set; }
    }
}
