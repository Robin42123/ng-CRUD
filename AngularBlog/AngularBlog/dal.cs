using AngularBlog;
using System.Data.SqlClient;

namespace AngularBlog
{
	public class dal
	{
		private readonly string _Connection;

		public dal(IConfiguration configuration)
		{
			_Connection = configuration.GetConnectionString("TempConnection");
		}

		public List<Students> GetAll()
		{
			List<Students> students = new List<Students>();

			string Sql = "Select * from Students";

			using (SqlConnection con = new SqlConnection(_Connection))
			{
				con.Open();
				var cmd = new SqlCommand(Sql, con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					Students sd = new Students();
					sd.ID = Convert.ToInt32(rdr["ID"]);
					sd.Name = Convert.ToString(rdr["Name"]);
					sd.Class = Convert.ToString(rdr["Class"]);

					students.Add(sd);
				}
			}

			return students;

		}
		public Students GetbyId(int ID)
		{
			Students sd = new Students();

			string Sql = "Select * from Students where ID = @ID";

			using (SqlConnection con = new SqlConnection(_Connection))
			{
				con.Open();
				var cmd = new SqlCommand(Sql, con);
				cmd.Parameters.AddWithValue("@ID", ID);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					sd.ID = Convert.ToInt32(rdr["ID"]);
					sd.Name = Convert.ToString(rdr["Name"]);
					sd.Class = Convert.ToString(rdr["Class"]);

				}
			}

			return sd;
		}

		public bool AddEditUpdte(Students Sd)
		{
			bool saved = false;
			string Sql = @"If Exists(Select * from Students where ID = @ID)
							BEGIN
								UPDATE Students SET NAME = @NAME, CLASS = @CLASS WHERE ID = @ID
							END
							ELSE
							BEGIN
								INSERT INTO STUDENTS (NAME,CLASS) VALUES (@NAME, @CLASS)
							END";
			using (SqlConnection CON = new SqlConnection(_Connection))
			{
				CON.Open();
				SqlCommand cmd = new SqlCommand(Sql, CON);
				cmd.Parameters.AddWithValue("@ID", Sd.ID);
				cmd.Parameters.AddWithValue("@NAME", Sd.Name);
				cmd.Parameters.AddWithValue("@CLASS", Sd.Class);

				saved = cmd.ExecuteNonQuery() > 0;
			}

			return saved;
		}
		public List<Students> GetAllDropdown()
		{
			List<Students> students = new List<Students>();

			string Sql = "Select DropName from StudentsDropdown";

			using (SqlConnection con = new SqlConnection(_Connection))
			{
				con.Open();
				var cmd = new SqlCommand(Sql, con);
				SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					Students sd = new Students();

					sd.DropDownNAme = Convert.ToString(rdr["DropName"]);


					students.Add(sd);
				}
			}

			return students;

		}
		public bool DeleteStudent(int ID)
		{
			bool saved = false;
			string Sql = @"Delete from  Students WHERE ID = @ID";
			using (SqlConnection CON = new SqlConnection(_Connection))
			{
				CON.Open();
				SqlCommand cmd = new SqlCommand(Sql, CON);
				cmd.Parameters.AddWithValue("@ID", ID);

				saved = cmd.ExecuteNonQuery() > 0;
			}

			return saved;
		}
	}
}
