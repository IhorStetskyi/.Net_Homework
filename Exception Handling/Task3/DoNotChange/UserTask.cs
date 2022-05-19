namespace Task3.DoNotChange
{
    public class UserTask : IUserTask
    {
        public string Description { get; }

        public UserTask(string description)
        {
            Description = description;
        }

        
    }
}