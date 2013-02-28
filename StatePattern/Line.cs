using System.Drawing;

namespace StatePattern
{
    public class Line : Shape
    {
        protected bool Equals(Line other)
        {
            return _begin.Equals(other._begin) && _end.Equals(other._end);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_begin.GetHashCode()*397) ^ _end.GetHashCode();
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

        private readonly Point _begin;
        private readonly Point _end;

        public Line(Point begin, Point end)
        {
            _begin = begin;
            _end = end;
        }

        public override string ToString()
        {
            return string.Format("<Line ({0},{1}), ({2},{3})>", _begin.X, _begin.Y, _end.X, _end.Y);
        }
    }
}