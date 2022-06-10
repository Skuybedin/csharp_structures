using System;

namespace Test
{
	public class DynamicArray
	{
		private int[] items;
		private int size = 0;

		public DynamicArray(int length)
		{
			items = new int[length];
		}

		public DynamicArray()
		{
			items = new int[0];
		}

		public string Print()
		{
			string result = "";

			for (int i = 0; i < size; i++)
			{
				result += items[i] + " ";
			}

			return result;
		}

		public int GetCount() => size;

		public int Get(int index)
		{
			if (index >= size || index < 0) throw new Exception("Индекс находится за пределами массива.");

			return items[index];
		}

		public int Find(int key)
		{
			for (int i = 0; i < size; i++)
			{
				if (items[i] == key) return i;
			}

			return -1;
		}

		public int FindLast(int key)
		{
			for (int i = size - 1; i > 0; i--)
			{
				if (key == items[i]) return i;
			}
			return -1;
		}

		private void IncreaseArray()
		{
			int newCount = size * 2;
			if (size == 0) newCount = 4;

			var newArray = new int[newCount];

			for (int i = 0; i < size; i++)
			{
				newArray[i] = items[i];
			}

			items = newArray;
		}

		public void PushBack(int item)
		{
			if (size == items.Length) IncreaseArray();

			items[size] = item;
			size++;
		}

		public void Insert(int index, int item)
		{
			if (index < 0 || index > size) throw new Exception("Выход за пределами массива");

			if (size == items.Length) IncreaseArray();

			for (int i = size - 1; i >= index; i--)
			{
				items[i + 1] = items[i];
			}

			items[index] = item;
			size++;
		}

		public void PushFront(int item) => Insert(0, item);

		public void PushBackRange(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (size == items.Length) IncreaseArray();

				items[size] = array[i];
				size++;
			}
		}

		public void InsertRange(int index, int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Insert(index, array[i]);
				index++;
			}
		}

		public void PopBack()
		{
			if (size == 0) throw new Exception("Массив пустой.");
			size--;
		}

		public void RemoveByIndex(int index)
		{
			if (size == 0) throw new Exception("Массив пустой!");
			if (index < 0 || index >= size) throw new Exception("Выход за пределами массива");

			for (int i = index + 1; i < size; i++)
			{
				items[i - 1] = items[i];
			}
			size--;
		}

		public void PopFront() => RemoveByIndex(0);

		public bool Remove(int item)
		{
			if (size == 0) throw new Exception("Массив пустой!");

			for (int i = 0; i < size; i++)
			{
				if (items[i] == item)
				{
					RemoveByIndex(i);
					return true;
				}
			}
			return false;
		}

		public int RemoveAll(int item)
		{
			int count = 0;
			if (size == 0) throw new Exception("Массив пустой!");

			for (int i = size - 1; i >= 0; i--)
			{
				if (items[i] == item)
				{
					RemoveByIndex(i);
					count++;
				}
			}

			return count;
		}
	}
}
