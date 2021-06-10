using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlCompare.Controls
{
    /// <summary>
    /// Логика взаимодействия для DeletableTextBox.xaml
    /// </summary>
    public partial class SolutionContainer : UserControl
    {
        public delegate void DeleteRequestHandler(int id);

        public event DeleteRequestHandler DeleteRequest;
        public int Id { get; set; }

        private Label _label;
        private RichTextBox _rtb;

        public string Text
        {
            get
            {
                return new TextRange(_rtb.Document.ContentStart, _rtb.Document.ContentEnd).Text;
            }
        }

        public void SetColor(Brush brush)
        {
            _rtb.Background = brush;
        }


        public SolutionContainer()
        {
            InitializeComponent();
        }

        public SolutionContainer(int id) : this()
        {
            Id = id;
            _label = (Label)FindName("lbl");
            _label.Content = "Решение " + id + ": ";
            _rtb = (RichTextBox)FindName("rtb");
        }

        private void GenerateDeleteRequest(object sender, RoutedEventArgs e)
        {
            DeleteRequest?.Invoke(Id);
        }

        public void OnShiftRequest(int id)
        {
            if(id < this.Id)
            {
                --this.Id;
                _label.Content = "Решение " + Id + ": ";
            }
        }
    }
}
