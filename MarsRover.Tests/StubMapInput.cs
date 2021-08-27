namespace MarsRover.Tests
{
    public class StubMapInput : IMapInput
    {
        public StubMapInput()
        {
        }

        public bool FileExists(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public string Read(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}