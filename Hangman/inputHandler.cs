using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class inputHandler
    {
        public inputHandler()
        {

        }

        public string ReadInputString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public int ReadInputInt(string message, string succesMessage, string failedMessage)
        {
            bool success = false;
            bool firstTime = true;
            int picked = -1;
            Console.WriteLine(message);
            while (!success)
            {
                if (!firstTime) {
                    Console.WriteLine(failedMessage);
                }
                success =int.TryParse(Console.ReadLine(), out picked);
                firstTime = false;
            }
            Console.WriteLine(succesMessage);

            return picked;
        }
    }
}
