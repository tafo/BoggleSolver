﻿using System.Diagnostics;
using BoggleSolver.Library;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace BoggleSolver.Tests
{
    public class ValidationTests
    {
        private readonly ITestOutputHelper _testOutput;

        public ValidationTests(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Validate_DictionarySolver()
        {
            var solver = new DictionarySolver { WordBook = TheBook.GetDictionary(TheBook.Test) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            result.Words.ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(TestData.Boggle.Count);
            result.Score.Should().Be(TestData.Boggle.Score);
        }

        [Fact]
        public void Validate_IndexSolver()
        {
            var solver = new IndexSolver { WordBook = TheBook.GetIndex(TheBook.Test) };
            var timer = Stopwatch.StartNew();
            var result = solver.Run(TestData.Boggle);
            timer.Stop();

            _testOutput.WriteLine($"Found {result.Words.Count} words in {timer.Elapsed}");
            _testOutput.WriteLine($"Checked {solver.ChainCounter} chains");
            result.Words.ForEach(x => _testOutput.WriteLine(x));
            result.Words.Count.Should().Be(TestData.Boggle.Count);
            result.Score.Should().Be(TestData.Boggle.Score);
        }
    }
}