using GalaSoft.MvvmLight;
using System;
using System.IO;
using System.Collections.ObjectModel;
using MinecraftBotManager.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Windows;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net;
using System.Windows.Data;
using NetMQ.Sockets;
using System.Diagnostics;
using System.Threading;
using MinecraftBotManager.Interfaces;
using Starksoft.Net.Proxy;
using MinecraftLibrary.MinecraftModels;
using System.Xml.Serialization;
using MinecraftLibrary.Interfaces;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace MinecraftBotManager.ViewModel
{

    public class MainViewModel : ViewModelBase, IMainViewModelController
    {

        public void Notifi(string content, MinecraftLibrary.Interfaces.NotifiType type)
        {
            Notifications.Add(new NotificationElement((Models.NotifiType)type, content));
        }

        public Guid CreateBackGroundTask(string name, int value = 0, int maxvalue = 100)
        {

            Guid id = Guid.NewGuid();
            if (value <= maxvalue && value >= 0)
            {
                BackgroundTasks.Add(new TaskVM(id, name, value, maxvalue));
            }
            return id;
        }

        public void UpdateTask(Guid id, int value)
        {
            TaskVM item = BackgroundTasks.FirstOrDefault(x => x.ID == id);
            if (item != null && value >= 0)
            {
                if (item.MaxValue <= value)
                {
                    item.Value = value;
                }
            }
        }

        public void RemoveTask(Guid id)
        {
            TaskVM item = BackgroundTasks.FirstOrDefault(x => x.ID == id);
            if (item != null)
            {
                BackgroundTasks.Remove(item);
            }
        }

        public ObservableCollection<NotificationElement> Notifications { get; private set; } = new ObservableCollection<NotificationElement>();


        public ObservableCollection<TaskVM> BackgroundTasks => new ObservableCollection<TaskVM>();



        private ViewModelBase curent;

        public ViewModelBase CurrentPage
        {
            get { return curent; }
            set
            {

                curent = value;
                RaisePropertyChanged();
            }
        }
        private readonly ControlCenterVM controlCenterVM;
        private readonly SettingsVM settingsVM;


        private readonly IDataService _dataservice;
        private readonly IModulesService modulesService;
        private readonly IDialogService dialogService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, IModulesService modulesService, IDialogService dialogService)
        {

            

            this.modulesService = modulesService;
            this.dialogService = dialogService;
            #region Генератор
            /*
            string code = "";


            using (StreamReader sr = new StreamReader(@"C:\Users\Пользователь\Desktop\Minecraft-Console-Client-master\MinecraftClient\McClient.cs"))
            {
                code = sr.ReadToEnd();

            }


            Regex regex = new Regex(@"DispatchBotEvent\(bot => bot\.(\w+)\(.+\);");
            List<Tuple<string, string>> methods = new List<Tuple<string, string>>();
            List<Tuple<string, ParameterInfo[]>> methodsWithParameters = new List<Tuple<string, ParameterInfo[]>>();
            string newcode = code;



            foreach (Match m in regex.Matches(code))
            {
                string parametrs = "";
                int i = 1;
                int j = m.Groups[1].Index + m.Groups[1].Value.Length + 1;
                while (i != 0 && j < code.Length)
                {
                    if (code[j] == '(')
                    {
                        i++;
                        parametrs += code[j];
                    }
                    else if (code[j] == ')')
                    {
                        i--;
                    }
                    else
                    {
                        parametrs += code[j];
                    }
                    j++;
                }
                newcode = newcode.Replace(m.Groups[0].Value, $"{m.Groups[0].Value}\n{m.Groups[1].Value}Changed?.Invoke(this, new {m.Groups[1].Value}EventArgs({parametrs}));");
                
                methods.Add(new Tuple<string, string>(m.Groups[1].Value, m.Groups[0].Value));
            }
            using (StreamWriter sw = new StreamWriter("newcode.txt"))
            {
                sw.WriteLine(newcode);
            }

            foreach (var method in typeof(ChatBot).GetMethods())
            {
                if (methods.Select(x => x.Item1).Contains(method.Name))
                {
                    methodsWithParameters.Add(new Tuple<string, ParameterInfo[]>(method.Name, method.GetParameters()));
                }
            }

            using (StreamWriter sw = new StreamWriter(@"methods.txt"))
            {
                Dictionary<string, List<Tuple<Type, string>>> methodsWithAllparam = new Dictionary<string, List<Tuple<Type, string>>>();
                CodeNamespace name = new CodeNamespace("EventArgsNameSpace");
                CodeTypeDeclaration mcclass = new CodeTypeDeclaration();
                mcclass.Attributes = MemberAttributes.Public;
                mcclass.Name = "EventClass";
                name.Types.Add(mcclass);
                var order = methodsWithParameters.GroupBy(x => x.Item1, x => x.Item2);
                foreach (var item in order)
                {
                    CodeTypeDelegate typeDelegate = new CodeTypeDelegate();
                    typeDelegate.Attributes = MemberAttributes.Public;
                    typeDelegate.Name = item.Key + "EventHandler";
                    typeDelegate.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "sender"));
                    typeDelegate.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference($"{item.Key}EventArgs"), "e"));
                    name.Types.Add(typeDelegate);
                    CodeMemberEvent memberEvent = new CodeMemberEvent();
                    memberEvent.Attributes = MemberAttributes.Public;
                    memberEvent.Type = new CodeTypeReference($"{item.Key}EventHandler");
                    memberEvent.Name = item.Key + "Changed";
                    mcclass.Members.Add(memberEvent);
                }
                foreach (var item in order)
                {
                    HashSet<string> properties = new HashSet<string>();
                    CodeTypeDeclaration EventargsClass = new CodeTypeDeclaration($"{item.Key}EventArgs");
                    EventargsClass.IsClass = true;
                    EventargsClass.TypeAttributes = TypeAttributes.Public;
                    foreach (var item1 in item)
                    {
                        CodeConstructor contruct = new CodeConstructor();
                        contruct.Attributes = MemberAttributes.Public;
                        foreach (var param in item1)
                        {
                            if (!properties.Contains(param.Name))
                            {
                                CodeMemberField field = new CodeMemberField();
                                field.Attributes = MemberAttributes.Private;
                                field.Name = $"_{param.Name}";
                                field.Type = new CodeTypeReference(param.ParameterType);

                                CodeMemberProperty property = new CodeMemberProperty();
                                
                                property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                                property.Type = new CodeTypeReference(param.ParameterType);
                                property.Name = $"{param.Name}Property";
                                property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), $"_{param.Name}")));
                                property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), $"_{param.Name}"), new CodePropertySetValueReferenceExpression()));
                                EventargsClass.Members.Add(field);
                                EventargsClass.Members.Add(property);
                            }
                            properties.Add(param.Name);
                            contruct.Parameters.Add(new CodeParameterDeclarationExpression(new CodeTypeReference(param.ParameterType), param.Name));
                            CodePropertyReferenceExpression codeProperty = new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), param.Name + "Property");

                            contruct.Statements.Add(new CodeAssignStatement(codeProperty,new CodeArgumentReferenceExpression(param.Name)));
                        }
                        EventargsClass.Members.Add(contruct);
                    }
                    name.Types.Add(EventargsClass);
                }
                // получены все параметры
                //todo создать классы Eventargs


                CodeDomProvider codeCompile = CodeDomProvider.CreateProvider("CSharp");
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BracingStyle = "C";
                codeCompile.GenerateCodeFromNamespace(name, sw, options);
            }
             */
            #endregion

            _dataservice = dataService;


            BotStorage = new ObservableCollection<BotObject>(_dataservice.GetAllBots());


            controlCenterVM = new ControlCenterVM(_dataservice, modulesService, dialogService, this);
            settingsVM = new SettingsVM(_dataservice, modulesService);
            CurrentPage = controlCenterVM;

            Application.Current.SessionEnding += Current_SessionEnding;
            Application.Current.Exit += Current_Exit;
            Cvs = new CollectionViewSource();
            Cvs.Source = ProxyServers;
            Cvs.Filter += Cvs_Filter;

            



        }

        private void Config_UnLoadModuleChanged(object sender, ReferencePath oldItem)
        {

        }


        private void Current_Exit(object sender, ExitEventArgs e)
        {
            ExitProgramm();
        }

        private void Current_SessionEnding(object sender, System.Windows.SessionEndingCancelEventArgs e)
        {
            ExitProgramm();
        }
        private void ExitProgramm()
        {
            DisconnectAll();
            this._dataservice.Save();
        }
        #region McProtocolLib


        #endregion

        #region Методы




        private readonly object locker = new object();

        readonly object saveproxylocker = new object();


        public void DisconnectAll()
        {
            BotStorage.ToList().ForEach(b => b.Disconnect());
        }
        #endregion
        #region Свойства
        private ObservableCollection<ProxyServer> proxyServers = new ObservableCollection<ProxyServer>();

        public ObservableCollection<ProxyServer> ProxyServers
        {
            get { return proxyServers; }
            set
            {
                proxyServers = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(All));
                RaisePropertyChanged(nameof(Cvs));
            }
        }



        public readonly ObservableCollection<BotObject> BotStorage;





        readonly object lockerBotmodels = new object();

        #endregion
        #region Команды
        private RelayCommand<bool> opensettings;

        public RelayCommand<bool> OpenSettingsCommand
        {
            get => opensettings ?? (opensettings = new RelayCommand<bool>(p =>
            {
                if (p)
                {
                    CurrentPage = settingsVM;
                }
                else
                {
                    CurrentPage = controlCenterVM;
                }
            }));
        }



        private RelayCommand<object> addproxycommand;

        public RelayCommand<object> AddProxyCommand
        {
            get => addproxycommand ?? (addproxycommand = new RelayCommand<object>(p =>
            {
                ProxyServer pNew = new ProxyServer();
                SelectProxy = pNew;
                ProxyServers.Add(pNew);
            }));
        }
        private RelayCommand<ProxyServer> deleteproxycommand;

        public RelayCommand<ProxyServer> DeleteProxyCommand
        {
            get => deleteproxycommand ?? (deleteproxycommand = new RelayCommand<ProxyServer>(p =>
            {
                ProxyServers.Remove(p);
            }));
        }
        private RelayCommand<object> findproxycommand;

        public RelayCommand<object> FindProxyCommand
        {
            get => findproxycommand ?? (findproxycommand = new RelayCommand<object>(async p =>
            {
                List<ProxyServer> result = new List<ProxyServer>();
                await Task.Run(() =>
                {
                    WebClient wc = new WebClient();
                    wc.Encoding = System.Text.Encoding.UTF8;

                    string answer = wc.DownloadString("http://api.foxtools.ru/v2/Proxy.xml");

                    using (StreamWriter sw = new StreamWriter("gg.txt"))
                    {
                        sw.WriteLine(answer);
                    }
                    Regex regex = new Regex(@"<item><ip>(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})</ip><port>(\d+)</port><type>(\d+)</type><anonymity>\w+</anonymity><uptime>\d+\.\d+</uptime><checked>[\w:-]+</checked><available>\w+</available><free>\w+</free><country><nameEn>\w+</nameEn><nameRu>[а-яА-я]+</nameRu><iso3166a2>\w+</iso3166a2></country></item>");
                    MatchCollection collection = regex.Matches(answer);

                    foreach (Match m in collection)
                    {
                        string host = m.Groups[1].Value;
                        int port = int.Parse(m.Groups[2].Value);
                        ProxyType type = ProxyType.Http;
                        switch (m.Groups[3].Value)
                        {
                            case "0": type = ProxyType.None; break;
                            case "1": type = ProxyType.Http; break;
                            case "4": type = ProxyType.Socks4; break;
                            case "8": type = ProxyType.Socks5; break;
                        }
                        result.Add(new ProxyServer { ProxyHost = host, ProxyPort = port, Proxy_Type = type });
                    }
                });
                result = result.Where(proxy => ProxyServers.All(x => !x.Equals(proxy))).ToList();
                foreach (ProxyServer item in result)
                {
                    ProxyServers.Add(item);
                }
            }));
        }

        #endregion
        #region PrxyViewModel
        private object selectproxy;

        public object SelectProxy
        {
            get { return selectproxy; }
            set
            {
                selectproxy = value;
                RaisePropertyChanged();
            }
        }
        private string filter;

        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                OnFilter();
            }
        }

        private void OnFilter()
        {
            Cvs?.View.Refresh();
        }
        private CollectionViewSource cvs;

        public CollectionViewSource Cvs
        {
            get { return cvs; }
            set
            {
                cvs = value;
                RaisePropertyChanged();
            }
        }


        public ICollectionView All
        {
            get { return Cvs.View; }
        }
        private void Cvs_Filter(object sender, FilterEventArgs e)
        {
            ProxyServer s = (ProxyServer)e.Item;
            if (string.IsNullOrWhiteSpace(Filter) || Filter.Length == 0)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = s.ProxyHost.Contains(Filter);
            }
        }


        #endregion
    }
}