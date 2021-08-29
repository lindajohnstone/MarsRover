namespace MarsRover
{
    public interface IMapInput
    {
        string Read(string input);
        bool FileExists(string filePath);
    }
}