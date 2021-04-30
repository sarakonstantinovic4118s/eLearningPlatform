
namespace ADO.NET_Disconnected_klase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateDataSet = new System.Windows.Forms.Button();
            this.dgKupci = new System.Windows.Forms.DataGridView();
            this.dgFakture = new System.Windows.Forms.DataGridView();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.dgFaktureStavke = new System.Windows.Forms.DataGridView();
            this.txtNoviKupac = new System.Windows.Forms.TextBox();
            this.lblNazivKupca = new System.Windows.Forms.Label();
            this.lblAdresa = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.btnDodajKupca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKupacID = new System.Windows.Forms.TextBox();
            this.btnDodajFakturu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFakturaID = new System.Windows.Forms.TextBox();
            this.txtNazivStavkeFakture = new System.Windows.Forms.TextBox();
            this.txtCenaStavke = new System.Windows.Forms.TextBox();
            this.btnDodajStavkuFakture = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgKupci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFakture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFaktureStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateDataSet
            // 
            this.btnCreateDataSet.Location = new System.Drawing.Point(6, 9);
            this.btnCreateDataSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateDataSet.Name = "btnCreateDataSet";
            this.btnCreateDataSet.Size = new System.Drawing.Size(96, 44);
            this.btnCreateDataSet.TabIndex = 0;
            this.btnCreateDataSet.Text = "Create DataSet";
            this.btnCreateDataSet.UseVisualStyleBackColor = true;
            this.btnCreateDataSet.Click += new System.EventHandler(this.btnCreateDataSet_Click);
            // 
            // dgKupci
            // 
            this.dgKupci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKupci.Location = new System.Drawing.Point(6, 67);
            this.dgKupci.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgKupci.Name = "dgKupci";
            this.dgKupci.RowHeadersWidth = 51;
            this.dgKupci.RowTemplate.Height = 24;
            this.dgKupci.Size = new System.Drawing.Size(230, 112);
            this.dgKupci.TabIndex = 1;
            // 
            // dgFakture
            // 
            this.dgFakture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFakture.Location = new System.Drawing.Point(256, 66);
            this.dgFakture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgFakture.Name = "dgFakture";
            this.dgFakture.RowHeadersWidth = 51;
            this.dgFakture.RowTemplate.Height = 24;
            this.dgFakture.Size = new System.Drawing.Size(236, 112);
            this.dgFakture.TabIndex = 2;
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Location = new System.Drawing.Point(6, 356);
            this.btnSaveXML.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(96, 41);
            this.btnSaveXML.TabIndex = 3;
            this.btnSaveXML.Text = "Save XML";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // dgFaktureStavke
            // 
            this.dgFaktureStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFaktureStavke.Location = new System.Drawing.Point(517, 67);
            this.dgFaktureStavke.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgFaktureStavke.Name = "dgFaktureStavke";
            this.dgFaktureStavke.RowHeadersWidth = 51;
            this.dgFaktureStavke.RowTemplate.Height = 24;
            this.dgFaktureStavke.Size = new System.Drawing.Size(218, 111);
            this.dgFaktureStavke.TabIndex = 4;
            // 
            // txtNoviKupac
            // 
            this.txtNoviKupac.Location = new System.Drawing.Point(75, 194);
            this.txtNoviKupac.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNoviKupac.Name = "txtNoviKupac";
            this.txtNoviKupac.Size = new System.Drawing.Size(132, 20);
            this.txtNoviKupac.TabIndex = 5;
            // 
            // lblNazivKupca
            // 
            this.lblNazivKupca.AutoSize = true;
            this.lblNazivKupca.Location = new System.Drawing.Point(9, 198);
            this.lblNazivKupca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNazivKupca.Name = "lblNazivKupca";
            this.lblNazivKupca.Size = new System.Drawing.Size(60, 13);
            this.lblNazivKupca.TabIndex = 6;
            this.lblNazivKupca.Text = "Ime kupca:";
            // 
            // lblAdresa
            // 
            this.lblAdresa.AutoSize = true;
            this.lblAdresa.Location = new System.Drawing.Point(9, 228);
            this.lblAdresa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdresa.Name = "lblAdresa";
            this.lblAdresa.Size = new System.Drawing.Size(43, 13);
            this.lblAdresa.TabIndex = 7;
            this.lblAdresa.Text = "Adresa:";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(75, 223);
            this.txtAdresa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(132, 20);
            this.txtAdresa.TabIndex = 8;
            // 
            // btnDodajKupca
            // 
            this.btnDodajKupca.Location = new System.Drawing.Point(6, 284);
            this.btnDodajKupca.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajKupca.Name = "btnDodajKupca";
            this.btnDodajKupca.Size = new System.Drawing.Size(136, 32);
            this.btnDodajKupca.TabIndex = 9;
            this.btnDodajKupca.Text = "Dodaj kupca";
            this.btnDodajKupca.UseVisualStyleBackColor = true;
            this.btnDodajKupca.Click += new System.EventHandler(this.btnDodajKupca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "KupacID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Datum:";
            // 
            // txtKupacID
            // 
            this.txtKupacID.Location = new System.Drawing.Point(317, 194);
            this.txtKupacID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKupacID.Name = "txtKupacID";
            this.txtKupacID.Size = new System.Drawing.Size(72, 20);
            this.txtKupacID.TabIndex = 12;
            // 
            // btnDodajFakturu
            // 
            this.btnDodajFakturu.Location = new System.Drawing.Point(317, 284);
            this.btnDodajFakturu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajFakturu.Name = "btnDodajFakturu";
            this.btnDodajFakturu.Size = new System.Drawing.Size(125, 32);
            this.btnDodajFakturu.TabIndex = 14;
            this.btnDodajFakturu.Text = "Dodaj fakturu";
            this.btnDodajFakturu.UseVisualStyleBackColor = true;
            this.btnDodajFakturu.Click += new System.EventHandler(this.btnDodajFakturu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "FakturaID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(514, 228);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Naziv stavke fakture:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Cena stavke:";
            // 
            // txtFakturaID
            // 
            this.txtFakturaID.Location = new System.Drawing.Point(632, 194);
            this.txtFakturaID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFakturaID.Name = "txtFakturaID";
            this.txtFakturaID.Size = new System.Drawing.Size(64, 20);
            this.txtFakturaID.TabIndex = 18;
            // 
            // txtNazivStavkeFakture
            // 
            this.txtNazivStavkeFakture.Location = new System.Drawing.Point(632, 223);
            this.txtNazivStavkeFakture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNazivStavkeFakture.Name = "txtNazivStavkeFakture";
            this.txtNazivStavkeFakture.Size = new System.Drawing.Size(103, 20);
            this.txtNazivStavkeFakture.TabIndex = 19;
            // 
            // txtCenaStavke
            // 
            this.txtCenaStavke.Location = new System.Drawing.Point(632, 254);
            this.txtCenaStavke.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCenaStavke.Name = "txtCenaStavke";
            this.txtCenaStavke.Size = new System.Drawing.Size(92, 20);
            this.txtCenaStavke.TabIndex = 20;
            // 
            // btnDodajStavkuFakture
            // 
            this.btnDodajStavkuFakture.Location = new System.Drawing.Point(589, 284);
            this.btnDodajStavkuFakture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDodajStavkuFakture.Name = "btnDodajStavkuFakture";
            this.btnDodajStavkuFakture.Size = new System.Drawing.Size(146, 32);
            this.btnDodajStavkuFakture.TabIndex = 21;
            this.btnDodajStavkuFakture.Text = "Dodaj stavku fakture";
            this.btnDodajStavkuFakture.UseVisualStyleBackColor = true;
            this.btnDodajStavkuFakture.Click += new System.EventHandler(this.btnDodajStavkuFakture_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "hh:mm:ss dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(317, 228);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(176, 20);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 406);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnDodajStavkuFakture);
            this.Controls.Add(this.txtCenaStavke);
            this.Controls.Add(this.txtNazivStavkeFakture);
            this.Controls.Add(this.txtFakturaID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDodajFakturu);
            this.Controls.Add(this.txtKupacID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDodajKupca);
            this.Controls.Add(this.txtAdresa);
            this.Controls.Add(this.lblAdresa);
            this.Controls.Add(this.lblNazivKupca);
            this.Controls.Add(this.txtNoviKupac);
            this.Controls.Add(this.dgFaktureStavke);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.dgFakture);
            this.Controls.Add(this.dgKupci);
            this.Controls.Add(this.btnCreateDataSet);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgKupci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFakture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFaktureStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateDataSet;
        private System.Windows.Forms.DataGridView dgKupci;
        private System.Windows.Forms.DataGridView dgFakture;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.DataGridView dgFaktureStavke;
        private System.Windows.Forms.TextBox txtNoviKupac;
        private System.Windows.Forms.Label lblNazivKupca;
        private System.Windows.Forms.Label lblAdresa;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Button btnDodajKupca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKupacID;
        private System.Windows.Forms.Button btnDodajFakturu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFakturaID;
        private System.Windows.Forms.TextBox txtNazivStavkeFakture;
        private System.Windows.Forms.TextBox txtCenaStavke;
        private System.Windows.Forms.Button btnDodajStavkuFakture;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

