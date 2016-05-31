using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgSplit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private static Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, System.Drawing.Imaging.PixelFormat.DontCare);
            return (Image)(bmpCrop);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "" && textBox2.Text != "" && textBox1.Text != "" && int.Parse(textBox1.Text) > 0 && int.Parse(textBox2.Text) > 0) {
            List<Image> list = new List<Image>();

            Image img = new Bitmap(openFileDialog1.FileName);

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                for (int i = 0; i < int.Parse(textBox1.Text); i++)
                {
                    for (int y = 0; y < int.Parse(textBox2.Text); y++)
                    {
                        Rectangle r = new Rectangle(i * (img.Width / int.Parse(textBox1.Text)),
                                                    y * (img.Height / int.Parse(textBox2.Text)),
                                                    img.Width / int.Parse(textBox1.Text),
                                                    img.Height / int.Parse(textBox2.Text));

                        cropImage(img, r).Save(folderBrowserDialog1.SelectedPath + "/Splitted Image " + i + "-" + y + ".png");

                    }
                }

            }

            MessageBox.Show("Images splitted successfully!");
        }

        }
    }
}
