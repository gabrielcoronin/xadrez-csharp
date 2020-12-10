﻿using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tab;

namespace xadrez.Pecas
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
