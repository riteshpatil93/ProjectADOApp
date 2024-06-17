using CrudAppUsingADO1.Models;
using System.Data.SqlClient;

namespace CrudAppUsingADO1
{
    public class PatientDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        public List<Patient> getAllPatient()
        {
            List<Patient> patientsList = new List<Patient>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPatient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient pt = new Patient();

                    pt.Id = Convert.ToInt32(reader["Id"]);
                    pt.FullName = reader["FullName"].ToString() ??"";
                    pt.AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"]);
                    pt.Mobile = reader["Mobile"].ToString() ?? "";
                    pt.PatientAddress = reader["PatientAddress"].ToString() ?? "";
                    patientsList.Add(pt);
                }
            }

            return patientsList;
        }

        public void AddPatient(Patient pt)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddPatient", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FullName", pt.FullName);
                cmd.Parameters.AddWithValue("@AdmissionDate", pt.AdmissionDate);
                cmd.Parameters.AddWithValue("@Mobile", pt.Mobile);
                cmd.Parameters.AddWithValue("@PatientAddress", pt.PatientAddress);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public Patient getPatientById(int? id)
        {
            Patient pt = new Patient();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Patient where Id = @id", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                    pt.Id = Convert.ToInt32(reader["Id"]);
                    pt.FullName = reader["FullName"].ToString() ?? "";
                    pt.AdmissionDate = Convert.ToDateTime(reader["AdmissionDate"]);
                    pt.Mobile = reader["Mobile"].ToString() ?? "";
                    pt.PatientAddress = reader["PatientAddress"].ToString() ?? "";
                   
                }
                
            }
            return pt;
        }
    }
}
