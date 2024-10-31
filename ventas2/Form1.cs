using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Entity;
using ventas2.Modelo;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ventas2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
        }



        private void btnVerificar_Click(object sender, EventArgs e)
        {

        }

        private void txtopcion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
 
        private void btnProductos_Click(object sender, EventArgs e)
        {

            string nombreUsuario = txtuser.Text;
            string contraseña = txtpassword.Text;
            // Validar que no haya campos vacíos
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            // Primero verificamos en la tabla de Usuarios
            using (var dbContext = new ConsesionariaEntities())
            {
                var usuario = dbContext.Usuarios.FirstOrDefault(u => u.Nombre == nombreUsuario && u.Contraseña == contraseña);

                if (usuario != null)
                {
                    login.idUser = usuario.IdUser;
                    login.username = usuario.Nombre;
                    MessageBox.Show($"Hola {usuario.Nombre} {usuario.Apellido} , {login.username}  bienvenido a la aplicación.");
                    Publico publico = new Publico();
                    publico.Show();
                    this.Hide();

                }
                else
                {
                    var administrador = dbContext.Administradors
                        .FirstOrDefault(a => a.Nombre == nombreUsuario && a.Contraseña == contraseña);

                    if (administrador != null)
                    {
                        login.idUser = administrador.IdAdmin;
                        login.username = administrador.Nombre;
                        // Usuario encontrado en la tabla de Administradores
                        MessageBox.Show("Ola administrador, bienvenido a la aplicación.");
                        FormProductos privado = new FormProductos();
                        privado.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Si no está en ninguna de las tablas, mostramos un mensaje de error
                        MessageBox.Show("Usuario o contraseña incorrectos. Intente de nuevo.");
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistrar registro = new FormRegistrar();
            registro.Show();
            this.Hide();
        }
    }
}
