namespace VectorCalculatorApp
{
    using System.Windows;
    using VectorCalculatorApp.ViewModel;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VectorViewModel(); // Set ViewModel as DataContext
        }
    }
}