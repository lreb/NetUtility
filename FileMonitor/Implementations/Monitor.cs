using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileMonitor.Templates;

namespace FileMonitor.Implementations
{
	public class Monitor
	{
		List<FileSystemWatcherConfiguration> configurations = new List<FileSystemWatcherConfiguration>();
		public Monitor()
		{

		}

		public FileSystemWatcher Scan(FileSystemWatcherConfiguration parameters)
		{
			FileSystemWatcher watcher = new FileSystemWatcher(parameters.Source);
			watcher.Path = parameters.Source;
			watcher.Filter = parameters.Filter;
			watcher.Changed += OnChanged;
			//Attach them to the same listeners,,,
			configurations.Add(parameters);
			//Set additional parameters...
			return watcher;
		}

		private void Watcher_Created(object sender, FileSystemEventArgs e)
		{
			System.Threading.Thread.Sleep(2000);
			FileInfo fileInfo = new FileInfo(e.FullPath);
			//if (!IsFileLocked(fileInfo))
			//{
				Console.WriteLine(e.FullPath);
			//}
		}

		// Define the event handlers. static
		private void OnChanged(object source, FileSystemEventArgs e)
		{
			System.Threading.Thread.Sleep(4000);
			// Specify what is done when a file is changed, created, or deleted.
			Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
			System.IO.FileSystemWatcher s = (System.IO.FileSystemWatcher)source;
			//		string sourcePath = (string)source.GetType().GetProperty("path").GetValue(source, null);
			FileSystemWatcherConfiguration config = configurations.Where(x => x.Source == s.Path).FirstOrDefault();

			if (System.IO.Directory.Exists(config.Source))
			{
				string[] files = System.IO.Directory.GetFiles(config.Source);

				// Copy the files and overwrite destination files if they already exist.
				foreach (string file in files)
				{
					// Use static Path methods to extract only the file name from the path.
					new Formats().Read();

					new FIle().Move(config.Source, file, config.Target, file);

					new Notification().Notify($"{config.Source} {file}");
				}
			}
			else
			{
				Console.WriteLine("Source path does not exist!");
			}
		}

		private static void OnRenamed(object source, RenamedEventArgs e)
		{
			// Specify what is done when a file is renamed.
			Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
		}
	}

	internal class Source
	{
		public string path { get; set; }
	}
}
