﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
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

    public class Menu
    {
        private readonly Point _position;
        private readonly List<string> _drives;
        private int _selectedIndex;
        private string _menuName;

        public string Drive => _drives[_selectedIndex];

        public Menu(Point position, List<string> drives)
        {
            _position = position;
            _drives = drives;
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

        public void SetIndex(int index)
        {
            _selectedIndex = Math.Clamp(index, 0, _drives.Count - 1);
            Draw();
        }

        public string GetSelectedItem()
        {
            return _drives[_selectedIndex];
        }

        public void SetDrive(string drive)
        {
            SetIndex(_drives.IndexOf(drive));
        }
    }
}