namespace ToTKLIE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            StatusLabel = new Label();
            ItemViewer = new GroupBox();
            PropertyLabel4 = new Label();
            ItemProperty4 = new NumericUpDown();
            PropertyLabel3 = new Label();
            ItemProperty3 = new NumericUpDown();
            editor_ItemImage = new PictureBox();
            FusionNameLabel = new Label();
            PropertyLabel2 = new Label();
            ItemProperty2 = new NumericUpDown();
            ModifierLabel = new Label();
            ItemModifierCB = new ComboBox();
            PropertyLabel1 = new Label();
            ItemProperty1 = new NumericUpDown();
            ItemIDLabel = new Label();
            ItemIDBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            ItemNameCB = new ComboBox();
            itemBindingSource = new BindingSource(components);
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            ItemTypeCB = new ComboBox();
            itemDictionaryBindingSource = new BindingSource(components);
            ItemViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemProperty4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemProperty3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editor_ItemImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemProperty2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ItemProperty1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemDictionaryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(271, 461);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(433, 461);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.AppWorkspace;
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.None;
            flowLayoutPanel1.Location = new Point(271, 52);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(455, 403);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(271, 5);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(0, 15);
            StatusLabel.TabIndex = 13;
            // 
            // ItemViewer
            // 
            ItemViewer.Controls.Add(PropertyLabel4);
            ItemViewer.Controls.Add(ItemProperty4);
            ItemViewer.Controls.Add(PropertyLabel3);
            ItemViewer.Controls.Add(ItemProperty3);
            ItemViewer.Controls.Add(editor_ItemImage);
            ItemViewer.Controls.Add(FusionNameLabel);
            ItemViewer.Controls.Add(PropertyLabel2);
            ItemViewer.Controls.Add(ItemProperty2);
            ItemViewer.Controls.Add(ModifierLabel);
            ItemViewer.Controls.Add(ItemModifierCB);
            ItemViewer.Controls.Add(PropertyLabel1);
            ItemViewer.Controls.Add(ItemProperty1);
            ItemViewer.Controls.Add(ItemIDLabel);
            ItemViewer.Controls.Add(ItemIDBox);
            ItemViewer.Controls.Add(label1);
            ItemViewer.Controls.Add(label2);
            ItemViewer.Controls.Add(button2);
            ItemViewer.Controls.Add(ItemNameCB);
            ItemViewer.Location = new Point(12, 12);
            ItemViewer.Name = "ItemViewer";
            ItemViewer.Size = new Size(253, 479);
            ItemViewer.TabIndex = 14;
            ItemViewer.TabStop = false;
            ItemViewer.Text = "CurrentItem";
            // 
            // PropertyLabel4
            // 
            PropertyLabel4.AutoSize = true;
            PropertyLabel4.Location = new Point(4, 332);
            PropertyLabel4.Name = "PropertyLabel4";
            PropertyLabel4.Size = new Size(56, 15);
            PropertyLabel4.TabIndex = 30;
            PropertyLabel4.Text = "Duration:";
            // 
            // ItemProperty4
            // 
            ItemProperty4.Location = new Point(68, 330);
            ItemProperty4.Maximum = new decimal(new int[] { 999999998, 0, 0, 0 });
            ItemProperty4.Name = "ItemProperty4";
            ItemProperty4.Size = new Size(165, 23);
            ItemProperty4.TabIndex = 29;
            // 
            // PropertyLabel3
            // 
            PropertyLabel3.AutoSize = true;
            PropertyLabel3.Location = new Point(4, 303);
            PropertyLabel3.Name = "PropertyLabel3";
            PropertyLabel3.Size = new Size(45, 15);
            PropertyLabel3.TabIndex = 28;
            PropertyLabel3.Text = "Health:";
            // 
            // ItemProperty3
            // 
            ItemProperty3.Location = new Point(68, 301);
            ItemProperty3.Maximum = new decimal(new int[] { 999999998, 0, 0, 0 });
            ItemProperty3.Name = "ItemProperty3";
            ItemProperty3.Size = new Size(165, 23);
            ItemProperty3.TabIndex = 27;
            // 
            // editor_ItemImage
            // 
            editor_ItemImage.BackColor = SystemColors.Control;
            editor_ItemImage.BackgroundImageLayout = ImageLayout.None;
            editor_ItemImage.Location = new Point(6, 22);
            editor_ItemImage.Name = "editor_ItemImage";
            editor_ItemImage.Size = new Size(128, 128);
            editor_ItemImage.SizeMode = PictureBoxSizeMode.StretchImage;
            editor_ItemImage.TabIndex = 1;
            editor_ItemImage.TabStop = false;
            // 
            // FusionNameLabel
            // 
            FusionNameLabel.AutoSize = true;
            FusionNameLabel.Location = new Point(0, 464);
            FusionNameLabel.Name = "FusionNameLabel";
            FusionNameLabel.Size = new Size(44, 15);
            FusionNameLabel.TabIndex = 26;
            FusionNameLabel.Text = "Fused: ";
            // 
            // PropertyLabel2
            // 
            PropertyLabel2.AutoSize = true;
            PropertyLabel2.Location = new Point(4, 274);
            PropertyLabel2.Name = "PropertyLabel2";
            PropertyLabel2.Size = new Size(61, 15);
            PropertyLabel2.TabIndex = 25;
            PropertyLabel2.Text = "Durability:";
            // 
            // ItemProperty2
            // 
            ItemProperty2.Location = new Point(68, 272);
            ItemProperty2.Maximum = new decimal(new int[] { 999999998, 0, 0, 0 });
            ItemProperty2.Name = "ItemProperty2";
            ItemProperty2.Size = new Size(165, 23);
            ItemProperty2.TabIndex = 24;
            // 
            // ModifierLabel
            // 
            ModifierLabel.AutoSize = true;
            ModifierLabel.Location = new Point(4, 217);
            ModifierLabel.Name = "ModifierLabel";
            ModifierLabel.Size = new Size(55, 15);
            ModifierLabel.TabIndex = 23;
            ModifierLabel.Text = "Modifier:";
            // 
            // ItemModifierCB
            // 
            ItemModifierCB.FormattingEnabled = true;
            ItemModifierCB.Location = new Point(68, 214);
            ItemModifierCB.Name = "ItemModifierCB";
            ItemModifierCB.Size = new Size(165, 23);
            ItemModifierCB.TabIndex = 22;
            ItemModifierCB.SelectedIndexChanged += ItemModifierCB_SelectedIndexChanged;
            // 
            // PropertyLabel1
            // 
            PropertyLabel1.AutoSize = true;
            PropertyLabel1.Location = new Point(4, 245);
            PropertyLabel1.Name = "PropertyLabel1";
            PropertyLabel1.Size = new Size(56, 15);
            PropertyLabel1.TabIndex = 21;
            PropertyLabel1.Text = "Quantity:";
            // 
            // ItemProperty1
            // 
            ItemProperty1.Location = new Point(68, 243);
            ItemProperty1.Maximum = new decimal(new int[] { 999999998, 0, 0, 0 });
            ItemProperty1.Name = "ItemProperty1";
            ItemProperty1.Size = new Size(165, 23);
            ItemProperty1.TabIndex = 20;
            // 
            // ItemIDLabel
            // 
            ItemIDLabel.AutoSize = true;
            ItemIDLabel.Location = new Point(4, 188);
            ItemIDLabel.Name = "ItemIDLabel";
            ItemIDLabel.Size = new Size(48, 15);
            ItemIDLabel.TabIndex = 19;
            ItemIDLabel.Text = "Item ID:";
            // 
            // ItemIDBox
            // 
            ItemIDBox.Location = new Point(68, 185);
            ItemIDBox.Name = "ItemIDBox";
            ItemIDBox.ReadOnly = true;
            ItemIDBox.Size = new Size(165, 23);
            ItemIDBox.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 159);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 17;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(172, 432);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 16;
            label2.Text = "Index:";
            // 
            // button2
            // 
            button2.Location = new Point(172, 450);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 15;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ItemNameCB
            // 
            ItemNameCB.FormattingEnabled = true;
            ItemNameCB.Location = new Point(68, 156);
            ItemNameCB.Name = "ItemNameCB";
            ItemNameCB.Size = new Size(165, 23);
            ItemNameCB.TabIndex = 0;
            ItemNameCB.SelectedIndexChanged += ItemNameCB_SelectedIndexChanged;
            // 
            // itemBindingSource
            // 
            itemBindingSource.DataSource = typeof(Item);
            // 
            // button4
            // 
            button4.Location = new Point(651, 460);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 15;
            button4.Text = "Write Items";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(352, 461);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
            button3.Text = "Disconnect";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(651, 23);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 16;
            button5.Text = "RamViewer";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // ItemTypeCB
            // 
            ItemTypeCB.Enabled = false;
            ItemTypeCB.FormattingEnabled = true;
            ItemTypeCB.Items.AddRange(new object[] { "Armor", "Bows", "Arrows", "Shields", "Weapons", "Materials", "Food", "Zonai", "Key" });
            ItemTypeCB.Location = new Point(271, 24);
            ItemTypeCB.Name = "ItemTypeCB";
            ItemTypeCB.Size = new Size(121, 23);
            ItemTypeCB.TabIndex = 17;
            ItemTypeCB.SelectedIndexChanged += ItemTypeCB_SelectedIndexChanged;
            // 
            // itemDictionaryBindingSource
            // 
            itemDictionaryBindingSource.DataSource = typeof(ItemDictionary);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 499);
            Controls.Add(ItemTypeCB);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(ItemViewer);
            Controls.Add(StatusLabel);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TotKLIE";
            ItemViewer.ResumeLayout(false);
            ItemViewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ItemProperty4).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemProperty3).EndInit();
            ((System.ComponentModel.ISupportInitialize)editor_ItemImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemProperty2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ItemProperty1).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemDictionaryBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label StatusLabel;
        private GroupBox ItemViewer;
        private PictureBox editor_ItemImage;
        private ComboBox ItemNameCB;
        private Button button2;
        private Button button4;
        private Label label2;
        private BindingSource itemBindingSource;
        private Button button3;
        private Button button5;
        private ComboBox ItemTypeCB;
        private Label label1;
        private Label PropertyLabel1;
        private NumericUpDown ItemProperty1;
        private Label ItemIDLabel;
        private TextBox ItemIDBox;
        private Label ModifierLabel;
        private ComboBox ItemModifierCB;
        private Label PropertyLabel2;
        private NumericUpDown ItemProperty2;
        private Label FusionNameLabel;
        private Label PropertyLabel3;
        private NumericUpDown ItemProperty3;
        private Label PropertyLabel4;
        private NumericUpDown ItemProperty4;
        private BindingSource itemDictionaryBindingSource;
    }
}