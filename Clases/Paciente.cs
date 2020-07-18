using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Clases
{
    public class Paciente:Persona
    {
        //Atributos
        string direccion;

        //Propiedades
        public int Id { get => id; set => id = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        //Conexion y metodos
        SqlConnection con = new SqlConnection("Data Source=LATITUDE-PC;Initial Catalog=ProyectoFinal;Integrated Security=True");

        SqlCommand comando;

        //1- INSERSION DE DATOS
        public void Guardar(int cod, string ced, string nom, string tel, string mail, string dir)
        {
            
                //Abrir la conexion
                con.Open();
                //Estableciendo el comando
                string lineaComando = $"insert into Pacientes values ({cod},'{ced}','{nom}','{tel}','{mail}','{dir}')";
                comando = new SqlCommand(lineaComando, con);
                //Ejecutar el comando
                comando.ExecuteNonQuery();
                //Cerrar la conexion
                con.Close();
            
        }

        //2- ACTUALIZACION DE DATOS
        public void Actualizar(int cod, string ced, string nom, string tel, string mail, string dir)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"update Pacientes set Cédula='{ced}', Nombre='{nom}', Teléfono='{tel}', Email= '{mail}', Dirección= '{dir}' where Id = {cod}";
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
            string lineaComando = $"delete from Pacientes where Id= {cod}";
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
            string lineaComando = "select * from Pacientes";
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
