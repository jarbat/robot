﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Practica_Robot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        DispatcherTimer timer2;
        Robot robot;
        int count;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
          
            robot = new Robot();
            robot.WIDTH = (int)canvas.Width;
            robot.HEIGHT = (int)canvas.Height;
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(500);
            count = 0;
        }
        
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Image image in robot.Robots)
            {
                move(image);
                sitoca(image);
                robot.CanviRobot(image);
            }
            
            tb_nIntents.Text = "Numero d'intents: " + count;
        }

        private void sitoca(Image sender)
        {
            int esquerrarob = (int)Canvas.GetLeft(sender);
            int adaltrob = (int)Canvas.GetTop(sender);
            int esquerra = (int)Canvas.GetLeft(robot.Tresor);
            int adalt = (int)Canvas.GetTop(robot.Tresor);
            if(adalt==adaltrob && esquerra==esquerrarob)
            {
                timer.Stop();
                btn_Incia.Content = "Final";
            }
        }

        private void btn_Incia_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        
            Random r = new Random();
            foreach (Image image in robot.Robots)
            {
                 Canvas.SetTop(image, (double)r.Next(robot.Ampladarob, robot.HEIGHT - (robot.Ampladarob+1)));
                 Canvas.SetLeft(image, (double)r.Next(robot.Llargadarob, robot.WIDTH - (robot.Ampladarob+1)));
               
                canvas.Children.Add(image);
               
            }
           
            Canvas.SetTop(robot.Tresor, (double)r.Next(robot.Ampladarob, robot.HEIGHT - (robot.Ampladarob + 1)));
            Canvas.SetLeft(robot.Tresor, (double)r.Next(robot.Llargadarob, robot.WIDTH - (robot.Ampladarob + 1)));
            canvas.Children.Add(robot.Tresor);
            
        }
        private void move(Image sender)
        {
           
            

            int esquerra=(int) Canvas.GetLeft(sender);
            int adalt = (int)Canvas.GetTop(sender);
            if (robot.Direccio == DireccioRobot.Nort)
            {
                count++;
                adalt -= 25;
                if (adalt <=  robot.Llargadarob)
                {
                    setDir();
                    robot.CanviRobot(sender);
                }
            }

            else if (robot.Direccio == DireccioRobot.Sud)
            {
                count++;
                adalt += 25;
                if (adalt >= (robot.HEIGHT -(robot.Llargadarob * 2)))
                {
                    setDir();
                    robot.CanviRobot(sender);
                }

            }
            else  if (robot.Direccio == DireccioRobot.Est)
            {
                count++;
                esquerra -= 25;
                if (esquerra <= robot.Ampladarob)
                {
                    setDir();
                    robot.CanviRobot(sender);
                }
            }
            else if (robot.Direccio == DireccioRobot.Oest)
            {
                count++;
                esquerra += 25;
                if (esquerra >= (robot.WIDTH - (robot.Ampladarob*2)))
                {
                    setDir();
                    robot.CanviRobot(sender);
                }

            }
            Canvas.SetLeft(sender, esquerra);
            Canvas.SetTop(sender, adalt);
        }

        public void setDir()
        {
            Random r = new Random();
            int randomRest = r.Next(0, 4);

            if (randomRest == 0)
            {
                robot.Direccio = DireccioRobot.Sud;
            }
            else if( randomRest ==1)
            {
                robot.Direccio = DireccioRobot.Nort;
            }
            else if (randomRest == 2)
            {
                robot.Direccio = DireccioRobot.Est;
            }
            else if (randomRest == 3)
            {
                robot.Direccio = DireccioRobot.Oest;
            }
           
        }

       
    }
}
