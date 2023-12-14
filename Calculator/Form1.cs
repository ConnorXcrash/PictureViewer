using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.CenterToScreen(); // Center the form to the screen
            Viewer.SizeMode = PictureBoxSizeMode.Zoom; // Set the picturebox to zoom
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to exit?";
            string title = "Exit";
            MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openPicDlg.FileName = ""; // Set the file name to empty
            openPicDlg.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp) | *.jpg; *.jpeg; *.png; *.gif; *.bmp"; // Set the filter to only show image files 

            openPicDlg.ShowDialog(); // Show the open file dialog
            if(!string.IsNullOrEmpty(openPicDlg.FileName)) // If the file name is not empty
            {
                Viewer.Image = Image.FromFile(openPicDlg.FileName); // Set the image to the file name
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Viewer.SizeMode = PictureBoxSizeMode.StretchImage; // Set the picturebox to stretch image
            Viewer.Refresh(); // Refresh the picturebox
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Viewer.SizeMode = PictureBoxSizeMode.Normal; // Set the picturebox to auto size

            Image img = Viewer.Image; // Set the image to the picturebox image
            Size imgSize = new Size(img.Width + 100, img.Height + 100); // Set the image size to the image width and height

            Bitmap bm = new Bitmap(img, imgSize); // Set the bitmap to the image and image size
            Graphics g = Graphics.FromImage(bm); // Set the graphics to the bitmap
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Set the interpolation mode to high quality bicubic

            Viewer.Image = bm; // Set the picturebox image to the bitmap
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Viewer.Image = null; // Set the picturebox image to null
            Viewer.BackColor = Color.Transparent; // Set the picturebox background color to null
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Viewer.SizeMode = PictureBoxSizeMode.Normal; // Set the picturebox to auto size

            Image img = Viewer.Image; // Set the image to the picturebox image
            Size imgSize = new Size(img.Width - 100, img.Height - 100); // Set the image size to the image width and height

            //Check if new size, width, or height are below 0
            if (imgSize.Width < 0 || imgSize.Height < 0)
            {
                MessageBox.Show("Image size cannot be below 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                return; // Return
            }

            Bitmap bm = new Bitmap(img, imgSize); // Set the bitmap to the image and image size
            Graphics g = Graphics.FromImage(bm); // Set the graphics to the bitmap
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // Set the interpolation mode to high quality bicubic

            Viewer.Image = bm; // Set the picturebox image to the bitmap
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Allows the user to set the color of the picture box
            ColorDialog colorDlg = new ColorDialog(); // Create a new color dialog
            colorDlg.AllowFullOpen = true; // Allow the user to open the full color dialog
            colorDlg.AnyColor = true; // Allow the user to select any color
            colorDlg.SolidColorOnly = false; // Allow the user to select a solid color
            colorDlg.ShowDialog();

            Viewer.BackColor = colorDlg.Color; // Set the picturebox background color to the color dialog color
        }
    }
}
