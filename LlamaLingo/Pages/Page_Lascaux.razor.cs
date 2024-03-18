using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LlamaLingo.Pages
{
	public partial class Page_Lascaux
	{
#nullable enable

		[Parameter]
		[SupplyParameterFromQuery]
		public int? pod { get; set; }
		[Parameter]
		[SupplyParameterFromQuery]
		public string? filterType { get; set; }
		[Parameter]
		[SupplyParameterFromQuery]
		public int? id { get; set; }
		[Parameter]
		[SupplyParameterFromQuery]
		public int? pid { get; set; }
		[Parameter]
		[SupplyParameterFromQuery]
		public string? prevPage { get; set; }
		private List<NovaLascaux> novas = new List<NovaLascaux>();
		public NovaLascaux novaLasc = new NovaLascaux();



		private readonly string sqlServerconnectionString = "Server=tcp:llamalingo.database.windows.net,1433;Initial Catalog=LlamaLingoDB;Persist Security Info=False;User ID=LlamaLingoLogin;Password=UMDLlamaLingo4444;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


		private int _selectedId = 1; // user filter selection


		public int selectedId
		{
			get { return _selectedId; }
			set
			{
				if (_selectedId != value)
				{
					_selectedId = value;
					setNovaLasc();
				}
			}
		}

		private void setNovaLasc()
		{
			if (filterType != "Nova")
			{
				novaLasc = novas.Find(x => x.NovaId == selectedId);
			}
			else
			{
				SingleNovaRead();
			}
		}

		private void GoToNextNova()
		{
			int curIndex = novas.FindIndex(x => x == novaLasc);
			if (curIndex < novas.Count() - 1)
			{
				selectedId = novas[curIndex + 1].NovaId;
			}
		}

		private void GoToPreviousNova()
		{
			int curIndex = novas.FindIndex(x => x == novaLasc);
			if (curIndex > 0)
			{
				selectedId = novas[curIndex - 1].NovaId;
			}
		}

		//*******************************************************************************
		//**************************** READ POD .dbo ************************************
		//*******************************************************************************

		private void Read()
		{
			SqlConnection connection = new SqlConnection(sqlServerconnectionString);
			SqlCommand cmd = new SqlCommand("[dbo].[Nova_Lascaux_Read]", connection);

			SqlParameter param1 = new SqlParameter();
			param1.ParameterName = "@pod";
			param1.Value = pod;

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@filterType";
			param2.Value = filterType;

			SqlParameter param3 = new SqlParameter();
			param3.ParameterName = "@id";
			param3.Value = id;

			cmd.Parameters.Add(param1);
			cmd.Parameters.Add(param2);
			cmd.Parameters.Add(param3);

			connection.Open();
			cmd.CommandType = CommandType.StoredProcedure;

			//execute the stored procedure
			cmd.ExecuteNonQuery();
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				novas.Add(new NovaLascaux
				{
					NovaId = reader.GetInt32(0),
					NovaSubjectLabel = reader.GetString(1),
					NovaActionLabel = reader.GetString(2),
					NovaObjectLabel = reader.GetString(3),
					SubjectURL = reader.GetString(4).Trim(),
					ActionURL = reader.GetString(5).Trim(),
					ObjectURL = reader.GetString(6).Trim()
				});
			}
		}


		//*******************************************************************************
		//**************************** Next NOVA .dbo ************************************
		//*******************************************************************************


		private void SingleNovaRead()
		{
			SqlConnection connection = new SqlConnection(sqlServerconnectionString);
			SqlCommand cmd = new SqlCommand("[dbo].[Nova_Lascaux_Read]", connection);

			SqlParameter param1 = new SqlParameter();
			param1.ParameterName = "@pod";
			param1.Value = pod;

			SqlParameter param2 = new SqlParameter();
			param2.ParameterName = "@filterType";
			param2.Value = filterType;

			SqlParameter param3 = new SqlParameter();
			param3.ParameterName = "@id";
			param3.Value = id;

			cmd.Parameters.Add(param1);
			cmd.Parameters.Add(param2);
			cmd.Parameters.Add(param3);

			connection.Open();
			cmd.CommandType = CommandType.StoredProcedure;

			//execute the stored procedure
			cmd.ExecuteNonQuery();
			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				novaLasc = new NovaLascaux
				{
					NovaId = reader.GetInt32(0),
					NovaSubjectLabel = reader.GetString(1),
					NovaActionLabel = reader.GetString(2),
					NovaObjectLabel = reader.GetString(3),
					SubjectURL = reader.GetString(4).Trim(),
					ActionURL = reader.GetString(5).Trim(),
					ObjectURL = reader.GetString(6).Trim()
				};
			}
		}

		//*******************************************************************************
		//**************************** Initialize NOVA **********************************
		//*******************************************************************************


		protected override void OnInitialized()   // Override the OnInitialized method
		{
			if (filterType != "Nova")
			{
				Read();
				if (novas.Any())
				{
					selectedId = novas[0].NovaId;
				}
			}
			else
			{
				setNovaLasc();
			}
		}
	}
	//testing
	public class NovaLascaux
	{
		public int NovaId { get; set; }
		public string NovaSubjectLabel { get; set; }
		public string NovaActionLabel { get; set; }
		public string NovaObjectLabel { get; set; }
		public string SubjectURL { get; set; }
		public string ActionURL { get; set; }
		public string ObjectURL { get; set; }
	}
}