using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace WpfRtfEditorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = "file1.rtf";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new();
            openFile.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if(openFile.ShowDialog() == true)
            {
                TextRange textRange = new TextRange(docEditor.Document.ContentStart, docEditor.Document.ContentEnd);
                using(FileStream file = File.Open(openFile.FileName, FileMode.Open))
                {
                    if(Path.GetExtension(openFile.FileName).ToLower() == ".rtf")
                    {
                        textRange.Load(file, DataFormats.Rtf);
                    }
                    else if(Path.GetExtension(openFile.FileName).ToLower() == ".txt")
                        textRange.Load(file, DataFormats.Text);
                    else
                        textRange.Load(file, DataFormats.Xaml);
                }
            }

            // code for ScrollViewer
            //using (FileStream file = File.Open(path, FileMode.Open))
            //{
            //    FlowDocument document = XamlReader.Load(file) as FlowDocument;
            //    if (document is not null)
            //        docViewer.Document = document;
            //}
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new();
            //saveFile.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == true)
            {
                TextRange textRange = new TextRange(docEditor.Document.ContentStart, docEditor.Document.ContentEnd);
                using (FileStream file = File.Create(saveFile.FileName))
                {
                    if (Path.GetExtension(saveFile.FileName).ToLower() == ".rtf")
                    {
                        textRange.Save(file, DataFormats.Rtf);
                    }
                    else if (Path.GetExtension(saveFile.FileName).ToLower() == ".txt")
                        textRange.Save(file, DataFormats.Text);
                    else
                        textRange.Save(file, DataFormats.Xaml);
                }
            }

            // code for ScrollViewer
            //using(FileStream file = File.Open(path,FileMode.Create))
            //{
            //    if(docViewer.Document is not null)
            //    {
            //        XamlWriter.Save(docViewer.Document, file);
            //    }
            //}
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            // code for ScrollViewer
            //docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }
    }
}
