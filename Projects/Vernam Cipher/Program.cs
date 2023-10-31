using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vernam_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the message to encrypt: ");
            string message = Console.ReadLine();
            Console.WriteLine("Enter the key: ");
            string key = Console.ReadLine();
            string encryptedMessage = Encrypt(message, key);
            Console.WriteLine(encryptedMessage);

            

        }
        static string Encrypt(string message, string key)
        {
            string encryptedMessage = "";
            for (int i = 0; i < message.Length; i++)
            {
                int messageChar = (int)message[i];
                int keyChar = (int)key[i];
                int encryptedChar = messageChar ^ keyChar;
                encryptedMessage += (char)encryptedChar;
            }
            return encryptedMessage;
        }
    }
}
