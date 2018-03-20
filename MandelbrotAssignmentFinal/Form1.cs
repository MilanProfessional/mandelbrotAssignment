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

namespace MandelbrotAssignmentFinal
{
    public partial class Fractal : Form
    {
        public Fractal()
        {
            //SX = Convert.ToDouble(readState()[0]);
            //SY = Convert.ToDouble(readState()[1]);
            //EX = Convert.ToDouble(readState()[2]);
            //EY = Convert.ToDouble(readState()[3]);

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
        private Image picture;
        private Graphics g1;
        private Cursor c1, c2;
        private HSB HSBcol = new HSB();
        private bool clicked, isFirstTime;
        private string texts;



        public void init() // all instances will be prepared
        {
            //HSBcol = new HSB();
            isFirstTime = true;
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

        public void start()
        {
            action = false;
            rectangle = false;
            initvalues();
            xzoom = (xende - xstart) / (double)x1;
            yzoom = (yende - ystart) / (double)y1;
            mandelbrot();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        public void update()
        {
            Graphics g = null;
            try
            {
                g = pictureBox1.CreateGraphics();
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex);
            }
            // Graphics g = pictureBox1.CreateGraphics();
            try
            {
                g.DrawImage(picture, 0, 0);
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
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics obj = e.Graphics;
            obj.DrawImage(picture, new Point(0, 0));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            {
                action = true;

                if (action)
                {
                    xs = e.X;
                    ys = e.Y;
                }
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

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fractal clone = new Fractal();
            clone.Show();
            isFirstTime = false;
           


        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You want to Restart Mandelbrot from initial ?", "Restart", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                reloadToolStripMenuItem_Click(sender, e);
                isFirstTime = false;

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
                if ((w < 2) && (z < 2)) initvalues();
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
                mandelbrot();
                rectangle = false;
               // action = false;
                clicked = false;
                update();
                isFirstTime = false;
                StreamWriter filewrite = new StreamWriter("statesaver.txt");
                
               
                filewrite.Write(xstart + Environment.NewLine);
                filewrite.Write(ystart + Environment.NewLine);
                filewrite.Write(xende + Environment.NewLine);
                filewrite.Write(yende);
                filewrite.Close();

                
                


            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            stop();

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }

        private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getInfo();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument p = new PrintDocument();
            p.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            p.Print();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Application.Restart();
            isFirstTime = false;
            start();
            mandelbrot();
            rectangle = false;
            update();
            StreamWriter filewrite = new StreamWriter("statesaver.txt");
            filewrite.Write("-2.025" + Environment.NewLine);
            filewrite.Write("-1.125" + Environment.NewLine);
            filewrite.Write("0.6" + Environment.NewLine);
            filewrite.Write("1.125");
            filewrite.Close();

           


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "JPG(*.JPG) | *.JPG";
            if (f.ShowDialog() == DialogResult.OK)
            {
                picture.Save(f.FileName);
            }
        }

        public void stop()
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
           // pictureBox1.Dispose();
            //pictureBox1 = null;
        }

        public void paint(Graphics g)
        {
            update();
        }

        private void propertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        private void mandelbrot() // calculate all points
        {
            int x, y;
            float h, b, alt = 0.0f;

            action = false;
            //textBox1.Text = "Mandelbrot-Set will be produced - please wait...";
            //textBox1.Enabled = false;
            for (x = 0; x < x1; x += 2)
                for (y = 0; y < y1; y++)
                {
                    h = pointcolour(xstart + xzoom * (double)x, ystart + yzoom * (double)y); // color value
                    if (h != alt)
                    {
                        b = 1.0f - h * h; // brightnes
                                          ///djm added
                                          HSBcol.fromHSB(h*255, 0.8f*255, b*255); //convert hsb to rgb then make a Java Color
                                          Color col = Color.FromArgb((int)HSBcol.rChan, (int)HSBcol.gChan, (int)HSBcol.bChan);
                       pen = new Pen(col);
                        //djm end
                        //djm added to convert to RGB from HSB
                        alt = h;
                    }
                    g1.DrawLine (pen, x, y, x + 1, y);
                }
            textBox1.Text= "Mandelbrot-Set ready - please select to zoom.";
            textBox1.Enabled = false;
            
            action = true;
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
            else {
                xstart = SX;
                ystart = SY;
                xende = EX;
                yende = EY;
               
            }
            if ((float)((xende - xstart) / (yende - ystart)) != xy)
                xstart = xende - (yende - ystart) * (double)xy;
           

           

            // readState();
            //mandel();



            //StreamReader s = File.OpenText("statesaver.txt");
            //string text = s.ReadLine();
            //int count = 0;
            //String[] array = new String[4];
            //while (true)
            //{
            //    {
            //        count++;

            //        if (count == 1)
            //        {

            //            array[count - 1] = text;
            //        }
            //        if (count == 2)
            //        {

            //            array[count - 1] = text;
            //        }
            //        if (count == 3)
            //        {

            //            array[count - 1] = text;
            //        }
            //        if (count == 4)
            //        {

            //            array[count - 1] = text;
            //        }

            //    }
            //    Console.WriteLine(array[2]);



            //}
        }

        //private void mandel()
        //{
            
        //    double SX = Convert.ToDouble(readState()[0]);
        //    double SY = Convert.ToDouble(readState()[1]);
        //    double EX= Convert.ToDouble(readState()[2]);
        //    double EY = Convert.ToDouble(readState()[3]);
            

        //    xstart = SX;
        //    ystart = SY;
        //    xende = EY;
        //    yende = EX;

        //    Console.WriteLine(SX + "hello");

        //}

        //private List<string> readState()
        //{
        //    //string path = Directory.GetCurrentDirectory() + "\\statesaver.txt";

        //    List<string> coordinate = new List<string>();

        //    using (StreamReader sr = File.OpenText("statesaver.txt"))
        //    {
        //        string s = "";
        //        while ((s = sr.ReadLine()) != null)
        //        {
        //            coordinate.Add(s);
        //        }
        //    }

        //    return coordinate;
        //}


        

        public void getInfo()
        {
            MessageBox.Show ("Mandelbrot by Milan");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
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
