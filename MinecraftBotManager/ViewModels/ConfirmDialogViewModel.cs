using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MinecraftBotManager.ViewModels
{
    public sealed partial class ConfirmDialogViewModel :ObservableObject
    {
        [ICommand]
        private void Ok()
        {
            DialogResult = true;            
        }
        [ICommand]
        private void Cancel()
        {
            DialogResult = false;
        }

        private bool? dialogResult;

        public bool? DialogResult
        {
            get => dialogResult;
            set => SetProperty(ref dialogResult, value);
        }

    }
}
