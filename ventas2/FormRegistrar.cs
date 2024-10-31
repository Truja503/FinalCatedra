using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventas2.Modelo;

namespace ventas2
{
    public partial class FormRegistrar : Form
    {
        public FormRegistrar()
        {
            InitializeComponent();
        }

        private void FormRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPais.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el correo tenga un formato válido
            if (!IsValidEmail(txtCorreo.Text))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el teléfono contenga solo números
            if (!txtTelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El número de teléfono debe contener solo números.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar guardar el usuario en la base de datos
            using (ConsesionariaEntities db = new ConsesionariaEntities())
            {
                try
                {
                    // Crear la instancia de usuario y asignar los valores
                    Usuario user = new Usuario
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Correo = txtCorreo.Text,
                        telefono = txtTelefono.Text,
                        Contraseña = txtPassword.Text,
                        Pais = txtPais.Text,
                        Ciudad = txtCiudad.Text
                    };

                    // Agregar el nuevo usuario a la base de datos
                    db.Usuarios.Add(user);
                    db.SaveChanges();

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abrir el formulario de sesión y cerrar el actual
                    Form1 sesion = new Form1();
                    sesion.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Mostrar el mensaje de error en caso de excepción
                    MessageBox.Show("Ocurrió un error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Método para validar el formato de correo electrónico
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
