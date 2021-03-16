<Query Kind="Program">
  <NuGetReference>AngleSharp</NuGetReference>
  <NuGetReference>Dapper</NuGetReference>
  <NuGetReference>DocumentFormat.OpenXml</NuGetReference>
  <NuGetReference>ExcelDataReader</NuGetReference>
  <NuGetReference>ExcelDataReader.DataSet</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <NuGetReference>System.Data.SqlClient</NuGetReference>
  <Namespace>Dapper</Namespace>
  <Namespace>ExcelDataReader</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Stopwatch sw = new Stopwatch();
	sw.Start();
	Console.WriteLine("start memory usage: " + System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024) + $"MB");

	System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
	var path = @"D:\git\MiniExcel\samples\xlsx\TestTypeMapping_AutoCheckFormat.csv";
	using (var stream = File.OpenRead(path))
	using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
	{
		while (reader.Read())
		{
			for (var i = 0; i < reader.FieldCount; i++)
				Console.Write($"| {reader.GetValue(i).GetType().Name}:{reader.GetValue(i)} |");
		    Console.WriteLine();
		}
		
		Console.WriteLine("end memory usage: " + System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / (1024 * 1024) + $"MB & run time : {sw.ElapsedMilliseconds}ms");
	}
}
