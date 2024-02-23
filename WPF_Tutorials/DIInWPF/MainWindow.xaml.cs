using System.Windows;
using WpfClassLibrary;

namespace DIInWPF;

public partial class MainWindow : Window
{
    private readonly IDataAccess _dataAccess;

    public MainWindow(IDataAccess dataAccess)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
        data.Text = _dataAccess.GetData();
    }
}