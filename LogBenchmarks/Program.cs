// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using LogBenchmarks;

var summary = BenchmarkRunner.Run<LogBench>();