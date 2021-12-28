using System;

namespace MinecraftLibrary.Interfaces
{
    public interface IMainViewModelController
    {
        void Notifi(string content,NotifiType type);
        Guid CreateBackGroundTask(string name,int value=0,int maxvalue=100);
        void UpdateTask(Guid id, int value);
        void RemoveTask(Guid id);
    }
    
}
