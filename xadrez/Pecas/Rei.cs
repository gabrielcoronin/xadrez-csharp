using xadrez.tab;

namespace xadrez.Pecas
{
    class Rei : Peca
    {

        private PartidaDeXadrez partida;

        public Rei(Tabuleiro Tabuleiro, Cor Cor, PartidaDeXadrez partida) : base(Tabuleiro, Cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao);
            return p == null || p.Cor != Cor;
        }

        private bool testeTorreParaRoque(Posicao posicao)
        {
            Peca p = Tabuleiro.Peca(posicao);
            return p != null && p is Torre && p.Cor == Cor && p.QuantidadeMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicao = new Posicao(0, 0);

            // acima
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // ne
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // direita
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // se
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // abaixo
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // so
            posicao.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // esquerda
            posicao.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }
            // no
            posicao.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.Linha, posicao.Coluna] = true;
            }

            // #jogadaespecial roque
            if (QuantidadeMovimentos == 0 && !partida.Xeque)
            {
                // #jogadaespecial roque pequeno
                Posicao posicaoT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (testeTorreParaRoque(posicaoT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Posicao posicaoT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (testeTorreParaRoque(posicaoT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }


            return mat;
        }
    }
}
