using MinecraftBotManager.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MinecraftBotManager.Services;
using MinecraftBotManager.Interfaces;
using MinecraftBotManager.ViewModel;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.IO.Compression;
using System.IO;
using System.IO.Packaging;
using System.Windows.Threading;

namespace MinecraftBotManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        bool _show = false;
        public App()
        {
            LoadedWindow loadedWindow = new LoadedWindow();
            loadedWindow.ProgressBar1.Maximum = 2;
            loadedWindow.ProgressBar2.Value = 0;
            loadedWindow.TextProgress1.Text = "Загрузка ресурсов";
            loadedWindow.Show();            
            BackgroundWorker LoadJsonBocks = new BackgroundWorker();
            LoadJsonBocks.WorkerReportsProgress = true;
            SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(this.Dispatcher));
            LoadJsonBocks.DoWork += (s, e) =>
            {
                MinecraftLibrary.MinecraftProtocol.StaticData.Blocks3DModels.LoadData(LoadJsonBocks).Wait();
                e.Result = true;
            };
            LoadJsonBocks.ProgressChanged += (s, e) =>
            {
                var state = (MinecraftLibrary.MinecraftProtocol.StaticData.LoadState)e.UserState;
                switch (state.StateLoad)
                {
                    case MinecraftLibrary.MinecraftProtocol.StaticData.LoadState.State.Items:
                        if (loadedWindow.TextProgress1.Text != "Загрузка предметов")
                            loadedWindow.TextProgress1.Text = "Загрузка предметов";
                        loadedWindow.ProgressBar1.Value = 1;
                        break;

                }
                //Console.WriteLine(e.ProgressPercentage);
                loadedWindow.TextProgress2.Text = state.Description;
                loadedWindow.ProgressBar2.Value = e.ProgressPercentage;
            };

            LoadJsonBocks.RunWorkerCompleted += (s, e) =>
            {

                loadedWindow.ProgressBar1.Value = 2;
                loadedWindow.ProgressBar2.Value = 100;
                loadedWindow.TextProgress1.Text = "Загрузка завершена";
                loadedWindow.TextProgress2.Text = "Загрузка завершена";
                Task.Run(() =>
                Dispatcher.BeginInvoke(DispatcherPriority.DataBind, new Action(() =>
                {
                    MainWindow main = new MainWindow();
                    main.ContentRendered += (s1, e1) =>
                    {                        
                        loadedWindow.Close();                        
                    };
                    main.Show();
                })));
            };
            
            loadedWindow.ProgressBar2.Value = 0;
            loadedWindow.ProgressBar2.Maximum = 100;
            LoadJsonBocks.RunWorkerAsync();
            loadedWindow.TextProgress1.Text = "Загрузка блоков";
        }
        protected override void OnStartup(StartupEventArgs e)
        {

        }
    }
    public enum Stage
    {
        LoadJsonBlock,
        LoadJsonItems,
        Complete
    }
}
