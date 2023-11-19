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

        // Open and close the navigation sidebar.
        public void ToggleNavMenu()
        {
            SidebarToggle = !SidebarToggle;
        }

        // Open and close the chat sidebar.
        public void ToggleChatMenu()
        {
            ChatbarToggle = !ChatbarToggle;
        }
    }
}