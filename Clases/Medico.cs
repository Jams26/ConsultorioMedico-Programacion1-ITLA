using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Medico:Persona
    {
        //Atributos
        string exequatur;
        string clinicas;

        //Propiedades
        public int Id { get => id; set => id = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Exequatur { get => exequatur; set => exequatur = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Clinicas { get => clinicas; set => clinicas = value; }

        //Conexion y metodos 
        SqlConnection con = new SqlConnection("Data Source=LATITUDE-PC;Initial Catalog=ProyectoFinal;Integrated Security=True");

        SqlCommand comando;

        //1- INSERSION DE DATOS
        public void Guardar(int cod, string ced, string exeq, string nom, string tel, string mail, string clin)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"insert into Medicos values ({cod},'{ced}','{exeq}','{nom}','{tel}','{mail}','{clin}')";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();

        }

        //2- ACTUALIZACION DE DATOS
        public void Actualizar(int cod, string ced, string exeq, string nom, string tel, string mail, string clin)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"update Medicos set Cédula='{ced}', Exequátur='{exeq}', Nombre='{nom}', Teléfono= '{tel}', Email= '{mail}', Clínicas= '{clin}' where Id = {cod}";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();
        }

        //3- ELIMINACION DE DATOS
        public void Eliminar(int cod)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"delete from Medicos where Id= {cod}";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();
        }

        //LECTURA DE DATOS
        public override DataTable LlenarGrid()
        {
            //Abrir la conexion
            con.Open();
            //Texto del comando
            string lineaComando = "select * from Medicos";
            //Establecer el comando
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();

            //Adaptamos los datos
            SqlDataAdapter data = new SqlDataAdapter(comando);

            //Crear la tabla en la memoria
            DataTable tabla = new DataTable();

            //Llenar el datatable
            data.Fill(tabla);

            //Cerrar la conexion
            con.Close();

            return tabla;
        }
    }
}
