namespace генетический_алгоритм__версия_1_
{
    partial class FormBot
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
            this.mindBot = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.BotEnergy = new System.Windows.Forms.TextBox();
            this.SaveAll = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.textBoxRotate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mindBot
            // 
            this.mindBot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mindBot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mindBot.Location = new System.Drawing.Point(12, 13);
            this.mindBot.Multiline = true;
            this.mindBot.Name = "mindBot";
            this.mindBot.Size = new System.Drawing.Size(220, 220);
            this.mindBot.TabIndex = 0;
            // 
            // textBoxX
            // 
            this.textBoxX.Enabled = false;
            this.textBoxX.Location = new System.Drawing.Point(239, 13);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(60, 20);
            this.textBoxX.TabIndex = 1;
            // 
            // textBoxY
            // 
            this.textBoxY.Enabled = false;
            this.textBoxY.Location = new System.Drawing.Point(305, 12);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(60, 20);
            this.textBoxY.TabIndex = 2;
            // 
            // BotEnergy
            // 
            this.BotEnergy.Location = new System.Drawing.Point(238, 39);
            this.BotEnergy.Name = "BotEnergy";
            this.BotEnergy.Size = new System.Drawing.Size(127, 20);
            this.BotEnergy.TabIndex = 3;
            // 
            // SaveAll
            // 
            this.SaveAll.Location = new System.Drawing.Point(238, 121);
            this.SaveAll.Name = "SaveAll";
            this.SaveAll.Size = new System.Drawing.Size(127, 23);
            this.SaveAll.TabIndex = 4;
            this.SaveAll.Text = "сохранить всех";
            this.SaveAll.UseVisualStyleBackColor = true;
            this.SaveAll.Click += new System.EventHandler(this.everySave_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(238, 92);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(127, 23);
            this.save.TabIndex = 5;
            this.save.Text = "сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // textBoxRotate
            // 
            this.textBoxRotate.Location = new System.Drawing.Point(239, 66);
            this.textBoxRotate.Name = "textBoxRotate";
            this.textBoxRotate.Size = new System.Drawing.Size(126, 20);
            this.textBoxRotate.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 245);
            this.Controls.Add(this.textBoxRotate);
            this.Controls.Add(this.save);
            this.Controls.Add(this.SaveAll);
            this.Controls.Add(this.BotEnergy);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.mindBot);
            this.MaximumSize = new System.Drawing.Size(389, 284);
            this.MinimumSize = new System.Drawing.Size(389, 284);
            this.Name = "Form2";
            this.Text = "бот";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mindBot;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox BotEnergy;
        private System.Windows.Forms.Button SaveAll;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox textBoxRotate;
    }
}