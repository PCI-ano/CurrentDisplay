using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CurrentDisplay
{
    class MainWindowData : INotifyPropertyChanged
    {
        // プロパティが変更されたときにViewに通知する
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string PropertyName)
        {
            var e = new PropertyChangedEventArgs(PropertyName);
            PropertyChanged?.Invoke(this, e);
        }

        //色の定義
        private Brush _main_color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 48, 48, 81));
        public Brush main_color {
            get { return _main_color; }
            set { 
                _main_color = value;
                NotifyPropertyChanged("main_color");
            }
        }

        private Brush _base1_color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
        public Brush base1_color
        {
            get { return _base1_color; }
            set
            {
                _base1_color = value;
                NotifyPropertyChanged("base1_color");
            }
        }

        private Brush _base2_color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 220, 220, 220));
        public Brush base2_color
        {
            get { return _base2_color; }
            set
            {
                _base2_color = value;
                NotifyPropertyChanged("base2_color");
            }
        }

        private Brush _main_or_base1_color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 48, 48, 81));
        public Brush main_or_base1_color
        {
            get { return _main_color; }
            set
            {
                _main_or_base1_color = value;
                NotifyPropertyChanged("main_or_base1_color");
            }
        }

        private Brush _base2_or_main_color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 220, 220, 220));
        public Brush base2_or_main_color
        {
            get { return _base2_or_main_color; }
            set
            {
                _base2_or_main_color = value;
                NotifyPropertyChanged("base2_or_main_color");
            }
        }

        // 数値の定義
        private string _current = "--.--";
        public string current
        {
            get { return _current; }
            set
            {
                _current = value;
                NotifyPropertyChanged("current");
            }
        }

        private string _current_limit = "--.-";
        public string current_limit
        {
            get { return _current_limit; }
            set
            {
                _current_limit = value;
                NotifyPropertyChanged("current_limit");
            }
        }

        private string _current_use_rate = "---.-";
        public string current_use_rate
        {
            get { return _current_use_rate; }
            set
            {
                _current_use_rate = value;
                NotifyPropertyChanged("current_use_rate");
            }
        }

        private string _current_use_message = "待機";
        public string current_use_message
        {
            get { return _current_use_message; }
            set
            {
                _current_use_message = value;
                NotifyPropertyChanged("current_use_message");
            }
        }

        private int _bar_height = 0;
        public int bar_height
        {
            get { return _bar_height; }
            set
            {
                _bar_height = value;
                NotifyPropertyChanged("bar_height");
            }
        }
    }
}
