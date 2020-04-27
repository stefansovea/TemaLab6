using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using LibrarieModele;
using NivelAccesDate;

namespace AutomobileForms
{
    class Program
    {
        static void Main(string[] args)
        {
            FormularAutomobile form1 = new FormularAutomobile();
            form1.Show();
            Application.Run();
        }
    }
    public class FormularAutomobile : Form
    {
        IStocareData admin = StocareFactory.GetAdministratorStocare();
        int NumarMasini = 0;
        int nrmasini;
        int ok = 0;
        int opt;
        Optiuni op;
        Automobile[] masini = new Automobile[100];
        
        private Label lblMarca;
        private TextBox txtMarca;

        private Label lblModel;
        private TextBox txtModel;

        private Label lblCuloare;
        private TextBox txtCuloare;

        private Label lblPret;
        private TextBox txtPret;

        private Label lblBudgetClass;
        private TextBox txtBudgetClass;

        private Button btnAdauga;
        private Label lblInfoAutomobil;

        private const int LATIME_CONTROL = 150; //in px
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        private const int LUNGIME_MIN = 1;
        private const int LUNGIME_MAX = 15;
        public FormularAutomobile()
        {
            masini = admin.GetAutomobile(out nrmasini);
            NumarMasini = nrmasini;

            this.Size = new System.Drawing.Size(600, 300);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 12);
            this.Text = "Formular adaugare automobil";

            lblMarca= new Label();
            lblMarca.Width = LATIME_CONTROL;
            lblMarca.Text = "Marca";
            this.Controls.Add(lblMarca);

            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Model";
            lblModel.Top = DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblModel);

            lblCuloare = new Label();
            lblCuloare.Width = LATIME_CONTROL;
            lblCuloare.Text = "Culoare";
            lblCuloare.Top = DIMENSIUNE_PAS_Y * 2;
            this.Controls.Add(lblCuloare);

            lblPret = new Label();
            lblPret.Width = LATIME_CONTROL;
            lblPret.Text = "Pret";
            lblPret.Top = DIMENSIUNE_PAS_Y * 3;
            this.Controls.Add(lblPret);

            lblBudgetClass = new Label();
            lblBudgetClass.Width = LATIME_CONTROL;
            lblBudgetClass.Text = "Clasa buget";
            lblBudgetClass.Top = DIMENSIUNE_PAS_Y * 4;
            this.Controls.Add(lblBudgetClass);

            txtMarca = new TextBox();
            txtMarca.Width = LATIME_CONTROL;
            txtMarca.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 0);
            this.Controls.Add(txtMarca);

            txtModel = new TextBox();
            txtModel.Width = LATIME_CONTROL;
            txtModel.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtModel);

            txtCuloare = new TextBox();
            txtCuloare.Width = LATIME_CONTROL;
            txtCuloare.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 2);
            this.Controls.Add(txtCuloare);

            txtPret = new TextBox();
            txtPret.Width = LATIME_CONTROL;
            txtPret.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 3);
            this.Controls.Add(txtPret);

            txtBudgetClass = new TextBox();
            txtBudgetClass.Width = LATIME_CONTROL;
            txtBudgetClass.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 4);
            this.Controls.Add(txtBudgetClass);

            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y * 5);
            btnAdauga.Text = "Adauga";
            this.Controls.Add(btnAdauga);
            btnAdauga.Click += OnBtnAdaugaClick;

            lblInfoAutomobil = new Label();
            lblInfoAutomobil.Height = 2 * DIMENSIUNE_PAS_Y;
            lblInfoAutomobil.Width = LATIME_CONTROL * 3;
            lblInfoAutomobil.Text = "";
            lblInfoAutomobil.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 6 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(lblInfoAutomobil);
        }
        private void OnBtnAdaugaClick(Object sender, EventArgs e)
        {
            int k = 1;
            if(txtMarca.Text.Length ==0 || txtMarca.Text.Length > LUNGIME_MAX)
            {
                lblMarca.ForeColor = Color.Red;
                k = 0;

            }
            if (txtModel.Text.Length == 0 || txtModel.Text.Length > LUNGIME_MAX)
            {
                lblModel.ForeColor = Color.Red;
                k = 0;

            }
            if (txtCuloare.Text.Length == 0 || txtCuloare.Text.Length > LUNGIME_MAX)
            {
                lblCuloare.ForeColor = Color.Red;
                k = 0;

            }
            if (txtPret.Text.Length == 0 || txtPret.Text.Length > LUNGIME_MAX)
            {
                lblPret.ForeColor = Color.Red;
                k = 0;

            }
            if (txtBudgetClass.Text.Length != 1)
            {
                lblBudgetClass.ForeColor = Color.Red;
                k = 0;

            }
            if(ok==0)
            {
                lblInfoAutomobil.Text = "Completati corect campurile in rosu!";
            }
            if (k==1)
            {
                Automobile s = new Automobile();
                s.Marca = txtMarca.Text;
                s.Model = txtModel.Text;
                s.Culoare = txtCuloare.Text;
                s.Pret = Convert.ToInt64(txtPret.Text);
                ClasaBuget buget = (ClasaBuget)Convert.ToInt32(txtBudgetClass.Text);
                s.BugetClass = buget;
                Random rand = new Random();
                for (int i = 0; i < rand.Next(1, 5); i++)
                {
                    s.Opt = s.Opt | (Optiuni)Convert.ToInt32(rand.Next(1, 16));
                }
                masini[NumarMasini] = s;
                NumarMasini++;
                admin.AddAutomobil(masini, NumarMasini);
                lblInfoAutomobil.Text = s.afisareconsola();
            }


           
        }
    }
}
