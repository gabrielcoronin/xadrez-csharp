﻿using xadrez.tab;
using System;

namespace xadrez
{
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.Peca(i, j) == null)
                        Console.WriteLine("- ");
                    
                    Console.WriteLine(tabuleiro.Peca(i,j) + "");
                }
            }
        }
    }
}
