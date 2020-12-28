using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine()
                                        .Split("&", StringSplitOptions.RemoveEmptyEntries)
                                        .ToList();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = cmdArgs[0];
                string bookName = cmdArgs[1];
                string bookNameToSwap = string.Empty;

                switch (command)
                {
                    case "Add Book":

                        if (!books.Contains(bookName))
                        {
                            books.Insert(0, bookName);
                        }
                        break;
                    case "Take Book":
                        if (books.Contains(bookName))
                        {
                            books.Remove(bookName);
                        }
                        break;
                    case "Swap Books":
                        bookNameToSwap = cmdArgs[2];
                        if (books.Contains(bookName) && books.Contains(bookNameToSwap))
                        {
                            int firstIndex = books.FindIndex(x => x == bookName);
                            int secondIndex = books.FindIndex(x => x == bookNameToSwap);

    
                            string temporar = books[firstIndex];
                            books[firstIndex] = bookNameToSwap;
                            books[secondIndex] = bookName;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Insert Book":
                        books.Add(bookName);
                        break;

                    case "Check Book":
                        int index = int.Parse(cmdArgs[1]);
                        if (index < 0 || index > books.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{books[index]}");
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", books));
        }
    }
}
