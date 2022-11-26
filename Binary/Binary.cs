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
            int[] array = new int[16];
            //create int array in binary form
            for (int i = 15; num > 0; i--)
            {
                array[i] = num % 2;
                num = num / 2;
            }

            Binary bin = new Binary();
            bin.value = array;
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
            //int[] array = this.value;

            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public static Binary operator -(Binary binary)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region(Binary Arithmatic Opertors: +, -, *, /)
        #endregion
        #region(Logical Operators: ==, !=, <, >, <=, >=)
        #endregion
    }
}
