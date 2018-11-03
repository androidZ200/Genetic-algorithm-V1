namespace генетический_алгоритм__версия_1_
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBot = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.generations = new System.Windows.Forms.TextBox();
            this.moveBot = new System.Windows.Forms.TextBox();
            this.botCount = new System.Windows.Forms.TextBox();
            this.options = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBot)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBot
            // 
            this.pictureBot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBot.Location = new System.Drawing.Point(13, 13);
            this.pictureBot.Name = "pictureBot";
            this.pictureBot.Size = new System.Drawing.Size(748, 396);
            this.pictureBot.TabIndex = 0;
            this.pictureBot.TabStop = false;
            this.pictureBot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.start.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.start.ForeColor = System.Drawing.SystemColors.Control;
            this.start.Location = new System.Drawing.Point(768, 13);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(64, 43);
            this.start.TabIndex = 1;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // reset
            // 
            this.reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reset.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reset.ForeColor = System.Drawing.SystemColors.Control;
            this.reset.Location = new System.Drawing.Point(767, 62);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(64, 43);
            this.reset.TabIndex = 2;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // generations
            // 
            this.generations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generations.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.generations.Enabled = false;
            this.generations.ForeColor = System.Drawing.SystemColors.Control;
            this.generations.Location = new System.Drawing.Point(767, 112);
            this.generations.Name = "generations";
            this.generations.Size = new System.Drawing.Size(65, 20);
            this.generations.TabIndex = 3;
            // 
            // moveBot
            // 
            this.moveBot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveBot.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.moveBot.Enabled = false;
            this.moveBot.ForeColor = System.Drawing.SystemColors.Control;
            this.moveBot.Location = new System.Drawing.Point(766, 138);
            this.moveBot.Name = "moveBot";
            this.moveBot.Size = new System.Drawing.Size(65, 20);
            this.moveBot.TabIndex = 3;
            // 
            // botCount
            // 
            this.botCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botCount.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.botCount.Enabled = false;
            this.botCount.ForeColor = System.Drawing.SystemColors.Control;
            this.botCount.Location = new System.Drawing.Point(766, 164);
            this.botCount.Name = "botCount";
            this.botCount.Size = new System.Drawing.Size(65, 20);
            this.botCount.TabIndex = 3;
            // 
            // options
            // 
            this.options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.options.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.options.ForeColor = System.Drawing.SystemColors.Control;
            this.options.Location = new System.Drawing.Point(766, 191);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(65, 23);
            this.options.TabIndex = 4;
            this.options.Text = "Options";
            this.options.UseVisualStyleBackColor = false;
            this.options.Click += new System.EventHandler(this.options_Click);
            // 
            // show
            // 
            this.show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.show.AutoSize = true;
            this.show.Checked = true;
            this.show.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show.ForeColor = System.Drawing.SystemColors.Control;
            this.show.Location = new System.Drawing.Point(766, 220);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(53, 17);
            this.show.TabIndex = 5;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(844, 421);
            this.Controls.Add(this.show);
            this.Controls.Add(this.options);
            this.Controls.Add(this.botCount);
            this.Controls.Add(this.moveBot);
            this.Controls.Add(this.generations);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.start);
            this.Controls.Add(this.pictureBot);
            this.MinimumSize = new System.Drawing.Size(439, 287);
            this.Name = "Form1";
            this.Text = "генетический алгоритм";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.CheckBox show;
        public System.Windows.Forms.PictureBox pictureBot;
        public System.Windows.Forms.TextBox generations;
        public System.Windows.Forms.TextBox moveBot;
        public System.Windows.Forms.TextBox botCount;
    }
}

