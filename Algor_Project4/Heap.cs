
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algor_Project4
{
    public class Heap<T> where T: IComparable
    {
        public List<T> Items = new List<T>();


        /// <summary>
        /// Returns Count of <list type="T">Items</list>
        /// </summary>
        public int Count
        {
            get { return Items.Count; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Heap()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Flush the Heap
        /// </summary>
        public void Flush()
        {
            Items.Clear();
        }

        public void Insert(T Item)
        {
            // Add item to List
            Items.Add(Item);

            int child = Items.Count - 1;

            while (child > 0)
            {
                int parent = (child - 1) / 2;

                if (Items[child].CompareTo(Items[parent]) >= 0)
                    break;

                // Swap
                Swap(ref child, ref parent);
            }
        }

        /// <summary>
        /// Swaps data items
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void Swap(ref int x, ref int y)
        {
            T Temp = Items[x];
            Items[x] = Items[y];
            Items[y] = Temp;
            x = y;
        }

        /// <summary>
        /// Extracts the top of Heap (Tree) T
        /// </summary>
        /// <returns></returns>
        public T ExtractMin()
        {
            if (Items.Count < 0)
            {
                throw new NullReferenceException();
            }

            int lastItem = Items.Count - 1;
            T First = Items[0];
            Items[0] = Items[lastItem];
            Items.RemoveAt(lastItem);

            int parent = 0;

            lastItem--;

            while (true)
            {
                int left = parent * 2 + 1;

                if (left > lastItem)
                    break;

                int right = left + 1;

                if (right <= lastItem && Items[right].CompareTo(Items[left]) < 0)
                    left = right;

                if (Items[parent].CompareTo(Items[left]) <= 0)
                    break;

                Swap(ref parent, ref left);
            }

            return First;
        }


        public void Sort()
        {
            Items.Sort();
        }


        /// <summary>
        /// Writes the current Heap to a file
        /// </summary>
        /// <param name="FileName">the file name</param>
        /// <param name="bNoflush">no flush heap?</param>
        /// <param name="bNoSort">no sort heap?</param>
        public void WriteToFile(string FileName = "data.bin", bool bNoflush = false, bool bNoSort = false)
        {
            if (!bNoSort)
            {
                this.Sort();
            }

            BinaryWriter binaryWriter = new BinaryWriter(File.Open(FileName, FileMode.OpenOrCreate));

            for (int i = 0; i < this.Count; i++)
            {
        
                // Was gonna write this as Generic Class, but BinaryWriter doesn't accept T out of the box.
                // I feel like writing a extension for this is out of the scope of the project.
                // I will keep it as <T> for future uses ? - 4/21/2020
                binaryWriter.Write(Convert.ToInt32(this.Items[i]));

            }

            binaryWriter.Close();

            if (!bNoflush)
            {
                this.Flush();
            }
        }
    }
}
