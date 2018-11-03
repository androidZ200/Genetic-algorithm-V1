using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace генетический_алгоритм__версия_1_
{
    public partial class FormMain : Form
    {
        object Lock = new object();
        Random rand = new Random();
        Thread t1;
        public string fileName = null;
        public string appearance = "стандарт";
        public bool AutoSave = false;
        public int StopPoint = 0;
        bool stop = false;
        public int fieldX, fieldY;
        public int NextFieldX = 122, NextFieldY = 62;
        public byte[,] field;
        public List<BOT> bot = new List<BOT>();
        public int generation = 1;
        public byte game = 0;
        public FormMain()
        {
            InitializeComponent();
            pictureBot.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void start_Click(object sender, EventArgs e)
        {
            t1 = new Thread(simulation);
            if (game == 1)
            {
                t1.Start();
                game = 2;
                stop = false;
                start.Text = "Stop";
            }
            else if (game == 2)
            {
                stop = true;
                game = 1;
                start.Text = "Start";
            }
        }
        private void reset_Click(object sender, EventArgs e)
        {
            if (t1 != null)
                t1.Abort();
            generation = 1;
            StopPoint = 0;
            stop = true;
            fieldX = NextFieldX;
            fieldY = NextFieldY;
            field = new byte[fieldX, fieldY];
            for (int i = 0; i < fieldX; i++)
                for (int j = 0; j < fieldY; j++)
                {
                    if (i == 0 || j == 0 || i == fieldX - 1 || j == fieldY - 1)
                    {
                        field[i, j] = 1;
                    }
                    else
                    {
                        field[i, j] = 0;
                        if (rand.Next(50) == 0)
                            field[i, j] = 1;
                        else if (rand.Next(15) == 0)
                            field[i, j] = 3;
                        else if (rand.Next(40) == 0)
                            field[i, j] = 4;
                    }
                }
            bot.Clear();
            for (int i = 0; i < 64; i++)
            {
                bot.Add(new BOT());
                int X, Y;
                while (true)
                {
                    X = rand.Next(1, fieldX);
                    Y = rand.Next(1, fieldY);
                    if (field[X, Y] == 0) break;
                }
                bot[i].X = X;
                bot[i].Y = Y;
                bot[i].rotate = (byte)rand.Next(8);
                field[X, Y] = 2;
            }
            game = 1;
            DrawField();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t1 != null)
                t1.Abort();
        }
        private void simulation()
        {
            int i = StopPoint;
            this.Invoke(new EventHandler(delegate { generations.Text = Convert.ToString(generation); }));
            this.Invoke(new EventHandler(delegate { moveBot.Text = Convert.ToString(i); }));
            this.Invoke(new EventHandler(delegate { botCount.Text = Convert.ToString(bot.Count); }));
            while (!stop)
            {
                bot[i].transitio = 0;
                while (bot[i].transitio < 10)
                {
                    if (bot.Count == 8) break;
                    if (bot[i].gene[bot[i].counter] <= 7) //сходить
                    {
                        int x = 0, y = 0;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 7 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 6 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 5) x = -1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 1 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 2 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 3) x = 1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 7 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 0 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 1) y = -1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 3 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 4 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 5) y = 1;
                        if (field[bot[i].X + x, bot[i].Y + y] == 0)
                        {
                            field[bot[i].X, bot[i].Y] = 0;
                            field[bot[i].X + x, bot[i].Y + y] = 2;
                            bot[i].X += x;
                            bot[i].Y += y;
                            bot[i].transitio = 10;
                            bot[i].counter = (byte)((bot[i].counter + bot[i].gene[(bot[i].counter + 1 + field[bot[i].X + x, bot[i].Y + y]) % 64]) % 64);
                        }
                        else if (field[bot[i].X + x, bot[i].Y + y] == 3)
                        {
                            field[bot[i].X, bot[i].Y] = 0;
                            field[bot[i].X + x, bot[i].Y + y] = 2;
                            bot[i].X += x;
                            bot[i].Y += y;
                            if (bot[i].energy < 90) bot[i].energy += 10;
                            else bot[i].energy = 100;
                            bot[i].transitio = 10;
                            bot[i].counter = (byte)((bot[i].counter + bot[i].gene[(bot[i].counter + 1 + field[bot[i].X + x, bot[i].Y + y]) % 64]) % 64);
                        }
                        else if (field[bot[i].X + x, bot[i].Y + y] == 4)
                        {
                            field[bot[i].X, bot[i].Y] = 3;
                            field[bot[i].X + x, bot[i].Y + y] = 0;
                            bot.RemoveAt(i);
                            i %= bot.Count;
                        }
                        else
                        {
                            bot[i].transitio = 10;
                            bot[i].counter = (byte)((bot[i].counter + bot[i].gene[(bot[i].counter + 1 + field[bot[i].X + x, bot[i].Y + y]) % 64]) % 64);
                        }
                    }
                    else if (bot[i].gene[bot[i].counter] <= 15) //съесть 
                    {
                        int x = 0, y = 0;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 7 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 6 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 5) x = -1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 1 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 2 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 3) x = 1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 7 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 0 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 1) y = -1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 3 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 4 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 5) y = 1;
                        if (field[bot[i].X + x, bot[i].Y + y] == 2)
                        {
                            for (int j = 0; j < bot.Count; j++)
                                if (bot[i].X + x == bot[j].X && bot[i].Y + y == bot[j].Y)
                                {
                                    bot.RemoveAt(j);
                                    if (j < i) i--;
                                }
                            if (bot[i].energy < 90) bot[i].energy += 10;
                            else bot[i].energy = 100;
                            field[bot[i].X + x, bot[i].Y + y] = 0;
                        }
                        else if (field[bot[i].X + x, bot[i].Y + y] == 3)
                        {
                            if (bot[i].energy < 90) bot[i].energy += 10;
                            else bot[i].energy = 100;
                            field[bot[i].X + x, bot[i].Y + y] = 0;
                        }
                        else if (field[bot[i].X + x, bot[i].Y + y] == 4)
                        {
                            field[bot[i].X + x, bot[i].Y + y] = 3;
                        }
                        bot[i].transitio = 10;
                        bot[i].counter = (byte)((bot[i].counter + bot[i].gene[(bot[i].counter + 1 + field[bot[i].X + x, bot[i].Y + y]) % 64]) % 64);
                    }
                    else if (bot[i].gene[bot[i].counter] <= 23) //посмотреть
                    {
                        int x = 0, y = 0;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 7 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 6 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 5) x = -1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 1 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 2 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 3) x = 1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 7 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 0 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 1) y = -1;
                        if ((bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 3 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 4 || (bot[i].rotate + bot[i].gene[bot[i].counter]) % 8 == 5) y = 1;
                        bot[i].transitio++;
                        bot[i].counter = (byte)((bot[i].counter + bot[i].gene[(bot[i].counter + 1 + field[bot[i].X + x, bot[i].Y + y]) % 64]) % 64);
                    }
                    else if (bot[i].gene[bot[i].counter] <= 30) //повороты
                    {
                        bot[i].rotate = (byte)((bot[i].rotate + bot[i].gene[bot[i].counter] + 1) % 8);
                        bot[i].transitio++;
                        bot[i].counter = (byte)((bot[i].counter + 1) % 64);
                    }
                    else //переход
                    {
                        bot[i].transitio++;
                        bot[i].counter = (byte)((bot[i].counter + bot[i].gene[bot[i].counter]) % 64);
                    }
                }
                bot[i].energy--;
                bot[i].transitio = 0;
                if (bot[i].energy == 0 && bot.Count > 8)
                {
                    field[bot[i].X, bot[i].Y] = 3;
                    bot.RemoveAt(i);
                    i--;
                }
                i++;
                i %= bot.Count;
                StopPoint = i;
                if (bot.Count == 8)
                {
                    for (int l = 0; l < 8; l++)
                        bot[l].mutant = false;
                    for (int l = 0; l < 56; l++)
                    {
                        bot.Add(new BOT(bot[l % 8].gene));
                        if (l >= 40)
                            bot[l + 8].Mutation(rand);
                        if (l >= 48)
                            bot[l + 8].Mutation(rand);
                    }
                    i = 0;
                    StopPoint = 0;
                    generation++;
                    for (int l = 0; l < fieldX; l++)
                        for (int j = 0; j < fieldY; j++)
                        {
                            field[l, j] = 0;
                            if (l == 0 || j == 0 || l == fieldX - 1 || j == fieldY - 1)
                            {
                                field[l, j] = 1;
                            }
                            else
                            {
                                field[l, j] = 0;
                                if (rand.Next(50) == 0)
                                    field[l, j] = 1;
                                else if (rand.Next(15) == 0)
                                    field[l, j] = 3;
                                else if (rand.Next(40) == 0)
                                    field[l, j] = 4;
                            }
                        }
                    for (int l = 0; l < 64; l++)
                    {
                        int X, Y;
                        while (true)
                        {
                            X = rand.Next(1, fieldX);
                            Y = rand.Next(1, fieldY);
                            if (field[X, Y] == 0) break;
                        }
                        bot[l].X = X;
                        bot[l].Y = Y;
                        bot[l].counter = 0;
                        bot[l].energy = 100;
                        bot[l].transitio = 0;
                        bot[l].rotate = (byte)rand.Next(8);
                        field[X, Y] = 2;
                    }
                }
                else if (rand.Next(15) == 0)
                    if (rand.Next(2) == 0)
                    {
                        int x = rand.Next(1, fieldX);
                        int y = rand.Next(1, fieldY);
                        if (field[x, y] != 1 && field[x, y] != 2)
                            field[x, y] = 3;
                    }
                    else
                    {
                        int x = rand.Next(1, fieldX);
                        int y = rand.Next(1, fieldY);
                        if (field[x, y] != 1 && field[x, y] != 2)
                            field[x, y] = 4;
                    }
                if (AutoSave && generation % 20 == 0 && StopPoint == 0 && bot.Count == 64)
                    autoSave();
                if (StopPoint == 0)
                    DrawField();
                this.Invoke(new EventHandler(delegate { generations.Text = Convert.ToString(generation); }));
                this.Invoke(new EventHandler(delegate { moveBot.Text = Convert.ToString(i); }));
                this.Invoke(new EventHandler(delegate { botCount.Text = Convert.ToString(bot.Count); }));
            }
        }
        public void DrawField()
        {
            if (show.Checked)
            {
                Bitmap bmp = new Bitmap(fieldX * 10, fieldY * 10);
                Graphics g = Graphics.FromImage(bmp);
                for (int l = 0; l < fieldX; l++)
                    for (int j = 0; j < fieldY; j++)
                    {
                        Color clr = Color.Black;
                        if (field[l, j] == 0) clr = Color.Black;
                        else if (field[l, j] == 1) clr = Color.Gray;
                        else if (field[l, j] == 2)
                        {
                            if (appearance.Length == 6)
                            {
                                for (int n = 0; n < bot.Count; n++)
                                    if (bot[n].X == l && bot[n].Y == j)
                                    {
                                        if (bot[n].mutant)
                                            clr = Color.DarkBlue;
                                        else
                                            clr = Color.Blue;
                                        break;
                                    }
                            }
                            else if (appearance.Length == 7)
                            {
                                for (int n = 0; n < bot.Count; n++)
                                    if (bot[n].X == l && bot[n].Y == j)
                                    {
                                        clr = Color.FromArgb(0, 0, bot[n].energy * 255 / 100);
                                        break;
                                    }
                            }
                            else
                                clr = Color.Blue;
                        }
                        else if (field[l, j] == 3) clr = Color.Green;
                        else if (field[l, j] == 4) clr = Color.Red;
                        g.FillRectangle(new SolidBrush(clr), l * 10, j * 10, 9, 9);
                    }
                lock (Lock)
                    pictureBot.Image = bmp;
            }
        }
        private void options_Click(object sender, EventArgs e)
        {
            game = 1;
            stop = true;
            start.Text = "Start";
            FormOptions newForm = new FormOptions(this);
            newForm.ShowDialog();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (game == 1)
            {
                byte x = 0, y = 0;
                for (int i = 0; i < fieldX; i++)
                    if (e.Location.X > i * (double)(pictureBot.Width * 1.0 / fieldX) && e.Location.X <= (i + 1) * (double)(pictureBot.Width * 1.0 / fieldX))
                        x = (byte)i;
                for (int i = 0; i < fieldY; i++)
                    if (e.Location.Y > i * (double)(pictureBot.Height * 1.0 / fieldY) && e.Location.Y <= (i + 1) * (double)(pictureBot.Height * 1.0 / fieldY))
                        y = (byte)i;
                if (field[x, y] == 2)
                {
                    byte i;
                    for (i = 0; i < bot.Count; i++)
                        if (bot[i].X == x && bot[i].Y == y) break;
                    FormBot newForm = new FormBot(this, i);
                    newForm.ShowDialog();
                }
            }
        }
        public void SaveEveryBot(byte[] NewGene, byte NewEnergy)
        {
            for (int i = 0; i < bot.Count; i++)
            {
                bot[i].NewGene(NewGene);
                bot[i].energy = NewEnergy;
                bot[i].counter = 0;
            }
        }
        private void autoSave()
        {
            if (fileName != null)
            {
                string save = null;
                save += Convert.ToString(fieldX) + " " + Convert.ToString(fieldY) + " " + Convert.ToString(generation) + " " + Convert.ToString(StopPoint) + "й";
                for (int j = 0; j < fieldY; j++)
                    for (int i = 0; i < fieldX; i++)
                        save += Convert.ToString(field[i, j]) + " ";
                save += "й";
                for (int i = 0; i < bot.Count; i++)
                {
                    for (int j = 0; j < 64; j++)
                        save += Convert.ToString(bot[i].gene[j]) + " ";
                    save += Convert.ToString(bot[i].energy) + " ";
                    save += Convert.ToString(bot[i].counter) + " ";
                    save += Convert.ToString(bot[i].rotate) + " ";
                    save += Convert.ToString(bot[i].X) + " ";
                    save += Convert.ToString(bot[i].Y) + "ц";
                }
                System.IO.File.WriteAllText(fileName, save);
            }
        }
    }

    public class BOT
    {
        static Random rand = new Random();
        public byte[] gene = new byte[64];
        public byte energy = 100;
        public byte counter = 0;
        public byte rotate = 0;
        public byte transitio = 0;
        public int X, Y;
        public bool mutant = false;
        public BOT()
        {
            for (int i = 0; i < 64; i++)
                gene[i] = (byte)rand.Next(64);
        }
        public BOT(byte[] outGene)
        {
            for (int i = 0; i < 64; i++)
                gene[i] = outGene[i];
        }
        public void NewGene(byte[] NewGene)
        {
            for (int i = 0; i < 64; i++)
                gene[i] = NewGene[i];
        }
        public void Mutation(Random rand)
        {
            gene[rand.Next(64)] = (byte)rand.Next(64);
            mutant = true;
        }
    }
}