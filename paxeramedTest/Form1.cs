using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace paxeramedTest
{
    public partial class Form1 : Form
    {
        
        private Bitmap sourceImg; //Bitmap for loaded image
        
        float ratio, xPos, yPos, xStartPos, yStartPos, xCurrent, yCurrent, initialRatio;

        //variables for drawing the ling
        float startX, endX, startY, endY;
        //State checks
        bool boolDrawLine = false;
        bool boolFirstImage  = false;
        bool boolMoveImage = false;
        bool boolGrayScale = false;
        bool boolInverse = false;
        bool boolSaveFile = false;

        //Color matrices used to convert image to matching format
        ImageAttributes CSAttributes = new ImageAttributes();
        ColorMatrix greyScaleMatrix = new ColorMatrix ( new float[][] {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1} });
        ColorMatrix inverseMatrix = new ColorMatrix ( new float[][] {
                 new float[] {-1, 0, 0, 0, 0},
                 new float[] {0, -1, 0, 0, 0},
                 new float[] {0, 0, -1, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {1, 1, 1, 0, 1} });
        ColorMatrix inverseGreyScaleMatrix = new ColorMatrix ( new float[][] {
                 new float[] {-.3f, -.3f, -.3f, 0, 0},
                 new float[] {-.59f, -.59f, -.59f, 0, 0},
                 new float[] {-.11f, -.11f, -.11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {1, 1, 1, 0, 1} });
        

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog()){
                openFileDialog1.Title = "Open Image";
                //Only allow bmp, JPEG, JPG, and png files
                openFileDialog1.Filter = "Image Files (*.bmp, *.jpeg, *.jpg, *.png)|*.bmp; *.jpeg; *.jpg; *.png";

                if (openFileDialog1.ShowDialog() == DialogResult.OK){
                    //Reset Values
                    xPos = yPos = xCurrent = yCurrent = 0.0F;
                    zoomBar.Value = 5;

                    sourceImg = new Bitmap(openFileDialog1.FileName);
                    //Write File information to text boxes 
                    widthBox.Text = "Width: " + sourceImg.Width + " px";
                    heightBox.Text = "Height: " + sourceImg.Height + " px";
                    DateTime fileCreatedDate = File.GetCreationTime(openFileDialog1.FileName);
                    dateBox.Text = "Created: " + fileCreatedDate;

                    //Calculate the ratio to scale image to
                    if (sourceImg.Width > sourceImg.Height){
                        ratio = (float)panel1.Width / (float)sourceImg.Width;
                    }
                    else{
                        ratio = (float)panel1.Height / (float)sourceImg.Height;
                    }
                    initialRatio = ratio;
                    //X and Y shift to Center the image
                    if (panel1.Width > (sourceImg.Width * ratio)){
                        xPos = (((float)panel1.Width/ratio) - (float)sourceImg.Width) / 2;
                    }
                    if (panel1.Height > (sourceImg.Height * ratio)){
                        yPos = (((float)panel1.Height / ratio) - (float)sourceImg.Height) / 2;
                    }

                    //Enable the buttons after first image
                    if (boolFirstImage == false){
                        this.panel1.Paint += new PaintEventHandler(panel1_Paint);
                        boolFirstImage = true;
                        buttonGreyScale.Enabled = true;
                        buttonInverse.Enabled = true;
                        zoomBar.Enabled = true;
                        buttonSaveFile.Enabled = true;
                    }
                    this.panel1.Invalidate();
                }
            }
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e){
           //Save starting positions for when moving the image or drawing line

            if (e.Button == MouseButtons.Left){
                xStartPos = e.X;
                yStartPos = e.Y;
                boolMoveImage = true;
            } 
            if (e.Button == MouseButtons.Right){
                startX = e.X *(1/ratio) - xPos;
                startY = e.Y *(1/ratio) - yPos;
                boolDrawLine = true;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e){
            //Save ending positions for when moving the image or drawing line

            if (e.Button == MouseButtons.Left && boolMoveImage == true  ){
                panel1.Cursor = Cursors.Hand;
                xPos = xCurrent + ((e.X - xStartPos) * (1 / ratio));
                yPos = yCurrent + ((e.Y - yStartPos) * (1 / ratio));
                panel1.Invalidate();
            }

            if (e.Button == MouseButtons.Right && boolDrawLine == true){
                panel1.Cursor = Cursors.Cross;
                endX = e.X * ( 1/ratio) - xPos;
                endY = e.Y * ( 1/ratio) - yPos;
                //Display line length
                int length = Math.Abs(((int)endX - (int)startX)^2) + Math.Abs(((((int)endY - (int)startY)^2)) ^ (1 / 2));
                lengthBox.Text = "Line Length: " + length.ToString() + " px";
                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e){
            //Exit state

            if (e.Button == MouseButtons.Left){
                panel1.Cursor = Cursors.Default;
                boolMoveImage = false;
                xCurrent = xPos;
                yCurrent = yPos;
            }

            if (e.Button == MouseButtons.Right){
                panel1.Cursor = Cursors.Default;
                boolDrawLine = false;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            Graphics graphicsObj = e.Graphics;
            graphicsObj.ScaleTransform(ratio , ratio);
            graphicsObj.TranslateTransform(xPos, yPos);

            //Draw image depnding on color matrix
            if (boolGrayScale == true && boolInverse == true){
                CSAttributes.SetColorMatrix(inverseGreyScaleMatrix);
                graphicsObj.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height),
                                0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, CSAttributes);
            }
            else if (boolGrayScale == true ){
                CSAttributes.SetColorMatrix(greyScaleMatrix);
                graphicsObj.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height),
                                 0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, CSAttributes);
            }
            else if (boolInverse == true){
                CSAttributes.SetColorMatrix(inverseMatrix);
                graphicsObj.DrawImage(sourceImg, new Rectangle(0, 0, sourceImg.Width, sourceImg.Height),
                                 0, 0, sourceImg.Width, sourceImg.Height, GraphicsUnit.Pixel, CSAttributes);
            }
            else{
                graphicsObj.DrawImage(sourceImg, 0, 0, sourceImg.Width, sourceImg.Height);
            }

            //Draw line
            Pen blackPen = new Pen(Color.Black, 5*(1/ratio));            
            Point point1 = new Point((int)startX, (int)startY);
            Point point2 = new Point((int)endX, (int)endY);
            graphicsObj.DrawLine(blackPen, point1, point2);

            //Save file if required
            if (boolSaveFile == true){
                boolSaveFile = false;
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog()){     
                    saveFileDialog1.Title = "Save Image";
                    saveFileDialog1.Filter = "Image Files (*.bmp, *.jpeg, *.jpg, *.png)|*.bmp; *.jpeg; *.jpg; *.png";

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                        using (Bitmap savedBitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height)){
                            panel1.DrawToBitmap(savedBitmap, panel1.ClientRectangle);
                            savedBitmap.Save(saveFileDialog1.FileName);   
                        }
                    }
                }  
            }
        }

        //Enter or exit grey scale state
        private void buttonGreyScale_Clicked(object sender, EventArgs e){
            boolGrayScale = !boolGrayScale;
            panel1.Invalidate();
        }

        //Enter or exit inverse state
        private void buttonInverse_Click(object sender, EventArgs e){
            boolInverse = !boolInverse;
            panel1.Invalidate();
        }

        //Zoom image: set ratio and calculate new center
        //Had to use a bar, did not have middle mouse button or scroll wheel
        //but technically its the same, only thing that would change is the event handler 
        private void zoomBar_Scroll(object sender, EventArgs e){
            if (zoomBar.Value == 0){
                ratio = 0.1F * initialRatio ;
            }
            else{
                ratio = initialRatio * zoomBar.Value * 2.0F   / 10.0F;
            }

            xPos = ((panel1.Width / ratio) - sourceImg.Width ) / 2;
            yPos = ((panel1.Height / ratio) - sourceImg.Height) / 2;
            panel1.Invalidate();
        }

        //Enter save file state 
        private void buttonSaveFile_Click(object sender, EventArgs e){
            boolSaveFile = true;
            panel1.Invalidate();
        }
    }
}
