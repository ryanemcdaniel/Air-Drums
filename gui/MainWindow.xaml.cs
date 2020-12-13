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
                Console.WriteLine(GBL.DOG_FRIENDLY);

            }
            else
            {
                 GBL.DOG_FRIENDLY = false;
                 Console.WriteLine(GBL.DOG_FRIENDLY);  

            }

        }

        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
            
                if(sender == command1 || sender == data1_1 || sender == data2_1)
                {
                
                    CMD.LEFT_TAP_QUAD_1[0] = Byte.Parse(command1.Text);
                    CMD.LEFT_TAP_QUAD_1[1] = Byte.Parse(data1_1.Text);
                    CMD.LEFT_TAP_QUAD_1[2] = Byte.Parse(data2_1.Text);
                
                }
                else if(sender == command2 || sender == data1_2 || sender == data2_2)
                {
                    CMD.LEFT_TAP_QUAD_2[0] = Byte.Parse(command2.Text);
                    CMD.LEFT_TAP_QUAD_2[1] = Byte.Parse(data1_2.Text);
                    CMD.LEFT_TAP_QUAD_2[2] = Byte.Parse(data2_2.Text);

                }
                else if(sender == command3 || sender == data1_3 || sender == data2_3)
                {
                    CMD.LEFT_TAP_QUAD_3[0] = Byte.Parse(command3.Text);
                    CMD.LEFT_TAP_QUAD_3[1] = Byte.Parse(data1_3.Text);
                    CMD.LEFT_TAP_QUAD_3[2] = Byte.Parse(data2_3.Text);

                }
                else if(sender == command4 || sender == data1_4 || sender == data2_4)
                {
                    CMD.LEFT_TAP_QUAD_4[0] = Byte.Parse(command4.Text);
                    CMD.LEFT_TAP_QUAD_4[1] = Byte.Parse(data1_4.Text);
                    CMD.LEFT_TAP_QUAD_4[2] = Byte.Parse(data2_4.Text);

                }
                else if(sender == command5 || sender == data1_5 || sender == data2_5)
                {
                    CMD.RIGHT_TAP_QUAD_1[0] = Byte.Parse(command5.Text);
                    CMD.RIGHT_TAP_QUAD_1[1] = Byte.Parse(data1_5.Text);
                    CMD.RIGHT_TAP_QUAD_1[2] = Byte.Parse(data2_5.Text);

                }
                else if(sender == command6 || sender == data1_6 || sender == data2_6)
                {
                    CMD.RIGHT_TAP_QUAD_2[0] = Byte.Parse(command6.Text);
                    CMD.RIGHT_TAP_QUAD_2[1] = Byte.Parse(data1_6.Text);
                    CMD.RIGHT_TAP_QUAD_2[2] = Byte.Parse(data2_6.Text);

                }
                else if(sender == command7 || sender == data1_7 || sender == data2_7)
                {
                    CMD.RIGHT_TAP_QUAD_3[0] = Byte.Parse(command7.Text);
                    CMD.RIGHT_TAP_QUAD_3[1] = Byte.Parse(data1_7.Text);
                    CMD.RIGHT_TAP_QUAD_3[2] = Byte.Parse(data2_7.Text);

                }
                else if(sender == command8 || sender == data1_8 || sender == data2_8)
                {
                    CMD.RIGHT_TAP_QUAD_4[0] = Byte.Parse(command8.Text);
                    CMD.RIGHT_TAP_QUAD_4[1] = Byte.Parse(data1_8.Text);
                    CMD.RIGHT_TAP_QUAD_4[2] = Byte.Parse(data2_8.Text);

                }
                else if(sender == NoteOffTime)
                {
                    CMD.MIDI_WAIT = Int32.Parse(NoteOffTime.Text);
                    Console.WriteLine(CMD.MIDI_WAIT);
                }
                
            }
        }
    }
}

