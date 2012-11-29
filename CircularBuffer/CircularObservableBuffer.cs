/*
 * Created by SharpDevelop.
 * User: ewilde
 * Date: 28/11/2012
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace CircularBuffer
{
	/// <summary>
	/// Description of CircularObservableBuffer.
	/// </summary>
	public class CircularObservableBuffer<T> : ObservableCollection<T>
	{	
		private int maxCapacity = 4;
		
		public CircularObservableBuffer()
		{
		}
		
		
		public CircularObservableBuffer(int maxCapacity)
		{
			this.MaxCapacity = maxCapacity;
		}
		
		public CircularObservableBuffer(List<T> list) : base(list)
		{		
		}
		
		public CircularObservableBuffer(IEnumerable<T> collection) : base(collection)
        {
        }
		
		public int MaxCapacity 
		{
			get
			{
				return this.maxCapacity;
			}
			
			set
			{
				this.maxCapacity = value;				
			}
		}
		
		protected override void InsertItem(int index, T item)
		{
			this.EnforceMaximumItems();
			base.InsertItem(index >= this.Count ? this.Count - 1 : index, item);
		}
		
		private void EnforceMaximumItems()
		{
			while(this.Count >= this.maxCapacity)
			{
				this.RemoveAt(0);
			}
		}
	}
}
