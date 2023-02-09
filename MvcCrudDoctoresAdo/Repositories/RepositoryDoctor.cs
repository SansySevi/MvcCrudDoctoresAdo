using MvcCrudDoctoresAdo.Models;
using System.Data;
using System.Data.SqlClient;

namespace MvcCrudDoctoresAdo.Repositories
{
    public class RepositoryDoctor
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctor()
        {
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2022";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM V_DOCTORES_HOSPITAL";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doc = new Doctor();
                doc.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doc.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doc.Apellido = this.reader["APELLIDO"].ToString();
                doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doc.Salario = int.Parse(this.reader["SALARIO"].ToString());
                doc.NombreHospital = this.reader["HOSPITAL_NOM"].ToString();
                doctores.Add(doc);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }

        public Doctor FindDoctor(int idDoctor)
        {
            string sql = "SELECT * FROM V_DOCTORES_HOSPITAL WHERE DOCTOR_NO=@IDDOCTOR";
            SqlParameter pamiddoctor = new SqlParameter("@IDDOCTOR", idDoctor);
            this.com.Parameters.Add(pamiddoctor);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();

            Doctor doc = new Doctor();
            doc.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            doc.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
            doc.Apellido = this.reader["APELLIDO"].ToString();
            doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
            doc.Salario = int.Parse(this.reader["SALARIO"].ToString());
            doc.NombreHospital = this.reader["HOSPITAL_NOM"].ToString();

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doc;

        }

        public void InsertDoc(int idHospital, int idDoctor, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (@IDHOSPITAL, @IDDOCTOR, @APELLIDO, @ESPECIALIDAD, @SALARIO)";
            SqlParameter pamidhospital = new SqlParameter("@IDHOSPITAL", idHospital);
            SqlParameter pamiddoctor = new SqlParameter("@IDDOCTOR", idDoctor);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamidhospital);
            this.com.Parameters.Add(pamiddoctor);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateDoc(int idHospital, int idDoctor, string apellido, string especialidad, int salario)
        {
            string sql = "UPDATE DOCTOR SET APELLIDO=@APELLIDO, ESPECIALIDAD= @ESPECIALIDAD, SALARIO= @SALARIO, HOSPITAL_COD=@IDHOSPITAL WHERE DOCTOR_NO=@IDDOCTOR";
            SqlParameter pamidhospital = new SqlParameter("@IDHOSPITAL", idHospital);
            SqlParameter pamiddoctor = new SqlParameter("@IDDOCTOR", idDoctor);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamidhospital);
            this.com.Parameters.Add(pamiddoctor);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteDoc(int idDoctor)
        {
            string sql = "DELETE FROM DOCTOR WHERE  DOCTOR_NO=@IDDOCTOR";
            SqlParameter pamiddoctor = new SqlParameter("@IDDOCTOR", idDoctor);
            this.com.Parameters.Add(pamiddoctor);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public List<Hospital> GetHospitales()
        {
            string sql = "SELECT * FROM HOSPITAL";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hospital);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

    }


}
