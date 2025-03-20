using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiOP4
{
    public partial class Form1 : Form
    {
        private List<Korisnik> korisnici = new List<Korisnik>();
        private const string FILE_PATH = "korisnici.txt";
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = korisnici; // Povezivanje liste s DataGridView
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                string ime = txtIme.Text;
                string prezime = txtPrezime.Text;
                string kontakt = txtKontakt.Text;

                Korisnik noviKorisnik = new Korisnik(id, ime, prezime, kontakt);
                korisnici.Add(noviKorisnik);

                // Osvježavanje DataGridView-a
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = korisnici;

                // Brisanje polja nakon unosa
                txtID.Clear();
                txtIme.Clear();
                txtPrezime.Clear();
                txtKontakt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pogrešan unos! Provjerite ID i ostale podatke.");
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FILE_PATH))
                {
                    foreach (var korisnik in korisnici)
                    {
                        sw.WriteLine(korisnik.ToString());
                    }
                }
                MessageBox.Show("Podaci su spremljeni u datoteku.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri spremanju u datoteku!");
            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(FILE_PATH))
                {
                    korisnici.Clear();
                    using (StreamReader sr = new StreamReader(FILE_PATH))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            korisnici.Add(Korisnik.FromString(line));
                        }
                    }

                    // Osvježavanje DataGridView-a
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = korisnici;
                }
                else
                {
                    MessageBox.Show("Datoteka ne postoji.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju iz datoteke!");
            }
        }
    }
}
