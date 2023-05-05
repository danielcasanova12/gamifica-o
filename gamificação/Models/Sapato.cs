using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gamificacao.Enums;

namespace gamificacao.Models
{
    public class Sapato : Acessorio
    {
        public TamanhoSapato TamanhoSapato { get; set; }
        public string Marca { get; set; }
    }

}
