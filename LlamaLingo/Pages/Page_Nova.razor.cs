using LlamaLingo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LlamaLingo.Pages
{
	public partial class Page_Nova
	{
		[Parameter]
		[SupplyParameterFromQuery]
		public int? pod { get; set; }
		[Parameter]
		[SupplyParameterFromQuery]
		public int? pid { get; set; }

        private static readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
        private readonly string sqlServerconnectionString = config.GetConnectionString("DatabaseConnection");
        
		public int id = 0;
		public string description = "Description of Nova";
		public string type = "test";
		public int subject = 0;
		public int action = 0;
		public int obj = 0;

		private List<Pype>
		pypes;  // Declare a private list of Pype objects
		private List<Nova>
			novas;  // Declare a private list of NOVA objects
		private List<Noun>
			subjects;  // Declare a private list of Noun objects
		private List<Verb>
			actions;  // Declare a private list of Verb objects
		private List<Noun>
			objects;  // Declare a private list of Noun objects
		private string _subjectFilter = "****"; // user filter selection
		public string subjectFilter
		{
			get { return _subjectFilter; }
			set
			{
				if (_subjectFilter != value)
				{
					_subjectFilter = value;
					Read("CRUD_Noun", "Subject");
				}
			}
		}
		private string _actionFilter = "****"; // user filter selection
		public string actionFilter
		{
			get { return _actionFilter; }
			set
			{
				if (_actionFilter != value)
				{
					_actionFilter = value;
					Read("CRUD_Verb", "Action");
				}
			}
		}
		private string _objectFilter = "****"; // user filter selection
		public string objectFilter
		{
			get { return _objectFilter; }
			set
			{
				if (_objectFilter != value)
				{
					_objectFilter = value;
					Read("CRUD_Noun", "Object");
				}
			}
		}

		private void OnCreate()
		{
			Create("NOVACRUD");
			//Read("NOVACRUD");
		}


		/************************ Stored Procedure *********************/
		/************************ Stored Procedure *********************/
		/************************ Stored Procedure *********************/



		private void Read(string storedProcedure, string TypePype)
		{
			var selectedFilter = TypePype == "Subject" ? subjectFilter : TypePype == "Action" ? actionFilter : TypePype == "Object" ? objectFilter : "Error";
			string spName = "dbo.[" + storedProcedure + "]";

			SqlConnection connection = new SqlConnection(sqlServerconnectionString);
			SqlCommand cmd = new SqlCommand(spName, connection);

			SqlParameter param1 = new SqlParameter();
			param1.ParameterName = "@PROC_filter";
			param1.Value = selectedFilter;

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@PROC_action";
			param2.Value = "Read";

			SqlParameter param3 = new SqlParameter();
			param3.ParameterName = "@pod";
			param3.Value = pod;


			cmd.Parameters.Add(param1);
			cmd.Parameters.Add(param2);
			cmd.Parameters.Add(param3);

			connection.Open();
			cmd.CommandType = CommandType.StoredProcedure;

			/****************************************************************/
			/********************* Subject Action Object ********************/
			/****************************************************************/



			cmd.ExecuteNonQuery();
			SqlDataReader reader = cmd.ExecuteReader();

			if (TypePype == "Subject")
			{
				subjects.Clear();
				while (reader.Read())
				{
					subjects.Add(new Noun
					{
						NounId = reader.GetInt32(0),
						NounLabel = reader.GetString(1),
						NounDescription = reader.GetString(2),
						NounType = reader.GetString(3),
					});
				}
			}
			else if (TypePype == "Action")
			{
				actions.Clear();
				while (reader.Read())
				{
					actions.Add(new Verb
					{
						VerbId = reader.GetInt32(0),
						VerbLabel = reader.GetString(1),
						VerbDescription = reader.GetString(2),
						VerbType = reader.GetString(3),
					});
				}
			}
			else if (TypePype == "Object")
			{
				objects.Clear();
				while (reader.Read())
				{
					objects.Add(new Noun
					{
						NounId = reader.GetInt32(0),
						NounLabel = reader.GetString(1),
						NounDescription = reader.GetString(2),
						NounType = reader.GetString(3),
					});
				}
			}
		}


		/************************ Stored Procedure *********************/
		/************************ Stored Procedure *********************/
		/************************ Stored Procedure *********************/

		private void Create(string storedProcedure)
		{
			string spName = "dbo.[" + storedProcedure + "]";

			SqlConnection connection = new SqlConnection(sqlServerconnectionString);
			SqlCommand cmd = new SqlCommand(spName, connection);

			SqlParameter param1 = new SqlParameter();
			SqlParameter param5 = new SqlParameter();
			SqlParameter param6 = new SqlParameter();
			param1.ParameterName = "@subject";
			param1.Value = subject;

			param5.ParameterName = "@action";
			param5.Value = action;

			param6.ParameterName = "@object";
			param6.Value = obj;

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@desc";
			param2.Value = description;

			SqlParameter param3 = new SqlParameter();
			param3.ParameterName = "@type";
			param3.Value = type;

			SqlParameter param4 = new SqlParameter();
			param4.ParameterName = "@PROC_action";
			param4.Value = "Create";

			cmd.Parameters.Add(param1);
			cmd.Parameters.Add(param2);
			cmd.Parameters.Add(param3);
			cmd.Parameters.Add(param4);
			cmd.Parameters.Add(param5);
			cmd.Parameters.Add(param6);

			connection.Open();
			cmd.CommandType = CommandType.StoredProcedure;

			//execute the stored procedure
			cmd.ExecuteNonQuery();
			description = ""; // clear out input
			type = ""; // clear out input
			subject = 0;
			action = 0;
			obj = 0;
		}

		/************************ Stored Procedure *********************/
		/************************ Stored Procedure *********************/
		/************************ Stored Procedure *********************/

		private void Change(string storedProcedure)
		{
			string spName = "dbo.[" + storedProcedure + "]";

			SqlConnection connection = new SqlConnection(sqlServerconnectionString);
			SqlCommand cmd = new SqlCommand(spName, connection);

			SqlParameter param1 = new SqlParameter();
			SqlParameter param5 = new SqlParameter();
			SqlParameter param6 = new SqlParameter();
			param1.ParameterName = "@subject";
			param1.Value = subject;

			param5.ParameterName = "@action";
			param5.Value = action;

			param6.ParameterName = "@object";
			param6.Value = obj;

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@desc";
			param2.Value = description;

			SqlParameter param3 = new SqlParameter();
			param3.ParameterName = "@id";
			param3.Value = id;

			SqlParameter param4 = new SqlParameter();
			param4.ParameterName = "@PROC_action";
			param4.Value = "Update";

			cmd.Parameters.Add(param1);
			cmd.Parameters.Add(param2);
			cmd.Parameters.Add(param3);
			cmd.Parameters.Add(param4);
			if (storedProcedure == "NOVA")
			{
				cmd.Parameters.Add(param5);
				cmd.Parameters.Add(param6);
			}

			connection.Open();
			cmd.CommandType = CommandType.StoredProcedure;

			//execute the stored procedure
			cmd.ExecuteNonQuery();
			description = ""; // clear out input
			id = 0; // clear out input
			subject = 0;
			action = 0;
			obj = 0;
		}

		private void Delete(string storedProcedure)
		{
			string spName = "dbo.[" + storedProcedure + "]";

			SqlConnection connection = new SqlConnection(sqlServerconnectionString);
			SqlCommand cmd = new SqlCommand(spName, connection);

			SqlParameter param1 = new SqlParameter();
			param1.ParameterName = "@id";
			param1.Value = id;

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@PROC_action";
			param2.Value = "Delete";

			cmd.Parameters.Add(param1);
			cmd.Parameters.Add(param2);

			connection.Open();
			cmd.CommandType = CommandType.StoredProcedure;

			//execute the stored procedure
			cmd.ExecuteNonQuery();

		}


		protected override void OnInitialized()   // Override the OnInitialized method
		{
			novas = db.Novas.ToList();
			pypes = db.Pypes.ToList();

			subjects = db.Nouns.ToList();
			actions = db.Verbs.ToList();
			objects = db.Nouns.ToList();

			Read("CRUD_Noun", "Subject");
			Read("CRUD_Verb", "Action");
			Read("CRUD_Noun", "Object");
		}

	}
}