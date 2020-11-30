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
            /////////////////////////////////////////////////////////
            eledisc.Add(new disciplinesportive("Calcio", 30, 50, 80));
            var d = eledisc.Where(s => s.nomeD == "Calcio").FirstOrDefault();
            elegrup.Add(new gruppisportivi("Mario spa", "Via sdsPapa", "Mario rossi", "0", "Maridsador@gmail.com"));
            var r = elegrup.Where(s => s.ragioneS == "Mario spa").FirstOrDefault();
            eleatl.Add(new atleta("axl0000s", "giovanni", DateTime.Parse("28/05/2020"), 53, "carlo", "mengoni", DateTime.Parse("28/05/2002"), "midwalano", r, d, "Junior"));
            /////////////////////////////////////////////////////////
            eledisc.Add(new disciplinesportive("Calcio", 30, 50, 80));
            var dd = eledisc.Where(s => s.nomeD == "Calcio").FirstOrDefault();
            elegrup.Add(new gruppisportivi("Mario spa", "Via Papa", "Mario rossi", "0", "Marior@gmail.com"));
            var rr = elegrup.Where(s => s.ragioneS == "Mario spa").FirstOrDefault();
            eleatl.Add(new atleta("axl00s", "giovanni", DateTime.Parse("28/05/2020"), 53, "carlo", "mengoni", DateTime.Parse("28/05/2002"), "miasdlano", r, d, "Dilettanti"));
            /////////////////////////////////////////////////////////
            eledisc.Add(new disciplinesportive("Calcio", 30, 50, 80));
            var ddd = eledisc.Where(s => s.nomeD == "Calcio").FirstOrDefault();
            elegrup.Add(new gruppisportivi("Mario spa", "Vdsia Papa", "Mario rossi", "0", "Marior@gmail.com"));
            var rrr = elegrup.Where(s => s.ragioneS == "Mardasdio spa").FirstOrDefault();
            eleatl.Add(new atleta("axl0s", "giovanni", DateTime.Parse("28/05/2020"), 53, "dascarlo", "mendasgoni", DateTime.Parse("28/05/2002"), "milaadsno", r, d, "Senior"));
            /////////////////////////////////////////////////////////

            var g = eledisc.Select(s => new { nome = s.nomeD, lvlm = s.livelloDil, lvlmx = s.livelloJun, lvlmxq = s.livelloSen });
            var l = elegrup.Select(k => new { rag = k.ragioneS, via = k.indirizzoS, nomep = k.nomeP, tel = k.telefono, mail = k.mail });
            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

            dataGridView1.DataSource = g.ToList();
            dataGridView2.DataSource = l.ToList();
            dataGridView3.DataSource = dataFin.ToList();
            dataGridView5.DataSource = g.ToList();
            dataGridView4.DataSource = l.ToList();
        }
        //funzione per svuotare le textbox
        public void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }
        //funzione per svuotare i numericUpDown
        public void ClearNUD(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl.GetType() == typeof(NumericUpDown))
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearNUD(ctrl.Controls);
                }
            }
        }
        //funzione per svuotare i dateTimePicker
        public void ClearDTP(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl.GetType() == typeof(DateTimePicker))
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearDTP(ctrl.Controls);
                }
            }
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

            ClearTextBoxes(this.Controls);
            ClearNUD(this.Controls);
            ClearDTP(this.Controls);
            comboBox1.SelectedIndex = -1;

            groupBox1.Visible = false;
            groupBox3.Visible = false;

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

        private void button4_Click(object sender, EventArgs e)
        {
            var eleEli = eleatl.Where(s => s.codI == textBox17.Text).FirstOrDefault();

            eleatl.Remove(eleEli);

            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

            dataGridView3.DataSource = dataFin.ToList();

            ClearTextBoxes(this.Controls);
            ClearDTP(this.Controls);
            comboBox2.SelectedIndex = -1;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox17.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox18.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker4.Text = DateTime.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()).Date.ToString();
            textBox16.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker3.Text = DateTime.Parse(dataGridView3.CurrentRow.Cells[6].Value.ToString()).Date.ToString();
            textBox15.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
            comboBox2.SelectedItem = dataGridView3.CurrentRow.Cells[10].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var atl = eleatl.Where(m => m.codI == textBox17.Text).FirstOrDefault();

            try
            {
                eleatl.Remove(atl);

                atl.med = textBox18.Text;
                atl.dataS = dateTimePicker3.Value.Date;
                atl.ido = int.Parse(textBox16.Text);
                atl.nomeA = textBox7.Text;
                atl.cogn = textBox9.Text;
                atl.dataN = dateTimePicker4.Value.Date;
                atl.citt = textBox15.Text;
                atl.lvl = comboBox2.SelectedItem.ToString();
                eleatl.Add(atl);
                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });
                MessageBox.Show("Dati dell'atleta modificati con successo");

                dataGridView3.DataSource = dataFin.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Dati inseriti non corretti");
                return;
            }
            ClearTextBoxes(this.Controls);
            ClearDTP(this.Controls);
            comboBox2.SelectedIndex = -1;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textBox18.Enabled = true;
                dateTimePicker3.Enabled = true;
                textBox16.Enabled = true;
                textBox7.Enabled = true;
                dateTimePicker4.Enabled = true;
                textBox9.Enabled = true;
                textBox15.Enabled = true;
                comboBox2.Enabled = true;

                button5.Visible = true;
            }
            else if(checkBox1.Checked == false)
            {
                textBox18.Enabled = false;
                dateTimePicker3.Enabled = false;
                textBox16.Enabled = false;
                textBox7.Enabled = false;
                dateTimePicker4.Enabled = false;
                textBox9.Enabled = false;
                textBox15.Enabled = false;
                comboBox2.Enabled = false;

                button5.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var gruppoR = elegrup.Where(i => i.ragioneS == textBox24.Text).FirstOrDefault();

            elegrup.Remove(gruppoR);

            var l = elegrup.Select(k => new { rag = k.ragioneS, via = k.indirizzoS, nomep = k.nomeP, tel = k.telefono, mail = k.mail });

            dataGridView4.DataSource = l.ToList();

            ClearTextBoxes(this.Controls);
            ClearDTP(this.Controls);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox24.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox23.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox22.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox21.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            textBox20.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox19.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            numericUpDown6.Value = int.Parse(dataGridView5.CurrentRow.Cells[1].Value.ToString());
            numericUpDown5.Value = int.Parse(dataGridView5.CurrentRow.Cells[2].Value.ToString());
            numericUpDown4.Value = int.Parse(dataGridView5.CurrentRow.Cells[3].Value.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var grup = elegrup.Where(m => m.ragioneS == textBox24.Text).FirstOrDefault();

            try
            {
                elegrup.Remove(grup);

                grup.ragioneS = textBox24.Text;
                grup.indirizzoS = textBox23.Text;
                grup.nomeP = textBox22.Text;
                grup.telefono = textBox21.Text;
                grup.mail = textBox20.Text;
                elegrup.Add(grup);
                var l = elegrup.Select(k => new { rag = k.ragioneS, via = k.indirizzoS, nomep = k.nomeP, tel = k.telefono, mail = k.mail });
                MessageBox.Show("Dati della ragione sociale modificati con successo");

                dataGridView4.DataSource = l.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Dati inseriti non corretti");
                return;
            }
            ClearTextBoxes(this.Controls);
            ClearDTP(this.Controls);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                textBox24.Enabled = true;
                textBox23.Enabled = true;
                textBox22.Enabled = true;
                textBox21.Enabled = true;
                textBox20.Enabled = true;

                button8.Visible = true;
            }

            if(checkBox2.Checked == false)
            {
                textBox24.Enabled = false;
                textBox23.Enabled = false;
                textBox22.Enabled = false;
                textBox21.Enabled = false;
                textBox20.Enabled = false;

                button8.Visible = false;
            }
        }
        

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Dilettanti")
            {
                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl }).Where(s => s.Livello_agonistico == "Dilettanti");

                dataGridView6.DataSource = dataFin.ToList();
            }

            if (comboBox3.Text == "Junior")
            {
                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl }).Where(s=>s.Livello_agonistico == "Junior");

                dataGridView6.DataSource = dataFin.ToList();
            }

            if (comboBox3.Text == "Senior")
            {
                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl }).Where(s => s.Livello_agonistico == "Senior");

                dataGridView6.DataSource = dataFin.ToList();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var disc = eledisc.Where(i => i.nomeD == textBox19.Text).FirstOrDefault();

            eledisc.Remove(disc);

            var g = eledisc.Select(s => new { nome = s.nomeD, lvlm = s.livelloDil, lvlmx = s.livelloJun, lvlmxq = s.livelloSen });

            dataGridView5.DataSource = g.ToList();

            ClearTextBoxes(this.Controls);
            ClearNUD(this.Controls);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var disc = eledisc.Where(m => m.nomeD == textBox17.Text).FirstOrDefault();

            try
            {
                eledisc.Remove(disc);

                disc.nomeD = textBox19.Text;
                disc.livelloDil = int.Parse(numericUpDown6.Value.ToString());
                disc.livelloDil = int.Parse(numericUpDown5.Value.ToString());
                disc.livelloDil = int.Parse(numericUpDown4.Value.ToString());
                var g = eledisc.Select(s => new { nome = s.nomeD, lvlm = s.livelloDil, lvlmx = s.livelloJun, lvlmxq = s.livelloSen });
                MessageBox.Show("Dati dell'atleta modificati con successo");

                dataGridView6.DataSource = g.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Dati inseriti non corretti");
                return;
            }
        }
    }
}
