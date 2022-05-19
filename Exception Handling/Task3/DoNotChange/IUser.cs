using System.Collections.Generic;

namespace Task3.DoNotChange
{
    public interface IUser
    {
        /// <summary>
        /// UserTask is changed to IUserTask
        /// Please see explanation in IUserTask interface
        /// </summary>
        IList<IUserTask> Tasks { get; }
    }
}