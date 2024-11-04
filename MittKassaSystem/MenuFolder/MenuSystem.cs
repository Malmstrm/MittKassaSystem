using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.MenuFolder
{
    public class MenuSystem
    {
        private int selectionIndex;
        private string[] options;
        private string prompt;
        public MenuSystem(string prompt, string[] options)
        {
            this.prompt = prompt;
            this.options = options;
            this.selectionIndex = 0;
        }
        private void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine($"{prompt}\n");

            for (int i = 0; i < options.Length; i++)
            {
                string currentIndex = options[i];

                if (i == selectionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"    {currentIndex}    ");
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow || keyPressed == ConsoleKey.W)
                {
                    selectionIndex--;
                    if (selectionIndex < 0)
                    {
                        selectionIndex = options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow || keyPressed == ConsoleKey.S)
                {
                    selectionIndex++;
                    if (selectionIndex >= options.Length)
                    {
                        selectionIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return selectionIndex;
        }

    }
}
