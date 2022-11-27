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
        {   //if -ve number, find binary of the number without sign, then return 2s complement
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
            if (num < 0)
            {

                bin = -bin;
            }
            return bin;

        }

        public static implicit operator int(Binary bin)
        {
            throw new NotImplementedException();
            // return bin.value;

        }

        #endregion
        #region(Methods: ToDecimal, ToString)
        public override string ToString()
        {
            string binaryString = string.Join(string.Empty, this.value);
            return string.Join(' ', binaryString.Chunk(size: 4).Select(b => new string(b)));
        }

        public decimal ToDecimal()
        {
            int dec = 0, power = 1;
            int[] array2 = new int[16];

            this.value.CopyTo(array2, 0);

            if (array2[0] == 1)
            {
                Binary bin = ~this;
                bin.value.CopyTo(array2, 0);

                AddOneToArray(array2);

                power = -1;
            }

            for (int i = (array2.Length - 1); i >= 0; i--)
            {
                dec = dec + (array2[i] * power);
                power = power * 2;
            }
            return dec;
        }

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
        public static Binary operator <<(Binary binary, int count)
        {
            int[] array = binary.value;
            for (int i = 0; i < array.Length; i++)
            {
                if ((i - count) >= 0)
                {
                    array[i - count] = array[i];
                }
            }
            for (int j = (array.Length - 1); j >= (array.Length - count); j--)
            {
                array[j] = 0;
            }
            binary.value = array;
            return binary;
        }
        public static Binary operator >>(Binary binary, int count)
        {

            int[] array = binary.value;
            for (int i = (array.Length - 1); i >= 0; i--)
            {
                if ((i + count) < array.Length)
                {
                    array[i + count] = array[i];
                }
            }
            for (int j = 0; j < count; j++)
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
