using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RotMG_Multitool
{
    partial class ItemCreatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.objectTypeText = new System.Windows.Forms.TextBox();
            this.objectIdText = new System.Windows.Forms.TextBox();
            this.createXMLButton = new MetroFramework.Controls.MetroButton();
            this.displayNameText = new System.Windows.Forms.TextBox();
            this.textureButton = new MetroFramework.Controls.MetroButton();
            this.classText = new System.Windows.Forms.TextBox();
            this.textureFileText = new System.Windows.Forms.TextBox();
            this.textureIndexText = new System.Windows.Forms.TextBox();
            this.rtextureInstanceText = new System.Windows.Forms.TextBox();
            this.rtextureIdText = new System.Windows.Forms.TextBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.slotTypeCombobox = new MetroFramework.Controls.MetroComboBox();
            this.tierText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionText = new System.Windows.Forms.TextBox();
            this.rateOfFireText = new System.Windows.Forms.TextBox();
            this.bagTypeCombobox = new MetroFramework.Controls.MetroComboBox();
            this.itemSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.loadSwfBtn = new System.Windows.Forms.Button();
            this.openItemImgBtn = new System.Windows.Forms.Button();
            this.dumpResourcesBtn = new System.Windows.Forms.Button();
            this.itemSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectTypeText
            // 
            this.objectTypeText.Location = new System.Drawing.Point(99, 19);
            this.objectTypeText.Name = "objectTypeText";
            this.objectTypeText.Size = new System.Drawing.Size(82, 20);
            this.objectTypeText.TabIndex = 0;
            this.objectTypeText.Text = "Object Type";
            // 
            // objectIdText
            // 
            this.objectIdText.Location = new System.Drawing.Point(187, 19);
            this.objectIdText.Name = "objectIdText";
            this.objectIdText.Size = new System.Drawing.Size(82, 20);
            this.objectIdText.TabIndex = 1;
            this.objectIdText.Text = "Item Name";
            // 
            // createXMLButton
            // 
            this.createXMLButton.Location = new System.Drawing.Point(324, 371);
            this.createXMLButton.Name = "createXMLButton";
            this.createXMLButton.Size = new System.Drawing.Size(86, 26);
            this.createXMLButton.TabIndex = 2;
            this.createXMLButton.Text = "Create";
            this.createXMLButton.UseSelectable = true;
            this.createXMLButton.Click += new System.EventHandler(this.createXMLButton_Click);
            // 
            // displayNameText
            // 
            this.displayNameText.Location = new System.Drawing.Point(187, 45);
            this.displayNameText.Name = "displayNameText";
            this.displayNameText.Size = new System.Drawing.Size(82, 20);
            this.displayNameText.TabIndex = 4;
            this.displayNameText.Text = "Display Name";
            // 
            // textureButton
            // 
            this.textureButton.Location = new System.Drawing.Point(17, 237);
            this.textureButton.Name = "textureButton";
            this.textureButton.Size = new System.Drawing.Size(97, 23);
            this.textureButton.TabIndex = 5;
            this.textureButton.Text = "Remote Texture";
            this.textureButton.UseSelectable = true;
            this.textureButton.Click += new System.EventHandler(this.textureButton_Click);
            // 
            // classText
            // 
            this.classText.Location = new System.Drawing.Point(99, 45);
            this.classText.Name = "classText";
            this.classText.Size = new System.Drawing.Size(82, 20);
            this.classText.TabIndex = 3;
            this.classText.Text = "Equipment";
            // 
            // textureFileText
            // 
            this.textureFileText.Location = new System.Drawing.Point(99, 71);
            this.textureFileText.Name = "textureFileText";
            this.textureFileText.Size = new System.Drawing.Size(82, 20);
            this.textureFileText.TabIndex = 6;
            this.textureFileText.Text = "File";
            // 
            // textureIndexText
            // 
            this.textureIndexText.Location = new System.Drawing.Point(187, 71);
            this.textureIndexText.Name = "textureIndexText";
            this.textureIndexText.Size = new System.Drawing.Size(82, 20);
            this.textureIndexText.TabIndex = 7;
            this.textureIndexText.Text = "Index";
            // 
            // rtextureInstanceText
            // 
            this.rtextureInstanceText.Location = new System.Drawing.Point(99, 71);
            this.rtextureInstanceText.Name = "rtextureInstanceText";
            this.rtextureInstanceText.Size = new System.Drawing.Size(82, 20);
            this.rtextureInstanceText.TabIndex = 8;
            this.rtextureInstanceText.Text = "draw";
            // 
            // rtextureIdText
            // 
            this.rtextureIdText.Location = new System.Drawing.Point(187, 71);
            this.rtextureIdText.Name = "rtextureIdText";
            this.rtextureIdText.Size = new System.Drawing.Size(82, 20);
            this.rtextureIdText.TabIndex = 9;
            this.rtextureIdText.Text = "Id";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.BackColor = System.Drawing.Color.White;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(3, 74);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(90, 13);
            this.warningLabel.TabIndex = 10;
            this.warningLabel.Text = "Don\'t change this";
            // 
            // slotTypeCombobox
            // 
            this.slotTypeCombobox.FormattingEnabled = true;
            this.slotTypeCombobox.ItemHeight = 23;
            this.slotTypeCombobox.Items.AddRange(new object[] {
            "Sword",
            "Dagger",
            "Bow",
            "Wand",
            "Staff"});
            this.slotTypeCombobox.Location = new System.Drawing.Point(120, 97);
            this.slotTypeCombobox.Name = "slotTypeCombobox";
            this.slotTypeCombobox.Size = new System.Drawing.Size(121, 29);
            this.slotTypeCombobox.Style = MetroFramework.MetroColorStyle.Purple;
            this.slotTypeCombobox.TabIndex = 11;
            this.slotTypeCombobox.UseSelectable = true;
            // 
            // tierText
            // 
            this.tierText.Location = new System.Drawing.Point(141, 132);
            this.tierText.Name = "tierText";
            this.tierText.Size = new System.Drawing.Size(82, 20);
            this.tierText.TabIndex = 12;
            this.tierText.Text = "Tier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(55, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Set to -1 for UT";
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(99, 158);
            this.descriptionText.Multiline = true;
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(170, 41);
            this.descriptionText.TabIndex = 14;
            this.descriptionText.Text = "Description";
            // 
            // rateOfFireText
            // 
            this.rateOfFireText.Location = new System.Drawing.Point(141, 205);
            this.rateOfFireText.Name = "rateOfFireText";
            this.rateOfFireText.Size = new System.Drawing.Size(82, 20);
            this.rateOfFireText.TabIndex = 15;
            this.rateOfFireText.Text = "Rate of Fire";
            // 
            // bagTypeCombobox
            // 
            this.bagTypeCombobox.FormattingEnabled = true;
            this.bagTypeCombobox.ItemHeight = 23;
            this.bagTypeCombobox.Items.AddRange(new object[] {
            "Brown Bag",
            "Purple Bag",
            "High Tiered Bag",
            "Potion Bag",
            "White Bag"});
            this.bagTypeCombobox.Location = new System.Drawing.Point(120, 231);
            this.bagTypeCombobox.Name = "bagTypeCombobox";
            this.bagTypeCombobox.Size = new System.Drawing.Size(121, 29);
            this.bagTypeCombobox.Style = MetroFramework.MetroColorStyle.Purple;
            this.bagTypeCombobox.TabIndex = 16;
            this.bagTypeCombobox.UseSelectable = true;
            // 
            // itemSettingsGroupBox
            // 
            this.itemSettingsGroupBox.Controls.Add(this.objectTypeText);
            this.itemSettingsGroupBox.Controls.Add(this.bagTypeCombobox);
            this.itemSettingsGroupBox.Controls.Add(this.objectIdText);
            this.itemSettingsGroupBox.Controls.Add(this.rateOfFireText);
            this.itemSettingsGroupBox.Controls.Add(this.descriptionText);
            this.itemSettingsGroupBox.Controls.Add(this.classText);
            this.itemSettingsGroupBox.Controls.Add(this.label1);
            this.itemSettingsGroupBox.Controls.Add(this.displayNameText);
            this.itemSettingsGroupBox.Controls.Add(this.tierText);
            this.itemSettingsGroupBox.Controls.Add(this.textureButton);
            this.itemSettingsGroupBox.Controls.Add(this.slotTypeCombobox);
            this.itemSettingsGroupBox.Controls.Add(this.textureFileText);
            this.itemSettingsGroupBox.Controls.Add(this.warningLabel);
            this.itemSettingsGroupBox.Controls.Add(this.textureIndexText);
            this.itemSettingsGroupBox.Controls.Add(this.rtextureIdText);
            this.itemSettingsGroupBox.Controls.Add(this.rtextureInstanceText);
            this.itemSettingsGroupBox.Location = new System.Drawing.Point(26, 92);
            this.itemSettingsGroupBox.Name = "itemSettingsGroupBox";
            this.itemSettingsGroupBox.Size = new System.Drawing.Size(384, 273);
            this.itemSettingsGroupBox.TabIndex = 17;
            this.itemSettingsGroupBox.TabStop = false;
            this.itemSettingsGroupBox.Text = "Item Properties";
            // 
            // loadSwfBtn
            // 
            this.loadSwfBtn.Location = new System.Drawing.Point(26, 63);
            this.loadSwfBtn.Name = "loadSwfBtn";
            this.loadSwfBtn.Size = new System.Drawing.Size(110, 23);
            this.loadSwfBtn.TabIndex = 18;
            this.loadSwfBtn.Text = "Load SWF...";
            this.loadSwfBtn.UseVisualStyleBackColor = true;
            this.loadSwfBtn.Click += new System.EventHandler(this.loadSwfBtn_Click);
            // 
            // openItemImgBtn
            // 
            this.openItemImgBtn.Location = new System.Drawing.Point(146, 63);
            this.openItemImgBtn.Name = "openItemImgBtn";
            this.openItemImgBtn.Size = new System.Drawing.Size(110, 23);
            this.openItemImgBtn.TabIndex = 19;
            this.openItemImgBtn.Text = "Open Item Image...";
            this.openItemImgBtn.UseVisualStyleBackColor = true;
            this.openItemImgBtn.Click += new System.EventHandler(this.openItemImgBtn_Click);
            // 
            // dumpResourcesBtn
            // 
            this.dumpResourcesBtn.Location = new System.Drawing.Point(262, 63);
            this.dumpResourcesBtn.Name = "dumpResourcesBtn";
            this.dumpResourcesBtn.Size = new System.Drawing.Size(148, 23);
            this.dumpResourcesBtn.TabIndex = 20;
            this.dumpResourcesBtn.Text = "Dump Images and XMLs";
            this.dumpResourcesBtn.UseVisualStyleBackColor = true;
            this.dumpResourcesBtn.Click += new System.EventHandler(this.dumpResourcesBtn_Click);
            // 
            // ItemCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(424, 407);
            this.Controls.Add(this.dumpResourcesBtn);
            this.Controls.Add(this.openItemImgBtn);
            this.Controls.Add(this.loadSwfBtn);
            this.Controls.Add(this.itemSettingsGroupBox);
            this.Controls.Add(this.createXMLButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ItemCreatorForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Item Creator";
            this.itemSettingsGroupBox.ResumeLayout(false);
            this.itemSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroButton createXMLButton;
        public TextBox objectIdText;
        public TextBox objectTypeText;
        public TextBox displayNameText;
        private MetroButton textureButton;
        public TextBox classText;
        public TextBox textureFileText;
        public TextBox textureIndexText;
        public TextBox rtextureInstanceText;
        public TextBox rtextureIdText;
        private Label warningLabel;
        private MetroComboBox slotTypeCombobox;
        public TextBox tierText;
        private Label label1;
        public TextBox descriptionText;
        public TextBox rateOfFireText;
        private MetroComboBox bagTypeCombobox;
        private GroupBox itemSettingsGroupBox;
        private Button loadSwfBtn;
        private Button openItemImgBtn;
        private Button dumpResourcesBtn;
    }
}