using System.Drawing;
using DrawPad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawPadTest
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
        public void given_2_click_should_add_a_line_object_to_draw_pad()
        {
            var expect = new Line(new Point(1, 1), new Point(2, 2));

            _sut.OnMouseClick(_mockMouse.Object, new Point(1, 1));
            _sut.OnMouseClick(_mockMouse.Object, new Point(2, 2));

            _mockPad.Verify(o => o.Add(expect), Times.Exactly(1));
        }

        [TestMethod]
        public void given_1_click_should_add_nothing_to_pad()
        {
            _sut.OnMouseClick(_mockMouse.Object, new Point(1, 1));

            _mockPad.Verify(o => o.Add(It.IsAny<Shape>()), Times.Never());
        }

        [TestMethod]
        public void given_3_clicks_should_add_a_line_object_to_draw_pad()
        {
            var expect = new Line(new Point(1, 1), new Point(2, 2));

            _sut.OnMouseClick(_mockMouse.Object, new Point(1, 1));
            _sut.OnMouseClick(_mockMouse.Object, new Point(2, 2));
            _sut.OnMouseClick(_mockMouse.Object, new Point(2, 3));

            _mockPad.Verify(o => o.Add(expect), Times.Exactly(1));
        }
    }
}
