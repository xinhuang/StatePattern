using System.Drawing;

namespace StatePattern
{
    internal abstract class AbstractMouseState
    {
        private bool _waitForClick = true;

        public bool WaitForClick
        {
            get { return _waitForClick; }
            protected set { _waitForClick = value; }
        }

        public abstract void OnMouseClick(Mouse mouse, Point location);
    }
}