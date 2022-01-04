using MinecraftBotManager.CustomControls.FileProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Interfaces
{
    public interface ICreateElementVisitor
    {
        void CreateFile(SolutionItem solutionItem);
        void CreateFile(DirectoryInfoVM directory);
        void CreateFolder(SolutionItem solutionItem);
        void CreateFolder(DirectoryInfoVM directoryItem);
    }
}
