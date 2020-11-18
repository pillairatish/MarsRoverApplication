using System;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoverUnitTest
{
    [TestClass]
    public class When_Moving_Rover
    {
        [TestMethod]
        public void Valid_Command_Sequence_Movement_Is_Successful()
        {
            IPlataeu plataeu = new Plataeu(40, 30);

            IObject rover = new Rover(plataeu);
            rover.RoverName = "Rover1";
            rover.SetPostion(10, 10, Direction.North);
            rover.Move("R1R3L2L1");
            Console.WriteLine(rover.GetPosition());

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException), "Fell off from the Plateau .. Resetting to the previous value.")]
        public void Impermissible_Command_Sequence_Causes_Fall_Off_Plateau()
        {
            IPlataeu plataeu = new Plataeu(40, 30);

            IObject rover = new Rover(plataeu);
            rover.RoverName = "Rover2";
            rover.SetPostion(0, 0, Direction.South);
            rover.Move("R1R3L2L1");
            Console.WriteLine(rover.GetPosition());
        }
    }
}
