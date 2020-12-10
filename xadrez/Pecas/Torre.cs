﻿using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tab;

namespace xadrez.Pecas
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
