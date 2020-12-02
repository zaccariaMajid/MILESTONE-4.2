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
            elegrup.Add(new gruppisportivi("Carlo spa", "Via Delle Ripe", "Mario rossi", "2356692564", "Carlo@gmail.com"));
            var r = elegrup.Where(s => s.ragioneS == "Carlo spa").FirstOrDefault();
            eleatl.Add(new atleta("axl0000s", "giovanni", DateTime.Parse("29/10/2020"), 56, "Marco", "Mengoni", DateTime.Parse("06/08/2006"), "Livorno", r, d, "Junior"));
            comboBox3.Items.Add("Carlo spa");
            /////////////////////////////////////////////////////////
            eledisc.Add(new disciplinesportive("Basket", 30, 70, 90));
            var dd = eledisc.Where(s => s.nomeD == "Basket").FirstOrDefault();
            elegrup.Add(new gruppisportivi("giovanni spa", "Via Papa", "giovanni verdi", "3225694582", "giovanni@gmail.com"));
            var rr = elegrup.Where(s => s.ragioneS == "giovanni spa").FirstOrDefault();
            eleatl.Add(new atleta("axl00s", "maria", DateTime.Parse("28/05/2020"), 95, "Giuseppe", "Diego", DateTime.Parse("08/02/2001"), "Milano" ,rr, dd, "Senior"));
            comboBox3.Items.Add("Giovanni spa");
            /////////////////////////////////////////////////////////
            eledisc.Add(new disciplinesportive("Scherma", 40, 60, 70));
            var ddd = eledisc.Where(s => s.nomeD == "Scherma").FirstOrDefault();
            elegrup.Add(new gruppisportivi("liano spa", "Piazza", "liano bianchi", "6552134784", "liano@gmail.com"));
            var rrr = elegrup.Where(s => s.ragioneS == "liano spa").FirstOrDefault();
            eleatl.Add(new atleta("axl0s", "liano", DateTime.Parse("04/12/2019"), 20, "Francesco", "Carminati", DateTime.Parse("26/05/2002"), "Genova", rrr, ddd, "Dilettanti"));
            comboBox3.Items.Add("Liano spa");
            /////////////////////////////////////////////////////////

            var g = eledisc.Select(s => new { Nome_disciplina = s.nomeD, Livello_dilettanti = s.livelloDil, Livello_junior = s.livelloJun, Livello_senior = s.livelloSen });
            var l = elegrup.Select(k => new { Ragione_sociale = k.ragioneS, Indirizzo = k.indirizzoS, Nome_presidente = k.nomeP, Numero_telefono = k.telefono, Indirizzo_mail = k.mail });
            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

            dataGridView1.DataSource = g.ToList();
            dataGridView2.DataSource = l.ToList();
            dataGridView3.DataSource = dataFin.ToList();
            dataGridView5.DataSource = g.ToList();
            dataGridView4.DataSource = l.ToList();
            //dataGridView6.DataSource = dataFin.ToList();
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
                
                var disc = eledisc.Where(s => s.nomeD == textBox14.Text).FirstOrDefault();
                var grup = elegrup.Where(s => s.ragioneS == textBox4.Text).FirstOrDefault();

                var nuovaAtl = new atleta(textBox1.Text, textBox2.Text, dateTimePicker2.Value.Date, int.Parse(textBox6.Text), textBox3.Text, textBox8.Text, dateTimePicker1.Value.Date, textBox10.Text, grup, disc, comboBox1.SelectedItem.ToString());

                eleatl.Add(nuovaAtl);

                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

                dataGridView3.DataSource = dataFin.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (textBox4.Enabled == true)
            {
                var nuovoGrup = new gruppisportivi(textBox4.Text, textBox5.Text, textBox11.Text, textBox12.Text, textBox13.Text);
                if (elegrup.Contains(nuovoGrup))
                {
                    MessageBox.Show("Disciplina esistente nel registro");
                }
                elegrup.Add(nuovoGrup);

                //visualizza gruppo sociale
                var q = elegrup.Select(k => new { Ragione_sociale = k.ragioneS, Indirizzo = k.indirizzoS, Nome_presidente = k.nomeP, Numero_telefono = k.telefono, Indirizzo_mail = k.mail });
                dataGridView2.DataSource = q.ToList();
                checkBox4.Checked = false;
                
                comboBox3.Items.Add(textBox4.Text);
            }
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
            if (textBox14.Enabled == true)
            {
                var nuovaDisc = new disciplinesportive(textBox14.Text, int.Parse(numericUpDown1.Value.ToString()), int.Parse(numericUpDown2.Value.ToString()), int.Parse(numericUpDown3.Value.ToString()));

                if (eledisc.Contains(nuovaDisc))
                {
                    MessageBox.Show("Disciplina esistente nel registro");
                }
                eledisc.Add(nuovaDisc);
                //visualizza disciplina
                var p = eledisc.Select(s => new { Nome = s.nomeD, Livello_dilettanti = s.livelloDil, Livello_junior = s.livelloJun, Livello_senior = s.livelloSen });
                
                checkBox5.Checked = false;
                dataGridView1.DataSource = p.ToList();
            }
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
                atl.dataS = dateTimePicker4.Value.Date;
                atl.ido = int.Parse(textBox16.Text);
                atl.nomeA = textBox7.Text;
                atl.cogn = textBox9.Text;
                atl.dataN = dateTimePicker3.Value.Date;
                atl.citt = textBox15.Text;
                atl.lvl = comboBox2.SelectedItem.ToString();
                eleatl.Add(atl);
                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });
                MessageBox.Show("Dati dell'atleta modificati con successo");

                dataGridView3.DataSource = dataFin.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            var gruppoR = elegrup.Where(i => i.ragioneS == textBox28.Text).FirstOrDefault();

            elegrup.Remove(gruppoR);

            var l = elegrup.Select(k => new { Ragione_sociale = k.ragioneS, Indirizzo = k.indirizzoS, Nome_presidente = k.nomeP, Numero_telefono = k.telefono, Indirizzo_mail = k.mail });
            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

            dataGridView3.DataSource = dataFin.ToList();
            dataGridView4.DataSource = l.ToList();

            ClearTextBoxes(this.Controls);
            ClearDTP(this.Controls);
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox28.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox23.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox22.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox21.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            textBox20.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox26.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            numericUpDown6.Value = int.Parse(dataGridView5.CurrentRow.Cells[1].Value.ToString());
            numericUpDown5.Value = int.Parse(dataGridView5.CurrentRow.Cells[2].Value.ToString());
            numericUpDown4.Value = int.Parse(dataGridView5.CurrentRow.Cells[3].Value.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var grup = elegrup.Where(m => m.ragioneS == textBox28.Text).FirstOrDefault();

            try
            {
                elegrup.Remove(grup);

                //grup.ragioneS = textBox28.Text;
                grup.indirizzoS = textBox23.Text;
                grup.nomeP = textBox22.Text;
                grup.telefono = textBox21.Text;
                grup.mail = textBox20.Text;
                elegrup.Add(grup);
                var l = elegrup.Select(k => new { Ragione_sociale = k.ragioneS, Indirizzo = k.indirizzoS, Nome_presidente = k.nomeP, Numero_telefono = k.telefono, Indirizzo_mail = k.mail });
                MessageBox.Show("Dati del gruppo sportivo modificati con successo");

                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

                dataGridView3.DataSource = dataFin.ToList();
                dataGridView4.DataSource = l.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            textBox28.Clear();
            textBox23.Clear();
            textBox22.Clear();
            textBox21.Clear();
            textBox20.Clear();
            checkBox3.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                textBox28.Enabled = false;
                textBox23.Enabled = true;
                textBox22.Enabled = true;
                textBox21.Enabled = true;
                textBox20.Enabled = true;

                button8.Visible = true;
            }

            if(checkBox2.Checked == false && textBox28.Text == "")
            {
                textBox28.Enabled = true;
                textBox23.Enabled = false;
                textBox22.Enabled = false;
                textBox21.Enabled = false;
                textBox20.Enabled = false;

                button8.Visible = false;
            }
        }
        

        

        private void button9_Click(object sender, EventArgs e)
        {
            var disc = eledisc.Where(i => i.nomeD == textBox26.Text).FirstOrDefault();

            eledisc.Remove(disc);

            var g = eledisc.Select(s => new { Nome_disciplina = s.nomeD, Livello_dilettanti = s.livelloDil, Livello_junior = s.livelloJun, Livello_senior = s.livelloSen });

            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

            dataGridView3.DataSource = dataFin.ToList();

            dataGridView5.DataSource = g.ToList();

            comboBox3.Items.Remove(textBox26.Text);

            ClearTextBoxes(this.Controls);
            ClearNUD(this.Controls);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var disc = eledisc.Where(m => m.nomeD == textBox26.Text).FirstOrDefault();

            try
            {
                eledisc.Remove(disc);

                disc.nomeD = textBox26.Text;
                disc.livelloDil = int.Parse(numericUpDown6.Value.ToString());
                disc.livelloJun = int.Parse(numericUpDown5.Value.ToString());
                disc.livelloSen = int.Parse(numericUpDown4.Value.ToString());
                eledisc.Add(disc);
                var g = eledisc.Select(s => new { Nome_disciplina = s.nomeD, Livello_dilettanti = s.livelloDil, Livello_junior = s.livelloJun, Livello_senior = s.livelloSen });
                MessageBox.Show("Dati del gruppo disciplina modificati con successo");
                var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl });

                dataGridView3.DataSource = dataFin.ToList();
                dataGridView6.DataSource = g.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Dati inseriti non corretti");
                return;
            }
            textBox26.Clear();
            numericUpDown6.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

            checkBox3.Checked = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl }).ToList();
            dataGridView6.DataSource = (new string[] { "#NaN#", "Dilettanti", "Junior", "Senior" })[(radioButton1.Checked ? 1 : 0) + (radioButton2.Checked ? 2 : 0) + (radioButton3.Checked ? 3 : 0)] == "#NaN#" ? dataFin : dataFin.Where(p => p.Livello_agonistico == (new string[] { "#NaN#", "Dilettanti", "Junior", "Senior" })[(radioButton1.Checked ? 1 : 0) + (radioButton2.Checked ? 2 : 0) + (radioButton3.Checked ? 3 : 0)] /*&& p.Livello_atleta ==*/ ).ToList();
            comboBox3.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text == "" || int.Parse(textBox6.Text) <= numericUpDown1.Value && int.Parse(textBox6.Text) < numericUpDown2.Value && int.Parse(textBox6.Text) < numericUpDown3.Value)
                comboBox1.Text = "Dilettanti";

            if (textBox6.Text == "" || int.Parse(textBox6.Text) > numericUpDown1.Value && int.Parse(textBox6.Text) >= numericUpDown2.Value && int.Parse(textBox6.Text) < numericUpDown3.Value)
                comboBox1.Text = "Junior";

            if (textBox6.Text == "" || int.Parse(textBox6.Text) > numericUpDown2.Value && int.Parse(textBox6.Text) > numericUpDown2.Value && int.Parse(textBox6.Text) >= numericUpDown3.Value)
                comboBox1.Text = "Senior";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            var dataFin = eleatl.Select(s => new { Codice_Idoneità = s.codI, Nome_medico = s.med, Data_rilascio = s.dataS, Livello_atleta = s.ido, Nome = s.nomeA, Cognome = s.cogn, Data_nascita = s.dataN, Città_residenza = s.citt, Gruppo_sportivo = s.gs.ragioneS, Disciplina = s.disc.nomeD, Livello_agonistico = s.lvl }).Where(s=>s.Gruppo_sportivo == comboBox3.Text).ToList();

            dataGridView6.DataSource = dataFin;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox3.Checked == true)
            {
                textBox26.Enabled = false;
                numericUpDown6.Enabled = true;
                numericUpDown5.Enabled = true;
                numericUpDown4.Enabled = true;
                button6.Visible = true;
            }
            if (checkBox3.Checked == false && textBox26.Text == "")
            {
                textBox26.Enabled = true;
                numericUpDown6.Enabled = false;
                numericUpDown5.Enabled = false;
                numericUpDown4.Enabled = false;
                button6.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox5.Checked == true)
            {
                groupBox3.Visible = true;

                textBox14.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;

                textBox14.Clear();
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
            }
            if(checkBox5.Checked == false)
                groupBox3.Visible = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked == true)
            {
                groupBox1.Visible = true;


                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                textBox13.Enabled = true;


                textBox4.Clear();
                textBox5.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
            }

            if (checkBox4.Checked == false)
                groupBox4.Visible = false;
        }


    }
}
