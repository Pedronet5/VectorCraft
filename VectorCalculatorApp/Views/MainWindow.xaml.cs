using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VectorCalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComputeCrossProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var vector1 = new Vector3D
                {
                    X = double.Parse(txtVector1X.Text),
                    Y = double.Parse(txtVector1Y.Text),
                    Z = double.Parse(txtVector1Z.Text)
                };

                var vector2 = new Vector3D
                {
                    X = double.Parse(txtVector2X.Text),
                    Y = double.Parse(txtVector2Y.Text),
                    Z = double.Parse(txtVector2Z.Text)
                };

                var result = Vector3D.CrossProduct(vector1, vector2);

                txtResult.Text = $"Result: ({result.X}, {result.Y}, {result.Z})";
            }
            catch (FormatException)
            {
                txtResult.Text = "Invalid input. Please enter valid numeric values.";
            }
        }
    }
}