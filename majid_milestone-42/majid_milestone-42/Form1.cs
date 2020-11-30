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

            eledisc.Add(new disciplinesportive("Calcio", 30, 50, 80));
            var d = eledisc.Where(s => s.nomeD == "Calcio").FirstOrDefault();
            elegrup.Add(new gruppisportivi("Mario spa", "Via Papa", "0", "Mario Rossi", "Marior@gmail.com"));
            var r = elegrup.Where(s => s.ragioneS == "Mario spa").FirstOrDefault();
            eleatl.Add(new atleta("axl00s", "giovanni", DateTime.Parse("28/05/2020"), 53, "carlo", "mengoni", DateTime.Parse("28/05/2002"), "milano", r, d, "Junior"));

            var g = eledisc.Select(s => new { nome = s.nomeD, lvlm = s.livelloDil, lvlmx = s.livelloJun, lvlmxq = s.livelloSen });
            var l = elegrup.Select(k => new { rag = k.ragioneS, via = k.indirizzoS, nomep = k.nomeP, tel = k.telefono, mail = k.mail });

            dataGridView1.DataSource = g.ToList();
            dataGridView2.DataSource = l.ToList();
        }

        

        List<disciplinesportive> eledisc = new List<disciplinesportive>();
        List<gruppisportivi> elegrup = new List<gruppisportivi>();
        List<atleta> eleatl = new List<atleta>();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Enabled == true)
                {
                    var nuovoGrup = new gruppisportivi(textBox4.Text, textBox5.Text, textBox11.Text, textBox12.Text, textBox13.Text);
                    if (elegrup.Contains(nuovoGrup))
                    {
                        MessageBox.Show("Disciplina esistente nel registro");
                    }
                    elegrup.Add(nuovoGrup);
                    
                    //visualizza gruppo sociale
                    var q = elegrup.Select(k => new { Ragione_sociale = textBox4.Text, Indirizzo = k.indirizzoS, Numero_telefono = k.telefono, Nome_presidente = k.nomeP, Indirizzo_mail = k.mail });
                    dataGridView2.DataSource = q.ToList();
                }

                if (textBox14.Enabled == true)
                {                    
                    var nuovaDisc = new disciplinesportive(textBox14.Text, int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()), int.Parse(numericUpDown3.Value.ToString()));

                    if (eledisc.Contains(nuovaDisc))
                    {
                        MessageBox.Show("Disciplina esistente nel registro");
                    }
                    eledisc.Add(nuovaDisc);
                    //visualizza disciplina
                    var p = eledisc.Select(s => new { Nome = textBox14.Text, Livello_dilettanti = s.livelloDil, Livello_junior = s.livelloJun, Livello_senior = s.livelloSen });
                    dataGridView1.DataSource = p.ToList();
                }



                var disc = eledisc.Where(s => s.nomeD == textBox14.Text).FirstOrDefault();
                var grup = elegrup.Where(s => s.ragioneS == textBox4.Text).FirstOrDefault();

                var nuovaAtl = new atleta(textBox1.Text, textBox2.Text, dateTimePicker1.Value.Date, int.Parse(textBox6.Text), textBox3.Text, textBox8.Text, dateTimePicker2.Value.Date, textBox10.Text, grup, disc, comboBox1.SelectedItem.ToString());

                eleatl.Add(nuovaAtl);

                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });
                //visualizza disciplina
                var d = eledisc.Select(s => new { Nome = s.nomeD, Livello_dilettanti = s.livelloDil, Livello_junior = s.livelloJun, Livello_senior = s.livelloSen });
                //visualizza gruppo sociale
                var l = elegrup.Select(k => new { Ragione_sociale = k.ragioneS, Indirizzo = k.indirizzoS, Numero_telefono = k.telefono, Nome_presidente = k.nomeP, Indirizzo_mail = k.mail });

                dataGridView1.DataSource = d.ToList();
                dataGridView2.DataSource = l.ToList();
                dataGridView3.DataSource = dataFin.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dati già esistenti", ex.Message);
                return;
            }

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
                    

            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            groupBox1.Visible = true;
            groupBox3.Visible = true;

            textBox14.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            numericUpDown2.Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            numericUpDown3.Value = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            if (groupBox3.Visible == true)
            {
                textBox14.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;

                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox13.Enabled = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            

            groupBox1.Visible = true;
            groupBox3.Visible = true;


            textBox4.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox11.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox12.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox13.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            if (groupBox1.Visible == true)
            {
                textBox14.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;

                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox13.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            groupBox3.Visible = true;

            textBox14.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
        }
    }
}
