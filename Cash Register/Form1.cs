﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;
namespace Cash_Register
{
    public partial class Form1 : Form
    {
        // stating the varribles.
        double BURGERS = 4.25;
        double FRIES = 2.20;
        double DRINKS = 1.00;
        double TAX = 0.13;
        double total;
        double subTotal;
        double taxTotal;
        double change;
        double cash;

        public Form1()
        {
            InitializeComponent();
            subLabel.Text = "";
            taxLabel.Text = "";
            totalLabel.Text = "";
            changeLabel.Text = "";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //math
            subTotal = BURGERS + FRIES + DRINKS;
            taxTotal = subTotal * TAX;
            total = subTotal + taxTotal;


            try
            {
                //changing lables
                subLabel.Text = subTotal.ToString("C"); ;
                taxLabel.Text = taxTotal.ToString("C");
                totalLabel.Text = total.ToString("C");
                //converting to text
                BURGERS = Convert.ToDouble(textBox1.Text);
                FRIES = Convert.ToDouble(textBox2.Text);
                DRINKS = Convert.ToDouble(textBox3.Text);
            }
            catch
            {

                catch1.Text = "You need to have a number in each textbox.";
                return;
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            change = cash - total;

            try
            {
                cash = Convert.ToDouble(textBox4.Text);
                changeLabel.Text = change.ToString("C");
            }
            catch
            {
                changeLabel.Text = "must input a number into the textbox";
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Choosing pen colour and thickness
            Graphics g = this.CreateGraphics();
            Pen drawPen = new Pen(Color.Black, 5);
            SolidBrush drawBrush = new SolidBrush(Color.Black);



            SolidBrush outlineBrush = new SolidBrush(Color.White);



            //Choosing Font
            Font reciptTitleFont = new Font("Times New Roman", 18, FontStyle.Bold);
            Font reciptFont = new Font("Times New Roman", 12);


            //playing sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.Printer);
            //Building reciept

            player.Play();
            g.FillRectangle(outlineBrush, 280, 45, 180, 340);
            g.DrawRectangle(drawPen, 280, 45, 180, 340);
            g.DrawString("Burger Store.", reciptTitleFont, drawBrush, 290, 55);
            Thread.Sleep(400);
            g.DrawString("Order Number 324", reciptFont, drawBrush, 285, 85);
            Thread.Sleep(400);
            g.DrawString("October 10, 2018", reciptFont, drawBrush, 285, 105);
            Thread.Sleep(400);
            g.DrawString("Burgers   x" + BURGERS, reciptFont, drawBrush, 285, 140);
            Thread.Sleep(400);
            g.DrawString("Fries       x" + FRIES, reciptFont, drawBrush, 285, 155);
            Thread.Sleep(400);
            g.DrawString("Drinks    x" + DRINKS, reciptFont, drawBrush, 285, 170);
            Thread.Sleep(400);
            g.DrawString("Subtotal         " + subTotal.ToString("C"), reciptFont, drawBrush, 285, 200);
            Thread.Sleep(400);
            g.DrawString("Tax                " + taxTotal.ToString("C"), reciptFont, drawBrush, 285, 220);
            Thread.Sleep(400);
            g.DrawString("Total              " + total.ToString("C"), reciptFont, drawBrush, 285, 240);
            Thread.Sleep(400);
            g.DrawString("Tendered       " + cash.ToString("C"), reciptFont, drawBrush, 285, 270);
            Thread.Sleep(400);
            g.DrawString("Change          " + change.ToString("C"), reciptFont, drawBrush, 285, 290);
            Thread.Sleep(400);
            g.DrawString("Have a Great Day!", reciptFont, drawBrush, 285, 330);
            Thread.Sleep(400);
            player.Stop();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clearing graphics
            Graphics g = this.CreateGraphics();
            g.Clear(Color.LightGray);

            //clearing variables
            BURGERS = 0;
            FRIES = 0;
            DRINKS = 0;
            total = 0;
            cash = 0;
            taxTotal = 0;
            change = 0;
            subTotal = 0;

            //clearing labels and boxes
            subLabel.Text = "";
            taxLabel.Text = "";
            totalLabel.Text = "";
            changeLabel.Text = "";
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            catch1.Text = "";
        }
    }
}
