using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO.NET_Disconnected_klase
{
    public partial class Form1 : Form
    {
        DataTable kupci, fakture, faktureStavke;
        DataSet fakturisanje;

        private void btnSaveXML_Click(object sender, EventArgs e)
        {
            // Omogućiti serijalizaciju sva tri entiteta u jedan XML fajl koji treba da sadrži XML šemu i podatke
            fakturisanje.WriteXml(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\fakture.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Successfully saved!");
        }

        private void btnDodajKupca_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow noviKupac = kupci.NewRow();
                if (txtNoviKupac.Text == "" || txtAdresa.Text == "")
                {
                    MessageBox.Show("Polje je prazno, molimo unesite vrednost!");
                }
                else
                {
                    noviKupac["NazivKupca"] = txtNoviKupac.Text;
                    noviKupac["Adresa"] = txtAdresa.Text;
                    kupci.Rows.Add(noviKupac);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Doslo je do greske prilikom unosa kupca, molimo pokusajte ponovo!");
            }

            txtNoviKupac.Text = "";
            txtAdresa.Text = "";
        }

        private void btnDodajFakturu_Click(object sender, EventArgs e)
        {
            DataRow novaFaktura = fakture.NewRow();

            try { 
                if(txtKupacID.Text == "")
                {
                    MessageBox.Show("Polje je prazno, molimo unesite vrednost!");
                }
                else
                {
                    novaFaktura["KupacID"] = int.Parse(txtKupacID.Text);
                    novaFaktura["Datum"] = dateTimePicker1.Text;
                    fakture.Rows.Add(novaFaktura);
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Doslo je do greske prilikom unosa fakture, molimo pokusajte ponovo!");
            }

            txtKupacID.Text = "";
            txtNoviKupac.Text = "";
        }

        private void btnDodajStavkuFakture_Click(object sender, EventArgs e)
        {
            DataRow novaStavka = faktureStavke.NewRow();

            try
            {
                if(txtFakturaID.Text == "" || txtCenaStavke.Text == "" || txtNazivStavkeFakture.Text == "")
                {
                    MessageBox.Show("Polje je prazno, molimo unesite vrednost!");
                }
                else
                {
                    novaStavka["FakturaID"] = int.Parse(txtFakturaID.Text);
                    novaStavka["NazivStavke"] = txtNazivStavkeFakture.Text;
                    novaStavka["CenaStavke"] = decimal.Parse(txtCenaStavke.Text);
                    faktureStavke.Rows.Add(novaStavka);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Doslo je do greske prilikom unosa fakture, molimo pokusajte ponovo!");
            }

            txtFakturaID.Text = "";
            txtNazivStavkeFakture.Text = "";
            txtCenaStavke.Text = "";
        }

        public Form1()
        {
            InitializeComponent();

            // Entitet Kupci
            kupci = new DataTable("Kupci");

            // autonumber - KupacID, int, autoincrement (počev od 1, korak 1), nisu dozvoljene NULL vrednosti, primarni ključ
            DataColumn idKup = new DataColumn("KupacID")
            {
                DataType = typeof(int),
                AutoIncrement = true,
                AutoIncrementSeed = 1, // po default-u
                AutoIncrementStep = 1, // po default-u
                AllowDBNull = false
            };
            kupci.Columns.Add(idKup);
            kupci.PrimaryKey = new DataColumn[] { idKup };

            // NazivKupca, string maksimalne dužine 50 karaktera, nisu dozvoljene NULL vrednosti
            DataColumn naziv = new DataColumn("NazivKupca")
            {
                DataType = typeof(string),
                MaxLength = 50,
                AllowDBNull = false
            };
            kupci.Columns.Add(naziv);

            // Adresa, string maksimalne dužine 200 karaktera, dozvoljene su NULL vrednosti
            DataColumn adr = new DataColumn("Adresa")
            {
                DataType = typeof(string),
                MaxLength = 200,
                AllowDBNull = true
            };
            kupci.Columns.Add(adr);

            // Entitet Fakture
            fakture = new DataTable("Fakture");

            // FakturaID, int, autoincrement (počev od 1, korak 1), nisu dozvoljene NULL vrednosti, primarni ključ
            DataColumn idFakt = new DataColumn("FakturaID")
            {
                DataType = typeof(int),
                AutoIncrement = true,
                AutoIncrementSeed = 1, // po default-u
                AutoIncrementStep = 1, // po default-u
                AllowDBNull = false
            };
            fakture.Columns.Add(idFakt);
            fakture.PrimaryKey = new DataColumn[] { idFakt };

            // KupacID, int, nisu dozvoljene NULL vrednosti, spoljni ključ - referiše se na entitet Kupci, kolonu KupacID
            DataColumn idKupF = new DataColumn("KupacID")
            {
                DataType = typeof(int),
                AllowDBNull = false
            };
            fakture.Columns.Add(idKupF);

            // Datum, datetime, nisu dozvoljene NULL vrednosti, default vrednost je trenutni datum i vreme
            DataColumn datum = new DataColumn("Datum")
            {
                DataType = typeof(DateTime),
                DefaultValue = DateTime.Now,
                AllowDBNull = false
            };
            fakture.Columns.Add(datum);

            // Entitet FaktureStavke
            faktureStavke = new DataTable("FaktureStavke");

            // FakturaID, int, nisu dozvoljene NULL vrednosti, spoljni ključ - referiše se na entitet Fakture, kolonu FakturaID
            DataColumn idFaktStav = new DataColumn("FakturaID")
            {
                DataType = typeof(int),
                AllowDBNull = false
            };
            faktureStavke.Columns.Add(idFaktStav);

            // NazivStavke, string maksimalne dužine 40 karaktera, nisu dozvoljene NULL vrednosti
            DataColumn nazivStavke = new DataColumn("NazivStavke") {
                DataType = typeof(string),
                MaxLength = 40,
                AllowDBNull = false
            };
            faktureStavke.Columns.Add(nazivStavke);

            // CenaStavke, decimal, nisu dozvoljene NULL vrednosti
            DataColumn cenaStavke = new DataColumn("CenaStavke"){
                DataType = typeof(decimal),
                AllowDBNull = false
            };
            faktureStavke.Columns.Add(cenaStavke);
            
            // Primarni ključ ovog entiteta je kompozitni i sastoji se od atributa FakturaID i NazivStavke
            faktureStavke.PrimaryKey = new DataColumn[] { idFaktStav, nazivStavke };

            // ubacivanje u data set
            fakturisanje = new DataSet();
            fakturisanje.Tables.Add(kupci);
            fakturisanje.Tables.Add(fakture);
            fakturisanje.Tables.Add(faktureStavke);

            // pravljenje relacije1
            DataRelation dataRelation1 = new DataRelation("RelacijaKupciFakture", kupci.Columns["KupacID"], fakture.Columns["KupacID"], true);
            fakturisanje.Relations.Add(dataRelation1);

            ForeignKeyConstraint fk = (ForeignKeyConstraint)fakture.Constraints["RelacijaKupciFakture"];

            // pravljenje relacije2
            DataRelation dataRelation2 = new DataRelation("RelacijaFaktureStavke", fakture.Columns["FakturaID"], faktureStavke.Columns["FakturaID"], true);
            fakturisanje.Relations.Add(dataRelation2);

            ForeignKeyConstraint fk2 = (ForeignKeyConstraint)faktureStavke.Constraints["RelacijaFaktureStavke"];

            // Za obe relacije postaviti UPDATE i DELETE RULE na none.
            fk.DeleteRule = Rule.None;
            fk.UpdateRule = Rule.None;
            fk2.DeleteRule = Rule.None;
            fk2.UpdateRule = Rule.None;

            // dodavanje par slogova
            kupci.Rows.Add(1, "Kupac 1", "Adresa 1");
            kupci.Rows.Add(2, "Kupac 2", "Adresa 2");
            kupci.Rows.Add(3, "Kupac 3", "Adresa 3");

            fakture.Rows.Add(1, 1);
            fakture.Rows.Add(2, 2, "15-4-2021 16:00:00");
            fakture.Rows.Add(3, 3, "10-4-2021 09:00:00");


            faktureStavke.Rows.Add(1, "Stavka 1", 1000);
            faktureStavke.Rows.Add(2, "Stavka 2", 2000);
        }

        private void btnCreateDataSet_Click(object sender, EventArgs e)
        {
            try{
                // U Windows Forms tipu aplikacije pomoću DataGridView kontrola, prikazati 
                // podatke iz sva tri entiteta. Sve uraditi na jednoj formi.
                dgKupci.DataSource = kupci;
                dgFakture.DataSource = fakture;
                dgFaktureStavke.DataSource = faktureStavke;
            }
            catch (Exception ex) {
                MessageBox.Show("Doslo je do greske prilikom ucitavanja tabele!");
            }
        }
    }
}
