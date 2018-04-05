using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace MandelbrotAssignmentFinal
{
    public partial class Fractal : Form
    {
        public Fractal()
        {
            InitializeComponent();
            init();
            start();
        }

      

        private readonly int MAX = 256;      // max iterations
        private readonly double SX = -2.025; // start value real
        private readonly double SY = -1.125; // start value imaginary
        private readonly double EX = 0.6;    // end value real
        private readonly double EY = 1.125;  // end value imaginarys
        private static int x1, y1, xs, ys, xe, ye;
        private static double xstart, ystart, xende, yende, xzoom, yzoom;
        private static bool action, rectangle, finished;
        private static float xy;
        private Pen pen;
        private Pen pen2;
        private Image picture;
        private Graphics g1;
        private Cursor c1, c2;
        private HSB HSBcol = new HSB();
        private bool clicked, isFirstTime;
        private string texts;
        public static Color[] palette = new Color[6];
        private Image tempPicture;
        private bool isFirst;
        int num1, num3, num2;
        private int num = 0;



        public void init() // all instances will be prepared
        {
            //HSBcol = new HSB();
            isFirstTime = true;
           isFirst = true;
            finished = false;
            x1 = pictureBox1.Width;
            y1 = pictureBox1.Height;
            xy = (float)x1 / (float)y1;
            picture = new Bitmap(x1, y1);
            g1 = Graphics.FromImage(picture);
            finished = true;
        }

        public void destroy() // delete all instances 
        {
            if (finished)
            { 
                picture = null;
                g1 = null;
               // System.GC.Collect(); // garbage collection
            }
        }


        //public static Color ColorFromHSV(double hue, double saturation, double value)
        //{
        //    int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        //    double f = hue / 60 - Math.Floor(hue / 60);

        //    value = value * 255;
        //    int v = Convert.ToInt32(value);
        //    int p = Convert.ToInt32(value * (1 - saturation));
        //    int q = Convert.ToInt32(value * (1 - f * saturation));
        //    int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

        //    if (hi == 0)
        //        return Color.FromArgb(255, v, t, p);
        //    else if (hi == 1)
        //        return Color.FromArgb(255, q, v, p);
        //    else if (hi == 2)
        //        return Color.FromArgb(255, p, v, t);
        //    else if (hi == 3)
        //        return Color.FromArgb(255, p, q, v);
        //    else if (hi == 4)
        //        return Color.FromArgb(255, t, p, v);
        //    else
        //        return Color.FromArgb(255, v, p, q);
        //}

        public void start()
        {
            action = false;
            rectangle = false;
            initvalues();
            xzoom = (xende - xstart) / (double)x1;
            yzoom = (yende - ystart) / (double)y1;

            //int num = 0;
            //if (isFirstTime == true) { } pakha hai
            using (StreamReader st = File.OpenText("colorstate.txt"))
            {
                int s = 0;
                while ((s = Convert.ToInt32(st.ReadLine())) != 0)
                {
                    num = s;
                }
            }

            mandelbrot(state_Of_Color_Reader());
            //randomPalette();
        }

       

        //private void colorCycling()
        //{

        //    try
        //    {

        //        System.Drawing.Imaging.ColorPalette palette = tempPicture.Palette;
        //        //palette.Entries[0] = Color.Black;
        //        Random rn = new Random();

        //        for (int i = 1; i < 256; i++)
        //        {
        //            palette.Entries[i] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255));
        //        }

        //        tempPicture.Palette = palette;
        //    }
        //    catch (Exception)
        //    {
        //    }

        //}

        //private void randomPalette()
        //{
        //    // TO generate random set of numbers for color
        //    Random rn = new Random();

        //    // Based on the HSB algorithm there are a total of 6 conditions
        //    // The clor will be random as the <code>rn</code> will be used to generate set of colors
        //    palette[0] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255)/*, rn.Next(255)*/);
        //    palette[1] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255), rn.Next(255));
        //    palette[2] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255), rn.Next(255));
        //    palette[3] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255), rn.Next(255));
        //    palette[4] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255), rn.Next(255));
        //    palette[5] = Color.FromArgb(rn.Next(255), rn.Next(255), rn.Next(255), rn.Next(255));
        //}

        public void update()
        {
            Graphics g = null;
            try
            {
                g = pictureBox1.CreateGraphics();
                g.DrawImage(picture, 0, 0);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex);
            } catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }

            
            
            if (rectangle)
                {
                    Pen mypen = new Pen(Color.White, 1);
                    if (xs < xe)
                    {
                        if (ys < ye) g.DrawRectangle(new Pen(Color.White), xs, ys, (xe - xs), (ye - ys));
                        else g.DrawRectangle(new Pen(Color.White), xs, ye, (xe - xs), (ys - ye));
                    }
                    else
                    {
                        if (ys < ye) g.DrawRectangle(new Pen(Color.White), xe, ys, (xs - xe), (ye - ys));
                        else g.DrawRectangle(new Pen(Color.White), xe, ye, (xs - xe), (ys - ye));
                    }
                }
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) //Drawing mandelbrot
        {
            Graphics obj = e.Graphics;
            obj.DrawImage(picture, new Point(0, 0));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            
                action = true;

                if (action)
                {
                    xs = e.X;
                    ys = e.Y;
                }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                if (action)
                {
                    xe = e.X;
                    ye = e.Y;
                    rectangle = true;

                    update();
                    
                }

            }
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e) // Creating clone // Opens another forms
        {
            Fractal clone = new Fractal();
            clone.Show();
            isFirstTime = false;
           


        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) // Restarting Mandelbrot
        {
            DialogResult dialogResult = MessageBox.Show("Do You want to Restart Mandelbrot from initial ?", "Restart", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                isFirstTime = false;
                
                reloadToolStripMenuItem_Click(sender, e);
                Application.Restart();
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Restart();
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int z, w;
            if (action)
            {
                xe = e.X;
                ye = e.Y;
                if (xs > xe)
                {
                    z = xs;
                    xs = xe;
                    xe = z;
                }
                if (ys > ye)
                {
                    z = ys;
                    ys = ye;
                    ye = z;
                }
                w = (xe - xs);
                z = (ye - ys);
                if ((w < 2) && (z < 2))  initvalues();
                else
                {
                    if (((float)w > (float)z * xy)) ye = (int)((float)ys + (float)w / xy);
                    else xe = (int)((float)xs + (float)z * xy);
                    xende = xstart + xzoom * (double)xe;
                    yende = ystart + yzoom * (double)ye;
                    xstart += xzoom * (double)xs;
                    ystart += yzoom * (double)ys;
                }
                xzoom = (xende - xstart) / (double)x1;
                yzoom = (yende - ystart) / (double)y1;
                mandelbrot(state_Of_Color_Reader());
                rectangle = false;
               // action = false;
                clicked = false;
                update();
                isFirstTime = false;
                StreamWriter filewrite = new StreamWriter("statesaver.txt"); // State Saving
                
               //Saving Coordinates
                filewrite.Write(xstart + Environment.NewLine);
                filewrite.Write(ystart + Environment.NewLine);
                filewrite.Write(xende + Environment.NewLine);
                filewrite.Write(yende);
                filewrite.Close();

                
                


            }
        }
        private int TimeChange = 1;
        private void timer1_Tick(object sender, EventArgs e)//Color cycling using timer // Algorithm
        {
            TimeChange++;

            if (TimeChange >= 8)
            {
                TimeChange = 1;
            }
            else
            {
                mandelbrot(TimeChange);
                update();
            }
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e) // Color Cycle // Animation Start
        {

            
            timer1.Start(); //statrs timer
            startToolStripMenuItem1.Enabled = false;
            stopToolStripMenuItem1.Enabled = true;


        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e) // Color Cycle // Animation Stop
        {
            Random rand = new Random();
            int num = rand.Next(1, 8);
            using (StreamWriter sw = File.CreateText("colorstate.txt"))
            {
                sw.WriteLine(num);
            }

            timer1.Stop(); // stops timer
            stopToolStripMenuItem1.Enabled = false;
            startToolStripMenuItem1.Enabled = true;


            mandelbrot(num);
            update();

        }

        private void howToToolStripMenuItem_Click(object sender, EventArgs e) //Opens Message Box for user knowledge about application
        {
            MessageBox.Show("File > Restart: To start the Stopped Mandelbrot." + Environment.NewLine +
                          "File > Reload: To reload Mandelbrot from initial." + Environment.NewLine +
                          "File > Stop: To stop the Mandelbrot Picture." + Environment.NewLine +
                          "File > Save: To save it as a Image File." + Environment.NewLine +
                          "Properties > Print: To print the Image File as required format." + Environment.NewLine +
                          "Properties > Clone: To make a clone of Mandelbrot." + Environment.NewLine +
                          "Properties > Color Pallete: To change the color of Mandelbrot randomly." + Environment.NewLine +
                          "Properties > Color Cycle > Start: To change color of Mandelbrot automatically" + Environment.NewLine +
                          "Properties > Color Cycle > Stop: To stop the automatic color change of Mandelbrot." + Environment.NewLine,
                          "How To Use This Application "
                          );
        }

        private void colorPelatteToolStripMenuItem_Click(object sender, EventArgs e) // Changes Color Randomly // After clicked by user
        {
            
            Random rand = new Random();
            int num = rand.Next(1, 8);

            state_Of_Color_Writer(num);

            mandelbrot(num);
            update();
        }


        private void stopToolStripMenuItem_Click(object sender, EventArgs e) // Calls Stop method
        {
               stop();

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e) // Calls print event //Communicates with driver
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e) // calls getinto method
        {
            getInfo();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) //Prints the documents
        {
            PrintDocument p = new PrintDocument();
            p.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            p.Print();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) // Reloads the mandelbrot in initial state
        {
            isFirstTime = false;
            start();
            mandelbrot(0);
            rectangle = false;
            update();
            StreamWriter filewrite = new StreamWriter("statesaver.txt");
            filewrite.Write("-2.025" + Environment.NewLine);
            filewrite.Write("-1.125" + Environment.NewLine);
            filewrite.Write("0.6" + Environment.NewLine);
            filewrite.Write("1.125");
            filewrite.Close();

            using (StreamWriter sw = File.CreateText("colorstate.txt"))
            {
                sw.WriteLine(0);
            }

           

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // Opens save dialog box and saves according to user's instruction
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "JPG(*.JPG) | *.JPG| BMP (*.bmp)| *.bmp| PNG(*.png) |*.png"; //Formats 
            if (f.ShowDialog() == DialogResult.OK)
            {
                picture.Save(f.FileName);
            }
        }

        public void stop() // stops picture box1 // Stops Mandelbrot color and other menu Strips
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
            pictureBox1.Dispose();
            textBox1.Text = "Mandelbrot disabled. Click File and Restart to restart mandelbrot";
            textBox1.Enabled = false;
            propertiesToolStripMenuItem1.Enabled = false;
            reloadToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            //startToolStripMenuItem.Enabled = false;
            editToolStripMenuItem1.Enabled = false;
        }

        public void paint(Graphics g)
        {
            update();
        }

        private void propertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        
        private void mandelbrot(int num = 0) // calculate all points
        {
            int x, y;
            float h, b, alt = 0.0f;

            action = false;

            for (x = 0; x < x1; x += 2)
                for (y = 0; y < y1; y++)
                {
                    h = pointcolour(xstart + xzoom * (double)x, ystart + yzoom * (double)y); // color value
                    if (h != alt)
                    {
                        b = 1.0f - h * h; // brightnes
                                          ///djm added
                        // Color col2 = HSB.HSBtoRGB(h, 0.8f, b);
                        //  HSBcol.fromHSB(h*20, 0.8f*34, b*255); //convert hsb to rgb then make a Java Color
                        
                      
                        
                            HSBcol.fromHSB(h * 255, 0.8f * 255, b * 255, num); //convert hsb to rgb then make a Java Color
                            Color col = Color.FromArgb((int)HSBcol.rChan, (int)HSBcol.gChan, (int)HSBcol.bChan);
                            pen = new Pen(col);

                       // pen2 = new Pen(col2);
                        //djm end
                        //djm added to convert to RGB from HSB
                        alt = h;
                    }
                    
                    /*if (isFirstTime)*/  g1.DrawLine(pen, x, y, x + 1, y); 
                   // else { g1.DrawLine(pen2, x, y, x + 1, y); }
                   
                }
            textBox1.Text= "Mandelbrot-Set ready - please select to zoom.";
            textBox1.Enabled = false;
            
            action = true;
            isFirst = false;
            
          
        }

        //private void colorChange(float h, float b)
        //{
        //    HSBcol.fromHSB(h * 25, 0.8f * 55, b * 205);
        //}

        private int state_Of_Color_Reader()
        {
            int temp = 0;

            using (StreamReader st = File.OpenText("colorstate.txt"))
            {
                int s = 0;
                while ((s = Convert.ToInt32(st.ReadLine())) != 0)
                {
                    temp = s;
                }
            }

            return temp;
        }

        private void state_Of_Color_Writer(int num)
        {
            string path = Directory.GetCurrentDirectory() + "\\colorstate.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(num);
            }
        }

        private float pointcolour(double xwert, double ywert) // color value from 0.0 to 1.0 by iterations
        {
            double r = 0.0, i = 0.0, m = 0.0;
            int j = 0;

            while ((j < MAX) && (m < 4.0))
            {
                j++;
                m = r * r - i * i;
                i = 2.0 * r * i + ywert;
                r = m + xwert;
            }
            return (float)j / (float)MAX;
        }

        private void initvalues() // reset start values


        {
            //Console.WriteLine( "Hello");
            if (isFirstTime == true)
            {
                List<string> coordinate = new List<string>();

                using (StreamReader sr = File.OpenText("statesaver.txt"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        coordinate.Add(s);
                    }
                }

                xstart = Double.Parse(coordinate[0]);
                ystart = Double.Parse(coordinate[1]);
                xende = Double.Parse(coordinate[2]);
                yende = Double.Parse(coordinate[3]);

                //Console.WriteLine(xstart + "Hello");


            }
            else
            {
                xstart = SX;
                ystart = SY;
                xende = EX;
                yende = EY;

            }
            if ((float)((xende - xstart) / (yende - ystart)) != xy)
                xstart = xende - (yende - ystart) * (double)xy;




        }






        public void getInfo() // Info about application
        {
            MessageBox.Show ( "Mandelbrot By:" + Environment.NewLine +
                "Name: Milan Babu Adhikari" + Environment.NewLine +
                "Email: milanadhikari09@live.com" + Environment.NewLine +
                "Contact No.: +9779803818797" + Environment.NewLine +
                "Developed in: Microsoft Visual Studio 2017 Community" + Environment.NewLine,
                "Version 1.0.8 Freeware" 
                );
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) //Quit Message box 
        {
            DialogResult dialogResult = MessageBox.Show("Do You want to quit ?", "Quit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
    }
}
