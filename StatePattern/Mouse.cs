using System.Drawing;

namespace StatePattern
{
    public class Mouse : IMouse
    {
        private readonly IDrawPad _drawPad;
        private IMouseState _mouseState;

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
                    _mouseState = new DrawLineMouseState();
                    return true;

                case "rectangle":
                    _mouseState = new DrawRectangleState();
                    return true;

                case "exit":
                    return false;

                default:
                    throw new InvalidCommandException(command + " is not recognized.");
            }
        }

        public void OnMouseClick(Point location)
        {
            _mouseState.OnMouseClick(this, location);
        }

        public void Reset()
        {
            _mouseState = new IdleMouseState();
        }
    }
}