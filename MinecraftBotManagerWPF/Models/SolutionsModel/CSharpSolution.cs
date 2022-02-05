using Microsoft.Build.Evaluation;
using MinecraftBotManager.CustomControls.FileProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace MinecraftBotManager.Models.SolutionsModel
{
    public class CSharpSolution : SolutionItem
    {
        

        static readonly string RootDirectory = Directory.GetCurrentDirectory() + @"\Data\SourceCodes\CSharp";
        static readonly string ProjPath = Path.Combine(RootDirectory,"CSModules", "CSModules.csproj");
        public CSharpSolution() : base(RootDirectory, scanning: true)
        {
            

            if (!Directory.Exists(FullPath))
                Directory.CreateDirectory(FullPath);
           
            Info = new DirectoryInfo(FullPath);


        }
        
        public override void Compile(ObservableCollection<string> Console)
        {

        }



    }


}
