
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace tasksharpdev
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			
			List<Task> lst_task = new List<Task>();
			Utility utility = new Utility();
			/*
			using (StreamReader sr = new StreamReader(@"C:\SO\task\test.txt"))
			{
				string line;
				while (sr.EndOfStream == false)
				{
					line = sr.ReadLine();
					Match match = Regex.Match(line, "^ciao.*[0-9]$", RegexOptions.IgnoreCase);
					string match_word = "";
					if (match.Success)
					{
						match_word = match.Groups[0].Value;
						// logger is log4net
						//logger.Info("will now process " + match_word);
						Debug.WriteLine("will now process " + match_word);
						var cur_task = Task<bool>.Factory.StartNew(() =>
						                                           utility.random_waiting_method(match_word), TaskCreationOptions.LongRunning);
						lst_task.Add(cur_task);
					}
				}
			}
			*/
			using (StreamReader sr = new StreamReader(@"C:\SO\task\test.txt"))
			{
				//string line;
				int mycount = 0;
				while (sr.EndOfStream == false)
				{
					string line = sr.ReadLine();
					Match match = Regex.Match(line, "^ciao.*[0-9]$", RegexOptions.IgnoreCase);
					string match_word = "";
					if (match.Success)
					{
						match_word = match.Groups[0].Value;
						// logger is log4net
						Debug.WriteLine("will now process " + line);
						//string word = String.Copy(line);
						Task cur_task = new Task(() => utility.random_waiting_method(
							match_word
							//line
							//word
							+ "_"+ (++mycount).ToString()), TaskCreationOptions.LongRunning);
						Debug.WriteLine("first loop count: " + mycount.ToString());
						lst_task.Add(cur_task);
						//cur_task.Start();
					}
				}

			}
			foreach(Task t in lst_task)
			{
				t.Start();
			}
			Task.WaitAll(lst_task.ToArray());
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
		

	}
}