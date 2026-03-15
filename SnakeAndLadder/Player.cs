namespace SnakeAndLadder
{
    public class Player
    {
        private string Name;
        private int id;
        public int Position {get;private set;}

        public Player(string name, int id)
        {
            Name = name;
            this.id = id; 
            Position = 0;
        }
        public string GetName()
        {
            return Name;
        }

        public int GetId()
        {
            return id;
        }
        public void Move(int newPosition)
        {
            Position = newPosition;
        }
    }
}