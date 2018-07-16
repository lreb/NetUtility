using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor.Templates
{
	public class FileSystemWatcherConfiguration
	{
		public string Module { get; set; }
		public string Source { get; set; }
		public string Target { get; set; }
		public string Filter { get; set; }
	}
}
