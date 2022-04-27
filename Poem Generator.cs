using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace HaikuGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
                  
            Console.WriteLine("Hello and welcome to the poem generator.\nPlease enter some words or a sentence: ");
            string userInput = "";            
            userInput = Console.ReadLine();
            string[] words = userInput.Split(' ');
            List<string> original = new List<string>();
            Random rnd = new Random();
            int length = words.Length;
            Thread.Sleep(200);
            Console.WriteLine("Please enter a file name to save your work:");
            string fileName = Console.ReadLine();
            StreamWriter file;
            if (!fileName.Contains(".txt"))
            {
                fileName += ".txt";
            }
            if (File.Exists(fileName))
            {
                Console.WriteLine("A file with that name already exists. Poems will be appended to end of file");
                file = new StreamWriter(fileName, true);
            }
            else
            {
                file = new StreamWriter(fileName);
                Console.WriteLine("New file created with the name: {0}", fileName);
            }
            
            Console.WriteLine("You have entered the following words: ");
            Thread.Sleep(200);
            foreach (string word in words)
            {
                original.Add(word);
                Console.Write(word + ", ");
            }

            string originalString = string.Join(' ', original); //merges the list 'original' to originalString adding spaces between each word.
            file.WriteLine("The original words entered were: \n" + originalString); 

            for (int count = 0; count < length; count++)
            {
                int randNum = rnd.Next(length);
                string temp = words[randNum];
                words[randNum] = words[count];
                words[count] = temp;
            }
            Console.WriteLine();
            Thread.Sleep(200);

            Console.WriteLine("Please enter a number for how often you want a new line (out of 100): ");
            int chance = 0;
            bool valid = false;
            do
            {
                try
                {
                    chance = Convert.ToInt32(Console.ReadLine());
                    if (chance <= 100 || chance > 0)
                    {
                        valid = true;
                    }
                }
                catch
                {
                    Console.WriteLine("You did not enter a valid number");
                }
            } while (!valid);
            Console.WriteLine("It has now been shuffled to read the following: ");
            file.WriteLine("It has been scrambled and now reads: \n");
            foreach (string word in words)
            {
                
                if(rnd.Next(100) <= chance)
                {
                    Console.WriteLine();
                    file.WriteLine();
                }
                Console.Write(word + " ");
                file.Write(word + " ");
            }
            file.WriteLine("\n");
            file.Close();
            Console.ReadLine();
        }
    }
}
