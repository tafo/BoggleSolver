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
        [InlineData(TheBook.Mini)]
        [InlineData(TheBook.Midi)]
        [InlineData(TheBook.Maxi)]
        public void Test_HashSetSolver(string size)
        {
            var solver = new HashSetSolver { Words = TheBook.GetSet(size) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Count} words in {timer.Elapsed}");
        }

        [Theory]
        [InlineData(TheBook.Mini)]
        [InlineData(TheBook.Midi)]
        [InlineData(TheBook.Maxi)]
        public void Test_DictionarySolver(string size)
        {
            var solver = new DictionarySolver { Words = TheBook.GetDictionary(size) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Count} words in {timer.Elapsed}");
        }
    }
}