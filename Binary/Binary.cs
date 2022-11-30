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
        private int[] arr = new int[16];
        #endregion 
        #region(Properties)
        public int Length { get { return arr.Length; } }
        #endregion
        #region(Index operator)
        public int this[int i]
        {
            get => arr[i];
            set => arr[i] = value;
        }
        #endregion
        #region(Implicit Convertors: int to Binary, Binary to int)

        public static implicit operator Binary(int num)
        {
            try
            {

                Binary bin = new Binary();
                
                int positiveNum = Math.Abs(num);

                //populate array with binary bits using index operator
                for (int i = 15; positiveNum > 0; i--)
                {
                    bin[i] = positiveNum % 2;
                    positiveNum = positiveNum / 2;
                }
                //binary of a -ve num is equivalent to 2s complement of its +ve value.
                if (num < 0)
                {

                    bin = -bin;
                }
                return bin;
            }
            catch
            {
                return null;
            }

        }

        public static implicit operator int(Binary binary)
        {
            try
            {
                int num = 0, power = 1;
                Binary bin1 = binary;
                //Find int of signed binary.(If 1st bit  is 1 its -ve integer, else +ve integer)
                if (binary[0] == 1)
                {
                    bin1 = ~binary;
                    AddOneToBinary(bin1);
                    power = -1;
                }
                for (int i = (bin1.Length - 1); i >= 0; i--)
                {
                    num = num + (bin1[i] * power);
                    power = power * 2;
                }
                return num;

            }
            catch
            {
                return 0;
            }
        }

        #endregion
        #region(Methods: ToDecimal, ToString)

        public override string ToString()
        {
            try
            {
                string binaryString = "";
                for (int i = 0; i < this.Length; i++)
                {
                    binaryString = binaryString + this[i];
                    if ((i + 1) % 4 == 0)
                    {
                        binaryString = binaryString + " ";
                    }
                }
                return binaryString;
            }
            catch
            {
                return string.Empty;
            }
        }

        public decimal ToDecimal()
        {
            return this;

        }
        /// <summary>
        /// Private method to add 1 to binary.
        /// </summary>
        /// <param name="array"></param>
        private static void AddOneToBinary(Binary binArray)
        {
            int mem = 0;
            for (int i = binArray.Length - 1; i >= 0; i--)
            {
                binArray[i] = (mem + binArray[i] + 1) % 2;
                mem = mem + binArray[i] + 1 >= 2 ? 1 : 0;
            }
        }
        public static Binary operator +(Binary bin1, Binary bin2)
        {
            int mem = 0;
            Binary result = new Binary();
            for (int i = bin1.Length - 1; i >= 0; i--)
            {
                result[i] = (mem + bin1[i] + bin2[i]) % 2;
                mem = mem + bin1[i] + bin2[i] >= 2 ? 1 : 0;
            }
            return result;
        }

        public static Binary operator -(Binary bin1, Binary bin2)
        {
            bin2 = -bin2;
            return bin1+bin2;
        }
        public static Binary operator *(Binary bin1, Binary bin2)
        {
            Binary result = new Binary();
           
            
            for (int i = bin1.Length - 1; i >= 0; i--)
            {
                if (i == 15)
                {
                    if (bin2[15] == 1)
                    {
                        result = bin1;
                    }
                    else
                    {
                        result = 0;
                    }
                    
                } else
                {
                    if (bin2[i] == 1)
                    {
                        bin1 = bin1 << 1;
                        result = result + bin1;
                    }
                    else
                    {
                        //result = result<<1;
                        bin1 = bin1 << 1;
                    }
                }
               

            }
            return result;
        }
        #endregion
        #region(Shift Opertors: Shift to left by n (<<), Shift to right by n (>>))

        public static Binary operator <<(Binary binary, int n)
        {
            try
            {
                for (int i = 0; i < binary.Length; i++)
                {
                    if ((i - n) >= 0)
                    {
                        binary[i - n] = binary[i];
                    }
                }
                // Add 0 to rightmost n bits
                for (int j = (binary.Length - 1); j >= (binary.Length - n); j--)
                {
                    binary[j] = 0;
                }
                return binary;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static Binary operator >>(Binary binary, int n)
        {
            try
            {
                for (int i = (binary.Length - 1); i >= 0; i--)
                {
                    if ((i + n) < binary.Length)
                    {
                        binary[i + n] = binary[i];
                    }
                }
                //Add 0 to the leftmost n bits
                for (int j = 0; j < n; j++)
                {
                    binary[j] = 0;
                }
                return binary;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #region(Binary Operators: Ones' complement, Negation)

        public static Binary operator ~(Binary binary)
        {
            try
            {
                Binary binary2 = new Binary();

                for (int i = 0; i < binary.Length; i++)
                {
                    if (binary[i] == 0)
                    {
                        binary2[i] = 1;

                    }
                    else
                    {
                        binary2[i] = 0;
                    }
                }
                return binary2;
            }
            catch
            {
                return null;
            }
        }
        public static Binary operator -(Binary binary)
        {

            Binary bin = ~binary;
            AddOneToBinary(bin);
            return bin;

        }
        #endregion
        #region(Binary Arithmatic Opertors: +, -, *, /)
        #endregion
        #region(Logical Operators: ==, !=, <, >, <=, >=)

        public static bool operator ==(Binary bin1, Binary bin2)
        {
            if (bin1 != bin2)
            {
                return false;
            }
            
            return true;
        }
        public static bool operator !=(Binary bin1, Binary bin2)
        {
            for (int i = 0; i < bin1.Length; i++)
            {
                if (bin1[i] != bin2[i])
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
