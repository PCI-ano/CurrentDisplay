using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrentDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowData mainWindowData;

        public MainWindow()
        {
            InitializeComponent();
            mainWindowData = this.DataContext as MainWindowData;
            mainWindowData.current_limit = ConfigurationManager.AppSettings.Get("measurement_current_limit");
            
            // センサーからの接続を受け付ける
            MeasureServer server = new MeasureServer();
            server.CurrentDataReceived += Server_CurrentDataReceived;
            server.run();
        }

        // センサーから電流データを受け取ったとき
        private void Server_CurrentDataReceived(object? sender, CurrentDataReceivedArgs e)
        {
            double current_value = e.Value; // 電流値
            double limit_value = Double.Parse(ConfigurationManager.AppSettings.Get("measurement_current_limit"));   // 電流制限値
            double use_rate_value = current_value / limit_value * 100;  // 使用率
            double caution_use_rate = Double.Parse(ConfigurationManager.AppSettings.Get("measurement_caution_use_rate"));
            double warning_use_rate = Double.Parse(ConfigurationManager.AppSettings.Get("measurement_warning_use_rate"));
            DateTime dateTime = DateTime.Now;

            //データ取得時刻の更新
            mainWindowData.data_time = dateTime.ToString("HH:mm:ss");

            // 電流値と使用率の更新
            mainWindowData.current = current_value.ToString();
            mainWindowData.current_use_rate = use_rate_value.ToString("F1");
            
            // 使用率バー表示の更新
            if (use_rate_value > 100)
            {
                mainWindowData.bar_height = 200;
            }
            else
            {
                mainWindowData.bar_height = (int)(use_rate_value * 2);
            }

            // 使用率に応じた色変更
            if (use_rate_value > warning_use_rate)
            {
                mainWindowData.current_use_message = "警告";
                mainWindowData.main_color = mainWindowData.warning_color_scheme;
                mainWindowData.main_or_base1_color = mainWindowData.base1_color_scheme;
                mainWindowData.base2_or_main_color = mainWindowData.warning_color_scheme;
            }
            else if (use_rate_value > caution_use_rate)
            {
                mainWindowData.current_use_message = "注意";
                mainWindowData.main_color = mainWindowData.caution_color_scheme;
                mainWindowData.main_or_base1_color = mainWindowData.caution_color_scheme;
                mainWindowData.base2_or_main_color = mainWindowData.base2_color_scheme;
            }
            else
            {
                mainWindowData.current_use_message = "正常";
                mainWindowData.main_color = mainWindowData.nomal_color_scheme;
                mainWindowData.main_or_base1_color = mainWindowData.nomal_color_scheme;
                mainWindowData.base2_or_main_color = mainWindowData.base2_color_scheme;
            }
           
        }

      
    }
}