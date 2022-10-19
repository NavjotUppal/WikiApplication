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
            populateComboBox();
           
        }

        //6.2 Create a global List<T> of type Information called Wiki.
        List<Information> wiki = new List<Information>();


        //6.3 Create a button method to ADD a new item to the list.
        //Use a TextBox for the Name input, ComboBox for the Category,
        //Radio group for the Structure and Multiline TextBox for the Definition.
        private void buttonADD_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBoxName.Text) && validName(textBoxName.Text))) {
                Information info = new Information();
                info.setName(textBoxName.Text);
                info.setCategory(comboBoxCategory.Text);
                info.setStructure(getStructureRadioButton());
                info.setDefinition(textBoxDefinition.Text);
                wiki.Add(info);
                displayData();
                resetFields();
            } else if (!validName(textBoxName.Text)) {
                //tool strip message
                MessageBox.Show("Name already exist");
                resetFields();
            }
            else
            {
                //tool strip message
            }

        }
        //6.4 Create a custom method to populate the
        //ComboBox when the Form Load method is called.
        //The six categories must be read from a simple text file.
        private void populateComboBox()
        {
            string[] cat = File.ReadAllLines("Category List.txt");
            string[] tokens=new string[cat.Length];
            foreach (string catItem in cat)
            {
                tokens=catItem.Split(',');
            }
            for(int i=0; i<tokens.Length; i++)
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
            if(wiki.Exists(dup => dup.getName() == checkName))
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
               // Trace.WriteLine("RadioButton = Checked");
                radioButtonLinear.Checked = true;
            }
            else
            {
                //Trace.WriteLine("RadioButton = Not Checked");
                radioButtonNonLinear.Checked = true;
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
                        wiki.Sort();
                        resetFields();
                        displayData();
                       
                    }
                    else
                    {
                        MessageBox.Show("Item NOT Deleted", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
               // add message
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
                // Trace.WriteLine("Item index: " + currentItem);
                {
                    var result = MessageBox.Show("Do you wish to continue", "EDIT",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        wiki[currentItem].setName(textBoxName.Text);
                        wiki[currentItem].setCategory(comboBoxCategory.Text);
                        wiki[currentItem].setStructure(getStructureRadioButton());
                        wiki[currentItem].setDefinition(textBoxDefinition.Text);
                        wiki.Sort();
                        displayData();
                        resetFields();

                    }
                    else
                    {
                        MessageBox.Show("Data Item NOT changed", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //add message
            }

        }
        //6.11 Create a ListView event so a user can select a
        //Data Structure Name from the list of Names and
        //the associated information will be displayed in the related text boxes combo box and radio button.
            private void displayData()
        {
            listViewData.Items.Clear();
            wiki.Sort();
            foreach(Information info in wiki)
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

       
    }
}
