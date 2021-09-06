using System.Collections.Generic;

namespace MarsRover.Tests
{
    public class StubOutput : IOutput
    {
        public StubOutput()
        {
        }

        public List<string> OutputList { get; private set; } = new List<string>();

        public void Write(string value)
        {
            OutputList.Add(value);
        }

        public void WriteLine(string value)
        {
            OutputList.Add(value);
        }

        public string GetLastOutput()
        {
            return OutputList[^1];
        }

        public string GetLastMapOutput()
        {
            return OutputList[^6];
        }
    }
}
