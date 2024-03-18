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

        /// <summary>
        /// Handles the button click event for computing the cross product of two vectors.
        /// </summary>
        /// <param name="sender">The object that raised the event (usually a button).</param>
        /// <param name="e">The event arguments.</param>
        private void ComputeCrossProduct_Click(object sender, RoutedEventArgs e)
        {
            VectorViewModel? vectorViewModel = DataContext as VectorViewModel;
            if (vectorViewModel != null)
            {
                vectorViewModel.ComputeCrossProduct();
            }
        }
    }
}