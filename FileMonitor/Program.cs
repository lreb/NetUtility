using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileMonitor.Implementations;
using FileMonitor.Templates;

namespace FileMonitor
{
	class Program
	{
		static void Main(string[] args)
		{
			// all configurations
			List<FileSystemWatcherConfiguration> configurations = new List<FileSystemWatcherConfiguration>();
			configurations.Add(new FileSystemWatcherConfiguration { Module = "a", Source = "C:\\monitor\\a", Target = "C:\\monitor\\target", Filter = "*.*" });
			configurations.Add(new FileSystemWatcherConfiguration { Module = "b", Source = "C:\\monitor\\b", Target = "C:\\monitor\\target", Filter = "*.txt" });
			configurations.Add(new FileSystemWatcherConfiguration { Module = "c",  Source = "C:\\monitor\\c", Target = "C:\\monitor\\target", Filter = "*.pdf" });
			// create list for all watchers
			List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
			// add watchers with its configuration
			Monitor monitors = new Monitor();
			foreach (var configuration in configurations)
			{
				watchers.Add(monitors.Scan(configuration));
			}
			// start watchers
			foreach (FileSystemWatcher watcher in watchers)
			{
				watcher.EnableRaisingEvents = true;
			}
			Console.WriteLine("press q to exit");
			while (Console.ReadKey().KeyChar != 'q') ;
		}
	}
}
