namespace генетический_алгоритм__версия_1_
{
    partial class FormOptions
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
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.autoSave = new System.Windows.Forms.CheckBox();
            this.apply = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.appearanceBots = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(12, 12);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 0;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(118, 12);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 1;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 38);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(100, 23);
            this.open.TabIndex = 2;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(118, 38);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // autoSave
            // 
            this.autoSave.AutoSize = true;
            this.autoSave.Location = new System.Drawing.Point(13, 68);
            this.autoSave.Name = "autoSave";
            this.autoSave.Size = new System.Drawing.Size(73, 17);
            this.autoSave.TabIndex = 4;
            this.autoSave.Text = "AutoSave";
            this.autoSave.UseVisualStyleBackColor = true;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(13, 92);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(204, 23);
            this.apply.TabIndex = 5;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // appearanceBots
            // 
            this.appearanceBots.Items.Add("стандарт");
            this.appearanceBots.Items.Add("мутант");
            this.appearanceBots.Items.Add("энергия");
            this.appearanceBots.Location = new System.Drawing.Point(118, 68);
            this.appearanceBots.Name = "appearanceBots";
            this.appearanceBots.ReadOnly = true;
            this.appearanceBots.Size = new System.Drawing.Size(98, 20);
            this.appearanceBots.TabIndex = 6;
            this.appearanceBots.Text = "стандарт";
            this.appearanceBots.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.appearanceBots.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 125);
            this.Controls.Add(this.appearanceBots);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.autoSave);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.MaximumSize = new System.Drawing.Size(245, 164);
            this.MinimumSize = new System.Drawing.Size(245, 164);
            this.Name = "Form3";
            this.Text = "Опции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.CheckBox autoSave;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DomainUpDown appearanceBots;
    }
}