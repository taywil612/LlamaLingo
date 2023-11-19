using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using LlamaLingo;
using LlamaLingo.Shared;
using Syncfusion.Blazor;
using LlamaLingo.Models;
using Syncfusion.Blazor.Gantt;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Buttons;
using Syncfusion.Blazor.Navigations;

namespace LlamaLingo.Shared
{
    public partial class MainLayout
    {
        #nullable enable
        #if NETCOREAPP3_1 || NETSTANDARD2_1
            SfSidebar Sidebar;
            SfSidebar Chat; 
        #else
        SfSidebar? Sidebar;
        SfSidebar? Chat;
        #endif

        private bool SidebarToggle { get; set; } = false;
        private bool ChatbarToggle { get; set; } = false;

        //Open and close the navigation sidebar.
        public void ToggleNavMenu()
        {
            SidebarToggle = !SidebarToggle;
        }

        //Open and close the chat sidebar.
        public void ToggleChatMenu()
        {
            ChatbarToggle = !ChatbarToggle;
        }
    }
}