﻿namespace BoggleSolver.Library
{
    public class CellSolver
    {
        public LetterTrie RootTrie { get; set; }
        public int ChainCounter { get; set; }

        public ResultModel Run(Boggle boggle)
        {
            var result = new ResultModel();
            boggle.MapCells();
            for (var i = 0; i < boggle.RowSize; i++)
            {
                for (var j = 0; j < boggle.ColSize; j++)
                {
                    Chain(boggle.CellGrid[i][j], string.Empty);
                }
            }
            return result;

            void Chain(BoggleCell cell, string chain)
            {
                cell.IsVisited = true;
                chain = $"{chain}{cell.Letter}";
                if (!CheckChain(chain))
                {
                    cell.IsVisited = false;
                    return;
                }

                foreach (var adjacentCell in cell.AdjacentCells)
                {
                    if (adjacentCell.IsVisited) continue;
                    Chain(adjacentCell, chain);
                }

                cell.IsVisited = false;
            }

            bool CheckChain(string chain)
            {
                ChainCounter++;

                if (chain.Length < 3) return true;

                if (chain.Length > boggle.Size) return false;

                var trie = RootTrie;
                foreach (var letter in chain)
                {
                    trie = trie[letter];
                    if (trie == null) return false;
                }

                if (trie.IsLastLetter) result.Words.Add(chain);
                return true;
            }
        }

        public override string ToString() => "Cell Solver";
    }
}