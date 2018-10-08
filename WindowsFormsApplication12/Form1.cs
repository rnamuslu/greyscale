using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        Bitmap kaynak, islem;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = openFileDialog1.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                kaynak = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = kaynak;
            }
        }
    

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void griyapToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Bitmap Image = new Bitmap(pictureBox1.Image);
            Bitmap gri = griYap(Image);
            islemBox.Image = gri;


        }
        private Bitmap griYap(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = Convert.ToInt16(bmp.GetPixel(j, i).R * 0.299 + bmp.GetPixel(j, i).G * 0.587 + bmp.GetPixel(j, i).B * 0.114);
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }

        private void ortalamaDeğerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap Image = new Bitmap(pictureBox1.Image);
            Bitmap gri = luma(Image);
            islemBox.Image = gri;


        }
        private Bitmap luma(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height - 1; i++)
            {
                for (int j = 0; j < bmp.Width - 1; j++)
                {
                    int deger = Convert.ToInt16(bmp.GetPixel(j, i).R * 0.299 + bmp.GetPixel(j, i).G * 0.587 + bmp.GetPixel(j, i).B * 0.114);
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    bmp.SetPixel(j, i, renk);
                }
            }
            return bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kaydetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
                saveFileDialog1.Filter = "PNG|*.png";
                DialogResult sonuc = saveFileDialog1.ShowDialog();
                ImageFormat format = ImageFormat.Png;
                if (sonuc == DialogResult.OK)
                {
        
                islem.Save(saveFileDialog1.FileName, format);
                }

            }

        private void bT709AlgoritmasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                int gen = kaynak.Width;
                int yuk = kaynak.Height;

                islem = new Bitmap(gen, yuk);

                for (int y = 0; y < yuk; y++)
                {
                    for (int x = 0; x < gen; x++)
                    {
                        Color renkliRenk = kaynak.GetPixel(x, y);
                        Color siraliRenk = Color.FromArgb(renkliRenk.G, renkliRenk.B, renkliRenk.R);
                        islem.SetPixel(x, y, siraliRenk);
                    }
                }

                islemBox.Image = islem;


            }


        }
    }
}










