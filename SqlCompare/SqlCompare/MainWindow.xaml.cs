using SqlCompare.Controls;
using SqlCompare.Sql;
using SqlCompare.Windows;
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

namespace SqlCompare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void ShiftRequestHandler(int id);

        public event ShiftRequestHandler ShiftRequest;

        private UIElementCollection solutions;
        private Connection connection;
        private RadioButton rbSpeed;

        public Connection Connection
        {
            get => connection;
        }

        public MainWindow()
        {
            InitializeComponent();
            solutions = ((StackPanel)FindName("workingArea")).Children;
            InitSolutions();
            rbSpeed = (RadioButton)FindName("rbTime");
        }


        private void AddSolution()
        {
            SolutionContainer newSolution = new SolutionContainer(solutions.Count + 1);
            this.ShiftRequest += newSolution.OnShiftRequest;
            solutions.Add(newSolution);
            newSolution.DeleteRequest += OnDeleteSolution;
        }

        private void InitSolutions()
        {
            AddSolution();
            AddSolution();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSolution();
        }

        private void MenuClear_Click(object sender, RoutedEventArgs e)
        {
            solutions.Clear();
            InitSolutions();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            SetColorForAll(Brushes.White);
            List<Query> queries = new List<Query>();

            foreach(var t in solutions)
            {
                SolutionContainer dtb = (SolutionContainer)t;
                string text = dtb.Text.Trim();
                if(text == "")
                {
                    MessageBox.Show(
                        $"Решение {dtb.Id} пустое, заполните его или удалите.",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                    return;
                }
                else
                {
                    queries.Add(new Query(text));
                }
            }

            Solver solver;
            if(rbSpeed.IsChecked.Value)
            {
                solver = new Solver(Connection, true);
            }
            else
            {
                solver = new Solver(Connection, false);
            }


            int? winner;
            List<int> winners = solver.Solve(queries, out winner).Select(i => i + 1).ToList();
            
            try
            {
                SetColorsAccordingToResult(queries, winner.Value);
            }
            catch
            {
                SetColorForAll(Brushes.LightGray);
            }

            if(winners.Count == 0)
            {

                MessageBox.Show(
                    "Ни одно из решений не было корректным",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return;
            }

            string winnersStr = string.Join(", ", winners);
            if(winners.Count > 1)
            {
                MessageBox.Show(
                    $"Номера лучших решений: {winnersStr}",
                    "Результат",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
                return;
            }
            else
            {
                MessageBox.Show(
                    $"Номер лучшего решения: {winnersStr}",
                    "Результат",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
                return;
            }

        }

        private void OnDeleteSolution(int id)
        {
            if (solutions.Count <= 2)
            {
                MessageBox.Show(
                    "Нельзя удалить решение, когда осталось всего два!", 
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
            solutions.Remove(solutions[id - 1]);
            ShiftRequest?.Invoke(id);
        }

        private void MenuConnect_Click(object sender, RoutedEventArgs e)
        {
            ConnectWindow connectWindow = new ConnectWindow();
            connectWindow.PassConnection += ReceiveConnection;
            connectWindow.ShowDialog();
        }

        private void ReceiveConnection(Connection connection)
        {
            this.connection = connection;
            ((Button)FindName("btnStart")).IsEnabled = true;
        }

        private void SetColorForAll(Brush brush)
        {
            foreach (var v in solutions)
            {
                ((SolutionContainer)v).SetColor(brush);
            }
        }

        private void SetColorsAccordingToResult(List<Query> queries, int win)
        {
            for(int i = 0; i < queries.Count; ++i)
            {
                if(queries[i].Cost == -1)
                {
                    ((SolutionContainer)solutions[i]).SetColor(Brushes.LightGray);
                }
                else if (queries[i].Cost == win)
                {
                    ((SolutionContainer)solutions[i]).SetColor(Brushes.Green);
                }

            }
        }
    }
}
