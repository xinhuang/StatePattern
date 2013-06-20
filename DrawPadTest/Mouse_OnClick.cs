using System.Drawing;
using DrawPad;
using DrawPad.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawPadTest
{
    [TestClass]
    public class Mouse_OnClick
    {
        private readonly Mock<IDrawPad> _mockPad = new Mock<IDrawPad>();
        private Mouse _sut;

        [TestInitialize]
        public void SetUp()
        {
            _sut = new Mouse(_mockPad.Object);
        }

        [TestMethod]
        public void given_draw_line_and_2_click_should_return_a_valid_line_object()
        {
            var expect = new Line(new Point(1, 1), new Point(1, 2));

            _sut.Process(Command.DrawLine);
            _sut.OnMouseClick(new Point(1, 1));
            _sut.OnMouseClick(new Point(1, 2));

            _mockPad.Verify(o => o.Add(expect), Times.Once());
        }

        [TestMethod]
        public void given_draw_line_and_1_click_should_wait_for_click()
        {
            _sut.Process(Command.DrawLine);
            _sut.OnMouseClick(new Point(1, 1));

            _mockPad.Verify(o => o.Add(It.IsAny<Shape>()), Times.Never());
        }
    }
}