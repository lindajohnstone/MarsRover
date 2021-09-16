using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRover.Tests
{
    public class ControllerShould
    {
        private readonly Controller _controller;
        private Mock<IInput> _mockInput;
        private readonly StubOutput _output;
        private readonly FileMapInput _fileMapInput;
        private readonly MapGenerator _mapGenerator;
        private readonly Generator _generator;

        public ControllerShould()
        {
            _mockInput = new Mock<IInput>();
            _output = new StubOutput();
            _fileMapInput = new FileMapInput();
            _mapGenerator = new MapGenerator(_mockInput.Object, _output, _fileMapInput);
            _generator = new Generator(_mockInput.Object, _output, _mapGenerator, It.IsAny<AutoMapGenerator>());
            _controller = new Controller(_mockInput.Object, _output, _generator);
        }
        [Fact]
        public void Run_ReturnsMapOutput_GivenRoverCommandsThatResultInNoObstacle()
        {
            _mockInput.SetupSequence(_ => _.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0")
                .Returns("lfrlb")
                .Returns("q");
            var expectedString = "🟫⬜️⏪⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";

            _controller.Run();

            _output.GetLastMapOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverReport_GivenRoverCommandsThatResultInAnObstacle()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("1,0")
                .Returns("lfr")
                .Returns("q");
            var expectedString = "Rover can't move. Obstacle at 0,0.";

            _controller.Run();

            _output.OutputList.Should().Contain(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverReport_GivenRoverCommandsThatResultInAnObstacleAnd2ConsecutiveCommandsSame()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("1.0")
                .Returns("2,0")
                .Returns("lff")
                .Returns("q");
            var expectedString = "Rover can't move. Obstacle at 0,0.";
            
            _controller.Run();

            _output.OutputList.Should().Contain(expectedString);
        }

        [Fact]
        public void Run_ReturnsRoverEndLocation_GivenMapAnd2SetsOfRoverCommands()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0")
                .Returns("lff")
                .Returns("rff")
                .Returns("q");
            var expectedString = "🟫⬜️⬜️⬜️\n⬜️⏫⬜️⬜️\n⬜️⬜️⬜️⬜️";

            _controller.Run();

            _output.GetLastMapOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Run_ReturnLastMap_GivenRoverInitialLocationHasObstacle()
        {
            _mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("0,0")
                .Returns("2,0")
                .Returns("lff")
                .Returns("rff")
                .Returns("q");
            var expectedString = "🟫⬜️⬜️⬜️\n⬜️⏫⬜️⬜️\n⬜️⬜️⬜️⬜️";

            _controller.Run();

            _output.GetLastMapOutput().Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void Run_ReturnsLastMap_GivenAutoMapAndRoverCommands()
        {
            var fileMapInput = new FileMapInput();
            var output = new StubOutput();
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.ReadLine())
                .Returns("TestFiles")
                .Returns("TestFiles/validFile1.txt")
                .Returns("N")
                .Returns("2,0")
                .Returns("lfrlb")
                .Returns("q");
            var expectedString = "🟫⬜️⏪⬜️\n⬜️⬜️⬜️⬜️\n⬜️⬜️⬜️⬜️";
            var fileRegister = new FileRegister();
            var mockRandomGenerator = new Mock<IRandomGenerator>();
            mockRandomGenerator.Setup(m => m.RandomString(It.IsAny<string[]>()))
                .Returns("TestFiles/validFile1.txt");
            var map = new AutoMapGenerator(mockInput.Object, fileMapInput, fileRegister, mockRandomGenerator.Object);
            var generator = new Generator(mockInput.Object, output, It.IsAny<MapGenerator>(), map);
            var controller = new Controller(mockInput.Object, output, generator);

            controller.Run();

            output.GetLastMapOutput().Should().BeEquivalentTo(expectedString);
        }
    }
}
