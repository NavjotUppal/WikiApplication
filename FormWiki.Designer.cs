namespace WikiApplication
{
    partial class FormWiki
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.groupBoxStructure = new System.Windows.Forms.GroupBox();
            this.radioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.buttonADD = new System.Windows.Forms.Button();
            this.buttonDEL = new System.Windows.Forms.Button();
            this.buttonEDIT = new System.Windows.Forms.Button();
            this.buttonLOAD = new System.Windows.Forms.Button();
            this.buttonSAVE = new System.Windows.Forms.Button();
            this.listViewData = new System.Windows.Forms.ListView();
            this.NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CATEGORY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSEARCH = new System.Windows.Forms.Button();
            this.textBoxSEARCH = new System.Windows.Forms.TextBox();
            this.groupBoxStructure.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Defintion";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(90, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(203, 22);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(90, 185);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(203, 194);
            this.textBoxDefinition.TabIndex = 5;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(90, 63);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(203, 24);
            this.comboBoxCategory.Sorted = true;
            this.comboBoxCategory.TabIndex = 6;
            // 
            // groupBoxStructure
            // 
            this.groupBoxStructure.Controls.Add(this.radioButtonNonLinear);
            this.groupBoxStructure.Controls.Add(this.radioButtonLinear);
            this.groupBoxStructure.Location = new System.Drawing.Point(16, 107);
            this.groupBoxStructure.Name = "groupBoxStructure";
            this.groupBoxStructure.Size = new System.Drawing.Size(306, 58);
            this.groupBoxStructure.TabIndex = 7;
            this.groupBoxStructure.TabStop = false;
            this.groupBoxStructure.Text = "Structure";
            // 
            // radioButtonNonLinear
            // 
            this.radioButtonNonLinear.AutoSize = true;
            this.radioButtonNonLinear.Location = new System.Drawing.Point(183, 21);
            this.radioButtonNonLinear.Name = "radioButtonNonLinear";
            this.radioButtonNonLinear.Size = new System.Drawing.Size(94, 20);
            this.radioButtonNonLinear.TabIndex = 1;
            this.radioButtonNonLinear.TabStop = true;
            this.radioButtonNonLinear.Text = "Non-Linear";
            this.radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(74, 21);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(65, 20);
            this.radioButtonLinear.TabIndex = 0;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Linear";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // buttonADD
            // 
            this.buttonADD.Location = new System.Drawing.Point(12, 400);
            this.buttonADD.Name = "buttonADD";
            this.buttonADD.Size = new System.Drawing.Size(75, 23);
            this.buttonADD.TabIndex = 8;
            this.buttonADD.Text = "ADD";
            this.buttonADD.UseVisualStyleBackColor = true;
            this.buttonADD.Click += new System.EventHandler(this.buttonADD_Click);
            // 
            // buttonDEL
            // 
            this.buttonDEL.Location = new System.Drawing.Point(115, 400);
            this.buttonDEL.Name = "buttonDEL";
            this.buttonDEL.Size = new System.Drawing.Size(75, 23);
            this.buttonDEL.TabIndex = 9;
            this.buttonDEL.Text = "DEL";
            this.buttonDEL.UseVisualStyleBackColor = true;
            this.buttonDEL.Click += new System.EventHandler(this.buttonDEL_Click);
            // 
            // buttonEDIT
            // 
            this.buttonEDIT.Location = new System.Drawing.Point(230, 400);
            this.buttonEDIT.Name = "buttonEDIT";
            this.buttonEDIT.Size = new System.Drawing.Size(75, 23);
            this.buttonEDIT.TabIndex = 10;
            this.buttonEDIT.Text = "EDIT";
            this.buttonEDIT.UseVisualStyleBackColor = true;
            this.buttonEDIT.Click += new System.EventHandler(this.buttonEDIT_Click);
            // 
            // buttonLOAD
            // 
            this.buttonLOAD.Location = new System.Drawing.Point(458, 400);
            this.buttonLOAD.Name = "buttonLOAD";
            this.buttonLOAD.Size = new System.Drawing.Size(75, 23);
            this.buttonLOAD.TabIndex = 11;
            this.buttonLOAD.Text = "LOAD";
            this.buttonLOAD.UseVisualStyleBackColor = true;
            // 
            // buttonSAVE
            // 
            this.buttonSAVE.Location = new System.Drawing.Point(612, 400);
            this.buttonSAVE.Name = "buttonSAVE";
            this.buttonSAVE.Size = new System.Drawing.Size(75, 23);
            this.buttonSAVE.TabIndex = 12;
            this.buttonSAVE.Text = "SAVE";
            this.buttonSAVE.UseVisualStyleBackColor = true;
            // 
            // listViewData
            // 
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NAME,
            this.CATEGORY});
            this.listViewData.HideSelection = false;
            this.listViewData.Location = new System.Drawing.Point(423, 63);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(315, 316);
            this.listViewData.TabIndex = 13;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            // 
            // NAME
            // 
            this.NAME.Text = "NAME";
            this.NAME.Width = 112;
            // 
            // CATEGORY
            // 
            this.CATEGORY.Text = "CATEGORY";
            this.CATEGORY.Width = 137;
            // 
            // buttonSEARCH
            // 
            this.buttonSEARCH.Location = new System.Drawing.Point(636, 19);
            this.buttonSEARCH.Name = "buttonSEARCH";
            this.buttonSEARCH.Size = new System.Drawing.Size(102, 23);
            this.buttonSEARCH.TabIndex = 14;
            this.buttonSEARCH.Text = "SEARCH";
            this.buttonSEARCH.UseVisualStyleBackColor = true;
            // 
            // textBoxSEARCH
            // 
            this.textBoxSEARCH.Location = new System.Drawing.Point(423, 19);
            this.textBoxSEARCH.Name = "textBoxSEARCH";
            this.textBoxSEARCH.Size = new System.Drawing.Size(187, 22);
            this.textBoxSEARCH.TabIndex = 15;
            // 
            // FormWiki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxSEARCH);
            this.Controls.Add(this.buttonSEARCH);
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.buttonSAVE);
            this.Controls.Add(this.buttonLOAD);
            this.Controls.Add(this.buttonEDIT);
            this.Controls.Add(this.buttonDEL);
            this.Controls.Add(this.buttonADD);
            this.Controls.Add(this.groupBoxStructure);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormWiki";
            this.Text = "Wiki Application";
            this.groupBoxStructure.ResumeLayout(false);
            this.groupBoxStructure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.GroupBox groupBoxStructure;
        private System.Windows.Forms.RadioButton radioButtonNonLinear;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.Button buttonADD;
        private System.Windows.Forms.Button buttonDEL;
        private System.Windows.Forms.Button buttonEDIT;
        private System.Windows.Forms.Button buttonLOAD;
        private System.Windows.Forms.Button buttonSAVE;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader NAME;
        private System.Windows.Forms.ColumnHeader CATEGORY;
        private System.Windows.Forms.Button buttonSEARCH;
        private System.Windows.Forms.TextBox textBoxSEARCH;
    }
}

