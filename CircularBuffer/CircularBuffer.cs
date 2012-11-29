/*
 * Created by SharpDevelop.
 * User: ewilde
 * Date: 16/11/2012
 * Time: 08:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace CircularBuffer
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	public class CircularBuffer<T> : IList<T>
	{
		private List<T> innerList;
		private int maxCapacity;
		
		public CircularBuffer() : this(4)
		{
		}
		
		public CircularBuffer(int maxCapacity)
		{
			this.maxCapacity = maxCapacity;
			this.innerList = new List<T>(this.maxCapacity);
		}
		
		
		public int Count {
			get {
				return this.innerList.Count;
			}
		}
		
		public bool IsReadOnly {
			get {
				return ((IList<T>)this.innerList).IsReadOnly;
			}
		}
		
		public int IndexOf(T item)
		{
			return this.innerList.IndexOf(item);
		}
		
		public void Insert(int index, T item)
		{
			this.innerList.Insert(index, item);
		}
		
		public void RemoveAt(int index)
		{
			this.innerList.RemoveAt(index);
		}
		
		public void Add(T item)
		{
			while(this.innerList.Count >= this.maxCapacity)
			{
				this.RemoveAt(0);
			}
			
			
			this.innerList.Add(item);
		}
		
		public void Clear()
		{
			this.innerList.Clear();
		}
		
		public bool Contains(T item)
		{
			return this.innerList.Contains(item);
		}
		
		public void CopyTo(T[] array, int arrayIndex)
		{
			this.innerList.CopyTo(array, arrayIndex);
		}
		
		public bool Remove(T item)
		{
			return this.innerList.Remove(item);
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			return this.innerList.GetEnumerator();
		}
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.innerList.GetEnumerator();
		}
		
		public T this[int index]
		{
			get{
				return this.innerList[index];
			}
			set{
				this.innerList[index] = value;
			}
		} 
	}
}