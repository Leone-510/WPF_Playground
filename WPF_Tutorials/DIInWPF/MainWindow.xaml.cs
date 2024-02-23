using DIInWPF.StartupHelpers;
using System.Windows;
using WpfClassLibrary;

namespace DIInWPF;

public partial class MainWindow : Window
{
    private readonly IDataAccess _dataAccess;
    private readonly IAbstractFactory<ChildForm> _factory;

    public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildForm> factory)
    {
        InitializeComponent();

        _dataAccess = dataAccess;
        _factory = factory;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
        data.Text = _dataAccess.GetData();
    }

    private void openChildForm_Click(object sender, RoutedEventArgs e)
    {
        _factory.Create().Show();
    }
}