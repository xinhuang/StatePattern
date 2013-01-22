using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StatePattern;

namespace StatePatternTest
{
    [TestClass]
    public class DrawLineMouseState_OnMouseClick
    {
        private readonly DrawLineMouseState _sut = new DrawLineMouseState();
        private readonly Mock<IMouse> _mockMouse = new Mock<IMouse>();
        private readonly Mock<IDrawPad> _mockPad = new Mock<IDrawPad>();

        [TestInitialize]
        public void SetUp()
        {
            _mockMouse.SetupGet(o => o.DrawPad).Returns(_mockPad.Object);
        }

        [TestMethod]
        public void given_2_click_should_add_a_line_object_to_draw_pad_and_reset_mouse()
        {
            _sut.OnMouseClick(_mockMouse.Object, new Point(1, 1));
            _sut.OnMouseClick(_mockMouse.Object, new Point(2, 2));

            _mockMouse.Verify(o => o.Reset(), Times.Once());
            _mockPad.Verify(o => o.Add(It.IsAny<Shape>()), Times.Once());
        }
    }
}
