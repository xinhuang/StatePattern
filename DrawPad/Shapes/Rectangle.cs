using System.Drawing;

namespace DrawPad.Shapes
{
    public class Rectangle : Shape
    {
        private readonly Point _topLeft;
        private readonly Point _bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        #region Override Equals
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
        #endregion
    }
}