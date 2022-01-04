/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MinecraftBotManager"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MinecraftBotManager.Interfaces;
using MinecraftBotManager.Services;
using System;
using System.Reflection;

namespace MinecraftBotManager.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IDataService, DesignDataService>();

                
            }
            else
            {

                SimpleIoc.Default.Register<IDataService, DataService>();
                // Create run time view services and models
                SimpleIoc.Default.Register<IModulesService, ModulesService>();

                SimpleIoc.Default.Register<IStorageService, StorageService>();
                SimpleIoc.Default.Register<IXMLSerializeSettingsService, XMLService>();
                
            }
            SimpleIoc.Default.Register<IDialogService>(()=>new DialogService(App.Current.MainWindow));
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ModuleMenegerViewModel>();
            SimpleIoc.Default.Register<AddModuleVM>();
            
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public ModuleMenegerViewModel ModuleMeneger
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ModuleMenegerViewModel>(Guid.NewGuid().ToString());
            }
        }
        public IModulesService ModulesService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IModulesService>();
            }
        }
        public AddModuleVM AddModuleVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddModuleVM>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}