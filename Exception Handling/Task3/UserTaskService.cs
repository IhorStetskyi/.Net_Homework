using System;
using System.Collections.Generic;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public string AddTaskForUser(int userId, UserTask task)
        {
            IUser user = null;
            IList<IUserTask> tasks = null;
            string validationResult = null;
            string creationResult = null;

            validationResult = CheckForException(userId, ref user);
            if (validationResult != null)
            { 
                return validationResult;
            }

            creationResult = TryToCreateTask(ref tasks, user, task);

            return creationResult;
        }

        bool CheckForStringEqualityIgnoringCase(string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
        string CheckForException(int userId, ref IUser user)
        {
            try
            {
                if (userId < 0)
                {
                    throw new Exception("Invalid userId");
                }

                user = _userDao.GetUser(userId);

                if (user == null)
                {
                    throw new Exception("User not found");
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }
        string TryToCreateTask(ref IList<IUserTask> tasks, IUser user, UserTask task)
        {
            try
            {
                tasks = user.Tasks;
                foreach (IUserTask t in tasks)
                {
                    bool areEqual = CheckForStringEqualityIgnoringCase(task.Description, t.Description);
                    if (areEqual)
                    {
                        throw new Exception("The task already exists");
                    }
                }
                tasks.Add(task);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return null;
        }
    }
}//string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase)