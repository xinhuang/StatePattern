using System.Drawing;

namespace DrawPad
{
    public class Rectangle : Shape
    {
        public override string ToString()
        {
            return string.Format("<Rectangle ({0},{1}), ({2},{3})>",
                _topLeft.X, _topLeft.Y, _bottomRight.X, _bottomRight.Y);
        }

        protected bool Equals(Rectangle other)
        {
            return _topLeft.Equals(other._topLeft) && _bottomRight.Equals(other._bottomRight);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rectangle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_topLeft.GetHashCode()*397) ^ _bottomRight.GetHashCode();
            }
        }

        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !Equals(left, right);
        }

        private readonly Point _topLeft;
        private readonly Point _bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }
    }
}