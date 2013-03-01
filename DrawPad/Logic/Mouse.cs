using System.Drawing;

namespace DrawPad.Logic
{
    public class Mouse : IMouse
    {
        private readonly IDrawPad _drawPad;
        private DrawLineState _state = DrawLineState.None;
        private Point _begin;
        private Point _end;

        enum DrawLineState
        {
            None,
            WaitBeginPoint,
            WaitEndPoint,
        }

        public Mouse(IDrawPad drawPad)
        {
            _drawPad = drawPad;
        }

        public IDrawPad DrawPad
        {
            get { return _drawPad; }
        }

        public bool Process(string command)
        {
            switch (command)
            {
                case "line":
                    _state = DrawLineState.WaitBeginPoint;
                    return true;

                case "exit":
                    return false;

                default:
                    throw new InvalidCommandException(command + " is not recognized.");
            }
        }

        public void OnMouseClick(Point location)
        {
            switch (_state)
            {
                case DrawLineState.WaitBeginPoint:
                    _begin = location;
                    _state = DrawLineState.WaitEndPoint;
                    break;

                case DrawLineState.WaitEndPoint:
                    _end = location;
                    _state = DrawLineState.WaitBeginPoint;
                    DrawPad.Add(new Line(_begin, _end));
                    break;

                default:
                    throw new InvalidCommandException("Draw line");
            }
        }
    }
}