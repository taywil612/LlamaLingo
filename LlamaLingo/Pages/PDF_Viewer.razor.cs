

using LlamaLingo.Models;

namespace LlamaLingo.Pages
{
    public partial class PDF_Viewer
    {
		private bool IsLoading { get; set; } = true;

		//Insturction manual for no pod# (default)
		private string DocumentPathDefault { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions Manual_Default.pdf";

		//Instruction manual for main pods #4 & #5
		private string DocumentPath { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions Manual.pdf";
        //Instruction manual for Pod#1
        private string DocumentPath1 { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions ManualV1.pdf";

        //Instruction manual for Pod#2
        private string DocumentPath2 { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions ManualV2.pdf";

        //Instruction manual for Pod#3
        private string DocumentPath3 { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions ManualV3.pdf";

        //Instruction manual for Pod#6
        private string DocumentPath6 { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions ManualV6.pdf";

        //Instruction manual for Pod#15
        private string DocumentPath15 { get; set; } = "wwwroot/pdf/LlamaLingo Parsing Instructions ManualV15.pdf";
    }
}