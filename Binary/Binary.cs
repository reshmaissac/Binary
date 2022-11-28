using System;

namespace CP
{
    // Requirements, Assignment/Implementation Rules:
    //  You must work with 16 bits, hint: Use an int array of 16 as a field
    //  Binary operators: ~, <<, >>
    //  Binary, Arithmatic, and Logical operators: +, -, *, /, ==, !=, <, >, <=, >= algorithms
    //      must perform in binary. Algorthims that convert to denary, perform in denary, and convert
    //      back to binary carry 0 marks.

    class Binary
    {
        #region(Fields)
        private int[] value;
        #endregion
        #region(Properties)
        #endregion
        #region(Index operator)
        #endregion
        #region(Implicit Convertors: int to Binary, Binary to int)

        public static implicit operator Binary(int num)
        {
            int positiveNum = Math.Abs(num);
            int[] array = new int[16];
            Binary bin = new Binary();
            //create int array in binary form
            for (int i = 15; positiveNum > 0; i--)
            {
                array[i] = positiveNum % 2;
                positiveNum = positiveNum / 2;
            }
            bin.value = array;
            //binary of a -ve num is equivalent to 2s complement of its +ve value.
            if (num < 0)
            {

                bin = -bin;
            }
            return bin;

        }

        public static implicit operator int(Binary bin)
        {
            int num = 0, power = 1;
            int[] array2 = bin.value;
            //Find int of signed binary.(If 1st bit  is 1 its -ve integer, else +ve integer)
            if (array2[0] == 1)
            {
                Binary bin1 = ~bin;
                bin1.value.CopyTo(array2, 0);

                AddOneToArray(array2);

                power = -1;
            }
            for (int i = (array2.Length - 1); i >= 0; i--)
            {
                num = num + (array2[i] * power);
                power = power * 2;
            }
            return num;
        }

        #endregion
        #region(Methods: ToDecimal, ToString)

        public override string ToString()
        {
            int[] array = this.value;
            string binaryString = "";
            for (int i = 0; i < array.Length; i++)
            {
                binaryString = binaryString + array[i];
                if ((i + 1) % 4 == 0)
                {
                    binaryString = binaryString + " ";
                }
            }
            //string binaryString = string.Join(string.Empty, this.value);
            //return string.Join(' ', binaryString.Chunk(size: 4).Select(b => new string(b)));
            return binaryString;
        }

        public decimal ToDecimal()
        {
            return this;

        }
        /// <summary>
        /// Private method to add 1 to binary.
        /// </summary>
        /// <param name="array"></param>
        private static void AddOneToArray(int[] array)
        {
            int mem = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array[i] = (mem + array[i] + 1) % 2;
                mem = mem + array[i] + 1 >= 2 ? 1 : 0;
            }
        }
        #endregion
        #region(Shift Opertors: Shift to left by n (<<), Shift to right by n (>>))

        public static Binary operator <<(Binary binary, int n)
        {
            int[] array = binary.value;
            for (int i = 0; i < array.Length; i++)
            {
                if ((i - n) >= 0)
                {
                    array[i - n] = array[i];
                }
            }
            // Add 0 to rightmost n bits
            for (int j = (array.Length - 1); j >= (array.Length - n); j--)
            {
                array[j] = 0;
            }
            binary.value = array;
            return binary;
        }
        public static Binary operator >>(Binary binary, int n)
        {

            int[] array = binary.value;
            for (int i = (array.Length - 1); i >= 0; i--)
            {
                if ((i + n) < array.Length)
                {
                    array[i + n] = array[i];
                }
            }
            //Add 0 to the leftmost n bits
            for (int j = 0; j < n; j++)
            {
                array[j] = 0;
            }
            binary.value = array;
            return binary;
        }
        #endregion
        #region(Binary Operators: Ones' complement, Negation)

        public static Binary operator ~(Binary binary)
        {
            Binary binary2 = new Binary();
            int[] array = new int[16];
            binary.value.CopyTo(array, 0);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    array[i] = 1;

                }
                else
                {
                    array[i] = 0;
                }
            }
            binary2.value = array;
            return binary2;
        }
        public static Binary operator -(Binary binary)
        {

            binary = ~binary;
            int[] array = binary.value;
            AddOneToArray(array);
            return binary;

        }
        #endregion
        #region(Binary Arithmatic Opertors: +, -, *, /)
        #endregion
        #region(Logical Operators: ==, !=, <, >, <=, >=)
        #endregion
    }
}
