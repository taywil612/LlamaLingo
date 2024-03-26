using LlamaLingo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LlamaLingo.Pages
{
	public partial class Index
    {
#nullable enable

        private string? Page {  get; set; }

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