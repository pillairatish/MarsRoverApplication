using MarsRover;
using System;
using System.ComponentModel;
using System.Drawing;

namespace RobotRoverTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlataeu plataeu = new Plataeu(40, 30); 

            IObject rover = new Rover(plataeu);
            rover.RoverName = "Rover1";
            rover.SetPostion(10, 10, Direction.North);
            rover.Move("R1R3L2L1");
            Console.WriteLine(rover.GetPosition());

            Rover rover1 = new Rover(plataeu);
            rover1.RoverName = "Rover2";
            rover1.SetPostion(10, 10, Direction.North);
            rover1.Move("R1R3L2L1");
            Console.WriteLine(rover1.GetPosition());


        }
    }
}

    

    

