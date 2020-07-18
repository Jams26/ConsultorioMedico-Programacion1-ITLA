using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Proyecto_Final
{
    public class Datos
    {
        //Conexion y metodos 
        SqlConnection con = new SqlConnection("Data Source=LATITUDE-PC;Initial Catalog=ProyectoFinal;Integrated Security=True");
        SqlCommand comando;
        DataSet dt;

        //PARA MODULO DE CLINICAS
        //1- INSERSION DE DATOS
        public void GuardarClinica(int cod, string nom, string dir)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"insert into Clínicas values ({cod},'{nom}','{dir}')";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();
        }
        //2- ACTUALIZACION DE DATOS
        public void ActualizarClinica(int cod, string nom, string dir)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"update Clínicas set Nombre='{nom}', Direccion='{dir}' where Id = {cod}";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();
        }
        //3- ELIMINACION DE DATOS
        public void EliminarClinica(int cod)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"delete from Clínicas where Id= {cod}";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();
        }
        //LECTURA DE DATOS
        public DataTable LlenarGridClinica()
        {
            //Abrir la conexion
            con.Open();
            //Texto del comando
            string lineaComando = "select * from Clínicas";
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

        //-----------------------------------------------------------------//
        //PARA MODULO CITA:
        public void GuardarCita(int cod, int idpac, int idmed, int idcli, string fec, string hor, string cau)
        {
            //Abrir la conexion
            con.Open();
            //Estableciendo el comando
            string lineaComando = $"insert into CitaMedica values ({cod},{idpac},{idmed},{idcli},'{fec}','{hor}','{cau}')";
            comando = new SqlCommand(lineaComando, con);
            //Ejecutar el comando
            comando.ExecuteNonQuery();
            //Cerrar la conexion
            con.Close();
        }
        public void ActualizarCita(int cod, int idpac, int idmed, int idcli, string fec, string hor, string cau)
        {
            con.Open();
            string lineaComando = $"Update CitaMedica set IdPaciente = {idpac}, IdMedico = {idmed}, IdClinica = {idcli}, Fecha = '{fec}', Hora = '{hor}', Causa = '{cau}' where Id = {cod}";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            con.Close();
        }
        public void EliminarCita(int cod)
        {
            con.Open();
            string lineaComando = $"delete from CitaMedica where Id = {cod}";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            con.Close();
        }
        public DataSet getId(string campo, string tabla, ComboBox txt)
        {
            con.Open();
            string lineaComando = $"select {campo} from {tabla} where Nombre = '{txt.Text}' ";
            SqlDataAdapter dp = new SqlDataAdapter(lineaComando, con);
            dt = new DataSet();
            dp.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LlenarGridCita()
        {
            con.Open();
            //Mostrar el registro con el nombre
            string lineaComando = $"select CitaMedica.Id, Pacientes.Nombre as Paciente, Medicos.Nombre as Medico, " +
              $"Clínicas.Nombre as Clínica, CitaMedica.Fecha, " +
              $"CitaMedica.Hora, CitaMedica.Causa from CitaMedica " +
              $"inner join Pacientes on Pacientes.Id = CitaMedica.IdPaciente " +
              $"inner join Medicos on Medicos.Id = CitaMedica.IdMedico " +
              $"inner join Clínicas on Clínicas.Id = CitaMedica.IdClinica";
            //Mostrar registro con el apellido
            //string lineaComando = $"select * from CitaMedica";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            con.Close();
            return tabla;

        }
        //---------------------------------------------------------------//
        //MODULO DE CONSULTAS:

        // CONSULTAR PACIENTE:
        public virtual DataTable ConsultarPacienteNombre(string pnombre)
        {
            //Abrir la conexion
            con.Open();
            //Texto del comando
            string lineaComando = $"select * from Pacientes where Nombre like '%{pnombre}%' ";
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
        public virtual DataTable ConsultarPacienteEmail(string mail)
        {
            con.Open();
            string lineaComando = $"select * from Pacientes where Email like '%{mail}%'";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            con.Close();
            return tabla;
        }
        public virtual DataTable ConsultarCitaNombre(string nom)
        {
            con.Open();
            string lineaComando = $"select CitaMedica.Id, Pacientes.Nombre as Paciente, " +
              $"Medicos.Nombre as Medico, Clínicas.Nombre as Clínica, CitaMedica.Fecha, " +
              $"CitaMedica.Hora, CitaMedica.Causa from CitaMedica " +
              $"inner join Pacientes on Pacientes.Id = CitaMedica.IdPaciente " +
              $"inner join Medicos on Medicos.Id = CitaMedica.IdMedico " +
              $"inner join Clínicas on Clínicas.Id = CitaMedica.IdClinica where Medicos.Nombre like '%{nom}%'";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            con.Close();
            return tabla;
        }
        public virtual DataTable ConsultarCitaExequatur(string exeq)
        {
            con.Open();
            string lineaComando = $"select CitaMedica.Id, Pacientes.Nombre as Paciente, " +
              $"Medicos.Exequátur as Exequatur, Clínicas.Nombre as Clínica, CitaMedica.Fecha, " +
              $"CitaMedica.Hora, CitaMedica.Causa from CitaMedica " +
              $"inner join Pacientes on Pacientes.Id = CitaMedica.IdPaciente " +
              $"inner join Medicos on Medicos.Id = CitaMedica.IdMedico " +
              $"inner join Clínicas on Clínicas.Id = CitaMedica.IdClinica where Medicos.Exequátur like '%{exeq}%'";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            con.Close();

            return tabla;
        }

        //CONSULTAR MEDICO
        public virtual DataTable ConsultarMedicoNombre(string nom)
        {
            con.Open();
            string lineaComando = $"select * from Medicos where Nombre like '%{nom}%'";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            con.Close();
            return tabla;
        }
        public virtual DataTable ConsultarMedicoExequatur(string exeq)
        {
            con.Open();
            string lineaComando = $"select * from Medicos where Exequátur like '%{exeq}%'";
            comando = new SqlCommand(lineaComando, con);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);
            con.Close();
            return tabla;
        }
    }
}
