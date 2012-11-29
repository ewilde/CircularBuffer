/*
 * Created by SharpDevelop.
 * User: ewilde
 * Date: 16/11/2012
 * Time: 08:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using CircularBuffer;

namespace CircularBufferConsole
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			CircularBuffer<int> items = new CircularBuffer<int>();
			
			for(int i = 0; i < 1000; i++)
			{
				items.Add(i);
			}
		
			Console.WriteLine("CircularBuffer<int> default capacity, current count: " + items.Count);
			
			ObservableCollection<int> obserableItems = new CircularObservableBuffer<int>(items);
			Console.WriteLine("ObservableCollection<int> default capacity, current count: " + items.Count);
			
			obserableItems.CollectionChanged += (sender, eventArgs) =>
			{
				Console.WriteLine(eventArgs.Action);
			};
			
			for(int i = 0; i < 1000; i++)
			{
				obserableItems.Add(i);
			}
			
			Console.WriteLine("ObservableCollection<int> default capacity, current count: " + obserableItems.Count);
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			
		}
	}
}