using System;
using System.Collections.Generic;
using System.Text;
namespace Hangman
{
    class Game
    {
        public int life { get; set; }
        public string word;
        private StringBuilder guessedLetters;
        public char[] revealer;
        private bool win = false;
        private bool gameover = false;
        public Game(string word)
        {
            this.life = 10;
            this.word = word;
            this.revealer = new char[(word.Length)];
            for (int i = 0; i < this.revealer.Length; i++)
            {
                this.revealer[i] = '_';
            }
            this.guessedLetters = new StringBuilder();
        }
        public bool guessChar(char letter)
        {
            if (guessedLetters.ToString().Contains(letter))
            {
                return false;
            }
            bool found = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {
                    this.revealer[i] = letter;
                    found = true;
                }
            }
            if(!found)
            {
                life--;
            }
            guessedLetters.Append(letter);
            this.checkIfWin();
            return found;
        }
        public bool guessWord(string word)
        {
            if(word.ToLower() == this.word.ToLower())
            {
                gameover = true;
                win = true;
                return true;
            }
            else
            {
                life--;
                return false;
            }
        }
        private void checkIfWin()
        {
            if (life == 0)
            {
                gameover = true;
            }
            string toCheck = new string(this.revealer);
            bool isExist = toCheck.Contains('_');

            if (!isExist)
            {
                gameover = true;
                win = true;
            }
        }
        public bool getWin()
        {
            return this.win;
        }
        public int getLife()
        {
            return this.life;
        }
        public bool getGameover()
        {
            return this.gameover;
        }
    }
}
