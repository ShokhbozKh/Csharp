using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercise_17
{
    class SimpleList
    {
        /*
         * Properties
         */

        #region Properties

        private int _size;
        private int _cap;
        public const int INITIAL_SIZE = 0;
        private int[] array;

        public int Size 
        {   get => _size; 
            set
            {
                _size = value;

                if(_cap <= _size)
                {
                    _cap = (int)Math.Pow(_cap, 2);
                }
            }
        }
        public int Capacity 
        { 
            get => _cap;
            set => _cap = value; 
        }

        #endregion

        /*
         * Constructors
         */

        #region Constructors

        public SimpleList()
        {
            Size = INITIAL_SIZE;
            Capacity = INITIAL_SIZE;
            array = null;
        }

        public SimpleList(int element)
        {
            int[] array = { element };
            _size = 1;
        }

        public SimpleList(int[] array)
        {
            this.array = array;
            _size = array.Length;
        }

        public SimpleList(SimpleList simpleList)
        {
            array = simpleList.array;
        }

        #endregion

        /*
         * Methods
         */

        #region Methods
        public void Clear()
        {
            Size = INITIAL_SIZE;
            Capacity = INITIAL_SIZE;
            array = null;
        }

        public void Trim()
        {
            Capacity = Size;
        }

        public SimpleList Insert(int index, int e)
        {
            if (index > Size || index < 0)
                throw new IndexOutOfRangeException("Incorrect index was provided");

            // Check if current capcaity is enough to add new element
            if(Size + 1 > Capacity)
            {
                Capacity = (int)Math.Pow(Capacity, 2);

                // Copy the old array to the new array
                int[] newArray = new int[Capacity];
                Array.Copy(array, newArray, Size);

                return this.Insert(index, e);
            }
            else
            {
                array[Size + 1] = e;

                return this;
            }
        }

        public SimpleList Insert(int index, int[] other)
        {
            // Check for correctness of index
            if (index > Size || index < 0)
                throw new IndexOutOfRangeException("Incorrect index was provided");

            // Check if current capcity is enough to add new elements
            if(other.Length + Size > Capacity)
            {
                Capacity = (int)Math.Pow(Capacity, 2);

                // Copy the old array to the new array
                int[] newArray = new int[Capacity];
                Array.Copy(array, newArray, array.Length);


                // Call the method again in case if the size is still insufficient
                return this.Insert(index, other);
            }
            else
            {
                // Declare new array
                int[] newArray = new int[Capacity];

                // Copy old array to the new array until the index position
                Array.Copy(array, newArray, index);

                // Starting from index position, copy all elements from other array to the new array
                Array.Copy(other, 0, newArray, index, other.Length);

                // Copy leftover elements from old array to the new array
                Array.Copy(array, index, newArray, index + other.Length, array.Length - index);

                // Set new size and reference for the old array to the new array
                _size = other.Length + array.Length;
                array = newArray;

                return this;
            }
            
        }

        public SimpleList Append(int e)
        {
            return Insert(Size, e);
        }

        public SimpleList Append(int[] array)
        {
            return Insert(Size, array);
        }

        public SimpleList Append(SimpleList list)
        {
            return Insert(Size, list.array);
        }

        public int Get(int index)
        {
            if (index < 0 || index > Size)
                throw new IndexOutOfRangeException("Incorrect index was provided");

            return array[index];
        }

        public SimpleList Set(int index, int value)
        {
            if (index < 0 || index > Size)
                throw new IndexOutOfRangeException("Incorrect index was provided");

            array[index] = value;
            return this;
        }

        public override string ToString()
        {
            return $"{array.Select(s => s.ToString())} ";
        }

        #endregion
    }
}
