using DrawPad;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawPadTest
{
    [TestClass]
    public class Mouse_Process
    {
        private readonly Mouse _sut = new Mouse(null);

        [TestMethod, ExpectedException(typeof(InvalidCommandException))]
        public void given_unrecoginized_commmand_should_throw_invalid_command_exception()
        {
            _sut.Process((Command)0xCAFE);
        }
    }
}
