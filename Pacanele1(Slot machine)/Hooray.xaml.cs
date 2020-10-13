using System.Timers;
using System.Windows;
using System.Windows.Threading;
using Timer = System.Timers.Timer;

namespace Pacanele1_Slot_machine_
{
    /// <summary>
    /// Interaction logic for Hooray.xaml
    /// </summary>
    public partial class Hooray : Window
    {
        Timer t;
        public Hooray()
        {
            InitializeComponent();
            t = new Timer(4000);
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Enabled = true;
        }
        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate (object o)
            {
                Close();
                return null;
            }, null);
        }
    }
}
