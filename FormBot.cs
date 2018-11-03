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
    public partial class FormBot : Form
    {
        byte Bot;
        FormMain f;
        public FormBot()
        {
            InitializeComponent();
        }
        public FormBot(FormMain f, byte Bot)
        {
            InitializeComponent();
            this.Bot = Bot;
            this.f = f;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (f.bot[Bot].gene[j * 8 + i] > 9)
                        mindBot.Text += (Convert.ToString(f.bot[Bot].gene[j * 8 + i]) + " ");
                    else
                        mindBot.Text += ("0" + Convert.ToString(f.bot[Bot].gene[j * 8 + i]) + " ");
                }
                mindBot.Text += Environment.NewLine;
            }
            textBoxX.Text = Convert.ToString(f.bot[Bot].X);
            textBoxY.Text = Convert.ToString(f.bot[Bot].Y);
            BotEnergy.Text = Convert.ToString(f.bot[Bot].energy);
            textBoxRotate.Text = Convert.ToString(f.bot[Bot].rotate);
        }
        private void save_Click(object sender, EventArgs e)
        {
            if (mindBot.Text.Split(' ').Length - 1 == 64)
            {
                byte[] gene = new byte[64];
                for (int i = 0; i < 64; i++)
                    gene[i] = Convert.ToByte(mindBot.Text.Split(' ')[i]);
                f.bot[Bot].NewGene(gene);
                if (Convert.ToByte(BotEnergy.Text) <= 100)
                    f.bot[Bot].energy = Convert.ToByte(BotEnergy.Text);
                else
                    f.bot[Bot].energy = 100;
                f.bot[Bot].rotate = (byte)(Convert.ToByte(textBoxRotate.Text) % 8);
            }
        }
        private void everySave_Click(object sender, EventArgs e)
        {
            if (mindBot.Text.Split(' ').Length - 1 == 64)
            {
                byte[] gene = new byte[64];
                for (int i = 0; i < 64; i++)
                    gene[i] = Convert.ToByte(mindBot.Text.Split(' ')[i]);
                if (Convert.ToByte(BotEnergy.Text) <= 100)
                    f.SaveEveryBot(gene, Convert.ToByte(BotEnergy.Text));
                else
                    f.SaveEveryBot(gene, 100);
            }
        }
    }
}
