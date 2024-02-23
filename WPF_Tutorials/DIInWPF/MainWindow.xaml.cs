using System.Windows;
using WpfClassLibrary;

namespace DIInWPF;

public partial class MainWindow : Window
{
    private readonly IDataAccess _dataAccess;
    private readonly ChildForm _childForm; 


    public MainWindow(IDataAccess dataAccess, ChildForm childForm)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
        _childForm = childForm;
    }

    private void getData_Click(object sender, RoutedEventArgs e)
    {
        data.Text = _dataAccess.GetData();
    }

    private void openChildForm_Click(object sender, RoutedEventArgs e)
    {
        _childForm.Show();
    }
}