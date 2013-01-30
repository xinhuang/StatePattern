using System.Drawing;

namespace StatePattern
{
    public class DrawLineMouseState : IMouseState
    {
        private enum State
        {
            WaitLineBeginPoint,
            WaitLineEndPoint,
        }

        private Point _begin;
        private Point _end;
        private State _state = State.WaitLineBeginPoint;

        public void OnMouseClick(IMouse mouse, Point location)
        {
            switch (_state)
            {
                case State.WaitLineBeginPoint:
                    _begin = location;
                    _state = State.WaitLineEndPoint;
                    break;

                case State.WaitLineEndPoint:
                    _end = location;
                    _state = State.WaitLineBeginPoint;
                    mouse.DrawPad.Add(new Line(_begin, _end));
                    break;
            }
        }
    }
}