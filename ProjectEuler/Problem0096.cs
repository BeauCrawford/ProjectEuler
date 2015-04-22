using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace ProjectEuler
{
    public class Problem0096 : Problem
    {
        public override void Execute()
        {
            var board = SodukoBoard.Parse(@"003 020 600
                                            900 305 001
                                            001 806 400
                                            008 102 900
                                            700 000 008
                                            006 708 200
                                            002 609 500
                                            800 203 009
                                            005 010 300");

            foreach (var line in board.Lines)
            {
                Console.WriteLine(line.Combinations.Count + " " + line.ToString());
            }

            Console.WriteLine();

            board.Reduce();

            foreach (var line in board.Lines)
            {
                Console.WriteLine(line.Combinations.Count + " " + line.ToString());
            }

            Console.WriteLine();

            // Console.WriteLine(board.GetCombinationCount());

            Console.WriteLine(board.FlattenCombos(8).Count());
        }
    }

    public class SodukoBoard
    {
        public static SodukoBoard Parse(string values)
        {
            var board = new SodukoBoard();

            foreach (var line in Regex.Split(values, Regex.Escape(Environment.NewLine)))
            {
                var trimmed = line.Trim();

                if (trimmed.Length > 0)
                {
                    trimmed = Regex.Replace(trimmed, @"\s+", string.Empty);

                    if (trimmed.Length != 9)
                        throw new InvalidOperationException();

                    board.Lines.Add(new SodukoLine(trimmed));
                }
            }

            return board;
        }

        private SodukoBoard()
        {
            Lines = new List<SodukoLine>();
        }

        public List<SodukoLine> Lines { get; private set; }

        public BigInteger GetCombinationCount()
        {
            var product = new BigInteger(1);

            foreach (var line in Lines)
            {
                product *= line.Combinations.Count;
            }

            return product;
        }

        public void Reduce()
        {
            foreach (var outer in Lines)
            {
                foreach (var inner in Lines)
                {
                    if (outer != inner)
                    {
                        inner.Reduce(outer.ToString());
                    }
                }
            }
        }

        public IEnumerable<string> FlattenCombos(int index)
        {
            var results = new List<string>();

            for (int i = 0; i <= index; i++)
            {
                results.AddRange(Lines[index].Combinations);
            }

            return results;
        }
    }

    public class SodukoLine
    {
        static SodukoLine()
        {
            var combos = new List<string>();

            foreach (var p1 in Numbers())
            {
                foreach (var p2 in Numbers(p1))
                {
                    foreach (var p3 in Numbers(p1, p2))
                    {
                        foreach (var p4 in Numbers(p1, p2, p3))
                        {
                            foreach (var p5 in Numbers(p1, p2, p3, p4))
                            {
                                foreach (var p6 in Numbers(p1, p2, p3, p4, p5))
                                {
                                    foreach (var p7 in Numbers(p1, p2, p3, p4, p5, p6))
                                    {
                                        foreach (var p8 in Numbers(p1, p2, p3, p4, p5, p6, p7))
                                        {
                                            foreach (var p9 in Numbers(p1, p2, p3, p4, p5, p6, p7, p8))
                                            {
                                                combos.Add(p1.ToString() + p2.ToString() + p3.ToString() + p4.ToString() + p5.ToString() + p6.ToString() + p7.ToString() + p8.ToString() + p9.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            PossibleLines = combos;
        }

        public static IEnumerable<int> Numbers(params int[] excluded)
        {
            var result = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            foreach (var e in excluded)
            {
                result.Remove(e);
            }

            return result;
        }

        public static IEnumerable<string> PossibleLines { get; private set; }

        public static bool IsMatch(string template, string candidate)
        {
            for (int t = 0; t < template.Length; t++)
            {
                if (template[t] != '0' && template[t] != candidate[t])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsMatchAny(string template, string other)
        {
            for (int t = 0; t < template.Length; t++)
            {
                if (template[t] != '0' && template[t] == other[t])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsValid(SodukoLine line)
        {
            var valid = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            return line.Values.Length == 9 && valid.Intersect(line.Values).Count() == 9;
        }

        public SodukoLine(string line)
        {
            Values = line.ToCharArray();

            Combinations = new List<string>();

            foreach (var combo in PossibleLines)
            {
                if (SodukoLine.IsMatch(line, combo))
                {
                    Combinations.Add(combo);
                }
            }
        }

        public char[] Values { get; private set; }

        public override string ToString()
        {
            return new string(Values);
        }

        public List<string> Combinations { get; private set; }

        public void Reduce(string template)
        {
            foreach (var combo in Combinations.ToArray())
            {
                if (IsMatchAny(template, combo))
                {
                    Combinations.Remove(combo);
                }
            }
        }
    }
}
