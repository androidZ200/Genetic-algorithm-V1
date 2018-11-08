using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace генетический_алгоритм__версия_1_
{
    public partial class FormOptions : Form
    {
        FormMain f;
        public FormOptions()
        {
            InitializeComponent();
        }
        public FormOptions(FormMain f)
        {
            this.f = f;
            InitializeComponent();
            textBoxX.Text = Convert.ToString(f.NextFieldX);
            textBoxY.Text = Convert.ToString(f.NextFieldY);
            autoSave.Checked = f.AutoSave;
            appearanceBots.Text = f.appearance;
        }
        private void apply_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBoxX.Text) > 802) textBoxX.Text = "802";
                if (Convert.ToInt32(textBoxY.Text) > 402) textBoxY.Text = "402";
                if (Convert.ToInt32(textBoxX.Text) < 52) textBoxX.Text = "42";
                if (Convert.ToInt32(textBoxY.Text) < 32) textBoxY.Text = "32";
                f.AutoSave = autoSave.Checked;
                f.NextFieldX = Convert.ToInt32(textBoxX.Text);
                f.NextFieldY = Convert.ToInt32(textBoxY.Text);
                f.appearance = appearanceBots.Text;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Введите только цифры");
            }
        }
        private void open_Click(object sender, EventArgs e)
        {
            byte[] open;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            open = System.IO.File.ReadAllBytes(fileName);
            f.SetSave(open);
            f.DrawField();
            this.Close();
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = saveFileDialog1.FileName;
            System.IO.File.WriteAllBytes(fileName, f.GetSave());
            MessageBox.Show("файл сохранен");
            f.fileName = fileName;
        }
    }
}
