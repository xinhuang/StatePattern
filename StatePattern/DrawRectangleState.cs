using System.Drawing;

namespace StatePattern
{
    class DrawRectangleState : AbstractMouseState
    {
        private enum State
        {
            WaitRectangleBeginPoint,
            WaitRectangleEndPoint
        }

        private Point _begin;
        private Point _end;
        private State _state = State.WaitRectangleBeginPoint;

        public override void OnMouseClick(Mouse mouse, Point location)
        {
            switch (_state)
            {
                case State.WaitRectangleBeginPoint:
                    _begin = location;
                    _state = State.WaitRectangleEndPoint;
                    break;

                case State.WaitRectangleEndPoint:
                    _end = location;
                    _state = State.WaitRectangleBeginPoint;
                    mouse.Pad.Add(new Rectangle(_begin, _end));
                    WaitForClick = false;
                    break;
            }
        }
    }
}