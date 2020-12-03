using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CryptoSoft
{
    public class Encoder
    {
        public Encoder()
        {

        }

        public static void Encrypt(string source, string destination)
        {
            string text = "";
            string binaryText = "";
            string key = "lmskdjfglmsdj";
            string binaryKey = "";

            if (File.Exists(source))
            {
                StreamReader reader = new StreamReader(source);
                while (!reader.EndOfStream)
                {
                    text += reader.ReadLine();
                }
                reader.Close();


                foreach(var character in text)
                {
                    int binValue = Convert.ToInt32(character);
                    binaryText += Convert.ToString(binValue, 2).PadLeft(8,'0');
                }
                
                foreach(var character in key)
                {
                    int binValue = Convert.ToInt32(character);
                    binaryKey += Convert.ToString(binValue, 2).PadLeft(8, '0');
                }

                Console.WriteLine(text);
                Console.WriteLine(binaryText);
                Console.WriteLine(binaryText.Length);
                Console.WriteLine(key);
                Console.WriteLine(binaryKey);

                var result = new StringBuilder();

                for(int i = 0; i < binaryText.Length; i++)
                {
                    result.Append(binaryText[i] ^ binaryKey[i % binaryKey.Length]);
                }

                text = result.ToString();
                Console.WriteLine(text);

                File.WriteAllText(destination, "");
                File.WriteAllText(destination, text);

            }
        }


        public static void Decrypt(string source, string destination)
        {

        }
    }
}
