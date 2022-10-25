using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WikiApplication
{
    public partial class FormWiki : Form
    {
        public FormWiki()
        {
            InitializeComponent();
            populateComboBox(); // Populate the combo box on form load

        }
        #region ADD/EDIT/DEL
        //6.2 Create a global List<T> of type Information called Wiki.
        List<Information> wiki = new List<Information>();
        String defaultFileName = "default.bin";

        //6.3 Create a button method to ADD a new item to the list.
        //Use a TextBox for the Name input, ComboBox for the Category,
        //Radio group for the Structure and Multiline TextBox for the Definition.
        private void buttonADD_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBoxName.Text) && validName(textBoxName.Text)))
            {
                Information info = new Information();
                info.setName(textBoxName.Text);
                info.setCategory(comboBoxCategory.Text);
                info.setStructure(getStructureRadioButton());
                info.setDefinition(textBoxDefinition.Text);
                wiki.Add(info);
                sortWikiData();
                resetFields();
                toolStripStatusLabel.Text = textBoxName.Text + " Data Structure is added to the list.";
            }
            else if (!validName(textBoxName.Text))
            {
                toolStripStatusLabel.Text = textBoxName.Text + " already exist in the Data Structure list.";
                MessageBox.Show("Name already exist");
                resetFields();
            }
            else
            {
                toolStripStatusLabel.Text = "Please enter the correct data.";
            }

        }
       
        //6.7 Create a button method that will delete the currently selected record in the ListView.
        //Ensure the user has the option to backout of this action by using a dialog box.
        //Display an updated version of the sorted list at the end of this process.
        private void buttonDEL_Click(object sender, EventArgs e)
        {
            try
            {
                int currentItem = listViewData.SelectedIndices[0];
                if (currentItem >= 0)
                {
                    DialogResult delRecord = MessageBox.Show("Do you wish to delete data structure?",
                     "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (delRecord == DialogResult.Yes)
                    {
                        wiki.RemoveAt(currentItem);
                        sortWikiData();
                        resetFields();


                    }
                    else
                    {
                        MessageBox.Show("Item NOT Deleted", "CAUTION", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (ArgumentOutOfRangeException E)
            {
                MessageBox.Show("Exception Occured" + E.Message);
            }
        }
        //6.8 Create a button method that will save the edited record of the currently selected item in the ListView.
        //All the changes in the input controls will be written back to the list.
        //Display an updated version of the sorted list at the end of this process.
        private void buttonEDIT_Click(object sender, EventArgs e)
        {
            try
            {
                int currentItem = listViewData.SelectedIndices[0];
                if (currentItem >= 0)
                {
                    var result = MessageBox.Show("Do you wish to continue", "EDIT",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        wiki[currentItem].setName(textBoxName.Text);
                        wiki[currentItem].setCategory(comboBoxCategory.Text);
                        wiki[currentItem].setStructure(getStructureRadioButton());
                        wiki[currentItem].setDefinition(textBoxDefinition.Text);
                        sortWikiData();
                        resetFields();
                        toolStripStatusLabel.Text = textBoxName.Text+" is Edited.";
                    }
                    else
                    {
                        MessageBox.Show("Data Item NOT changed", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (ArgumentOutOfRangeException E)
            {
                MessageBox.Show("Exception Occured" + E.Message);
            }

        }
        #endregion ADD/EDIT/DEL
        #region SORT/SEARCH
        //6.9 Create a single custom method that will sort and
        //then display the Name and Category from the wiki information in the list.
        private void sortWikiData()
        {
            wiki.Sort();
            displayData();
        }
        //6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        //If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView.
        //At the end of the search process the search input TextBox must be cleared.
        private void buttonSEARCH_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSEARCH.Text))
            {
                Information findData = new Information();
                findData.setName(textBoxSEARCH.Text);
                int found = wiki.BinarySearch(findData);
                if (found >= 0)
                {
                    listViewData.Focus();
                    listViewData.Items[found].Selected = true;
                    textBoxName.Text = wiki[found].getName();
                    comboBoxCategory.Text = wiki[found].getCategory();
                    if (wiki[found].getStructure() == "Linear")
                    {
                        radioButtonHighlight(0);
                    }
                    else
                    {
                        radioButtonHighlight(1);
                    }
                    textBoxDefinition.Text = wiki[found].getDefinition();
                }
                else
                {
                    MessageBox.Show(textBoxSEARCH+ " Not Found");
                }
            }
            else
            {
                MessageBox.Show("Please input a name to search for in the current wiki records.");
            }
        }
        #endregion SORT/SEARCH
        #region OPEN/SAVE
        // 6.14 Create two buttons for the manual open and save option;
        // this must use a dialog box to select a file or rename a saved file.
        // All Wiki data is stored/retrieved using a binary reader/writer file format.


        private void buttonSAVE_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bin file|=.bin";
            saveFileDialog.Title = "Save a BIN file";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "bin";
            string defaultFileName = "default.bin";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (saveFileDialog.FileName != "")
            {
                saveDataFile(fileName);
                toolStripStatusLabel.Text = fileName + " has been saved.";
            }
            else
            {
                saveDataFile(defaultFileName);
                toolStripStatusLabel.Text = defaultFileName+" has been saved.";
            }

            resetFields();
            listViewData.Items.Clear();
        }
        private void saveDataFile(string saveFileName)
        {
            try
            {
                using (Stream stream = File.Open(saveFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        foreach (var item in wiki)
                        {
                            writer.Write(item.getName());
                            writer.Write(item.getCategory());
                            writer.Write(item.getStructure());
                            writer.Write(item.getDefinition());
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonLOAD_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "BIN FILES|*.bin";
            openFileDialog.Title = "Open a BIN file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                openDataFile(openFileDialog.FileName);
                toolStripStatusLabel.Text=openFileDialog.FileName+" has been loaded.";

            }
        }
        private void openDataFile(string openFileName)
        {
            try
            {
                using (var stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {                       
                        wiki.Clear();

                        while (stream.Position < stream.Length)
                        {
                            Information openFile = new Information();
                            openFile.setName(reader.ReadString());
                            openFile.setCategory(reader.ReadString());
                            openFile.setStructure(reader.ReadString());
                            openFile.setDefinition(reader.ReadString());
                            wiki.Add(openFile);

                        }

                        displayData();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        // 6.15 The Wiki application will save data when the form closes. 
        private void FormWiki_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult saveRecord = MessageBox.Show("Do you wish to save this file?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (saveRecord == DialogResult.Yes)
            {
                saveDataFile(defaultFileName);
            }
            else
            {
                MessageBox.Show("File NOT saved", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion OPEN/SAVE
        #region UTILITIES
        //6.4 Create a custom method to populate the
        //ComboBox when the Form Load method is called.
        //The six categories must be read from a simple text file.
        private void populateComboBox()
        {
            string[] cat = File.ReadAllLines("Category List.txt");
            string[] tokens = new string[cat.Length];
            foreach (string catItem in cat)
            {
                tokens = catItem.Split(',');
            }
            for (int i = 0; i < tokens.Length; i++)
            {
                comboBoxCategory.Items.Add(tokens[i]);

            }
            comboBoxCategory.SelectedIndex = 0;
        }
        //6.5 Create a custom ValidName method which will take a
        //parameter string value from the Textbox Name and returns
        //a Boolean after checking for duplicates.
        //Use the built in List<T> method “Exists” to answer this requirement.
        private bool validName(string checkName)
        {
            if (wiki.Exists(dup => dup.getName() == checkName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        //The first method must return a string value from the selected radio button (Linear or Non-Linear).
        //The second method must send an integer index which will highlight an appropriate radio button.
        private string getStructureRadioButton()
        {
            string rbValue = "";
            foreach (RadioButton rb in groupBoxStructure.Controls.OfType<RadioButton>())
            {
                if (rb.Checked)
                {
                    rbValue = rb.Text;
                    break;
                }
                else
                {
                    rbValue = "Other";
                }
            }
            return rbValue;
        }
        private void radioButtonHighlight(int radio)
        {
            if (radio == 0)
            {
                radioButtonLinear.Checked = true;
            }
            else
            {
                radioButtonNonLinear.Checked = true;
            }
        }
        //6.11 Create a ListView event so a user can select a
        //Data Structure Name from the list of Names and
        //the associated information will be displayed in the related text boxes combo box and radio button.
        private void displayData()
        {
            listViewData.Items.Clear();
            foreach (Information info in wiki)
            {
                ListViewItem lvi = new ListViewItem(info.getName());
                lvi.SubItems.Add(info.getCategory());
                listViewData.Items.Add(lvi);
            }
        }
        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void resetFields()
        {
            textBoxName.Clear();
            textBoxDefinition.Clear();
            comboBoxCategory.SelectedIndex = 0;
            foreach (RadioButton rb in groupBoxStructure.Controls.OfType<RadioButton>())
            {
                rb.Checked = false;
            }

        }


        //6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.

        private void textBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            resetFields();
            toolStripStatusLabel.Text = "Form has been reset.";
        }
        private void listViewData_Click(object sender, EventArgs e)
        {
            int pos = listViewData.SelectedIndices[0];
                       displayData(pos);
        }
        private void displayData(int pos)
        {
            textBoxName.Text=wiki[pos].getName();
            comboBoxCategory.Text=wiki[pos].getCategory();
            if (wiki[pos].getStructure() == "Linear")
            {
                radioButtonHighlight(0);
            }
            else
            {
                radioButtonHighlight(1);
            }
           
          textBoxDefinition.Text=  wiki[pos].getDefinition();
        }

        private void textBoxName_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(textBoxName, "Double click on the text box to empty all the fields.");
        }
        // Verify that the pressed key isn't CTRL or any numeric digit
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBoxSEARCH_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        #endregion UTILITIES
    }
}
