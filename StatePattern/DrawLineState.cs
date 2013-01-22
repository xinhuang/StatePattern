using System.Drawing;

namespace StatePattern
{
    class DrawLineState : AbstractMouseState
    {
        private enum State
        {
            WaitLineBeginPoint,
            WaitLineEndPoint,
        }

        private Point _begin;
        private Point _end;
        private State _state = State.WaitLineBeginPoint;

        public override void OnMouseClick(Mouse mouse, Point location)
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
                    WaitForClick = false;
                    mouse.Pad.Add(new Line(_begin, _end));
                    mouse.Reset();
                    break;
            }
        }
    }
}