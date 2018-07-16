using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor.Implementations
{
	class Notification
	{
		public void Notify(string message)
		{
			Console.WriteLine($"notify: {message}");
		}
	}
}
