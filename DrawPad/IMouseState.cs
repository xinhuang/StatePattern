using System.Drawing;

namespace DrawPad
{
    public interface IMouseState
    {
        void OnMouseClick(IMouse mouse, Point location);
    }
}