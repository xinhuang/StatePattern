using System.Drawing;

namespace StatePattern
{
    public class Mouse
    {
        public bool _waitForClick = true;
        public DrawerState _drawerState = DrawerState.None;
        public Point _begin;
        public Point _end;
        public Shape _shape;
        private RectangleMouse _mouseState;

        public bool WaitForClick
        {
            get { return _waitForClick; }
        }

        public Shape Shape
        {
            get { return _shape; }
        }

        public bool Process(string command)
        {
            switch (command)
            {
                case "line":
                    _drawerState = DrawerState.WaitLineBeginPoint;
                    _waitForClick = true;
                    return true;

                case "rectangle":
                    _mouseState = new RectangleMouse();
                    _drawerState = DrawerState.WaitRectangleBeginPoint;
                    _waitForClick = true;
                    return true;

                case "exit":
                    return false;

                default:
                    throw new InvalidCommandException(command + " is not recognized.");
            }
        }

        public void OnMouseClick(Point location)
        {
            switch (_drawerState)
            {
                case DrawerState.WaitLineBeginPoint:
                    _begin = location;
                    _drawerState = DrawerState.WaitLineEndPoint;
                    break;

                case DrawerState.WaitLineEndPoint:
                    _end = location;
                    _drawerState = DrawerState.None;
                    _shape = new Line(_begin, _end);
                    _waitForClick = false;
                    break;

                case DrawerState.WaitRectangleBeginPoint:
                case DrawerState.WaitRectangleEndPoint:
                    _mouseState.OnMouseClick(this, location);
                    break;

                default:
                    throw new InvalidCommandException("Draw line");
            }
        }
    }
}