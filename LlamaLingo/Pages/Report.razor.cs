using LlamaLingo.Data;
using Microsoft.JSInterop;

namespace LlamaLingo.Pages
{
    public partial class Report
    {
        // ReportDesigner options
        BoldReportDesignerOptions designerOptions = new BoldReportDesignerOptions();

        // Used to render the Bold Report Designer component in Blazor page.
        public async void RenderReportDesigner()
        {
            designerOptions.ServiceURL = "/api/BoldReportsAPI";
            await JSRuntime.InvokeVoidAsync("BoldReports.RenderDesigner", "designer", designerOptions);
        }
        // Initial rendering of Bold Report Designer
        protected override void OnAfterRender(bool firstRender)
        {
            RenderReportDesigner();
        }
    }
}