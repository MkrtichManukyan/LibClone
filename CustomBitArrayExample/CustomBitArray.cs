using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomBitArrayExample
{
    class CustomBitArray
    {
        private byte[] data;

        public int Length { get; private set; }

        public CustomBitArray(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than 0.");
            }

            Length = length;
            int arraySize = (int)Math.Ceiling(length / 8.0);
            data = new byte[arraySize];
        }

        public bool this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                int byteIndex = index / 8;
                int bitIndex = index % 8;

                return (data[byteIndex] & (1 << bitIndex)) != 0;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                int byteIndex = index / 8;
                int bitIndex = index % 8;

                if (value)
                {
                    data[byteIndex] |= (byte)(1 << bitIndex);
                }
                else
                {
                    data[byteIndex] &= (byte)~(1 << bitIndex);
                }
            }
        }
    }
}