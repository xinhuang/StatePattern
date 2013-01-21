using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatePattern;
using Rectangle = StatePattern.Rectangle;

namespace StatePatternTest
{
    [TestClass]
    public class Mouse_OnClick
    {
        private readonly Mouse _sut = new Mouse();

        [TestMethod]
        public void given_draw_line_and_2_click_should_return_a_valid_line_object()
        {
            var expectLine = new Line(new Point(1, 1), new Point(1, 2));

            _sut.Process("line");
            _sut.OnMouseClick(new Point(1, 1));
            _sut.OnMouseClick(new Point(1, 2));

            Assert.IsFalse(_sut.WaitForClick);
            Assert.AreEqual(expectLine, _sut.Shape);
        }

        [TestMethod]
        public void given_draw_line_and_1_click_should_wait_for_click()
        {
            _sut.Process("line");
            _sut.OnMouseClick(new Point(1, 1));

            Assert.IsTrue(_sut.WaitForClick);
            Assert.AreEqual(null, _sut.Shape);
        }

        [TestMethod]
        public void given_draw_rectangle_and_2_click_should_return_a_valid_rectangle_object()
        {
            var expect = new Rectangle(new Point(1, 1), new Point(1, 2));

            _sut.Process("rectangle");
            _sut.OnMouseClick(new Point(1, 1));
            _sut.OnMouseClick(new Point(1, 2));

            Assert.IsFalse(_sut.WaitForClick);
            Assert.AreEqual(expect, _sut.Shape);
        }
    }
}