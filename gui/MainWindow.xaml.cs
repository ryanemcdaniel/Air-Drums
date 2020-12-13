
using System.Windows;
using System.Windows.Input;

namespace air_drums
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            NoteOffTime.Text = "centi-sec";
        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
            
                if(sender == command1 || sender == data1_1 || sender == data2_1)
                {
                
                
                
                }
                else if(sender == command2 || sender == data1_2 || sender == data2_2)
                {

                }
                else if(sender == command3 || sender == data1_3 || sender == data2_3)
                {

                }
                else if(sender == command4 || sender == data1_4 || sender == data2_4)
                {

                }
                else if(sender == command5 || sender == data1_5 || sender == data2_5)
                {

                }
                else if(sender == command6 || sender == data1_6 || sender == data2_6)
                {

                }
                else if(sender == command7 || sender == data1_7 || sender == data2_7)
                {

                }
                else if(sender == command8 || sender == data1_8 || sender == data2_8)
                {

                }
                
            }
        }
    }
}

