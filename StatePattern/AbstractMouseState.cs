using System.Drawing;

namespace StatePattern
{
    public abstract class AbstractMouseState
    {
        private bool _waitForClick = true;

        public bool WaitForClick
        {
            get { return _waitForClick; }
            protected set { _waitForClick = value; }
        }

        public abstract void OnMouseClick(IMouse mouse, Point location);
    }
}