using System.Drawing;

namespace DrawPad.Logic
{
    public interface IMouseState
    {
        void OnMouseClick(IMouse mouse, Point location);
    }
}