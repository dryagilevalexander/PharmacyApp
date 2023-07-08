using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public static class Utils
    {
        public static string GetValue(int numberOfDigits)
        {
            StringBuilder sb = new StringBuilder(numberOfDigits);
            int curStart = Console.CursorLeft;
            int curOffset = 0;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if(keyInfo.Key == ConsoleKey.Escape)
                {
                    return "AbortOperation";
                }
                if (char.IsDigit(keyInfo.KeyChar) && sb.Length < numberOfDigits)
                {
                    sb.Insert(curOffset, keyInfo.KeyChar);
                    curOffset++;
                    Console.Write(keyInfo.KeyChar);
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow && curOffset > 0) curOffset--;
                if (keyInfo.Key == ConsoleKey.RightArrow && curOffset < sb.Length) curOffset++;
                if (keyInfo.Key == ConsoleKey.Backspace && curOffset > 0)
                {
                    curOffset--;
                    sb.Remove(curOffset, 1);
                    Console.CursorLeft = curStart;
                    Console.Write(sb.ToString().PadRight(numberOfDigits));
                }
                if (keyInfo.Key == ConsoleKey.Delete && curOffset < sb.Length)
                {
                    sb.Remove(curOffset, 1);
                    Console.CursorLeft = curStart;
                    Console.Write(sb.ToString().PadRight(numberOfDigits));
                }
                Console.CursorLeft = curStart + curOffset;
            }
            while (!(keyInfo.Key == ConsoleKey.Enter && sb.Length > 0));
            Console.WriteLine();
            return sb.ToString();
        }

        public static string GetNameValue(int numberOfChars)
        {
            StringBuilder sb = new StringBuilder(numberOfChars);
            int curStart = Console.CursorLeft;
            int curOffset = 0;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "AbortOperation";
                }
                if ((char.IsDigit(keyInfo.KeyChar) || char.IsLetter(keyInfo.KeyChar) || char.IsWhiteSpace(keyInfo.KeyChar) || char.IsSymbol(keyInfo.KeyChar)) && sb.Length < numberOfChars && keyInfo.Key != ConsoleKey.Enter)
                {
                    sb.Insert(curOffset, keyInfo.KeyChar);
                    curOffset++;
                    Console.Write(keyInfo.KeyChar);
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow && curOffset > 0) curOffset--;
                if (keyInfo.Key == ConsoleKey.RightArrow && curOffset < sb.Length) curOffset++;
                if (keyInfo.Key == ConsoleKey.Backspace && curOffset > 0)
                {
                    curOffset--;
                    sb.Remove(curOffset, 1);
                    Console.CursorLeft = curStart;
                    Console.Write(sb.ToString().PadRight(numberOfChars));
                }
                if (keyInfo.Key == ConsoleKey.Delete && curOffset < sb.Length)
                {
                    sb.Remove(curOffset, 1);
                    Console.CursorLeft = curStart;
                    Console.Write(sb.ToString().PadRight(numberOfChars));
                }
                Console.CursorLeft = curStart + curOffset;
            }
            while (!(keyInfo.Key == ConsoleKey.Enter && sb.Length > 0));
            Console.WriteLine();
            return sb.ToString();
        }

        public static string GetAddressValue(int numberOfChars)
        {
            StringBuilder sb = new StringBuilder(numberOfChars);
            int curStart = Console.CursorLeft;
            int curOffset = 0;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return "AbortOperation";
                }
                if ((char.IsDigit(keyInfo.KeyChar) || char.IsLetter(keyInfo.KeyChar) || char.IsWhiteSpace(keyInfo.KeyChar) || char.IsSymbol(keyInfo.KeyChar) || char.IsPunctuation(keyInfo.KeyChar)) && sb.Length < numberOfChars && keyInfo.Key != ConsoleKey.Enter)
                {
                    sb.Insert(curOffset, keyInfo.KeyChar);
                    curOffset++;
                    Console.Write(keyInfo.KeyChar);
                }
                if (keyInfo.Key == ConsoleKey.LeftArrow && curOffset > 0) curOffset--;
                if (keyInfo.Key == ConsoleKey.RightArrow && curOffset < sb.Length) curOffset++;
                if (keyInfo.Key == ConsoleKey.Backspace && curOffset > 0)
                {
                    curOffset--;
                    sb.Remove(curOffset, 1);
                    Console.CursorLeft = curStart;
                    Console.Write(sb.ToString().PadRight(numberOfChars));
                }
                if (keyInfo.Key == ConsoleKey.Delete && curOffset < sb.Length)
                {
                    sb.Remove(curOffset, 1);
                    Console.CursorLeft = curStart;
                    Console.Write(sb.ToString().PadRight(numberOfChars));
                }
                Console.CursorLeft = curStart + curOffset;
            }
            while (!(keyInfo.Key == ConsoleKey.Enter && sb.Length > 0));
            Console.WriteLine();
            return sb.ToString();
        }
    }
}
