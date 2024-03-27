using BoldReports.RDL.DOM;
using LlamaLingo.Models;
using LlamaLingo.Shared;
using Microsoft.AspNetCore.Components;
using System;

namespace LlamaLingo.Pages
{
    public partial class Index

    {
#nullable enable

        private string? Page { get; set; }

        
        [Parameter]
        [SupplyParameterFromQuery]
        public int? pod { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public int? pid { get; set; }

        protected override void OnInitialized()
        {
            try
            {
                switch (SelectedInfo.CurrentPerson?.PersonRole)
                {
                    case "admn":
                        Page = "/Administration";
                        break;
                    case "engr":
                        Page = "/Engineer";
                        break;
                    case "xprt":
                        Page = "/Expert";
                        break;
                    case "user":
                        Page = "/User";
                        break;
                    case "acad":
                        Page = "/Academy";
                        break;
                    case "nnai":
                        Page = "/Nnet";
                        break;
                    default:
                        Page = "/";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
	}
}