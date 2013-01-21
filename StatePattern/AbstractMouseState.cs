using System.Drawing;

namespace StatePattern
{
    internal abstract class AbstractMouseState
    {
        protected bool _waitForClick = true;

        public virtual bool WaitForClick
        {
            get { return _waitForClick; }
        }

        public abstract void OnMouseClick(Mouse mouse, Point location);
    }
}