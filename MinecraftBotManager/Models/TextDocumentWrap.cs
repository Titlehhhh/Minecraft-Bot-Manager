using ICSharpCode.AvalonEdit.Document;
using MinecraftBotManager.CustomControls.FileProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Models
{
    [Serializable]
    public class TextDocumentWrap : INotifyPropertyChanged, IDeserializationCallback
    {
        [NonSerialized]
        private TextDocument code = new TextDocument();

        public TextDocument SourceCode
        {
            get { return code; }
            set
            {
                code = value;
                RaisePropertyChanged();
            }
        }
        public string DipspathCode => App.Current.Dispatcher.Invoke(() => { return SourceCode.Text; });
        private string syntax;

        public string Syntax
        {
            get { return syntax; }
            set
            {
                syntax = value;
                RaisePropertyChanged();
            }
        }



        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private string path;

        public string FullPath
        {
            get { return path; }
            set
            {
                path = value;
                RaisePropertyChanged();
            }
        }

        public TextDocumentWrap(FileInfoVM file)
        {
            Name = file.Name;
            FullPath = file.FullPath;
        }
        public TextDocumentWrap()
        {

        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void OnDeserialization(object sender)
        {

            Task.Run(() =>
            {
                if (File.Exists(FullPath))
                    using (StreamReader sr = new StreamReader(FullPath))
                    {
                        string code = sr.ReadToEnd();
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            SourceCode = new TextDocument();
                            SourceCode.Text = code;
                        });
                    }
            });
        }
    }

}
