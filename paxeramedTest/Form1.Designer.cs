namespace paxeramedTest
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGreyScale = new System.Windows.Forms.Button();
            this.buttonInverse = new System.Windows.Forms.Button();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.widthBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.lengthBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(787, 101);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 587);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // buttonGreyScale
            // 
            this.buttonGreyScale.Enabled = false;
            this.buttonGreyScale.Location = new System.Drawing.Point(787, 157);
            this.buttonGreyScale.Name = "buttonGreyScale";
            this.buttonGreyScale.Size = new System.Drawing.Size(75, 23);
            this.buttonGreyScale.TabIndex = 0;
            this.buttonGreyScale.Text = "GreyScale";
            this.buttonGreyScale.UseVisualStyleBackColor = true;
            this.buttonGreyScale.Click += new System.EventHandler(this.buttonGreyScale_Clicked);
            // 
            // buttonInverse
            // 
            this.buttonInverse.Enabled = false;
            this.buttonInverse.Location = new System.Drawing.Point(787, 211);
            this.buttonInverse.Name = "buttonInverse";
            this.buttonInverse.Size = new System.Drawing.Size(75, 23);
            this.buttonInverse.TabIndex = 3;
            this.buttonInverse.Text = "Inverse";
            this.buttonInverse.UseVisualStyleBackColor = true;
            this.buttonInverse.Click += new System.EventHandler(this.buttonInverse_Click);
            // 
            // zoomBar
            // 
            this.zoomBar.Enabled = false;
            this.zoomBar.LargeChange = 1;
            this.zoomBar.Location = new System.Drawing.Point(727, 75);
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.zoomBar.Size = new System.Drawing.Size(45, 262);
            this.zoomBar.TabIndex = 4;
            this.zoomBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.zoomBar.Value = 5;
            this.zoomBar.Scroll += new System.EventHandler(this.zoomBar_Scroll);
            // 
            // widthBox
            // 
            this.widthBox.BackColor = System.Drawing.SystemColors.Menu;
            this.widthBox.Location = new System.Drawing.Point(727, 458);
            this.widthBox.Name = "widthBox";
            this.widthBox.ReadOnly = true;
            this.widthBox.Size = new System.Drawing.Size(145, 20);
            this.widthBox.TabIndex = 5;
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(727, 484);
            this.heightBox.Name = "heightBox";
            this.heightBox.ReadOnly = true;
            this.heightBox.Size = new System.Drawing.Size(145, 20);
            this.heightBox.TabIndex = 6;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(727, 510);
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Size = new System.Drawing.Size(145, 20);
            this.dateBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Picture Information:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(724, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Zoom Slider";
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.Enabled = false;
            this.buttonSaveFile.Location = new System.Drawing.Point(787, 258);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFile.TabIndex = 10;
            this.buttonSaveFile.Text = "Save File";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // lengthBox
            // 
            this.lengthBox.Location = new System.Drawing.Point(727, 562);
            this.lengthBox.Name = "lengthBox";
            this.lengthBox.ReadOnly = true;
            this.lengthBox.Size = new System.Drawing.Size(145, 20);
            this.lengthBox.TabIndex = 11;
            this.lengthBox.Text = "Line Length:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.lengthBox);
            this.Controls.Add(this.buttonSaveFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.zoomBar);
            this.Controls.Add(this.buttonInverse);
            this.Controls.Add(this.buttonGreyScale);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonOpenFile);
            this.MaximumSize = new System.Drawing.Size(900, 650);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "Form1";
            this.Text = "Paxeramed ";
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGreyScale;
        private System.Windows.Forms.Button buttonInverse;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.TextBox widthBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.TextBox lengthBox;
    }
}

