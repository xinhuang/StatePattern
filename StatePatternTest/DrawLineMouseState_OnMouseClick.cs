using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StatePattern;

namespace StatePatternTest
{
    [TestClass]
    public class DrawLineMouseState_OnMouseClick
    {
        [TestMethod]
        public void given_2_click_should_add_a_line_object_to_draw_pad_and_reset_mouse()
        {
            var sut = new DrawLineMouseState();
            var mockMouse = new Mock<IMouse>();
            var mockPad = new Mock<IDrawPad>();
            mockMouse.SetupGet(o => o.DrawPad).Returns(mockPad.Object);

            sut.OnMouseClick(mockMouse.Object, new Point(1, 1));
            sut.OnMouseClick(mockMouse.Object, new Point(2, 2));

            mockMouse.Verify(o => o.Reset(), Times.Once());
            mockPad.Verify(o => o.Add(It.IsAny<Shape>()), Times.Once());
        }
    }
}
