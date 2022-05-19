#define delayEnabled
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoldersHW;


public delegate void NotifyAboutComparingEventHandler(string x, string y);
public delegate void NotifyAboutAddingToTheListBoxEventHandler(string x, FolderOrFileEnum en);
public delegate void ChangeStatusLableEventHandler(Statuses s);

namespace FoldersHW
{


    /// <summary>
    /// Static Clsss with static RreturnInclude and ReturnExclude methods whitch are used duting filtering
    /// </summary>
    public static class StaticFilterMethods
    {
        
        static public event NotifyAboutComparingEventHandler notifyAboutComparing;
        static public event NotifyAboutAddingToTheListBoxEventHandler notifyAboutAddingToTheListBox;
        static public event ChangeStatusLableEventHandler changeStatus;
        static public bool isStopped;


        /// <summary>
        /// Method that returns List of values that are matched with the Filter list
        /// </summary>
        /// <param name="fv">Values from Filter list</param>
        /// <param name="listToBeFiltered">Values from list that should be filtered</param>
        /// <param name="en">Enum that displays if it is Folder or File</param>
        /// <returns></returns>
        public static List<string> ReturnInclude(FilterValuesList fv, List<string> listToBeFiltered, FolderOrFileEnum en)
        {
            List<string> filtered = new List<string>();
            foreach (string i in listToBeFiltered)
            {
                if (!isStopped)
                {
                    try
                    {
                        changeStatus.Invoke(Statuses.Filtering);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message.ToString() + "  Looks like This is Unit Test for ReturnInclude (changeStatus)");
                    }

//small delay during filtering
#if delayEnabled
                    Task.Delay(1000).Wait();
#endif
                    foreach (string x in fv)
                    {

                        try
                        {
                            notifyAboutComparing.Invoke(i, x);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message.ToString() + "  Looks like This is Unit Test for ReturnInclude (notifyAboutCompating)");
                        }
                        if (i.ToLower().Trim().Contains(x.ToLower().Trim()))
                        {
                            filtered.Add(i);
                            try
                            {
                                notifyAboutAddingToTheListBox(i, en);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message.ToString() + "  Looks like This is Unit Test for ReturnInclude (notifyAboutAddingToTheListBox)");
                            }
                        }

                    }
                }
            }
            return filtered;
        }

        /// <summary>
        /// Method that returns List of values that are NOT matched with the Filter list
        /// </summary>
        /// <param name="fv">Values from Filter list</param>
        /// <param name="listToBeFiltered">Values from list that should be filtered</param>
        /// <param name="en">Enum that displays if it is Folder or File</param>
        /// <returns></returns>
        public static List<string> ReturnExclude(FilterValuesList fv, List<string> listToBeFiltered, FolderOrFileEnum en)
        {
            List<string> filtered = new List<string>();
            foreach (string i in listToBeFiltered)
            {
                if (!isStopped)
                {
                    try
                    {
                        changeStatus.Invoke(Statuses.Filtering);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message.ToString() + "  Looks like This is Unit Test for ReturnExclude (changeStatus)");
                    }

                    //small delay during filtering
#if delayEnabled
                    Task.Delay(1000).Wait();
#endif
                    bool isOk = true;
                    foreach (string x in fv)
                    {
                        try
                        {
                            notifyAboutComparing.Invoke(i, x);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message.ToString() + "  Looks like This is Unit Test for ReturnExclude (notifyAboutComparing)");
                        }
                        if (i.ToLower().Trim().Contains(x.ToLower().Trim()))
                        {
                            isOk = false;
                        }
                    }
                    if (isOk)
                    {
                        filtered.Add(i);
                        try
                        {
                            notifyAboutAddingToTheListBox(i, en);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message.ToString() + "  Looks like This is Unit Test for ReturnExclude (notifyAboutAddingToTheListBox)");
                        }
                    }
                }
            }
            return filtered;
        }

    }
}
