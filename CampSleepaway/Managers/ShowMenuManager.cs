using System;
using System.Collections.Generic;
using System.Linq;

namespace SP2.Managers
{
    public class ShowMenuManager
    {
        public int ShowMenu(string prompt, List<string> options)
        {
            Console.WriteLine(prompt);

            Console.CursorVisible = false;

            int width = options.Max(option => option.Length);

            int selected = 0;
            int top = Console.CursorTop;
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                var option = options[i];
                Console.WriteLine("- " + option.PadRight(width));

                Console.ResetColor();
            }

            Console.CursorLeft = 0;
            Console.CursorTop = top - 1;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(intercept: true).Key;

                Console.CursorTop = top + selected;
                string oldOption = options[selected];
                Console.Write("- " + oldOption.PadRight(width));
                Console.CursorLeft = 0;
                Console.ResetColor();

                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Count - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }

                Console.CursorTop = top + selected;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                string newOption = options[selected];
                Console.Write("- " + newOption.PadRight(width));
                Console.CursorLeft = 0;
                Console.CursorTop = top + selected - 1;
                Console.ResetColor();
            }

            Console.CursorTop = top + options.Count;
            Console.CursorVisible = true;

            return selected;
        }
    }
}
