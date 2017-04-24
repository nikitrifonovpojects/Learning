using System;
using System.Text;

namespace EncodeEncrypt
{
    public class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();

            var textCypher = Encrypt(message, cypher) + cypher;
            var compressed = Encode(textCypher) + cypher.Length;

            Console.WriteLine(compressed);
        }

        public static string Encode(string message)
        {
            var encodedText = new StringBuilder(message.Length);
            int indexMessage = 0;
            while (indexMessage < message.Length)
            {
                char currentSymbol = message[indexMessage];
                int scanIndex = indexMessage + 1;
                int repeatLength = 1;
                while (scanIndex < message.Length && message[scanIndex] == currentSymbol)
                {
                    repeatLength++;
                    scanIndex++;
                }

                indexMessage = scanIndex;
                if (repeatLength > 2)
                {
                    encodedText.Append(repeatLength);
                    encodedText.Append(currentSymbol);
                }
                else
                {
                    encodedText.Append(new string(currentSymbol, repeatLength));
                }
            }

            return encodedText.ToString();
        }

        public static string Encrypt(string message, string cypher)
        {
            var cypherText = new StringBuilder(message);
            var maxlenght = Math.Max(message.Length, cypher.Length);

            for (int i = 0; i < maxlenght; i++)
            {
                var messageIndex = i % message.Length;
                var cypherIndex = i % cypher.Length;
                var charInMessage = cypherText[messageIndex] - 'A';
                var charInCypher = cypher[cypherIndex] - 'A';

                cypherText[messageIndex] = (char)('A' + (charInMessage ^ charInCypher));
            }

            return cypherText.ToString();
        }
    }
}
