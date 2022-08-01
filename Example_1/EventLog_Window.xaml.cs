using System.Windows;


namespace Example_1
{
    /// <summary>
    /// Логика взаимодействия для EventLog_Window.xaml
    /// </summary>
    public partial class EventLog_Window : Window
    {
        public EventLog_Window()
        {
            InitializeComponent();
            ListEvent.ItemsSource = Bank_A.Events;
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
