using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatePattern;

namespace StatePatternTest
{
    [TestClass]
    public class Mouse_Process
    {
        private readonly Mouse _sut = new Mouse();

        [TestMethod]
        public void given_line_should_wait_for_click_set_to_true()
        {
            _sut.Process("line");
            _sut.Process("line");

            Assert.IsTrue(_sut.WaitForClick);
        }

        [TestMethod, ExpectedException(typeof(InvalidCommandException))]
        public void given_llne_should_throw_invalid_command_exception()
        {
            _sut.Process("llne");
        }
    }
}
