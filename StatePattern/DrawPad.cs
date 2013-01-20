using System;
using System.Collections.Generic;
using System.Drawing;

namespace StatePattern
{
    public class DrawPad
    {
        private readonly List<Shape> _shapes = new List<Shape>();
        private readonly Mouse _mouse = new Mouse();

        public void OnPaint()
        {
            if (_shapes.Count == 0)
            {
                Console.WriteLine("There's nothing on canvas.");
                return;
            }

            Console.WriteLine("Canvas:");
            _shapes.ForEach(s => Console.WriteLine(s.ToString()));
        }

        public void Run()
        {
            while (true)
            {
                OnPaint();
                if (!ProcessCommand())
                    break;
            }
        }

        private bool ProcessCommand()
        {
            Console.WriteLine("Please enter a command:");
            string command = Console.ReadLine();
            if (!_mouse.Process(command))
                return false;

            do
            {
                Console.WriteLine("Please enter a point:");
                string value = Console.ReadLine();
                _mouse.OnMouseClick(GetPoint(value));
            } while (_mouse.WaitForClick);

            _shapes.Add(_mouse.Shape);
            return true;
        }

        private static Point GetPoint(string stringValue)
        {
            var values = stringValue.Split(',');
            return new Point(Int32.Parse(values[0]), Int32.Parse(values[1]));
        }
    }
}