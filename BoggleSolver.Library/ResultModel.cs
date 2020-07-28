﻿using System.Collections.Generic;

namespace BoggleSolver.Library
{
    public class ResultModel
    {
        public ResultModel()
        {
            Words = new HashSet<string>();
        }

        public int Score
        {
            get
            {
                var result = 0;
                foreach (var word in Words)
                {
                    switch (word.Length)
                    {
                        case 3:
                        case 4:
                            result += 1;
                            break;
                        case 5:
                            result += 2;
                            break;
                        case 6:
                            result += 3;
                            break;
                        case 7:
                            result += 5;
                            break;
                        case 8:
                            result += 11;
                            break;
                    }
                }

                return result;
            }
        }

        public HashSet<string> Words { get; set; }

        public void Add(string word)
        {
            Words.Add(word);
        }
    }
}