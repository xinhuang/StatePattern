using System;
using System.Collections.Generic;
using System.Drawing;

namespace StatePattern
{
    public class DrawPad : IDrawPad
    {
        private readonly List<Shape> _shapes = new List<Shape>();
        private readonly Mouse _mouse;

        public DrawPad()
        {
            _mouse = new Mouse(this);
        }

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
            do
            {
                OnPaint();
                if (!ProcessCommand())
                    break;
            } while (true);
        }

        public void Add(Shape shape)
        {
            _shapes.Add(shape);
            OnPaint();
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
                command = Console.ReadLine();

                Point location;
                if (!TryGetPoint(command, out location))
                {
                    Console.WriteLine("Invalid point.");
                    break;
                }

                _mouse.OnMouseClick(location);
            } while (true);

            return true;
        }

        private bool TryGetPoint(string stringValue, out Point point)
        {
            if (!stringValue.Contains(","))
            {
                point = Point.Empty;
                return false;
            }

            var values = stringValue.Split(',');
            point = new Point(Int32.Parse(values[0]), Int32.Parse(values[1]));
            return true;
        }
    }
}