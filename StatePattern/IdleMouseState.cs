using System.Drawing;

namespace StatePattern
{
    class IdleMouseState : AbstractMouseState
    {
        public IdleMouseState()
        {
            WaitForClick = false;
        }

        public override void OnMouseClick(Mouse mouse, Point location)
        {
        }
    }
}