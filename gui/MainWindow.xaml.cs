using System;
using System.Windows;
using System.Windows.Input;
using System.Text;
using Global;


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
        private void DogFriendlyClick(object sender, System.EventArgs e)
        {

            if(DogFriendlyCheckBox.IsChecked == true)
            {
                GBL.DOG_FRIENDLY = true;
            }
            else
            {
                 GBL.DOG_FRIENDLY = false;
        
            }

        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
            
                if(sender == command1 || sender == data1_1 || sender == data2_1)
                {
                
            
                    CMD.LEFT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command1.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_1.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_1.Text, 2));
                    Console.WriteLine(CMD.LEFT_TAP_QUAD_1[0]);
                
                
                }
                else if(sender == command2 || sender == data1_2 || sender == data2_2)
                {
                    CMD.LEFT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command2.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_2.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_2.Text, 2));

                }
                else if(sender == command3 || sender == data1_3 || sender == data2_3)
                {
                    CMD.LEFT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command3.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_3.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_3.Text, 2));

                }
                else if(sender == command4 || sender == data1_4 || sender == data2_4)
                {
                    CMD.LEFT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command4.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_4.Text, 2));
                    CMD.LEFT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_4.Text, 2));

                }
                else if(sender == command5 || sender == data1_5 || sender == data2_5)
                {
                    CMD.RIGHT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_5.Text, 2));

                }
                else if(sender == command6 || sender == data1_6 || sender == data2_6)
                {
                    CMD.RIGHT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command6.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_6.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_6.Text, 2));

                }
                else if(sender == command7 || sender == data1_7 || sender == data2_7)
                {
                    CMD.RIGHT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_7.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_7.Text, 2));

                }
                else if(sender == command8 || sender == data1_8 || sender == data2_8)
                {
                    CMD.RIGHT_TAP_QUAD_1[0] = Convert.ToByte(Convert.ToInt32(command5.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[1] = Convert.ToByte(Convert.ToInt32(data1_8.Text, 2));
                    CMD.RIGHT_TAP_QUAD_1[2] = Convert.ToByte(Convert.ToInt32(data2_8.Text, 2));

                }
                else if(sender == NoteOffTime)
                {
                    CMD.MIDI_WAIT = Int32.Parse(NoteOffTime.Text);
                    
                }
                
            }
        }
    }
}

