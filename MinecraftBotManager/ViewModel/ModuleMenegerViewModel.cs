using GalaSoft.MvvmLight;
using MinecraftBotManager.Interfaces;
using MinecraftBotManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using System.Runtime.Serialization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MinecraftBotManager.CustomControls.FileProvider;
using MinecraftBotManager.Models.SolutionsModel;
using MinecraftLibrary.MinecraftModels;

namespace MinecraftBotManager.ViewModel
{
    public class ModuleMenegerViewModel : ViewModelBase
    {
        public const string DialogID = "RootDialogModuleManager";

        private ObservableCollection<string> emm = new ObservableCollection<string>();

        public ObservableCollection<string> ConsoleItems
        {
            get { return emm; }
            set
            {
                emm = value;
                RaisePropertyChanged();
            }
        }



        private ExplorerViewModel explorerView;

        public ExplorerViewModel ExplorerVM
        {
            get { return explorerView; }
            private set
            {
                explorerView = value;
                RaisePropertyChanged();
            }
        }


        private readonly ObservableCollection<TextDocumentWrap> documents = new ObservableCollection<TextDocumentWrap>();

        public ObservableCollection<TextDocumentWrap> Documents => documents;

        private readonly IDataService dataService;
        private readonly IStorageService storageService;



        public ModuleMenegerViewModel(IDataService dataservice, IStorageService storageService)
        {
            string dir = Directory.GetCurrentDirectory() + @"\DataBase\SourceCodes";

            ExplorerVM = new ExplorerViewModel(storageService);

            ExplorerVM.Solutions.Add(new CSharpSolution());

            dataService = dataservice;
            dataService.DocumentsCollectionChanged += DataService_DocumentsCollectionChanged;
            this.storageService = storageService;


            Task.Run(Load);
        }

        private void DataService_DocumentsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (TextDocumentWrap item in e.NewItems)
                    Documents.Add(item);
            if (e.OldItems != null)
                foreach (TextDocumentWrap item in e.OldItems)
                    Documents.Remove(item);
        }
        #region Команды
        private RelayCommand<object> close;

        public RelayCommand<object> CloseCommand
        {
            get => close ?? (close = new RelayCommand<object>(p =>
            {
                //Task.Run(Save);
            }));
        }


        private RelayCommand<object> createfile;

        public RelayCommand<object> CreateFileCommand
        {
            get => createfile ?? (createfile = new RelayCommand<object>(p =>
            {
                //dataService.AddDocument(new TextDocumentWrap() { SourceCode = new TextDocument() { Text = CreatePattern() } });
            }));
        }




        private RelayCommand<object> save;

        public RelayCommand<object> SaveCommand
        {
            get => save ?? (save = new RelayCommand<object>(p =>
            {
                //Task.Run(Save);
            }));
        }

        private RelayCommand<Item<FileInfo>> openfile;

        public RelayCommand<Item<FileInfo>> OpenFileCommand
        {
            get => openfile ?? (openfile = new RelayCommand<Item<FileInfo>>(file =>
            {
                if (file is FileInfoVM && Documents.FirstOrDefault(x => x.FullPath == file.FullPath) == null)
                    Documents.Add(new TextDocumentWrap((FileInfoVM)file));
            }));
        }

        private void Save()
        {
            try
            {
                Dictionary<string, string> pathCode = new Dictionary<string, string>();
                App.Current.Dispatcher.Invoke(() =>
                {
                    // pathCode = Documents.ToDictionary(k => k.FullPath, v => v.SourceCode.Text);
                });
                foreach (var document in pathCode)
                {
                    using (StreamWriter sw = new StreamWriter(document.Key))
                    {
                        sw.WriteLine(document.Value);
                    }
                }
                TextDocumentWrap[] openDocuments = Documents.ToArray();

                using (FileStream sw = new FileStream(@"DataBase\Documents.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(sw, openDocuments);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
        private void Load()
        {
            var getdocs = LoadDocuments().ToList();
            App.Current.Dispatcher.Invoke(() =>
            {
                foreach (TextDocumentWrap document in getdocs)
                {
                    Documents.Add(document);
                }
            });
        }
        private TextDocumentWrap[] LoadDocuments()
        {
            try
            {
                TextDocumentWrap[] result = Enumerable.Empty<TextDocumentWrap>().ToArray();
                using (FileStream sw = new FileStream(@"DataBase\Documents.dat", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    result = (TextDocumentWrap[])bin.Deserialize(sw);
                }
                return result;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
                return new TextDocumentWrap[0];
            }
        }

        private RelayCommand<object> build;

        public RelayCommand<object> BuildCommand
        {
            get => build ?? (build = new RelayCommand<object>(p =>
            {
                ConsoleItems.Clear();
                ConsoleItems.Add("Сборка начата...");
                Task.Run(() =>
                {
                    Save();
                    SyntaxTree[] codes = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Database\SourceCodes", "*.*", SearchOption.AllDirectories).Select(f => CSharpSyntaxTree.ParseText(ReadFile(f))).ToArray();



                    CSharpCompilation compilation = CSharpCompilation.Create("Module1",
                        codes,
                        new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                                    MetadataReference.CreateFromFile(typeof(MinecraftModule).Assembly.Location)},
                        new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                        );
                    using (FileStream fs = new FileStream(@"Database\Assemblys\NewModule.dll", FileMode.OpenOrCreate))
                    using (MemoryStream pdpstream = new MemoryStream())
                    {

                        var res = compilation.Emit(fs, pdpstream);
                        if (!res.Success)
                        {
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                ConsoleItems.Add("Ошибки: ");
                                foreach (var item in res.Diagnostics)
                                {
                                    ConsoleItems.Add(item.ToString());
                                }
                            });
                        }
                        else
                        {
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                ConsoleItems.Add("Сборка успешно!");
                            });

                        }
                    }

                });
            }));
        }

        public static string ReadFile(string path)
        {
            string res = "";
            using (StreamReader sr = new StreamReader(path))
            {
                res = sr.ReadToEnd();
            }
            return res;
        }
        #endregion

        /*
         * 
         */

        public static string CreatePattern()
        {
            return @"using System;
using MinecraftBotManager.Models;
using MinecraftBotManager.Interfaces;

namespace MinecraftBotManager.Modules 
{
    public class NewModule : MinecraftModule
    {
        public NewModule(BotObject bot, IDataService service) : base(bot,service)
        {
        }
    }
}";
        }
    }


}
