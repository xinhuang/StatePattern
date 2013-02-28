using System.Drawing;

namespace DrawPad
{
    class DrawRectangleState : IMouseState
    {
        private enum State
        {
            WaitRectangleBeginPoint,
            WaitRectangleEndPoint
        }

        private Point _begin;
        private Point _end;
        private State _state = State.WaitRectangleBeginPoint;

        public void OnMouseClick(IMouse mouse, Point location)
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
                    mouse.DrawPad.Add(new Rectangle(_begin, _end));
                    break;
            }
        }
    }
}