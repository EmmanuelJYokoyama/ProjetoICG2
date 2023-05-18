﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoICG_2BIM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int esp = 0;
        int[] coordenadas = new int[10];
        int cont = 0;
        int qtdPontos = 0;
        int pos = 0;
        int pontosClicados = 0;
        int desenhoClicado = 0;
        Pen pen;

        public void DesenhaRetangulo(PaintEventArgs e, Pen caneta, int x, int y, int altura, int largura)
        {
            //DesenhaRetangulo(e, pen, coordenadas[pos], coordenadas[pos + 1], coordenadas[pos + 2], coordenadas[pos + 3]);
            altura = Math.Abs(altura - x);
            largura  = Math.Abs(largura - y);

            if(coordenadas[0]< coordenadas[2])
            {
                x = coordenadas[0];
            }
            else
            {
                x = coordenadas[2];

            }
            if(coordenadas[1] < coordenadas[3]){
                y = coordenadas[1];

            }
            else
            {
                y = coordenadas[3];

            }

            e.Graphics.DrawRectangle(caneta, x, y, altura, largura);
        }

        void circulo(int xc, int yc, int raio, Color cor, PaintEventArgs e)
        {
            ponto(xc, yc, cor, e);
            for (int i = 0; i <= 360; i++)
            {
                int x = (int)(xc + raio * Math.Cos(i));
                int y = (int)(yc + raio * Math.Sin(i));
                ponto(x, y, cor, e);
            }
        }

        public Pen estiloLinha(PaintEventArgs e, Color cor, int esp, float[] valores)
        {
            float[] dashdot = valores;
            pen.DashPattern = dashdot;
            return pen;

        }

        public Color cor(PaintEventArgs e, int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        void ponto(int x, int y, Color cor, PaintEventArgs e)
        {
            Pen caneta = new Pen(cor, 0);
            DesenhaLinha(e, caneta, x, y, x + 1, y);
        }

        public Pen caneta(PaintEventArgs e, Color cor, int esp)
        {
            Pen caneta = new Pen(cor, esp);
            return caneta;
        }

        public void triangulo(PaintEventArgs e, Pen caneta, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            DesenhaLinha(e, caneta, x1, y1, x2, y2);
            DesenhaLinha(e, caneta, x2, y2, x3, y3);
            DesenhaLinha(e, caneta, x3, y3, x1, y1);
        }

        public void DesenhaLinha(PaintEventArgs e, Pen caneta, int x0, int y0, int x1, int y1)
        {
            e.Graphics.DrawLine(caneta, x0, y0, x1, y1);
        }
        
    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color cores = cor(e, 255, 0, 0);
            pen = caneta(e,Color.Black, esp);

            if (desenhoClicado == 1)
            {
                DesenhaLinha(e, pen, coordenadas[0], coordenadas[1], coordenadas[2], coordenadas[ 3]);
            }
            else if (desenhoClicado == 2) 
            {

                if (string.IsNullOrEmpty(textBox1.Text) == false)
                {
                    int raio = int.Parse(textBox1.Text);
                    circulo(coordenadas[0], coordenadas[1], raio, Color.Black, e);
                }
            }
            else if (desenhoClicado == 3)
            {
                triangulo(e, pen, coordenadas[0], coordenadas[1], coordenadas[2], coordenadas[3], coordenadas[4], coordenadas[5]);
            } else if (desenhoClicado == 5)
            {
                DesenhaRetangulo(e, pen, coordenadas[pos], coordenadas[pos + 1], coordenadas[pos + 2], coordenadas[pos + 3]);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //linha
            qtdPontos = 2;
            desenhoClicado = 1;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //circulo
            desenhoClicado = 2;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //triangulo
            qtdPontos = 3;
            desenhoClicado = 3;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //losango
            desenhoClicado = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //quadrado
            qtdPontos = 2;
            desenhoClicado = 5;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //pent
            qtdPontos = 5;
            desenhoClicado = 6;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pontosClicados < qtdPontos)
            {
                coordenadas[pos++] = e.X;
                coordenadas[pos++] = e.Y;
                pontosClicados++;
               
            }
            if (pontosClicados == qtdPontos)
            {
                Invalidate();
                pontosClicados = 0;
                pos = 0;
            }

            if(desenhoClicado == 2)
            {
                coordenadas[pos++] = e.X;
                coordenadas[pos++] = e.Y;
                Invalidate();

                pos = 0;
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //estilo
            int itemSelecionado = comboBox1.SelectedIndex;
            switch (itemSelecionado)
            {
                case 0:
                    float[] linha = { 5, 2, 1, 2 };
                  //  estiloLinha(e, cor, esp, linha);
                    break;

                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;


            }
            MessageBox.Show(comboBox1.SelectedIndex.ToString());

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //expessura
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //raio

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //altura
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}