using System.Drawing;

namespace StatePattern
{
    class LineMouse : AbstractMouseState
    {
        public override bool WaitForClick
        {
            get { return _waitForClick; }
        }

        public override void OnMouseClick(Mouse mouse, Point location)
        {
            switch (mouse._drawerState)
            {
                case DrawerState.WaitLineBeginPoint:
                    mouse._begin = location;
                    mouse._drawerState = DrawerState.WaitLineEndPoint;
                    break;

                case DrawerState.WaitLineEndPoint:
                    mouse._end = location;
                    mouse._drawerState = DrawerState.None;
                    mouse._shape = new Line(mouse._begin, mouse._end);
                    _waitForClick = false;
                    break;
            }
        }
    }
}