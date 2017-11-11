using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        double rez; //результат
        string ch_s= string.Empty,oper = "";// ch_s - число в текстовом формате; oper операция которую нужно сделать
        bool comma = true, is_first = true, one_key = true; // comma-логическая перемннная для проверки запятых. is_first = В первые


        //метод для результата
        private void rezult()
        {
          // если не в первые то делать действия иначе в результат занести первое число
           if (!is_first)
           {
                  if (oper == "plus") rez += Convert.ToDouble(ch_s);
                  if (oper == "minus") rez -= Convert.ToDouble(ch_s);
                  if (oper == "umnosh") rez *= Convert.ToDouble(ch_s);
                  if (oper == "del") rez /= Convert.ToDouble(ch_s);
                  ch_s = string.Empty;
           }
           else
           { 
                rez = Convert.ToDouble(ch_s);
                ch_s = string.Empty;
                is_first = false;
           }
   
        }

        public Form1()
        {
            InitializeComponent();
            base.Font = new Font(FontFamily.GenericMonospace, 9.0F); 
        }

        private void button_click(object sender, EventArgs e)
        { 
            // метод который по названию кнопки заносит результат (в form1.designer вместо клика этот метод)
            Button b = sender as Button;
            textBox1.Text += b.Text;
            ch_s += b.Text;
            one_key = true;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            if (one_key)
            {
                textBox1.Text += " + ";
                comma = true;
                rezult();
                oper = "plus";
            }
            //one_key = false;
        }

        private void button12_Click(object sender, EventArgs e)
        { 
            
            if (one_key)
            {
                textBox1.Text += " - ";
                comma = true;
                rezult();
                oper = "minus";
            }
           //one_key = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (one_key)
            {
                textBox1.Text += " * ";
                comma = true;
                rezult();
                oper = "umnosh";
            }
           // one_key = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            if (one_key)
            {
                textBox1.Text += " / ";
                comma = true;
                rezult();
                oper = "del";
            }
            //one_key = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //кнопка СЕ, учищает все
            textBox1.Text = string.Empty;
            rez = 0;
            ch_s = string.Empty;
            comma = true;
            //one_key = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //кнопка удалить последний символ, текстбокс = подстрока без последнего символа
            if (textBox1.Text[textBox1.Text.Length-1] == ',') comma = true;
            textBox1.Text  = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (ch_s!="") ch_s = ch_s.Substring(0, ch_s.Length - 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //кнпка = 
            rezult();
            textBox1.Text += " = " + Convert.ToString(rez);
            rez = 0;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            //проверяет можно ли использовать кнопку или нет
            if (comma)
                textBox1.Text += ",";
            ch_s += ","; 
            comma = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {

            // знак отрицательного числа, ставит запятую перед числом
            if ((textBox1.Text == "")||(textBox1.Text[textBox1.TextLength-1] == ' '))
            { 
                textBox1.Text += "-"; 
                ch_s = "-" + ch_s; 
            }
        }
         

    }
}
