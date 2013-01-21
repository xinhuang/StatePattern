using System.Drawing;

namespace StatePattern
{
    public class Mouse
    {
        private bool _waitForClick = true;
        private LineDrawer _drawer = LineDrawer.None;
        private Point _begin;
        private Point _end;
        private Shape _shape;

        enum LineDrawer
        {
            None,
            WaitLineBeginPoint,
            WaitLineEndPoint,
            WaitRectangleBeginPoint,
            WaitRectangleEndPoint
        }

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
                    _drawer = LineDrawer.WaitLineBeginPoint;
                    _waitForClick = true;
                    return true;

                case "rectangle":
                    _drawer = LineDrawer.WaitRectangleBeginPoint;
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
            switch (_drawer)
            {
                case LineDrawer.WaitLineBeginPoint:
                    _begin = location;
                    _drawer = LineDrawer.WaitLineEndPoint;
                    break;

                case LineDrawer.WaitLineEndPoint:
                    _end = location;
                    _drawer = LineDrawer.None;
                    _shape = new Line(_begin, _end);
                    _waitForClick = false;
                    break;

                case LineDrawer.WaitRectangleBeginPoint:
                    _begin = location;
                    _drawer = LineDrawer.WaitRectangleEndPoint;
                    break;

                case LineDrawer.WaitRectangleEndPoint:
                    _end = location;
                    _drawer = LineDrawer.None;
                    _shape = new Rectangle(_begin, _end);
                    _waitForClick = false;
                    break;

                default:
                    throw new InvalidCommandException("Draw line");
            }
        }
    }
}