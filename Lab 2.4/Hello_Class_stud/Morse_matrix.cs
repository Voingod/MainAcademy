using System;
using System.Text;
using System.Threading;

namespace Hello_Class_stud
{
    //Implement class Morse_matrix derived from String_matrix, which realize IMorse_crypt
    class Morse_matrix: String_matrix, IMorse
    {
        public const int Size_2 = Alphabet.Size;
        private int offset_key = 0;
        private const int wordPositionStart = 0;
        private const int signalPositionStart = 1;

        public int Offset_key { get => offset_key; set => offset_key = value; }
        public string Morse { get; set; }
        public Morse_matrix()
        {
            fd(Alphabet.Dictionary_arr);
            sd();
        }
        //Implement Morse_matrix constructor with the int parameter for offset
        //Use fd(Alphabet.Dictionary_arr) and sd() methods
        public  Morse_matrix(int offset = 0)
        {
            Offset_key = offset;
            fd(Alphabet.Dictionary_arr);
            sd();
        }
        //Implement Morse_matrix constructor with the string [,] Dict_arr and int parameter for offset
        //Use fd(Dict_arr) and sd() methods
        public Morse_matrix(string[,] Dict_arr, int offset = 0)
        {
            Offset_key= offset;
            fd(Dict_arr);
            sd();
        }
        public Morse_matrix(string morse)
        {
            Morse = morse;
        }
        private void fd(string[,] Dict_arr)
        {
            for (int ii = 0; ii < Size1; ii++)
                for (int jj = 0; jj < Size_2; jj++)
                    this[ii, jj] = Dict_arr[ii, jj];
        }


        private  void sd()
        {
            int off = Size_2 - Offset_key;
            for (int jj = 0; jj < off; jj++)
                this[signalPositionStart, jj] = this[signalPositionStart, jj + Offset_key];
            for (int jj = off; jj < Size_2; jj++)
                this[signalPositionStart, jj] = Alphabet.Dictionary_arr[signalPositionStart, jj - off];
        }

        //Implement Morse_matrix operator +
        public static Morse_matrix operator +(Morse_matrix tbl1, Morse_matrix tbl2)
        { 
            throw new NotImplementedException();
        }
        //Realize crypt() with string parameter
        //Use indexers
        public string crypt(string cryptWord)
        {

            char[] alphabet = cryptWord.ToCharArray();
            StringBuilder resBuild = new StringBuilder();
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    if (this[wordPositionStart, j] == alphabet[i].ToString())
                    {
                        resBuild.Append(this[signalPositionStart, j]);
                    }
                }
            }
            return resBuild.ToString();
        }

        //Realize decrypt() with string array parameter
        //Use indexers
        public string decrypt(string [] decryptSignal)
        {
            StringBuilder resBuild = new StringBuilder();
            for (int i = 0; i < decryptSignal.Length; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    if (this[signalPositionStart, j] == decryptSignal[i])
                    {
                        resBuild.Append(this[wordPositionStart, j]);
                    }
                }
            }
            return resBuild.ToString();
        }


        //Implement Res_beep() method with string parameter to beep the string
        public void Res_beep(string beep)
        {
            foreach (var morse in beep)
            {
                if (morse == '.')
                {
                    Thread.Sleep(50);
                    Console.Beep(1000, 250);
                }
                else if (morse == '-')
                {
                    Thread.Sleep(50);
                    Console.Beep(1000, 750);
                }
            }
        }

    }
}

