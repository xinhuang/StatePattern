using System.Drawing;

namespace StatePattern
{
    internal abstract class AbstractMouseState
    {
        private bool _waitForClick = true;
        private Shape _shape;

        public bool WaitForClick
        {
            get { return _waitForClick; }
            protected set { _waitForClick = value; }
        }

        public Shape Shape
        {
            get { return _shape; }
            protected set { _shape = value; }
        }

        public abstract void OnMouseClick(Mouse mouse, Point location);
    }
}