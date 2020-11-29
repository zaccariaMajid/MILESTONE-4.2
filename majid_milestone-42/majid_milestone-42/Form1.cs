using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace majid_milestone_42
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //disciplina
            eledisc.Add(new disciplinesportive("Calcio", 30, 60, 80));
            comboBox1.Items.Add("Calcio");
            var a = comboBox1.Items.IndexOf("Calcio");
            comboBox1.SelectedIndex = a;

            //gruppi
            elegrup.Add(new gruppisportivi("marco SPA", "via X settembre 6", "giacomo martinelli","3578945623","giacomom@gmail.com"));
        }

        List<disciplinesportive> eledisc = new List<disciplinesportive>();
        List<gruppisportivi> elegrup = new List<gruppisportivi>();
        List<atleta> eleatl = new List<atleta>();
        private void button1_Click(object sender, EventArgs e)
        {
            var rag = elegrup.Where(g => g.ragioneS == textBox4.Text);

            eledisc.Add(new disciplinesportive(textBox14.Text, int.Parse(textBox15.Text), int.Parse(textBox16.Text), int.Parse(textBox17.Text)));

            elegrup.Add(new gruppisportivi(textBox4.Text, textBox5.Text, textBox11.Text, textBox12.Text, textBox13.Text));

            //eleatl.Add(new atleta(textBox1.Text, textBox2.Text, DateTime.Parse(textBox3.Text), textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, );
        }
    }
}
