namespace MarsRover
{
    public class Controller
    {
        /*
        // rover check max & min width/height
            Setup:
                ask for fileinput
                does file exist?
                if file exists:
                    validate the file
                    if not
                        keep asking if file is not valid
                    if valid
                        parse the map
                        DisplayMap(map)
                ask for rover direction from user
                    validate direction
                    if not valid
                        keep asking for valid direction
                    if valid
                    ask for rover location from user
                        validate location
                        if not valid
                            keep asking for valid location
                        if valid
                            is there an obstacle?
                            yes - back to line 21
                            no - create rover
                            DisplayMap(map, rover)
                ** test to return map with rover when setup complete
        */

        // Move logic:
        // 1/ GetTargetLocation to determine where Rover should Move to
        // 2a/ use Map.GetSquareAtLocation in order to find Square -  ?? HasObstacle - Controller
        // 2b/ use Map.HasObstacle on the square to check if there is an obstacle - Controller
        // 3/ if no obstacle, set Rover.Location to the location of that square - ?? Move
        // if there is an obstacle, Rover.Location remains the same
    }
}