using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicación_de_Notas
{
    public partial class AppNotas : Form
    {
        List<Nota> _notas = new List<Nota>();
        public AppNotas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtNotas.Text))
            {
                MessageBox.Show("El título y la nota no pueden estar vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string titulo = txtTitulo.Text.Trim();

            // Verificar si ya existe una nota con el mismo título
            if (_notas.Any(n => n.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Ya existe una nota con el título '{titulo}'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Nota nota = new Nota
            {
                Titulo = titulo,
                Notas = txtNotas.Text
            };

            _notas.Add(nota);

            AgregarAGrilla();
        }


        private void AgregarAGrilla()
        {
            //Utilizo el Binding para cuando algo cambie, se vaya actualizando en la grilla.
            BindingSource bs = new BindingSource();
            bs.DataSource = _notas;
            dgvNotas.DataSource = bs;
        }

        private void LimpiarFormulario()
        {
            txtTitulo.Text = ""; //una forma
            txtNotas.Text = string.Empty; //otra forma
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            if(dgvNotas.SelectedRows != null) //SelectedRows = es una coleccion de filas, seleccionadas por el usuario.
            {                                 //Validamos con esto = Distinto de nulo, siempre y cuando haya una fila seleccionada, podemos hacer lo que sigue.
                var titulo = dgvNotas.SelectedCells[0].Value.ToString();
                var nota = GetNotasPorTitulo(titulo);

                txtTitulo.Text = titulo;
                txtNotas.Text = nota;

            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvNotas.SelectedRows != null)
            {
                var titulo = dgvNotas.SelectedCells[0].Value.ToString();

                BorrarPorTitulo(titulo);

                AgregarAGrilla();


            }
        }

        private void BorrarPorTitulo(string titulo)
        {
            Nota notasABorrar = null;

            foreach (var nota in _notas)
            {
                if (nota.Titulo == titulo)
                {
                    notasABorrar = nota;
                }
            }

           if (notasABorrar != null)
               _notas.Remove(notasABorrar);
        }

        private string GetNotasPorTitulo(string titulo)
        {
            var notas = string.Empty;

            foreach (var nota in _notas)
            {
                if (nota.Titulo == titulo)
                {
                    notas = nota.Notas;
                }
            }

            return notas;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
