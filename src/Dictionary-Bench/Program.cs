// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using Dictionary_Bench;

var config = ManualConfig.CreateMinimumViable();
config.AddExporter(CsvMeasurementsExporter.Default);
config.AddExporter(RPlotExporter.Default);

BenchmarkRunner.Run<Benchmarks>(config);
