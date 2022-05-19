#define delayEnabled
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoldersHW;
public delegate List<string> Filter(FilterValuesList fv, List<string> toFilter, FolderOrFileEnum en);
delegate void NotifyStartOrEndEventHandler(StartOrEndEnum en);
delegate void NotifyFileOrFolderFoundEventHandler(string x, FolderOrFileEnum en);


namespace FoldersHW
{
    class FileSystemVisitor
    {
        Form_Folders formFolders;
        List<string> folders;
        List<string> files;
        private event NotifyStartOrEndEventHandler notify;
        private event NotifyFileOrFolderFoundEventHandler notifyFileOrFolderFound;

        #region Constructors
        /// <summary>
        /// Default constructr when filter is not active
        /// </summary>
        /// <param name="wf">Windows Form class</param>
        public FileSystemVisitor(Form_Folders wf)
        {
            try
            {
                DefaultPartOfConstructor(wf);
                FillFolderAndFileLists(formFolders.folderPath);
                WriteDataIntoListboxes();
                notify(formFolders.isStopped ? StartOrEndEnum.Interrupted : StartOrEndEnum.End);
            }
            catch(Exception e)
            {
                MessageBox.Show("Constructor Exception \n" + e.Message.ToString());
            }
        }

        /// <summary>
        /// Constructor when filter is active
        /// </summary>
        /// <param name="wf"></param>
        /// <param name="filter">Windows Form class</param>
        public FileSystemVisitor(Form_Folders wf, Filter filter)
        {
            DefaultPartOfConstructor(wf);
            FillFolderAndFileLists(formFolders.folderPath);
            FilterData(filter);
            WriteDataIntoListboxes();
            notify(formFolders.isStopped ? StartOrEndEnum.Interrupted : StartOrEndEnum.End);
        }
        #endregion


        #region Adding/Clearing/Filtering Listboxes
        void WriteDataIntoListboxes()
        {
            foreach (string file in files)
            {
                formFolders.FilesListbox.Items.Add(file);
            }
            foreach (string folder in folders)
            {
                formFolders.FoldersListbox.Items.Add(folder);
            }
        }
        private void AddToFolders(string foldername)
        {
            folders.Add(foldername);
        }
        private void AddToFiles(string filename)
        {
            files.Add(filename);
        }
        private void ClearFilesAndFolders()
        {
            files.Clear();
            folders.Clear();
            formFolders.FoldersListbox.Items.Clear();
            formFolders.FilesListbox.Items.Clear();
        }
        private void FilterData(Filter f)
        {
            folders = f(formFolders.filterValues, folders, FolderOrFileEnum.Folder);
            files = f(formFolders.filterValues, files, FolderOrFileEnum.File);
        }
        #endregion


        #region Main methods to find folders and files

        /// <summary>
        /// Clears Files/Folders lists and invokes recursive method for filling them again
        /// </summary>
        /// <param name="path">Path to the root folder</param>
        private void FillFolderAndFileLists(string path)
        {
            ClearFilesAndFolders();
            DirectoryInfo rootDirectory = new DirectoryInfo(path);
            SearchForFoldersAndFiles(rootDirectory);
        }

        /// <summary>
        /// Method that is invoked recursively and fill Files and Folders lists with data
        /// </summary>
        /// <param name="folder">Path to the current folder</param>
        private void SearchForFoldersAndFiles(DirectoryInfo folder)
        {

            AddToFolders(folder.Name);
            foreach (DirectoryInfo dir in Folders(folder))
            {
                if(!formFolders.isStopped)
                {
                    //small delay during search
#if delayEnabled
                    Task.Delay(1000).Wait();
#endif
                    SearchForFoldersAndFiles(dir);
                }
            }
            foreach (FileInfo file in Files(folder))
            {
                if(!formFolders.isStopped)
                {
                    //small delay during search
#if delayEnabled
                    Task.Delay(1000).Wait();
#endif
                    AddToFiles(file.Name);
                }
            }

        }

        #endregion


        #region IEnumerablePart
        /// <summary>
        /// IEnumerable part that returns FileInfo type for each file found
        /// </summary>
        /// <param name="dir">Directory where search for the files</param>
        /// <returns></returns>
        private IEnumerable Files(DirectoryInfo dir)
        {
            foreach (FileInfo file in dir.GetFiles())
            {
                notifyFileOrFolderFound(file.Name, FolderOrFileEnum.File);
                yield return file;
            }
        }
        /// <summary>
        /// IEnumerable part that returns DirectoryInfo type for each file found
        /// </summary>
        /// <param name="dir">Directory where search for the files</param>
        /// <returns></returns>
        private IEnumerable Folders(DirectoryInfo dir)
        {
            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                notifyFileOrFolderFound(directory.Name, FolderOrFileEnum.Folder);
                yield return directory;
            }
        }
        #endregion

        //part of constructor that is always the same
        void DefaultPartOfConstructor(Form_Folders ff)
        {
            formFolders = ff;
            notify = formFolders.WriteStartOrEnd;
            notifyFileOrFolderFound = formFolders.WriteFileOrFolderFound;
            notify(StartOrEndEnum.Start);
            folders = new List<string>();
            files = new List<string>();
        }



    }
}
