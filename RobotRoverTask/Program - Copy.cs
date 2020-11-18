//using System;
//using System.ComponentModel;

//namespace RobotRoverTask
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Plataeu plataeu = new Plataeu(40, 30);
//            Rover rover = new Rover(plataeu);
//            rover.SetPostion(10, 10, Direction.North);
//            rover.Move("R1R3L2L1");
//            Console.WriteLine(rover.GetPosition());

//        }
//    }

//    public class Plataeu
//    {
//        public int SizeX { get; set; }
//        public int SizeY { get; set; }
//        public Plataeu(int sizeX, int sizeY )
//        {
//            this.SizeX = sizeX;
//            this.SizeY = sizeY;
//        }


//    }

//    public class Rover
//    {

//        private Plataeu Plateau{ get; set; }
//        public int PosX { get; set; }
//        public int PosY { get; set; }

//        public Rover(Plataeu plataeu )
//        {
//            this.Plateau = plataeu;

//        }
//        public Direction Direction{ get; set; }
        

//        public void SetPostion(int x, int y, Direction direction)
//        {
//            this.PosX = x;
//            this.PosY = y;
//            this.Direction = direction;
//        }

//        public void Move(string commands)
//        {
            
//            var charCommands = commands.ToCharArray();
//            for(int i=0;i< charCommands.Length;i++)
//            {
//                int steps;
//                if(!int.TryParse(charCommands[i].ToString(), out steps))
//                {

//                    MoveDirection(charCommands[i]);
//                }
//                else
//                {
//                    MoveSteps(steps);

//                }
                
                
//            }

//        }

//        public string GetPosition()
//        {
//            return this.PosX + " " + this.PosY + " " + this.Direction;
//        }

//        private void MoveSteps(int steps)
//        {
//            int currentPosX = this.PosX;
//            int currentPosY = this.PosY;
//            Direction currentDirection = this.Direction;

//            switch (this.Direction)
//            {

//                case Direction.North:
//                    this.PosY += steps;
//                    break;
//                case Direction.West:
//                        this.PosX -= steps;
//                    break;
//                case Direction.East:
//                        this.PosX += steps;
//                    break;
//                case Direction.South:
//                    if(this.PosY>0)
//                        this.PosY -= steps;
//                    break;
//            }

//            if (this.PosX < 0 || this.PosY < 0)
//            {
//                this.PosX = currentPosX;
//                this.PosY = this.PosY;
//                this.Direction = currentDirection;
//                throw new ApplicationException("Fell off from the Plateau .. Resetting to the previous value");
                
//            }
                

//        }

//        private void MoveDirection(char direction)
//        {
//            if (direction == 'L')
//            {
//                MoveLeft();
//            }
//            else if(direction=='R')
//            {
//                MoveRight();
//            }
//        }

//        private void MoveRight()
//        {
//            switch (this.Direction)
//            {

//                case Direction.North:
//                    this.Direction = Direction.East;
//                    break;
//                case Direction.West:
//                    this.Direction = Direction.North;
//                    break;
//                case Direction.East:
//                    this.Direction= Direction.South;
//                    break;
//                case Direction.South:
//                    this.Direction = Direction.West;
//                    break;

//            }
//        }

//        private void MoveLeft()
//        {
//            switch (this.Direction)
//            {

//                case Direction.North:
//                    this.Direction = Direction.West;
//                    break;
//                case Direction.West:
//                    this.Direction = Direction.South;
//                    break;
//                case Direction.East:
//                    this.Direction = Direction.North;
//                    break;
//                case Direction.South:
//                    this.Direction = Direction.East;
//                    break;

//            }
//        }
//    }

//    public enum Direction
//    {
//        North,
//        South,
//        East,
//        West

//    }
//}
