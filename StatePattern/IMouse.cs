namespace StatePattern
{
    public interface IMouse
    {
        IDrawPad DrawPad { get; }
        void Reset();
    }
}