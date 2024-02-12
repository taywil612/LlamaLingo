using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using LlamaLingo.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;
using System.Linq;

namespace LlamaLingo.Pages
{
    public partial class Page_Element
    {
		//[Parameter]
		//[SupplyParameterFromQuery]
		//public int? pod { get; set; }

		//[Parameter]
		//[SupplyParameterFromQuery]
		//public int? pid { get; set; }

		private readonly string sqlServerconnectionString = "Server=tcp:llamalingo.database.windows.net,1433;Initial Catalog=LlamaLingoDB;Persist Security Info=False;User ID=LlamaLingoLogin;Password=UMDLlamaLingo4444;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public bool showCreate = false;
        public bool showModify = false;
        public bool showDelete = false;
        public bool showList = false;
        public string table = "";
        public int DDCounter = 0;
        
        private List<Element> elements;
        private Element currentElement = new Element();
        private string _selectedFilter = "****"; // user filter selection

        private List<Pype> pypes = new List<Pype>(); // Declare a private list of Pype objects
        private List<Element> elementsDelete = new List<Element>(); // Declare a private list of Element objects

        public string selectedFilter
        {
            get
            {
                return _selectedFilter;
            }

            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    Read();
                }
            }
        }

        private int _selectedElement = 1; // user filter selection
        public int selectedElement
		{
            get
            {
                return _selectedElement;
            }

            set
            {
                if (_selectedElement != value)
                {
					_selectedElement = value;
                    AutoFill();
                }
            }
        }

        private void ShowList()
        {
            if (showList == false)
            {
                showModify = false;
                showDelete = false;
                showList = true;
                showCreate = false;
            }
            else
            {
                showList = false;
            }
        }

        private void ShowCreate()
        {
            if (showCreate == false)
            {
                showModify = false;
                showDelete = false;
                showList = false;
                showCreate = true;
            }
            else
            {
                showCreate = false;
            }
        }

        private void ShowModify()
        {
            if (showModify == false)
            {
                showCreate = false;
                showDelete = false;
                showList = false;
                showModify = true;
            }
            else
            {
                showModify = false;
            }
        }

        private void ShowDelete()
        {
            if (showDelete == false)
            {
                showCreate = false;
                showModify = false;
                showList = false;
                showDelete = true;
            }
            else
            {
                showDelete = false;
            }
        }

        private void OnCreate()
        {
            Create();
            Read();
            DeleteRead();
        }

        private void OnChange()
        {
            Change();
            Read();
            DeleteRead();
        }

        private void OnDelete()
        {
            Delete();
            Read();
            DeleteRead();
        }

        private void AutoFill()
        {
            Element target = elements.Find(x => x.ElementId == selectedElement);
            currentElement.ElementLabel = target.ElementLabel;
			currentElement.ElementType = target.ElementType;
		}

        private void Read()
        {
			elements = db.Set<Element>().ToList();
		}

		private void Create()
        {
            db.Add(currentElement);
            db.SaveChanges();
            currentElement = new Element();
        }

        private void Change()
        {
			var data = db.Elements.Where(x => x.ElementId == selectedElement).SingleOrDefault();
            data.ElementLabel = currentElement.ElementLabel;
            data.ElementType = currentElement.ElementType;

			db.SaveChanges();

			currentElement = new Element();
		}

		private void Delete()
        {
			Element toDelete = db.Elements.Find(currentElement.ElementId);
			db.Elements.Remove(toDelete);
			db.SaveChanges();
		}

        private void DeleteRead()
        {
            //string spName = "dbo.VerbDeleteRead";
            //SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            //SqlCommand cmd = new SqlCommand(spName, connection);
            //SqlParameter param1 = new SqlParameter();
            //param1.ParameterName = "@PROC_filter";
            //param1.Value = selectedFilter;
            //SqlParameter param2 = new SqlParameter();
            //param2.ParameterName = "@pod";
            //param2.Value = pod;
            //cmd.Parameters.Add(param1);
            //cmd.Parameters.Add(param2);
            //connection.Open();
            //cmd.CommandType = CommandType.StoredProcedure;
            ////execute the stored procedure
            //cmd.ExecuteNonQuery();
            //SqlDataReader reader = cmd.ExecuteReader();
            //verbsDelete.Clear();
            //while (reader.Read())
            //{
            //    verbsDelete.Add(new Verb { VerbId = reader.GetInt32(0), VerbLabel = reader.GetString(1), VerbDescription = reader.GetString(2), VerbType = reader.GetString(3), VerbStatus = reader.GetString(4), PodIdFk = reader.GetInt32(5), UrlIdPk = reader.GetInt32(6) });
            //}
        }

        private void PypeRead()
        {
            //string spName = "dbo.sp_Pype_Type_Locked";
            //SqlConnection connection = new SqlConnection(sqlServerconnectionString);
            //SqlCommand cmd = new SqlCommand(spName, connection);
            //SqlParameter param1 = new SqlParameter();
            //param1.ParameterName = "@PROC_Input_Filter";
            //param1.Value = "VERB";
            //SqlParameter param2 = new SqlParameter();
            //param2.ParameterName = "@pod";
            //param2.Value = pod;
            //cmd.Parameters.Add(param1);
            //cmd.Parameters.Add(param2);
            //connection.Open();
            //cmd.CommandType = CommandType.StoredProcedure;
            ////execute the stored procedure
            //cmd.ExecuteNonQuery();
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    pypes.Add(new Pype { PypeId = reader.GetString(0), PypeType = reader.GetString(1), PypeLabel = reader.GetString(2), PypeStatus = reader.GetString(3), PypeDesc = reader.GetString(4), PypeLink = reader.GetString(5), });
            //}
        }

        protected override void OnInitialized() // Override the OnInitialized method
        {
            Read();
            //PypeRead();
            //DeleteRead();
        }
    }
}