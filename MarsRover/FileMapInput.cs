using System.IO;

namespace MarsRover
{
    // var path = "somepath.txt"

    // currently:
    // var fi = new FileInput()
    // fi.FileExists(path)
    // fi.Read(path)

    // proposed:
    // var fi = new FileInput(path)
    // fi.FileExists()
    // fi.Read()



    // hey user, enter your map
    // ONNN
    // NNNN
    // NNNN
    // NNNN
    // done

    // hey user, where should your rover be?
    // -1,2
    // hey that didn't quite look right, where should your rover be?
    // 1,1

    // hey user, which direction should your rover be facing?
    // north

    // hey user, what commands do you want to give to your rover?
    // FBLRLRLRLR


    // option 1 file
    // ONNN
    // NNNN
    // NNNN
    // NNNN

    // option 2 file
    // ONNN
    // NNNN
    // NNNN
    // NNNN
    // done
    // -1,2
    // 1,1
    // north
    // FBLRLRLRLR


    public class FileMapInput : IMapInput
    {
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public string Read(string input)
        {
            return File.ReadAllText(input);
        }
    }
}
