

using LlamaLingo.Models;

namespace LlamaLingo.Pages
{
    public partial class PDF_Viewer
    {
		private bool IsLoading { get; set; } = true;

        //Insturction manual for no pod# (default)
         private string DocumentPathDefault { get; set; } 

        //Instruction manual for main pods #4 & #5
        private string DocumentPath { get; set; } 
        //Instruction manual for Pod#1
        private string DocumentPath1 { get; set; } 

        //Instruction manual for Pod#2
        private string DocumentPath2 { get; set; } 

        //Instruction manual for Pod#3
        private string DocumentPath3 { get; set; }

        //Instruction manual for Pod#6
        private string DocumentPath6 { get; set; } 

        //Instruction manual for Pod#15
        private string DocumentPath15 { get; set; } 


    }


}