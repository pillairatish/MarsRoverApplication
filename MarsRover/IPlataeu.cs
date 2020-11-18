namespace MarsRover
{
    public interface IPlataeu
    {

        bool SetObjectToGridLocation(IObject rover);

        bool RemoveObjectFromGridLocation(IObject rover);

    }

    public interface IObject
    {

        string RoverName { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }

        void SetPostion(int x, int y, Direction direction);

        string GetPosition();

        void Move(string commands);
    }
}