﻿using System.Diagnostics;
using BoggleSolver.Library;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class PerformanceTests
    {
        private readonly ITestOutputHelper _testOutput;

        public PerformanceTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Theory]
        [InlineData(WordBook.Mini, 1)]
        [InlineData(WordBook.Midi, 1)]
        [InlineData(WordBook.Maxi, 1)]
        [InlineData(WordBook.Mini, 2)]
        [InlineData(WordBook.Midi, 2)]
        [InlineData(WordBook.Maxi, 2)]
        public void Validate_TrieSolver(string size, int level)
        {
            LetterTrie.Level = level;
            var solver = new Solver(size);
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
        }
    }
}