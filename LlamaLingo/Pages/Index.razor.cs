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
        private bool RoleSet { get; set; } = false;

        protected override void OnInitialized()
        {
            try
            {
                switch (SelectedInfo.CurrentPerson?.PersonRole)
                {
                    case "admn":
                        Page = "/Administration";
                        RoleSet = true;
                        break;
                    case "engr":
                        Page = "/Engineer";
						RoleSet = true;
						break;
                    case "xprt":
                        Page = "/Expert";
						RoleSet = true;
						break;
                    case "user":
                        Page = "/User";
						RoleSet = true;
						break;
                    case "acad":
                        Page = "/Academy";
						RoleSet = true;
						break;
                    case "nnai":
                        Page = "/Nnet";
						RoleSet = true;
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