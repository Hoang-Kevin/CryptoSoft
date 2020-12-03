using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CryptoSoft
{
    public class Encoder
    {
        public static string key = "lmskdjfglmsdj";
        public static string binaryKey = "";
        public Encoder()
        {

        }

        public static void Encrypt(string source, string destination)
        {
            string text = "";
            string binaryText = "";


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


        public static void Decrypt(string source)
        {
            string data = "";
            string text = "";
            string binary = "";
            var result = new StringBuilder();
            if (File.Exists(source))
            {
                StreamReader streamReader = new StreamReader(source);
                while (!streamReader.EndOfStream)
                {
                    binary += streamReader.ReadLine();
                }
                streamReader.Close();
                foreach (var character in key)
                {
                    int binValue = Convert.ToInt32(character);
                    binaryKey += Convert.ToString(binValue, 2).PadLeft(8, '0');
                }

                for (int c = 0; c < binary.Length; c++)
                {
                    result.Append(binary[c] ^ binaryKey[c % binaryKey.Length]);
                }
                var stringBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    if (i% 8 == 0)
                        stringBuilder.Append(' ');
                    stringBuilder.Append(result[i]);
                }
                string[] stringBytes = stringBuilder.ToString().Substring(1).Split(' ');
                string decodeMessage = "";
                Console.WriteLine(stringBytes[0]);
                foreach (var item in stringBytes)
                {
                    var number = Convert.ToInt32(item, 2);
                    decodeMessage += (char)number;

                }
                data = decodeMessage;
                File.WriteAllText(source, "");
                File.WriteAllText(source, data);

            }
        }
    }
}
