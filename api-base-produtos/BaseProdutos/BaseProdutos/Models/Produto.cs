using System;
using System.Collections.Generic;

namespace BaseProdutos.Models
{
    public partial class Produto
    {
        public int ID_Produto { get; set; }
        public string Nome_Produto { get; set; } = null!;
        public string Dsc_Produto { get; set; } = null!;
        public int ID_Categoria_Produto { get; set; }

        public Categoria? Categoria { get; set; } = null!;
    }
}
