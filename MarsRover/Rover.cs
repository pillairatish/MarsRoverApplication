using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{

    public enum Direction
    {
        North =0,
        East =1,
        South =2,
        West=3

    }

    public class Rover :IObject
    {

        private IPlataeu Plateau { get; set; }

        public string RoverName { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Rover(IPlataeu plataeu)
        {
            this.Plateau = plataeu;

        }
        public Direction Direction { get; set; }


        public void SetPostion(int x, int y, Direction direction)
        {
            var currentx = this.PosX;
            var currenty = this.PosY;
            var currentdirection = this.Direction;

            this.PosX = x;
            this.PosY = y;
            this.Direction = direction;

            if (this.PosX < 0 || this.PosY < 0)
            {
                this.PosX = currentx;
                this.PosY = currenty;
                this.Direction = currentdirection;
                throw new ApplicationException("Fell off from the Plateau .. Resetting to the previous value");

            }
            try
            {
                this.Plateau.SetObjectToGridLocation(this);
            }
            catch(ApplicationException ex)
            {
                this.PosX = currentx;
                this.PosY = currenty;
                this.Direction = currentdirection;

                Console.WriteLine(ex.Message);
                Console.WriteLine("Setting Rover to the Valid Value");
            }
            
        }

        public void Move(string commands)
        {

            var charCommands = commands.ToCharArray();
            for (int i = 0; i < charCommands.Length; i++)
            {
                int steps;
                if (!int.TryParse(charCommands[i].ToString(), out steps))
                {

                    MoveDirection(charCommands[i]);
                }
                else
                {
                    MoveSteps(steps);

                }


            }

        }

        public string GetPosition()
        {
            return this.PosX + " " + this.PosY + " " + this.Direction;
        }

        private void MoveSteps(int steps)
        {
            int currentPosX = this.PosX;
            int currentPosY = this.PosY;
            Direction currentDirection = this.Direction;

            this.Plateau.RemoveObjectFromGridLocation(this);

            switch (this.Direction)
            {

                case Direction.North:
                    SetPostion(this.PosX, this.PosY + steps, this.Direction);
                    break;
                case Direction.West:
                    SetPostion(this.PosX - steps, this.PosY, this.Direction);
                    break;
                case Direction.East:
                    SetPostion(this.PosX + steps, this.PosY, this.Direction);
                    break;
                case Direction.South:
                    SetPostion(this.PosX, this.PosY - steps, this.Direction);
                    break;
            }

            if (this.PosX < 0 || this.PosY < 0)
            {
                SetPostion(currentPosX, currentPosY, currentDirection);
                throw new ApplicationException("Fell off from the Plateau .. Resetting to the previous value");

            }


        }

        private void MoveDirection(char direction)
        {
            if (direction == 'L')
            {
                MoveLeft();
            }
            else if (direction == 'R')
            {
                MoveRight();
            }
        }

        private void MoveLeft()
        {
            if ((int)this.Direction == 0)
                this.Direction = Direction.West;
            else
                this.Direction--;

        }

        private void MoveRight()
        {
            if ((int)this.Direction == 3)
                this.Direction = Direction.North;
            else
                this.Direction++;
        }
    }

   
}
