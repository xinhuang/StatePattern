using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatePattern;

namespace StatePatternTest
{
    [TestClass]
    public class Mouse_Process
    {
        private readonly Mouse _sut = new Mouse(null);

        [TestMethod, ExpectedException(typeof(InvalidCommandException))]
        public void given_llne_should_throw_invalid_command_exception()
        {
            _sut.Process("llne");
        }
    }
}
