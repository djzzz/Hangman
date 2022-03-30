using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            inputHandler input = new inputHandler();

            //pick difficalty
            int diffPicked = input.ReadInputInt("Pick difficulty \n 1.easy \n 2.medium \n 3.hard", "You succesfully chosen difficulty", "the input couldnt be converted to a int try again");
            Difficulty diffChossen = (Difficulty)(diffPicked - 1);

            //generate a random word
            WordGenerator wordGenerator = new WordGenerator(diffChossen);
            string word = wordGenerator.word;
            Console.WriteLine(word);
            //init a game class
            Game game = new Game(word);
            //Ask for guess
            while (!game.getGameover())
            {
                string guess = input.ReadInputString("Write a letter or a string");
                if (guess.Length == 1)
                {
                    int lifes = game.getLife();
                    //for chars
                    if (game.guessChar(guess[0]))
                    {
                        foreach (char c in game.revealer)
                        {
                            Console.Write(c + " ");
                            
                        }
                        Console.Write("\n");
                    }
                    else if (lifes == game.getLife())
                    {
                        Console.WriteLine("Char has allready been given");
                    }

                }
                else
                {
                    // do something to string inputed
                    if (!game.guessWord(guess))
                    {
                        Console.WriteLine($"Sorry {guess} was not the word");
                    }
                }
            }
            if (game.getWin())
            {
                Console.WriteLine("Congrats you won the game");
            }
            else
            {
                Console.WriteLine("Game over! you lost");
            }
                
                

        }
    }
}
