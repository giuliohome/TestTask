
using System;
using System.Diagnostics;
using System.Threading;

namespace tasksharpdev
{
	/// <summary>
	/// Description of Utility.
	/// </summary>
	public class Utility
	{
		public Utility()
		{
		}
		
		internal bool random_waiting_method(string match_word)
		{
			// do something with match_word, process time may vary
			
			
			Thread.Sleep(3000);
			Debug.WriteLine("here: "+match_word);
			return true;
		}
	}
}
