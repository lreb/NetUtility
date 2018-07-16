using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileMonitor.Implementations
{
	public class FIle
	{
		public void Move(string source, string sourceFile, string target, string targetFile)
		{
			try
			{
				File.Move(sourceFile, Path.Combine(targetFile, System.IO.Path.GetFileName(targetFile)));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				//throw;
			}
		}
	}
}
