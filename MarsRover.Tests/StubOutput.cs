using System.Collections.Generic;

namespace MarsRover.Tests
{
    public class StubOutput : IOutput
    {
        public StubOutput()
        {
        }

        public List<string> OutputList { get; private set; } = new List<string>();

        public void WriteLine(string value)
        {
            OutputList.Add(value);
        }

        public string GetLastMapOutput()
        {
            return OutputList[^6];
        }
    }
}
