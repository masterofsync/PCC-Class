using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace pacgame
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer movement = new System.Media.SoundPlayer(Properties.Resources.movement1);
        System.Media.SoundPlayer startmp = new System.Media.SoundPlayer(Properties.Resources.startmp1);
        System.Media.SoundPlayer eating = new System.Media.SoundPlayer(Properties.Resources.eating1);
        System.Media.SoundPlayer death = new System.Media.SoundPlayer(Properties.Resources.death);

        int guess = 1;
        private int lives;
        private int eu, ev;
        private int u, v;
        private int uu, vv;
        private int ue,ve;
        private Bitmap enemy1 = null;
        private Bitmap enemy2 = null;
        private Bitmap enemy3 = null;
        private Bitmap enemy4 = null;
        Random ran;
        private int[] tem;
        private int[] tem1;
        private int[] tempo;
        private int[] tempo1;
        private int[] temp;
        private int[] temps;
        private int[] temps1;

        private int x, y;
        private int zx,xz;
        private Bitmap image = null;
        private int xy;
        int score;
        int[] temp1;
        private int prestart = 0;
        private Bitmap []image1 = null;
        private int []ab;
        private int []ba;
        int i;
        private Rectangle []pointer = new Rectangle[100];
        private int count;
        int trying;

        public Form1()
        {
            InitializeComponent();
            lives = 3;
            trying = 1;
            x = 15;
            y = 11;
            ran = new Random();
            u = 310;
            v = 296;
            eu = 170;
            ev = 156;
            uu = 310;
            vv = 156;
            ue = 170;
            ve = 296;
            tempo = new int[20];
            tempo1 = new int[20];
            temp = new int[20];
            temp1 = new int[20];
            tem = new int[20];
            tem1 = new int[20];
            temps = new int[20];
            temps1 = new int[20];

            for (int zzzzz = 0; zzzzz < 20; zzzzz++)
            {
                tempo[zzzzz] = 0;
                tempo1[zzzzz] = 0;
                temp[zzzzz] = 0;
                temp1[zzzzz] = 0;
                tem[zzzzz] = 0;
                tem1[zzzzz] = 0;
                temps[zzzzz] = 0;
                temps1[zzzzz] = 0;
            }
     
            zx = 12;
            xz = 14;
            enemy1 = Properties.Resources.ghost1;
            enemy2 = Properties.Resources.ghost2;
            enemy3 = Properties.Resources.ghost3;
            enemy4 = Properties.Resources.ghost4;
            image = Properties.Resources.pacclosed;
            image.MakeTransparent(Color.Black);
            xy = 1;
            DoubleBuffered = true;
            score = 0;
            
            image1 = new Bitmap[100];
            count = 0;

            label5.Text = Convert.ToString(lives);

            ab = new int[100];
            ba = new int[100];

            
            for (i = 1; i < 100; i++)
            {
                image1[i] = Properties.Resources.yellow;
                image1[i].MakeTransparent(Color.Black);   
            }

            
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           deathpac.Stop();
           startsound.Stop();
           enemy11.Start();
           enemy22.Start();
           enemy33.Start();
           enemy44.Start();
           timer2.Start();
           xz = x;
           zx = y;
           label3.Text = Convert.ToString(x) + " , " + Convert.ToString(y);
           
            /* if (x ==475 && y>210 &&y<221)
            {
                label1.Text = "gu";
               if (pictureBox1.Image == Properties.Resources.yellow)
                {
                    pictureBox1.InitialImage = null;
                    this.Controls.Remove(pictureBox1);
                    score += 100;
                    scoreBox.Text = Convert.ToString(score);
                }
            }*/
           
           count = 0;
           for (i = 1; i <37; i++)
           {
               if (image1[i] != null)
               {
                   count++;
               }
           }

          

           if (count == 0||lives==0)
           {
               
               timer1.Stop();
               MessageBox.Show("You finished the game. Your score is: " + score);
               DialogResult dialogResult = MessageBox.Show("Do you want to retry?","Retry", MessageBoxButtons.YesNo);
               if (dialogResult == DialogResult.Yes)
               {
                   x = 15;
                   y = 11;
                   u = 310;
                   v = 296;
                   eu =170 ;
                   ev=156;
                   uu = 310;
                   vv = 156;
                   ue = 170;
                   ve = 296; 
                   enemy11.Stop();
                   enemy22.Stop();
                   enemy33.Stop();
                   enemy44.Stop();
                   for (i = 1; i < 100; i++)
                   {
                       image1[i] = Properties.Resources.yellow;
                       image1[i].MakeTransparent(Color.Black);
                   }
                   score = 0;
                   scoreBox.Text = Convert.ToString(score);
                   image = Properties.Resources.pacclosed;
                   image.MakeTransparent(Color.White);
                   xy = 1;
                   prestart = 0;
                  
                   lives = 3;
                   label5.Text = Convert.ToString(lives);
                   for (int xyz = 0; xyz < 20; xyz++)
                   {

                       temp[xyz] = 0;
                       temp1[xyz] = 0;

                       tempo[xyz] = 0;
                       tempo1[xyz] = 0;

                       tem[xyz] = 0;
                       tem1[xyz] = 0;

                       temps[xyz] = 0;
                       temps1[xyz] = 0;
                   }
               }
               else if (dialogResult == DialogResult.No)
               {
                   this.Close();
               }
               
           }
           if (x == ue && y == ve || y == ve && ue > x && (x + 15) > (ue - 10) || y == ve && x > ue && (ue + 10) > (x - 15) || x == ue && y > ve && (ve + 10) > (y - 15) || x == ue && y < ve && (y + 15) > (ve - 10)||x == uu && y == vv || y == vv && uu > x && (x + 15) > (uu - 10) || y == vv && x > uu && (uu + 10) > (x - 15) || x == uu && y > vv && (vv + 10) > (y - 15) || x == uu && y < vv && (y + 15) > (vv - 10)||x == eu && y == ev || y == ev && eu > x && (x + 15) > (eu - 10) || y == ev && x > eu && (eu + 10) > (x - 15) || x == eu && y > ev && (ev + 10) > (y - 15) || x == eu && y < ev && (y + 15) > (ev - 10)||x == u && y == v || y == v && u > x && (x + 15) > (u - 10) || y == v && x > u && (u + 10) > (x - 15) || x == u && y > v && (v + 10) > (y - 15) || x == u && y < v && (y + 15) > (v - 10))
           {
               if (lives != 0)
               {
                   lives = lives - 1;
                   label5.Text = Convert.ToString(lives);
                   guess = 1;
                   trying = 1;
                   if (score >= 200)
                   {
                       score = score - 200;
                   }

                   scoreBox.Text = Convert.ToString( score);

                   timer1.Stop();
                   enemy11.Stop();
                   enemy22.Stop();
                   enemy33.Stop();
                   enemy44.Stop();
                   deathpac_Tick(sender,e);

                  deathpac.Start();
                   //this.Invalidate();
               }

           }
           
           
           for (i = 1; i <37; i++)
           {
               if (x >(ab[i]-25) && x<(ab[i]+5) && y == ba[i]-11)
               {
                   //label1.Text += ab[i];
                   if (image1[i] != null)
                   {
                       timer2.Stop();
                       eating.Play();
                       image1[i] = null;
                       score += 100;
                       scoreBox.Text = Convert.ToString(score);
                   }
               }
           }
                if (xy == 1)
                {
                    image = Properties.Resources.pacopen;
                    image.MakeTransparent(Color.Black);
                    if ((x < 475 && y == 156) || (x < 475 && y == 296) || (x < 475 && y == 11) || (x < 475 && y == 406))
                    {
                        
                        xy = 0;
                        x += 5;
                        
                    }
                }
                else if (xy == 0)
                {
                    image = Properties.Resources.pacclosed;
                    image.MakeTransparent(Color.Black);
                    if ((x < 475 && y == 156) || (x < 475 && y == 296) || (x < 475 && y == 11) || (x < 475 && y == 406))
                    {
                        
                        xy = 1;
                        x += 5;
                      
                    } 
                }

                if (xy == 3)
                {
                    image = Properties.Resources.pacopenleft;
                    image.MakeTransparent(Color.Black);
                    if ((x > 15 && y == 156) || (x > 15 && y == 296) || (x > 15 && y == 11) || (x > 15 && y == 406))
                    {
                        
                        xy = 2;
                        x -= 5;
                        
                    }
                }
                else if (xy == 2)
                {
                    image = Properties.Resources.pacclosedleft;
                    image.MakeTransparent(Color.Black);
                    if ((x > 15 && y == 156) || (x > 15 && y == 296) || (x > 15 && y == 11) || (x > 15 && y == 406))
                    {
                      
                        xy = 3;
                        x -= 5;
                        
                    }
                }
            
                if (xy == 7)
                {
                    image = Properties.Resources.pacopentop;
                    image.MakeTransparent(Color.Black);
                    if ((y > 15 && x == 15) || (y > 15 && x == 250 && y < 157) || (y > 15 && x == 250 && y > 296) || (y > 15 && x == 475) || (y > 15 && x == 170 && y > 156&&y<297) || (y > 15 && x == 310 && y >156&& y<297))
                    {
                       
                        xy = 6;
                        y -= 5;
                       
                    }
                }
                else if (xy == 6)
                {
                    image = Properties.Resources.pacclosedup;
                    image.MakeTransparent(Color.Black);
                    if ((y > 15 && x == 15) || (y > 15 && x == 250 && y < 157) || (y > 15 && x == 250 && y > 296) || (y > 15 && x == 475) || (y > 15 && x == 170 && y > 156&&y<297) || (y > 15 && x == 310 && y > 156&& y<297))
                    {
                        
                        xy = 7;
                        y -= 5;
                       
                    }
                }

                if (xy == 5)
                {
                    image = Properties.Resources.pacdownopen;
                    image.MakeTransparent(Color.Black);
                    if ((y < 405 && x == 15) || (y < 405 && x == 250 && y < 156) || (y < 405 && x == 475) || (y < 405 && y < 296 && x == 170&&y>11) || (y < 405 && y < 296 && x == 310&&y>11) || (y < 405 && y > 295&&x==250))
                    {
                        
                        xy = 4;
                        y += 5;
                   
                    }
                }
                else if (xy == 4)
                {
                    image = Properties.Resources.paccloseddown;
                    image.MakeTransparent(Color.Black);
                    if ((y < 405 && x == 15) || (y < 405 && x == 250 && y < 156) || (y < 405 && x == 475) || (y < 405 && y < 296 && x == 170&&y>11) || (y < 405 && y < 296 && x == 310&&y>11) || (y < 405 && y > 295 && x == 250))
                    {
                        
                        xy = 5;
                        y += 5;
                       
                    }
                }
               
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blocktopleft = new Pen(Color.White);
/*
            Image img = Properties.Resources.bricks;
            

            
           Brush blocktopleftfill = new SolidBrush(Color.DarkGray);

            Rectangle blocktopleft1 = new Rectangle(47,43,200,110);       
            //g.FillRectangle(blocktopleftfill, blocktopleft1);
            //g.DrawRectangle(blocktopleft, blocktopleft1);
            
            //g.DrawImage(img, blocktopleft1);

            Rectangle blocktopright1 = new Rectangle(282, 43, 190, 110);
            //g.FillRectangle(blocktopleftfill, blocktopright1);
            //g.DrawRectangle(blocktopleft, blocktopright1);
            //g.DrawImage(img, blocktopright1);

            Rectangle blockmidleft = new Rectangle(47, 188, 120, 105);
            //g.FillRectangle(blocktopleftfill, blockmidleft);
            //g.DrawRectangle(blocktopleft, blockmidleft);
            //g.DrawImage(img, blockmidleft);

            Rectangle blockmidmid = new Rectangle(202, 188, 105, 105);
            //g.FillRectangle(blocktopleftfill, blockmidmid);
            //g.DrawRectangle(blocktopleft, blockmidmid);
            //g.DrawImage(img, blockmidmid);

            Rectangle blockmidright = new Rectangle(343, 188, 129, 105);
            //g.FillRectangle(blocktopleftfill, blockmidright);
            //g.DrawRectangle(blocktopleft, blockmidright);
            //g.DrawImage(img, blockmidright);

            Rectangle blocklowleft = new Rectangle(47, 328, 200, 75);
            //g.FillRectangle(blocktopleftfill, blocklowleft);
            //g.DrawRectangle(blocktopleft, blocklowleft);
            //g.DrawImage(img, blocklowleft);

            Rectangle blocklowright = new Rectangle(282, 328, 190, 75);
            //g.FillRectangle(blocktopleftfill, blocklowright);
            //g.DrawRectangle(blocktopleft, blocklowright);
            //g.DrawImage(img, blocklowright);
            */

            Graphics g = e.Graphics;
            Pen bottomside = new Pen(Color.White);
            g.DrawLine(bottomside, 12, 438, 507, 438);

            Pen topside = new Pen(Color.White);
            g.DrawLine(topside, 12, 8, 507, 8);

            Pen leftside = new Pen(Color.White);
            g.DrawLine(leftside, 12, 8, 12, 438);

            Pen rightside = new Pen(Color.White);
            g.DrawLine(rightside, 507, 8, 507, 438);


            for (i = 1; i < 37; i++)
            {
                if (image1[i] != null)
                {
                    image1[i].MakeTransparent(Color.Black);
                    g.DrawImage(image1[i], pointer[i]);
                }
            }
           
            Rectangle rect = new Rectangle(x, y, 30, 30);
            image.MakeTransparent(Color.White);
            g.DrawImage(image, rect);

            Rectangle rect1 = new Rectangle(u, v, 30, 30);
            enemy1.MakeTransparent(Color.Black);
            g.DrawImage(enemy1, rect1);

            Rectangle rect2 = new Rectangle(eu, ev, 30, 30);
            enemy2.MakeTransparent(Color.Black);
            g.DrawImage(enemy2, rect2);

            Rectangle rect3 = new Rectangle(uu, vv, 30, 30);
            enemy3.MakeTransparent(Color.Black);
            g.DrawImage(enemy3, rect3);

            Rectangle rect4 = new Rectangle(ue, ve, 30, 30);
            enemy4.MakeTransparent(Color.Black);
            g.DrawImage(enemy4, rect4);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                xy = 7;

            }
            else if (e.KeyCode == Keys.Down)
            {
               
                xy = 5;

            }
            else if (e.KeyCode == Keys.Left)
            {
                
                xy = 3;

            }
            else if (e.KeyCode == Keys.Right)
            {
                
                xy = 1;

            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lives != 0)
                {
                    startsound_Tick(sender, e);
                    startsound.Start();
                }
                //else if (lives == 0)
                //{
                  //  timer1.Start();
                //}
            }
            else if (e.KeyCode == Keys.Space)
            {
                timer1.Stop();
                enemy11.Stop();
                enemy22.Stop();
                enemy33.Stop();
                enemy44.Stop();
            }
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (i = 1; i < 10; i++)
            {
                ab[i] = i* 50;
                ba[i] = 22;
            }

            for (i = 10; i < 19; i++)
            {
                ab[i] = (i-9)*50;
                ba[i] = 167;
            }

            for (i = 19; i < 28; i++)
            {
                ab[i] = (i - 18) * 50;
                ba[i] = 307;
            }

            for (i = 28; i < 37; i++)
            {
                ab[i] = (i - 27) * 50;
                ba[i] = 417;
            }

            for (i = 1; i < 100; i++)
            {
                pointer[i] = new Rectangle(ab[i], ba[i], 10, 10);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (xz != x || zx != y)
            {
                if(timer1.Enabled == true)
                movement.Play();
            }
            else
            {
                movement.Stop();
            }
        }

        

        private void startsound_Tick(object sender, EventArgs e)
        {
            if (prestart == 0)
            {
                startmp.Play();
            }

            if (prestart == 1)
            {
                timer1.Start();
            }
            prestart = 1;
            
        }

        private void enemy11_Tick(object sender, EventArgs e)
        {
            
            
            if (u == 15 && v == 156 || u == 15 && v == 11 ||u==310&&v==156|| u == 250 && v == 11||u==475&&v==11 || u == 475 && v == 156 || u == 250 && v == 156 || u == 170 && v == 156 || u == 15 && v == 296 || u == 170 && v == 296 || u == 310 && v == 296 || u == 250 && v == 296 || u == 475 && v == 296 || u == 475 && v == 296 || u == 475 && v == 406 || u == 250 && v == 406 || u == 15 && v == 406)
            {
                if (u == 15 && v == 11 || u == 475 && v == 11 || u == 475 && v == 406 || u == 15 && v == 406)
                {

                    temp[0] = ran.Next(1, 3);
                    temp[1] = ran.Next(1, 3);
                    temp[2] = ran.Next(1, 3);
                    temp[3] = ran.Next(1, 3);
                    
                    if (u == 15 && v == 11)
                    {
                        if (temp[0] == 1)
                        {
                            u += 5;
                        }
                        else if (temp[0] == 2)
                        {
                            v += 5;
                        }
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;
                        temp1[0] = 0;
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                    }

                    else if (u == 475 && v == 11)
                    {
                        if (temp[1] == 1)
                        {
                            v += 5;
                        }
                        else if (temp[1] == 2)
                        {
                            u -= 5;
                        }
                        temp[0] = 0;
                        temp[2] = 0;
                        temp[3] = 0;
                        temp1[0] = 0;
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                    }

                    else if (u == 475 && v == 406)
                    {
                        if (temp[2] == 1)
                        {
                            v -= 5;
                        }
                        else if(temp[2] ==2)
                        {
                            u -= 5;
                        }
                        temp[1] = 0;
                        temp[0] = 0;
                        temp[3] = 0;
                        temp1[0] = 0;
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                    }

                    else if (u == 15 && v == 406)
                    {
                        if (temp[3] == 1)
                        {
                            v -= 5;
                        }
                        else if(temp[3] == 2)
                        {
                            u+=5;
                        }
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[0] = 0;
                        temp1[0] = 0;
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                    }

                }

                else if (u == 15 && v == 156 || u == 250 && v == 11|| u == 475 && v == 156 || u == 250 && v == 156 || u == 170 && v == 156 || u == 15 && v == 296 || u == 170 && v == 296 || u == 310 && v == 296 || u == 250 && v == 296 || u == 475 && v == 296 || u == 250 && v == 406||u==310&&v==156)
                {
                    temp1[0] = ran.Next(1, 4);
                    temp1[1] = ran.Next(1, 4);
                    temp1[2] = ran.Next(1, 4);
                    temp1[3] = ran.Next(1, 4);
                    temp1[4] = ran.Next(1, 4);
                    temp1[5] = ran.Next(1, 4);
                    temp1[6] = ran.Next(1, 4);
                    temp1[7] = ran.Next(1, 4);
                    temp1[8] = ran.Next(1, 4);
                    temp1[9] = ran.Next(1, 4);
                    temp1[10] = ran.Next(1, 4);
                    temp1[11] = ran.Next(1,4);
                    temp1[12] = ran.Next(1, 4);
                    
                    if (u == 15 && v == 156)
                    {
                        if (temp1[0] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[0] == 2)
                        {
                            v += 5;
                        }
                        else if (temp1[0] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;
                        
                    }
                    else if (u == 250 && v == 11)
                    {
                        if (temp1[1] == 1)
                        {
                            u -= 5;
                        }
                        else if (temp1[1] == 2)
                        {
                            v += 5;
                        }
                        else if (temp1[1] == 3)
                        {
                            u += 5;
                        }
                        temp1[0] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 475 && v == 156)
                    {
                        if (temp1[2] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[2] == 2)
                        {
                            v += 5;
                        }
                        else if (temp1[2] == 3)
                        {
                            u -= 5;
                        }
                        temp1[1] = 0;
                        temp1[0] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 250 && v == 156)
                    {
                        if (temp1[3] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[3] == 2)
                        {
                            u += 5;
                        }
                        else if (temp1[3] == 3)
                        {
                            u -= 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[0] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 170 && v == 156)
                    {
                        if (temp1[4] == 1)
                        {
                            u -= 5;
                        }
                        else if (temp1[4] == 2)
                        {
                            v += 5;
                        }
                        else if (temp1[4] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[0] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 15 && v == 296)
                    {
                        if (temp1[5] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[5] == 2)
                        {
                            v += 5;
                        }
                        else if (temp1[5] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[0] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if(u==15 &&v==296)
                    {
                        if (temp1[6] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[6] == 2)
                        {
                            v += 5;
                        }
                        else if (temp1[6] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[0] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 170 && v == 296)
                    {
                        if (temp1[7] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[7] == 2)
                        {
                            u -= 5;
                        }
                        else if (temp1[7] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[0] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 310 && v == 296)
                    {
                        if (temp1[8] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[8] == 2)
                        {
                            u -= 5;
                        }
                        else if (temp1[8] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[0] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 250 && v == 296)
                    {
                        if (temp1[9] == 1)
                        {
                            u += 5;
                        }
                        else if (temp1[9] == 2)
                        {
                            u -= 5;
                        }
                        else if (temp1[9] == 3)
                        {
                            v += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[0] = 0;
                        temp1[10] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 475 && v == 296)
                    {
                        if (temp1[10] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[10] == 2)
                        {
                            u -= 5;
                        }
                        else if (temp1[10] == 3)
                        {
                            v += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[0] = 0;
                        temp1[11] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 250 && v == 406)
                    {
                        if (temp1[11] == 1)
                        {
                            v -= 5;
                        }
                        else if (temp1[11] == 2)
                        {
                            u -= 5;
                        }
                        else if (temp1[11] == 3)
                        {
                            u += 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[0] = 0;
                        temp1[12] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                    else if (u == 310 && v == 156)
                    {
                        if (temp1[12] == 1)
                        {
                            v += 5;
                        }
                        else if (temp1[12] == 2)
                        {
                            u += 5;
                        }
                        else if (temp1[12] == 3)
                        {
                            u -= 5;
                        }
                        temp1[1] = 0;
                        temp1[2] = 0;
                        temp1[3] = 0;
                        temp1[4] = 0;
                        temp1[5] = 0;
                        temp1[6] = 0;
                        temp1[7] = 0;
                        temp1[8] = 0;
                        temp1[9] = 0;
                        temp1[10] = 0;
                        temp1[0] = 0;
                        temp1[11] = 0;
                        temp[0] = 0;
                        temp[1] = 0;
                        temp[2] = 0;
                        temp[3] = 0;

                    }
                }

                

            }

            if (temp[3] == 1 || temp[2] == 1 || temp1[5] == 1 || temp1[3] == 1 || temp1[2] == 1 || temp1[0] == 1 || temp1[11] == 1 || temp1[10] == 1 || temp1[8] == 1 || temp1[7] == 1 || temp1[6] == 1)
            {
                v -= 5;
            }
            else if (temp1[12]==2||temp[3] == 2 || temp[0] == 1 || temp1[5] == 3 || temp1[4] == 3 || temp1[3] == 2 || temp1[1] == 3 || temp1[0] == 3 || temp1[11] == 3 || temp1[9] == 1 || temp1[7] == 3 || temp1[6] == 3 || temp1[8] == 3)
            {
                u += 5;
            }
            else if(temp1[12]==3||temp[2] ==2||temp[1]==2||temp1[4]==1||temp1[3]==3||temp1[2] == 3||temp1[1]==1||temp1[11]==2||temp1[10] ==2||temp1[9]==2||temp1[8]==2||temp1[7] ==2)
            {
                u-=5;
            }
            else if(temp1[12] ==1||temp[1]==1||temp[0]==2||temp1[5]==2||temp1[4]==2||temp1[2]==2||temp1[1]==2||temp1[0]==2||temp1[10]==3||temp1[9]==3||temp1[6]==2)
            {
                v+=5;
            }

           /* label1.Text = Convert.ToString(temp) + " , " + Convert.ToString(temp1);
            if (mov == 1)
            {
                if (temp == 0)
                {
                    u += 5;
                }
                if (u < 475 && (v-5)==temp2||u<475&&(v+5) == temp2)
                {
                    if ((u < 475 && v == 156) || (u < 475 && v == 296) || (u < 475 && v == 11) || (u < 475 && v == 406))
                    {
                        temp = u;
                        u += 5;
                        
                    }
                }
                else if (u > 15 && (v-5) == temp3||u>15 &&(v+5) ==temp3)
                {
                    if ((u > 15 && v == 156) || (u > 15 && v == 296) || (u > 15 && v == 11) || (u > 15 && v == 406))
                    {
                        temp1 = u;
                        u -= 5;
                        
                    }
                }
                if ((u == 475 && v == 156) || (u == 475 && v == 296) || (u == 475 && v == 11) || (u == 475 && v == 406) || (u == 15 && v == 156) || (u == 15 && v == 296) || (u == 15 && v == 11) || (u == 15 && v == 406))
                {
                    mov = 0;
                }
            }

            if (mov == 0)
            {
                if (temp2 == 0)
                {
                    v -= 5;
                }
                if (v > 15 && (u-5) == temp||v>15&&(u+5) ==temp)
                {
                    if ((v > 15 && u == 15) || (v > 15 && u == 250 && v < 157) || (v > 15 && u == 250 && v > 296) || (v > 15 && u == 475) || (v > 15 && u == 170 && v > 156 && v < 297) || (v > 15 && u == 310 && v > 156 && v < 297))
                    {
                        temp2 = v;
                        v -= 5;
                    }
                }
                else if (v < 405 && (u-5) == temp1||v<405 && (u+5) == temp1)
                {
                    if ((v < 405 && u == 15) || (v < 405 && u == 250 && y < 156) || (v < 405 && u == 475) || (v < 405 && v < 296 && u == 170 && v > 11) || (v < 405 && v < 296 && u == 310 && v > 11) || (v < 405 && v > 295 && u == 250))
                    {
                        temp3 = v;
                        v += 5;
                    }
                }
                if ((v == 11 && u == 15)|| (v == 11 && u == 475) || (v == 405 && u == 15) || (v == 405 && u == 475) )
                {
                    mov = 1;
                }
            }  
            this.Invalidate();*/
        }

        private void deathpac_Tick(object sender, EventArgs e)
        {
            if (guess == 1)
            {
                pacspin.Start();
                timer1.Stop();
                enemy11.Stop();
                enemy22.Stop();
                enemy33.Stop();
                enemy44.Stop();
                death.Play();
                
               
                guess++;
                this.Invalidate();
            }
            else if(guess ==2)
            {
                deathpac.Stop();
                prestart = 0;
                timer1.Stop();
                if (lives == 0)
                {
                    timer1.Start();
                    this.Invalidate();
                }
                else if (lives != 0)
                {
                    x = 15;
                    y = 11;

                    u = 310;
                    v = 296;
                    eu = 170;
                    ev = 156;
                    uu = 310;
                    vv = 156;
                    ue = 170;
                    ve = 296;
                }
                
                pacspin.Stop();
                this.Invalidate();
                
            }
            
        }

        private void pacspin_Tick(object sender, EventArgs e)
        {
            
            if (trying == 1)
            {
                image = Properties.Resources.pacopentop;
                trying=2;
            }
            else if (trying == 2)
            {
                image = Properties.Resources.pacopenleft;
                trying=3;
            }
            else if (trying == 3)
            {
                image = Properties.Resources.pacdownopen;
                trying=4;
            }
            else if (trying == 4)
            {
                image = Properties.Resources.pacopen;
                trying=5;
            }
            this.Invalidate();
        }

        private void enemy22_Tick(object sender, EventArgs e)
        {

            if (eu == 15 && ev == 156 || eu == 15 && ev == 11 || eu == 310 && ev == 156 || eu == 250 && ev == 11 || eu == 475 && ev == 11 || eu == 475 && ev == 156 || eu == 250 && ev == 156 || eu == 170 && ev == 156 || eu == 15 && ev == 296 || eu == 170 && ev == 296 || eu == 310 && ev == 296 || eu == 250 && ev == 296 || eu == 475 && ev == 296 || eu == 475 && ev == 296 || eu == 475 && ev == 406 || eu == 250 && ev == 406 || eu == 15 && ev == 406)
            {
                if (eu == 15 && ev == 11 || eu == 475 && ev == 11 || eu == 475 && ev == 406 || eu == 15 && ev == 406)
                {

                    tempo[0] = ran.Next(1, 3);
                    tempo[1] = ran.Next(1, 3);
                    tempo[2] = ran.Next(1, 3);
                    tempo[3] = ran.Next(1, 3);

                    if (eu == 15 && ev == 11)
                    {
                        if (tempo[0] == 1)
                        {
                            eu += 5;
                        }
                        else if (tempo[0] == 2)
                        {
                            ev += 5;
                        }
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;
                        tempo1[0] = 0;
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                    }

                    else if (eu == 475 && ev == 11)
                    {
                        if (tempo[1] == 1)
                        {
                            ev += 5;
                        }
                        else if (tempo[1] == 2)
                        {
                            eu -= 5;
                        }
                        tempo[0] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;
                        tempo1[0] = 0;
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                    }

                    else if (eu == 475 && ev == 406)
                    {
                        if (tempo[2] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo[2] == 2)
                        {
                            eu -= 5;
                        }
                        tempo[1] = 0;
                        tempo[0] = 0;
                        tempo[3] = 0;
                        tempo1[0] = 0;
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                    }

                    else if (eu == 15 && ev == 406)
                    {
                        if (tempo[3] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo[3] == 2)
                        {
                            eu += 5;
                        }
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[0] = 0;
                        tempo1[0] = 0;
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                    }

                }

                else if (eu == 15 && ev == 156 || eu == 250 && ev == 11 || eu == 475 && ev == 156 || eu == 250 && ev == 156 || eu == 170 && ev == 156 || eu == 15 && ev == 296 || eu == 170 && ev == 296 || eu == 310 && ev == 296 || eu == 250 && ev == 296 || eu == 475 && ev == 296 || eu == 250 && ev == 406 || eu == 310 && ev == 156)
                {
                    tempo1[0] = ran.Next(1, 4);
                    tempo1[1] = ran.Next(1, 4);
                    tempo1[2] = ran.Next(1, 4);
                    tempo1[3] = ran.Next(1, 4);
                    tempo1[4] = ran.Next(1, 4);
                    tempo1[5] = ran.Next(1, 4);
                    tempo1[6] = ran.Next(1, 4);
                    tempo1[7] = ran.Next(1, 4);
                    tempo1[8] = ran.Next(1, 4);
                    tempo1[9] = ran.Next(1, 4);
                    tempo1[10] = ran.Next(1, 4);
                    tempo1[11] = ran.Next(1, 4);
                    tempo1[12] = ran.Next(1, 4);

                    if (eu == 15 && ev == 156)
                    {
                        if (tempo1[0] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[0] == 2)
                        {
                            ev += 5;
                        }
                        else if (tempo1[0] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 250 && ev == 11)
                    {
                        if (tempo1[1] == 1)
                        {
                           eu -= 5;
                        }
                        else if (tempo1[1] == 2)
                        {
                            ev += 5;
                        }
                        else if (tempo1[1] == 3)
                        {
                           eu += 5;
                        }
                        tempo1[0] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 475 && ev == 156)
                    {
                        if (tempo1[2] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[2] == 2)
                        {
                            ev += 5;
                        }
                        else if (tempo1[2] == 3)
                        {
                            eu -= 5;
                        }
                        tempo1[1] = 0;
                        tempo1[0] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 250 && ev == 156)
                    {
                        if (tempo1[3] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[3] == 2)
                        {
                            eu += 5;
                        }
                        else if (tempo1[3] == 3)
                        {
                            eu -= 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[0] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 170 && ev == 156)
                    {
                        if (tempo1[4] == 1)
                        {
                            eu -= 5;
                        }
                        else if (tempo1[4] == 2)
                        {
                            ev += 5;
                        }
                        else if (tempo1[4] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[0] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 15 && ev == 296)
                    {
                        if (tempo1[5] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[5] == 2)
                        {
                            ev += 5;
                        }
                        else if (tempo1[5] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[0] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 15 && ev == 296)
                    {
                        if (tempo1[6] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[6] == 2)
                        {
                            ev += 5;
                        }
                        else if (tempo1[6] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[0] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 170 && ev == 296)
                    {
                        if (tempo1[7] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[7] == 2)
                        {
                            eu -= 5;
                        }
                        else if (tempo1[7] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[0] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 310 && ev == 296)
                    {
                        if (tempo1[8] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[8] == 2)
                        {
                            eu -= 5;
                        }
                        else if (temp1[8] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[0] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 250 && ev == 296)
                    {
                        if (tempo1[9] == 1)
                        {
                            eu += 5;
                        }
                        else if (tempo1[9] == 2)
                        {
                            eu -= 5;
                        }
                        else if (tempo1[9] == 3)
                        {
                            ev += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[0] = 0;
                        tempo1[10] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 475 && ev == 296)
                    {
                        if (tempo1[10] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[10] == 2)
                        {
                            eu -= 5;
                        }
                        else if (tempo1[10] == 3)
                        {
                            ev += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[0] = 0;
                        tempo1[11] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 250 && ev == 406)
                    {
                        if (tempo1[11] == 1)
                        {
                            ev -= 5;
                        }
                        else if (tempo1[11] == 2)
                        {
                            eu -= 5;
                        }
                        else if (tempo1[11] == 3)
                        {
                            eu += 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[0] = 0;
                        tempo1[12] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                    else if (eu == 310 && ev == 156)
                    {
                        if (tempo1[12] == 1)
                        {
                            ev += 5;
                        }
                        else if (tempo1[12] == 2)
                        {
                            eu += 5;
                        }
                        else if (tempo1[12] == 3)
                        {
                            eu -= 5;
                        }
                        tempo1[1] = 0;
                        tempo1[2] = 0;
                        tempo1[3] = 0;
                        tempo1[4] = 0;
                        tempo1[5] = 0;
                        tempo1[6] = 0;
                        tempo1[7] = 0;
                        tempo1[8] = 0;
                        tempo1[9] = 0;
                        tempo1[10] = 0;
                        tempo1[0] = 0;
                        tempo1[11] = 0;
                        tempo[0] = 0;
                        tempo[1] = 0;
                        tempo[2] = 0;
                        tempo[3] = 0;

                    }
                }



            }

            if (tempo[3] == 1 || tempo[2] == 1 || tempo1[5] == 1 || tempo1[3] == 1 || tempo1[2] == 1 || tempo1[0] == 1 || tempo1[11] == 1 || tempo1[10] == 1 || tempo1[8] == 1 || tempo1[7] == 1 || tempo1[6] == 1)
            {
                ev -= 5;
            }
            else if (tempo1[12] == 2 || tempo[3] == 2 || tempo[0] == 1 || tempo1[5] == 3 || tempo1[4] == 3 || tempo1[3] == 2 || tempo1[1] == 3 || tempo1[0] == 3 || tempo1[11] == 3 || tempo1[9] == 1 || tempo1[7] == 3 || tempo1[6] == 3 || tempo1[8] == 3)
            {
                eu += 5;
            }
            else if (tempo1[12] == 3 || tempo[2] == 2 || tempo[1] == 2 || tempo1[4] == 1 || tempo1[3] == 3 || tempo1[2] == 3 || tempo1[1] == 1 || tempo1[11] == 2 || tempo1[10] == 2 || tempo1[9] == 2 || tempo1[8] == 2 || tempo1[7] == 2)
            {
                eu -= 5;
            }
            else if (tempo1[12] == 1 || tempo[1] == 1 || tempo[0] == 2 || tempo1[5] == 2 || tempo1[4] == 2 || tempo1[2] == 2 || tempo1[1] == 2 || tempo1[0] == 2 || tempo1[10] == 3 || tempo1[9] == 3 || tempo1[6] == 2)
            {
                ev += 5;
            }
        }

        private void enemy33_Tick(object sender, EventArgs e)
        {
            if (uu == 15 && vv == 156 || uu == 15 && vv == 11 || uu == 310 && vv == 156 || uu == 250 && vv == 11 || uu == 475 && vv == 11 || uu == 475 && vv == 156 || uu == 250 && vv == 156 || uu == 170 && vv == 156 || uu == 15 && vv== 296 || uu == 170 && vv == 296 || uu == 310 && vv == 296 || uu == 250 && vv== 296 || uu == 475 && vv == 296 || uu == 475 && vv == 296 || uu == 475 && vv == 406 || uu == 250 && vv == 406 || uu == 15 && vv == 406)
            {
                if (uu == 15 && vv == 11 || uu == 475 && vv == 11 || uu == 475 && vv == 406 || uu == 15 && vv == 406)
                {

                    tem[0] = ran.Next(1, 3);
                    tem[1] = ran.Next(1, 3);
                    tem[2] = ran.Next(1, 3);
                    tem[3] = ran.Next(1, 3);

                    if (uu == 15 && vv == 11)
                    {
                        if (temp[0] == 1)
                        {
                            uu += 5;
                        }
                        else if (temp[0] == 2)
                        {
                            vv += 5;
                        }
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                        tem1[0] = 0;
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                    }

                    else if (uu == 475 && vv == 11)
                    {
                        if (tem[1] == 1)
                        {
                            vv += 5;
                        }
                        else if (tem[1] == 2)
                        {
                            uu -= 5;
                        }
                        tem[0] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                        tem1[0] = 0;
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                    }

                    else if (uu == 475 && vv == 406)
                    {
                        if (tem[2] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem[2] == 2)
                        {
                            uu -= 5;
                        }
                        tem[1] = 0;
                        tem[0] = 0;
                        tem[3] = 0;
                        tem1[0] = 0;
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                    }

                    else if (uu == 15 && vv == 406)
                    {
                        if (tem[3] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem[3] == 2)
                        {
                            uu += 5;
                        }
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[0] = 0;
                        tem1[0] = 0;
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                    }

                }

                else if (uu == 15 && vv== 156 || uu == 250 && vv == 11 || uu == 475 && vv == 156 || uu == 250 && vv == 156 || uu == 170 && vv == 156 || uu == 15 && vv == 296 || uu == 170 && vv == 296 || uu == 310 && vv == 296 || uu == 250 && vv == 296 || uu == 475 && vv == 296 || uu == 250 && vv == 406 || uu == 310 && vv == 156)
                {
                    tem1[0] = ran.Next(1, 4);
                    tem1[1] = ran.Next(1, 4);
                    tem1[2] = ran.Next(1, 4);
                    tem1[3] = ran.Next(1, 4);
                    tem1[4] = ran.Next(1, 4);
                    tem1[5] = ran.Next(1, 4);
                    tem1[6] = ran.Next(1, 4);
                    tem1[7] = ran.Next(1, 4);
                    tem1[8] = ran.Next(1, 4);
                    tem1[9] = ran.Next(1, 4);
                    tem1[10] = ran.Next(1, 4);
                    tem1[11] = ran.Next(1, 4);
                    tem1[12] = ran.Next(1, 4);

                    if (uu == 15 && vv == 156)
                    {
                        if (tem1[0] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[0] == 2)
                        {
                            vv += 5;
                        }
                        else if (tem1[0] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;

                    }
                    else if (uu == 250 && vv == 11)
                    {
                        if (tem1[1] == 1)
                        {
                            uu -= 5;
                        }
                        else if (tem1[1] == 2)
                        {
                            vv += 5;
                        }
                        else if (tem1[1] == 3)
                        {
                            uu += 5;
                        }
                        tem1[0] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;

                    }
                    else if (uu == 475 && vv == 156)
                    {
                        if (tem1[2] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[2] == 2)
                        {
                            vv += 5;
                        }
                        else if (tem1[2] == 3)
                        {
                            uu-= 5;
                        }
                        tem1[1] = 0;
                        tem1[0] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                    else if (uu == 250 && vv == 156)
                    {
                        if (tem1[3] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[3] == 2)
                        {
                            uu += 5;
                        }
                        else if (tem1[3] == 3)
                        {
                            uu -= 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[0] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                    else if (uu == 170 && vv == 156)
                    {
                        if (tem1[4] == 1)
                        {
                            uu -= 5;
                        }
                        else if (tem1[4] == 2)
                        {
                            vv += 5;
                        }
                        else if (tem1[4] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[0] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;

                    }
                    else if (uu == 15 && vv == 296)
                    {
                        if (tem1[5] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[5] == 2)
                        {
                            vv += 5;
                        }
                        else if (tem1[5] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[0] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                    else if (uu == 15 && vv == 296)
                    {
                        if (tem1[6] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[6] == 2)
                        {
                            vv += 5;
                        }
                        else if (temp1[6] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[0] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                    else if (uu == 170 && vv == 296)
                    {
                        if (tem1[7] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[7] == 2)
                        {
                            uu -= 5;
                        }
                        else if (tem1[7] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[0] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;

                    }
                    else if (uu == 310 && vv == 296)
                    {
                        if (tem1[8] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[8] == 2)
                        {
                            uu -= 5;
                        }
                        else if (tem1[8] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[0] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;

                    }
                    else if (uu == 250 && vv == 296)
                    {
                        if (tem1[9] == 1)
                        {
                            uu += 5;
                        }
                        else if (tem1[9] == 2)
                        {
                            uu -= 5;
                        }
                        else if (tem1[9] == 3)
                        {
                            vv += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[0] = 0;
                        tem1[10] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                    else if (uu == 475 && vv == 296)
                    {
                        if (tem1[10] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[10] == 2)
                        {
                            uu -= 5;
                        }
                        else if (tem1[10] == 3)
                        {
                            vv += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[0] = 0;
                        tem1[11] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;

                    }
                    else if (uu == 250 && vv == 406)
                    {
                        if (tem1[11] == 1)
                        {
                            vv -= 5;
                        }
                        else if (tem1[11] == 2)
                        {
                            uu -= 5;
                        }
                        else if (tem1[11] == 3)
                        {
                            uu += 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[0] = 0;
                        tem1[12] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                    else if (uu == 310 && vv == 156)
                    {
                        if (tem1[12] == 1)
                        {
                            vv += 5;
                        }
                        else if (tem1[12] == 2)
                        {
                            uu += 5;
                        }
                        else if (tem1[12] == 3)
                        {
                            uu -= 5;
                        }
                        tem1[1] = 0;
                        tem1[2] = 0;
                        tem1[3] = 0;
                        tem1[4] = 0;
                        tem1[5] = 0;
                        tem1[6] = 0;
                        tem1[7] = 0;
                        tem1[8] = 0;
                        tem1[9] = 0;
                        tem1[10] = 0;
                        tem1[0] = 0;
                        tem1[11] = 0;
                        tem[0] = 0;
                        tem[1] = 0;
                        tem[2] = 0;
                        tem[3] = 0;
                    }
                }
            }

            if (tem[3] == 1 || tem[2] == 1 || tem1[5] == 1 || tem1[3] == 1 || tem1[2] == 1 || tem1[0] == 1 || tem1[11] == 1 || tem1[10] == 1 || tem1[8] == 1 || tem1[7] == 1 || tem1[6] == 1)
            {
                vv -= 5;
            }
            else if (tem1[12] == 2 || tem[3] == 2 || tem[0] == 1 || tem1[5] == 3 || tem1[4] == 3 || tem1[3] == 2 || tem1[1] == 3 || tem1[0] == 3 || tem1[11] == 3 || tem1[9] == 1 || tem1[7] == 3 || tem1[6] == 3 || tem1[8] == 3)
            {
                uu += 5;
            }
            else if (tem1[12] == 3 || tem[2] == 2 || tem[1] == 2 || tem1[4] == 1 || tem1[3] == 3 || tem1[2] == 3 || tem1[1] == 1 || tem1[11] == 2 || tem1[10] == 2 || tem1[9] == 2 || tem1[8] == 2 || tem1[7] == 2)
            {
                uu -= 5;
            }
            else if (tem1[12] == 1 || tem[1] == 1 || tem[0] == 2 || tem1[5] == 2 || tem1[4] == 2 || tem1[2] == 2 || tem1[1] == 2 || tem1[0] == 2 || tem1[10] == 3 || tem1[9] == 3 || tem1[6] == 2)
            {
                vv += 5;
            }

        }

        private void enemy44_Tick(object sender, EventArgs e)
        {
            if (ue == 15 && ve == 156 || ue == 15 && ve == 11 || ue == 310 && ve == 156 || ue == 250 && ve == 11 || ue == 475 && ve == 11 || ue == 475 && ve == 156 || ue == 250 && ve == 156 || ue == 170 && ve == 156 || ue == 15 && ve == 296 || ue == 170 && ve == 296 || ue == 310 && ve == 296 || ue == 250 && ve == 296 || ue == 475 && ve == 296 || ue == 475 && ve == 296 || ue == 475 && ve == 406 || ue == 250 && ve == 406 || ue == 15 && ve == 406)
            {
                if (ue == 15 && ve == 11 || ue == 475 && ve == 11 || ue == 475 && ve == 406 || ue == 15 && ve == 406)
                {
                    temps[0] = ran.Next(1, 3);
                    temps[1] = ran.Next(1, 3);
                    temps[2] = ran.Next(1, 3);
                    temps[3] = ran.Next(1, 3);

                    if (ue == 15 && ve == 11)
                    {
                        if (temps[0] == 1)
                        {
                            ue += 5;
                        }
                        else if (temps[0] == 2)
                        {
                            ve += 5;
                        }
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                        temps1[0] = 0;
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                    }

                    else if (ue== 475 && ve == 11)
                    {
                        if (temps[1] == 1)
                        {
                            ve += 5;
                        }
                        else if (temps[1] == 2)
                        {
                            ue -= 5;
                        }
                        temps[0] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                        temps1[0] = 0;
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                    }

                    else if (ue == 475 && ve == 406)
                    {
                        if (temps[2] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps[2] == 2)
                        {
                            ue -= 5;
                        }
                        temps[1] = 0;
                        temps[0] = 0;
                        temps[3] = 0;
                        temps1[0] = 0;
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                    }

                    else if (ue == 15 && ve == 406)
                    {
                        if (temps[3] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps[3] == 2)
                        {
                            ue += 5;
                        }
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[0] = 0;
                        temps1[0] = 0;
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                    }

                }

                else if (ue == 15 && ve == 156 || ue == 250 && ve == 11 || ue == 475 && ve == 156 || ue == 250 && ve == 156 || ue == 170 && ve == 156 || ue == 15 && ve == 296 || ue == 170 && ve == 296 || ue == 310 && ve == 296 || ue == 250 && ve == 296 || ue == 475 && ve == 296 || ue == 250 && ve == 406 || ue == 310 && ve == 156)
                {
                    temps1[0] = ran.Next(1, 4);
                    temps1[1] = ran.Next(1, 4);
                    temps1[2] = ran.Next(1, 4);
                    temps1[3] = ran.Next(1, 4);
                    temps1[4] = ran.Next(1, 4);
                    temps1[5] = ran.Next(1, 4);
                    temps1[6] = ran.Next(1, 4);
                    temps1[7] = ran.Next(1, 4);
                    temps1[8] = ran.Next(1, 4);
                    temps1[9] = ran.Next(1, 4);
                    temps1[10] = ran.Next(1, 4);
                    temps1[11] = ran.Next(1, 4);
                    temps1[12] = ran.Next(1, 4);

                    if (ue == 15 && ve == 156)
                    {
                        if (temps1[0] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[0] == 2)
                        {
                            ve += 5;
                        }
                        else if (temps1[0] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 250 && ve == 11)
                    {
                        if (temps1[1] == 1)
                        {
                            ue -= 5;
                        }
                        else if (temps1[1] == 2)
                        {
                            ve += 5;
                        }
                        else if (temps1[1] == 3)
                        {
                            ue += 5;
                        }
                        temps1[0] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 475 && ve == 156)
                    {
                        if (temps1[2] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[2] == 2)
                        {
                            ve += 5;
                        }
                        else if (temps1[2] == 3)
                        {
                            ue -= 5;
                        }
                        temps1[1] = 0;
                        temps1[0] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 250 && ve == 156)
                    {
                        if (temps1[3] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[3] == 2)
                        {
                            ue += 5;
                        }
                        else if (temps1[3] == 3)
                        {
                            ue -= 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[0] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 170 && ve == 156)
                    {
                        if (temps1[4] == 1)
                        {
                            ue -= 5;
                        }
                        else if (temps1[4] == 2)
                        {
                            ve += 5;
                        }
                        else if (temps1[4] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[0] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 15 && ve == 296)
                    {
                        if (temps1[5] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[5] == 2)
                        {
                            ve += 5;
                        }
                        else if (temps1[5] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[0] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 15 && ve == 296)
                    {
                        if (temps1[6] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[6] == 2)
                        {
                            ve += 5;
                        }
                        else if (temps1[6] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[0] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;

                    }
                    else if (ue == 170 && ve == 296)
                    {
                        if (temps1[7] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[7] == 2)
                        {
                            ue -= 5;
                        }
                        else if (temps1[7] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[0] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 310 && ve == 296)
                    {
                        if (temps1[8] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[8] == 2)
                        {
                            ue -= 5;
                        }
                        else if (temps1[8] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[0] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 250 && ve == 296)
                    {
                        if (temps1[9] == 1)
                        {
                            ue += 5;
                        }
                        else if (temps1[9] == 2)
                        {
                            ue -= 5;
                        }
                        else if (temps1[9] == 3)
                        {
                            ve += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[0] = 0;
                        temps1[10] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 475 && ve == 296)
                    {
                        if (temps1[10] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[10] == 2)
                        {
                            ue -= 5;
                        }
                        else if (temps1[10] == 3)
                        {
                            ve += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[0] = 0;
                        temps1[11] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 250 && ve == 406)
                    {
                        if (temps1[11] == 1)
                        {
                            ve -= 5;
                        }
                        else if (temps1[11] == 2)
                        {
                            ue -= 5;
                        }
                        else if (temps1[11] == 3)
                        {
                            ue += 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[0] = 0;
                        temps1[12] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                    else if (ue == 310 && ve == 156)
                    {
                        if (temps1[12] == 1)
                        {
                            ve += 5;
                        }
                        else if (temps1[12] == 2)
                        {
                            ue += 5;
                        }
                        else if (temps1[12] == 3)
                        {
                            ue -= 5;
                        }
                        temps1[1] = 0;
                        temps1[2] = 0;
                        temps1[3] = 0;
                        temps1[4] = 0;
                        temps1[5] = 0;
                        temps1[6] = 0;
                        temps1[7] = 0;
                        temps1[8] = 0;
                        temps1[9] = 0;
                        temps1[10] = 0;
                        temps1[0] = 0;
                        temps1[11] = 0;
                        temps[0] = 0;
                        temps[1] = 0;
                        temps[2] = 0;
                        temps[3] = 0;
                    }
                }



            }

            if (temps[3] == 1 || temps[2] == 1 || temps1[5] == 1 || temps1[3] == 1 || temps1[2] == 1 || temps1[0] == 1 || temps1[11] == 1 || temps1[10] == 1 || temps1[8] == 1 || temps1[7] == 1 || temps1[6] == 1)
            {
                ve -= 5;
            }
            else if (temps1[12] == 2 || temps[3] == 2 || temps[0] == 1 || temps1[5] == 3 || temps1[4] == 3 || temps1[3] == 2 || temps1[1] == 3 || temps1[0] == 3 || temps1[11] == 3 || temps1[9] == 1 || temps1[7] == 3 || temps1[6] == 3 || temps1[8] == 3)
            {
                ue += 5;
            }
            else if (temps1[12] == 3 || temps[2] == 2 || temps[1] == 2 || temps1[4] == 1 || temps1[3] == 3 || temps1[2] == 3 || temps1[1] == 1 || temps1[11] == 2 || temps1[10] == 2 || temps1[9] == 2 || temps1[8] == 2 || temps1[7] == 2)
            {
                ue -= 5;
            }
            else if (temps1[12] == 1 || temps[1] == 1 || temps[0] == 2 || temps1[5] == 2 || temps1[4] == 2 || temps1[2] == 2 || temps1[1] == 2 || temps1[0] == 2 || temps1[10] == 3 || temps1[9] == 3 || temps1[6] == 2)
            {
                ve += 5;
            }

        }
    }
}
