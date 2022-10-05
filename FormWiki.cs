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
           //comboBoxCategory.SelectedIndex = 0;
        }

        //6.2 Create a global List<T> of type Information called Wiki.
        List<Information> wiki = new List<Information>();


        //6.3 Create a button method to ADD a new item to the list.
        //Use a TextBox for the Name input, ComboBox for the Category,
        //Radio group for the Structure and Multiline TextBox for the Definition.
        private void buttonADD_Click(object sender, EventArgs e)
        {
            Information info = new Information();
          info.setName(textBoxName.Text);
            info.setCategory(comboBoxCategory.Text);
            info.setStructure(getStructureRadioButton());
           info.setDefintion(textBoxDefinition.Text);  
            wiki.Add(info);
            displayData();
            resetFields();

        }
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
    }
}
