using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StatePattern;
using Rectangle = StatePattern.Rectangle;

namespace StatePatternTest
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

            _sut.Process("line");
            _sut.OnMouseClick(new Point(1, 1));
            _sut.OnMouseClick(new Point(1, 2));

            Assert.IsFalse(_sut.WaitForClick);
            _mockPad.Verify(o => o.Add(expect), Times.Once());
        }

        [TestMethod]
        public void given_draw_line_and_1_click_should_wait_for_click()
        {
            _sut.Process("line");
            _sut.OnMouseClick(new Point(1, 1));

            Assert.IsTrue(_sut.WaitForClick);
            _mockPad.Verify(o => o.Add(It.IsAny<Shape>()), Times.Never());
        }

        [TestMethod]
        public void given_draw_rectangle_and_2_click_should_return_a_valid_rectangle_object()
        {
            var expect = new Rectangle(new Point(1, 1), new Point(1, 2));

            _sut.Process("rectangle");
            _sut.OnMouseClick(new Point(1, 1));
            _sut.OnMouseClick(new Point(1, 2));

            Assert.IsFalse(_sut.WaitForClick);
            _mockPad.Verify(o => o.Add(expect), Times.Once());
        }
    }
}