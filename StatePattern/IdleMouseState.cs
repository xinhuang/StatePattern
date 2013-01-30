using System.Drawing;

namespace StatePattern
{
    class IdleMouseState : IMouseState
    {
        public void OnMouseClick(IMouse mouse, Point location)
        {
        }
    }
}