using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.DoNotChange
{
    /// <summary>
    /// This is the only change i made in DoNotChange folder (also in IUser interface because IList was using UserTask as a generic type)
    /// I've created this interface to follow open/close principle
    /// So we can refer to interface instead of a class implementation
    /// And in any moment we can change class implementation and code still will be working.
    /// Not sure about the profit of this changes, I was just trying to follow the task requirements.
    /// </summary>
    public interface IUserTask
    {
        public string Description { get; }
    }
}
