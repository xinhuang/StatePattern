using System.Drawing;

namespace StatePattern
{
    class RectangleMouse : AbstractMouseState
    {
        public override void OnMouseClick(Mouse mouse, Point location)
        {
            switch (mouse._drawerState)
            {
                case DrawerState.WaitRectangleBeginPoint:
                    mouse._begin = location;
                    mouse._drawerState = DrawerState.WaitRectangleEndPoint;
                    break;

                case DrawerState.WaitRectangleEndPoint:
                    mouse._end = location;
                    mouse._drawerState = DrawerState.None;
                    mouse._shape = new Rectangle(mouse._begin, mouse._end);
                    mouse._waitForClick = false;
                    break;
            }
        }
    }

    internal abstract class AbstractMouseState
    {
        public abstract void OnMouseClick(Mouse mouse, Point location);
    }

    class LineMouse : AbstractMouseState
    {
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
                    mouse._waitForClick = false;
                    break;
            }
        }
    }
}