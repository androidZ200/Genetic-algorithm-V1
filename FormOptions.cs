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
            string open;
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = openFileDialog1.FileName;
            open = System.IO.File.ReadAllText(fileName);
            f.fileName = fileName;
            f.fieldX = Convert.ToInt32(open.Split('й')[0].Split(' ')[0]);
            f.fieldY = Convert.ToInt32(open.Split('й')[0].Split(' ')[1]);
            f.generation = Convert.ToInt32(open.Split('й')[0].Split(' ')[2]);
            f.StopPoint = Convert.ToInt32(open.Split('й')[0].Split(' ')[3]);
            f.game = 1;
            f.field = new byte[f.fieldX, f.fieldY];
            for (int j = 0; j < f.fieldY; j++)
                for (int i = 0; i < f.fieldX; i++)
                    f.field[i, j] = Convert.ToByte(open.Split('й')[1].Split(' ')[j * f.fieldX + i]);
            f.bot.Clear();
            for (int i = 0; i < Convert.ToInt32(open.Split('й')[2].Split('ц').Length) - 1; i++)
            {
                f.bot.Add(new BOT());
                for (int j = 0; j < 64; j++)
                    f.bot[i].gene[j] = Convert.ToByte(open.Split('й')[2].Split('ц')[i].Split(' ')[j]);
                f.bot[i].energy = Convert.ToByte(open.Split('й')[2].Split('ц')[i].Split(' ')[64]);
                f.bot[i].counter = Convert.ToByte(open.Split('й')[2].Split('ц')[i].Split(' ')[65]);
                f.bot[i].rotate = Convert.ToByte(open.Split('й')[2].Split('ц')[i].Split(' ')[66]);
                f.bot[i].X = Convert.ToByte(open.Split('й')[2].Split('ц')[i].Split(' ')[67]);
                f.bot[i].Y = Convert.ToByte(open.Split('й')[2].Split('ц')[i].Split(' ')[68]);
            }
            f.DrawField();
            f.generations.Text = Convert.ToString(f.generation);
            f.moveBot.Text = Convert.ToString(f.StopPoint);
            f.botCount.Text = Convert.ToString(f.bot.Count);
            this.Close();
        }
        private void save_Click(object sender, EventArgs e)
        {
            string save = null;
            save += Convert.ToString(f.fieldX) + " " + Convert.ToString(f.fieldY) + " " + Convert.ToString(f.generation) + " " + Convert.ToString(f.StopPoint) + "й";
            for (int j = 0; j < f.fieldY; j++)
                for (int i = 0; i < f.fieldX; i++)
                    save += Convert.ToString(f.field[i, j]) + " ";
            save += "й";
            for (int i = 0; i < f.bot.Count; i++)
            {
                for (int j = 0; j < 64; j++)
                    save += Convert.ToString(f.bot[i].gene[j]) + " ";
                save += Convert.ToString(f.bot[i].energy) + " ";
                save += Convert.ToString(f.bot[i].counter) + " ";
                save += Convert.ToString(f.bot[i].rotate) + " ";
                save += Convert.ToString(f.bot[i].X) + " ";
                save += Convert.ToString(f.bot[i].Y) + "ц";
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string fileName = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(fileName, save);
            MessageBox.Show("файл сохранен");
            f.fileName = fileName;
        }
    }
}
