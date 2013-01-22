using System.Drawing;

namespace StatePattern
{
    class IdleMouseState : AbstractMouseState
    {
        public IdleMouseState()
        {
            WaitForClick = false;
        }

        public override void OnMouseClick(IMouse mouse, Point location)
        {
        }
    }
}