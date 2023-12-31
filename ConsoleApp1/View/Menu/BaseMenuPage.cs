﻿namespace PharmacyApp.View.Menu
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class BaseMenuPage
    {
        private readonly Point _position;
        private readonly List<string> _drives;
        private int _selectedIndex;

        public string Drive => _drives[_selectedIndex];
        protected virtual List<string> Items{ get;}
        public BaseMenuPage()
        {
            _position = new Point(Console.WindowWidth / 2 - Items[0].Length / 2, Console.WindowHeight / 2 - Items.Count() / 2);
            _drives = Items;
        }

        public BaseMenuPage(List<string> items)
        {
            _position = new Point(Console.WindowWidth / 2 - items[0].Length / 2, Console.WindowHeight / 2 - items.Count() / 2);
            _drives = items;
        }

        public void Draw()
        {
            Point backupPos = new Point(Console.CursorLeft, Console.CursorTop);
            Console.SetCursorPosition(_position.X, _position.Y);

            for (int i = 0; i < _drives.Count; i++)
            {
                Console.ForegroundColor = i == _selectedIndex ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine(_drives[i] + " ");
                Console.SetCursorPosition(Console.CursorLeft + _position.X, Console.CursorTop);
            }
            Console.ResetColor();
            Console.SetCursorPosition(backupPos.X, backupPos.Y);
        }

        public void Next()
        {
            _selectedIndex = (_selectedIndex + 1) % _drives.Count;
            Draw();
        }

        public void Previous()
        {
            _selectedIndex = _selectedIndex == 0 ? _drives.Count - 1 : _selectedIndex - 1;
            Draw();
        }

        public string GetSelectedItem()
        {
            return _drives[_selectedIndex];
        }

        public string WaitingForInput()
        {
            string nameMenuItem = "";

            while (nameMenuItem == "")
            {
                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        Next();
                        break;
                    case ConsoleKey.UpArrow:
                        Previous();
                        break;
                    case ConsoleKey.Enter:
                        nameMenuItem = GetSelectedItem();
                        break;
                }
            }
            return nameMenuItem;
        }
    }
}
