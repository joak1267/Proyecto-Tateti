using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictuc
{
    public partial class Form1 : Form
    {
        string jugadorX = "";
        string jugadorO = "";
        bool cambio = true;
        int empate = 0;
        int ganadasX = 0;
        int ganadasO = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OnOffBtn(false);
        }

        private void OnOffBtn(bool onoff)
        {
            a1.Enabled = onoff;
            a2.Enabled = onoff;
            a3.Enabled = onoff;
            b1.Enabled = onoff;
            b2.Enabled = onoff;
            b3.Enabled = onoff;
            c1.Enabled = onoff;
            c2.Enabled = onoff;
            c3.Enabled = onoff;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ingresar();
        }
        private void Ingresar()
        {
           if (txtUser1.Text == "" && txtUser2.Text == "")
            {
                MessageBox.Show("el nombre de los jugadores no tiene que estar vacio", "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           else
            {
                if(txtUser1.Text == "")
                {
                    MessageBox.Show("el nombre del jugador 1 no tiene que estar vacio", "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (txtUser2.Text == "")
                {
                    MessageBox.Show("el nombre del jugador 2 no tiene que estar vacio", "Nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           if(txtUser1.Text != "" && txtUser2.Text != "")
            {
                if (rbtnUser1X.Checked && rbtnUser2O.Checked)
                {
                    jugadorX = txtUser1.Text;
                    jugadorO = txtUser2.Text;
                    rbtnUser1O.Enabled = false;
                    rbtnUser2X.Enabled = false;
                    Playgame();
                }
                if (rbtnUser1O.Checked && rbtnUser2X.Checked)
                {
                    jugadorX = txtUser2.Text;
                    jugadorO = txtUser1.Text;
                    rbtnUser1X.Enabled = false;
                    rbtnUser2O.Enabled = false;
                    Playgame();
                }
                if (rbtnUser1X.Checked && rbtnUser2X.Checked)
                {
                    MessageBox.Show("Los 2 jugadores no pueden seleccionar la letra X", "Elija devuelta la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (rbtnUser1O.Checked && rbtnUser2O.Checked)
                {
                    MessageBox.Show("Los 2 jugadores no pueden seleccionar la letra O", "Elija devuelta la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(rbtnUser1X.Checked == false && rbtnUser1O.Checked == false || rbtnUser2X.Checked == false && rbtnUser2O.Checked == false)
                {
                    MessageBox.Show("Los jugadores solo pueden seleccionar una letra", "Elija devuelta la letra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Playgame()
        {
            IblUser1.Text = txtUser1.Text;
            IblUser2.Text = txtUser2.Text;

            IblUserPuntos1.Visible = true;
            IblUserPuntos2.Visible = true;

            groupBox1.Text = "Marcador";

            btnborrar.Visible = true;
            btnreiniciar.Visible = true;

            btniniciar.Visible = false;
            txtUser1.Visible = false;
            txtUser2.Visible = false;

            MessageBox.Show("Arranca " + jugadorX, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OnOffBtn(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(cambio)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;
            Partida();
        }

        private void Partida()
        {
           if((a1.Text == a2.Text) & (a2.Text == a3.Text) && (!a1.Enabled))
            { Valido(a1); }
           else if ((b1.Text == b2.Text) & (b2.Text == b3.Text) && (!b1.Enabled))
            { Valido(b1); }
            else if ((c1.Text == c2.Text) & (c2.Text == c3.Text) && (!c1.Enabled))
            { Valido(c1); }

            if ((a1.Text == b1.Text) & (b1.Text == c1.Text) && (!a1.Enabled))
            { Valido(a1); }
            else if ((a2.Text == b2.Text) & (b2.Text == c2.Text) && (!a2.Enabled))
            { Valido(a2); }
            else if ((a3.Text == b3.Text) & (b3.Text == c3.Text) && (!a3.Enabled))
            { Valido(a3); }

            if ((a1.Text == b2.Text) & (b2.Text == c3.Text) && (!a1.Enabled))
            { Valido(a1); }
            else if ((a3.Text == b2.Text) & (b2.Text == c1.Text) && (!a3.Enabled))
            { Valido(a3); }

            empate++;

            if(empate == 9)
            {
                MessageBox.Show("Los jugadores Empataron", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Borrar();
                OnOffBtn(true);
                empate = 0;
            }
        }
        public void Valido(Button b)
        {
            empate = -1;
            if(b.Text == "X")
            {
                MessageBox.Show("Gano " + jugadorX, "Ganaste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("Gano " + jugadorO, "Ganaste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;
            }
            if(rbtnUser1X.Checked && rbtnUser2O.Checked)
            {
                IblUserPuntos1.Text = ganadasX.ToString();
                IblUserPuntos2.Text = ganadasO.ToString();
            }
            else if (rbtnUser1O.Checked && rbtnUser2X.Checked)
            {
                IblUserPuntos1.Text = ganadasO.ToString();
                IblUserPuntos2.Text = ganadasX.ToString();
            }
            Borrar();
            OnOffBtn(true);
        }
        private void Borrar()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";
        }

        private void btnreiniciar_Click(object sender, EventArgs e)
        {
            Borrar();
            OnOffBtn(true);
            btnborrar.Visible = false;
            btnreiniciar.Visible = false;

            btniniciar.Visible = true;
            txtUser1.Visible = true;
            txtUser2.Visible = true;

            jugadorX = "";
            jugadorO = "";
            ganadasX = 0;
            ganadasO = 0;
            cambio = true;

            IblUserPuntos1.Text = 0.ToString();
            IblUserPuntos2.Text = 0.ToString();

            IblUser1.Text = "";
            IblUser2.Text = "";

            rbtnUser1O.Enabled = true;
            rbtnUser2X.Enabled = true;
            rbtnUser1X.Enabled = true;
            rbtnUser2O.Enabled = true;

            rbtnUser1X.Checked = false;
            rbtnUser1O.Checked = false;
            rbtnUser2O.Checked = false;
            rbtnUser2X.Checked = false;

            groupBox1.Text = "Agregar nombre de los jugadores";

            IblUserPuntos1.Visible = false;
            IblUserPuntos2.Visible = false;
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            Borrar();
            OnOffBtn(true);
            empate = 0;
        }
    }
}
