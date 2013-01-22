using System.Drawing;

namespace StatePattern
{
    public class Mouse
    {
        private DrawPad _pad;
        private AbstractMouseState _mouseState;

        public Mouse(DrawPad pad)
        {
            _pad = pad;
        }

        public bool WaitForClick
        {
            get { return _mouseState.WaitForClick; }
        }

        public Shape Shape
        {
            get { return _mouseState.Shape; }
        }

        public bool Process(string command)
        {
            switch (command)
            {
                case "line":
                    _mouseState = new DrawLineState();
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
    }
}