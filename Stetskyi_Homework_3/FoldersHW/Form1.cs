using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FoldersHW
{
    public partial class Form_Folders : Form
    {
        public FilterValuesList filterValues;
        public string folderPath;
        FileSystemVisitor FSV;

        public bool isStopped;
        Thread workingThread;
        public CheckBox IncludeCheckbox
        {
            get { return checkBox_Include; }
            set { checkBox_Include = value; }
        }
        public CheckBox ExcludeCheckbox
        {
            get { return checkBox_Exclude; }
            set { checkBox_Exclude = value; }
        }
        public ListBox FoldersListbox
        {
            get { return listBox_Folders; }
            set { listBox_Folders = value; }
        }
        public ListBox FilesListbox
        {
            get { return listBox_Files; }
            set { listBox_Folders = value; }
        }
        public ListBox LogListbox
        {
            get { return listBox_Logs; }
            set { listBox_Logs = value; }
        }




        public Form_Folders()
        {

            InitializeComponent();
            StrangeThingsToDisable();

            #region Subscribing events in static cless using lambda exp
            StaticFilterMethods.changeStatus += ChangeStatus;
            StaticFilterMethods.notifyAboutComparing += (x, y) =>
            {
                LogListbox.Items.Add($"Comparing \"{x}\" and \"{y}\"");
                MoveDownInListBox();
            };

            StaticFilterMethods.notifyAboutAddingToTheListBox += (x, y) =>
            {
                LogListbox.Items.Add(String.Format("==>{0} \"{1}\" is added", y == FolderOrFileEnum.File ? "File" : "Folder", x));
                MoveDownInListBox();
            };
            #endregion

            #region Default disabling of buttons at the beginning
            IncludeCheckbox.Enabled = false;
            ExcludeCheckbox.Enabled = false;
            button_ClearFilter.Enabled = false;
            button_Stop.Enabled = false;
            ChangeStatus(Statuses.NotStarted);
            #endregion

        }


        #region Buttons/fields/checkboxes click events

        //Browse Button
        private void button_Browse_Click(object sender, EventArgs e)
        {
            isStopped = false;
            StaticFilterMethods.isStopped = false;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbd.SelectedPath;
                workingThread = new Thread(new ThreadStart(WorkToStart));
                workingThread.Start();
            }
        }

        //Stop Button
        private void button_Stop_Click(object sender, EventArgs e)
        {
            isStopped = true;
            button_Stop.Enabled = false;
            StaticFilterMethods.isStopped = true;
        }

        //Double Click on folders item
        private void listBox_Folders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox_Folders.Items.Remove(listBox_Folders.SelectedItem);
        }

        //Double Click on files item
        private void listBox_Files_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox_Files.Items.Remove(listBox_Files.SelectedItem);
        }

        //Include Checkbox
        private void checkBox_Include_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Include.Checked)
            {
                checkBox_Exclude.Checked = false;
            }
        }

        //Exclude Checkbox
        private void checkBox_Exclude_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Exclude.Checked)
            {
                checkBox_Include.Checked = false;
            }
        }

        //Add To Filter Button
        private void button_AddToFilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Filter.Text.ToString()))
            {
                if (filterValues == null)
                {
                    filterValues = new FilterValuesList();
                }
                filterValues.Add(textBox_Filter.Text.ToString());
                listBox_Filter.Items.Clear();
                foreach (string item in filterValues)
                {
                    listBox_Filter.Items.Add(item);
                }
                EnableFiltering();
            }
            textBox_Filter.Text = "Enter value and press \"Add To Filter\"";

        }

        //Clear Filter Button
        private void button_ClearFilter_Click(object sender, EventArgs e)
        {
            filterValues.Clear();
            listBox_Filter.Items.Clear();
            DisableFiltering();
        }

        //Textbox click
        private void textBox_Filter_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Filter.Text = "";
        }
        #endregion


        #region Logs methods
        public void WriteStartOrEnd(StartOrEndEnum en)
        {
            switch (en)
            {
                case StartOrEndEnum.Start:
                    listBox_Logs.Items.Add("=====Start=====");
                    ChangeStatus(Statuses.Searcing);
                    MoveDownInListBox();
                    break;
                case StartOrEndEnum.End:
                    listBox_Logs.Items.Add("=====End=====");
                    ChangeStatus(Statuses.Done);
                    MoveDownInListBox();
                    break;
                case StartOrEndEnum.Interrupted:
                    listBox_Logs.Items.Add("=====Interrupted=====");
                    ChangeStatus(Statuses.Interrupted);
                    MoveDownInListBox();
                    break;
            }
            MoveDownInListBox();
        }
        public void WriteFileOrFolderFound(string x, FolderOrFileEnum en)
        {
            switch (en)
            {
                case FolderOrFileEnum.File:
                    listBox_Logs.Items.Add($"File \"{x}\" found");
                    MoveDownInListBox();
                    break;
                case FolderOrFileEnum.Folder:
                    listBox_Logs.Items.Add($"Folder \"{x}\" found");
                    MoveDownInListBox();
                    break;
            }
           
        }
        #endregion


        #region Disable/Enable buttons methods
        private void EnableFiltering()
        {
            if (listBox_Filter.Items.Count > 0)
            {
                checkBox_Include.Enabled = true;
                checkBox_Exclude.Enabled = true;
                button_ClearFilter.Enabled = true;
            }
        }
        private void DisableFiltering()
        {
            checkBox_Include.Enabled = false;
            checkBox_Include.Checked = false;
            checkBox_Exclude.Enabled = false;
            checkBox_Exclude.Checked = false;
            button_ClearFilter.Enabled = false;
        }
        #endregion


        //unfortunatelly was not able to find event for listbox value added, so created this method to scroll down
        public void MoveDownInListBox()
        {
            listBox_Logs.SelectedIndex = listBox_Logs.Items.Count - 1;
        }

        //void that changes status lable
        public void ChangeStatus(Statuses s)
        {
            switch (s)
            {
                case Statuses.Done:
                    label_Status.Text = "Status: Done";
                    button_Stop.Enabled = false;
                    break;
                case Statuses.Filtering:
                    label_Status.Text = "Status: Filtering";
                    break;
                case Statuses.Searcing:
                    label_Status.Text = "Status: Searching";
                    button_Stop.Enabled = true;
                    break;
                case Statuses.NotStarted:
                    label_Status.Text = "Status: Not Started";
                    button_Stop.Enabled = false;
                    break;
                case Statuses.Interrupted:
                    label_Status.Text = "Status: Interrupted by user";
                    button_Stop.Enabled = false;
                    break;
            }
        }

        //void to start new Thread
        void WorkToStart()
        {
            if (IncludeCheckbox.Checked == true)
            {
                FSV = new FileSystemVisitor(this, StaticFilterMethods.ReturnInclude);
            }
            else if (ExcludeCheckbox.Checked == true)
            {
                FSV = new FileSystemVisitor(this, StaticFilterMethods.ReturnExclude);
            }
            else
            {
                FSV = new FileSystemVisitor(this);
            }
        }

        /// <summary>
        /// Without invoking whis window i will not be able to change listbox values from another thread for some reason...
        /// Google says it is a good idea to invoke this
        /// </summary>
        void StrangeThingsToDisable()
        {
            CheckBox.CheckForIllegalCrossThreadCalls = false;
            Label.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }


    }
}
