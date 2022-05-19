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
            IUser user;
            IList<IUserTask> tasks;


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
            try
            {
                tasks = user.Tasks;
                foreach (IUserTask t in tasks)
                {
                    if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
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
}