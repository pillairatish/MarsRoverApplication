using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plataeu :IPlataeu
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Grid[,] Grid;
        public Plataeu(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Grid = new Grid[sizeX, sizeY];
        }

        public bool SetObjectToGridLocation(IObject rover)
        {
            if (this.Grid[rover.PosX, rover.PosY] == null)
                this.Grid[rover.PosX, rover.PosY] = new Grid();

            if (this.Grid[rover.PosX, rover.PosY].Rover == null)
            {
                this.Grid[rover.PosX, rover.PosY].Rover = rover;
                return true;
            }
            else
            {
                throw new ApplicationException(this.Grid[rover.PosX, rover.PosY].Rover.RoverName + " already at the posion " + rover.PosX + " " + rover.PosY );
            }
            
        }

        public bool RemoveObjectFromGridLocation(IObject rover)
        {
            this.Grid[rover.PosX, rover.PosY].Rover = null;
            return true;

        }

    }
}
