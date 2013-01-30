using System.Drawing;

namespace StatePattern
{
    public interface IMouseState
    {
        void OnMouseClick(IMouse mouse, Point location);
    }
}