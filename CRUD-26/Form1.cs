using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CRUD_26
{
    public partial class Form1 : Form
    {
        #region declare
        string file;
        public Form1()
        {
            InitializeComponent();
            file = @"carrello.csv";
            p = new Prodotto[100];
            d = 0;
        }
        public struct Prodotto
        {
            public float prezzo;
            public string nome;
        }
        public static Prodotto[] p;
        public static int d;
        
        #endregion
        #region pulsanti
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void stampa_Click(object sender, EventArgs e)
        {
            p[d].nome = textBox1.Text;
            p[d].prezzo = float.Parse(textBox2.Text);
            d++;
            vis();
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }

        private void cerca_Click(object sender, EventArgs e)
        {

        }

        private void modify_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        #region funzioni
        //funzioni per la stampa
        public string proString(Prodotto p)
        {
            return "Nome: " + p.nome + " Prezzo: " + p.prezzo.ToString();
        }
        void vis()
        {
            listView1.Items.Clear();
            for (int i = 0; i < d; i++)
            {
                listView1.Items.Add(proString(p[i]));
            }
        }
        //funzioni per la ricerca
        int research(Prodotto[] p, string nome)
        {
            int pos;
            for (int i = 0; i < d; i++)
            {
                if (p[i].nome == nome)
                {
                    pos = i;
                    return pos;
                }
            }
            pos = -1;
            return pos;

        }
        //funzioni per la modifica

        //funzioni per la cancellazione
        void delete(string nome)
        {
            if(File.Exists(file))
            {
                using (StreamReader st = File.OpenText(file))
                {
                    for (int i = 0; i < d; i++)
                    {

                        while ((p[i].nome = st.ReadLine()) != null)
                        {
                            if (p[i].nome == nome)
                            {
                                for (int j = i; j < p.Length - 1; j++)
                                {
                                    p[i] = p[i + 1];
                                }
                                d--;
                            }
                        }
                    }
                }  
            }
            else
            {
                MessageBox.Show("Il file non è presente");
            }
        }
        #endregion
    }
}
