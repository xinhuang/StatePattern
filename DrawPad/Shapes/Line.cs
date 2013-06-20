using System.Drawing;

namespace DrawPad.Shapes
{
    public class Line : Shape
    {
        private readonly Point _begin;
        private readonly Point _end;

        public Line(Point begin, Point end)
        {
            _begin = begin;
            _end = end;
        }

        #region Override Equals
        protected bool Equals(Line other)
        {
            return _begin.Equals(other._begin) && _end.Equals(other._end);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_begin.GetHashCode() * 397) ^ _end.GetHashCode();
            }
        }

        public static bool operator ==(Line left, Line right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Line left, Line right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}