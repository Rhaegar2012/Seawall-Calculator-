using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SeawallCalculator
{
    //ModelView collects and displays information from the UI 
     public class ModelView
    {
        private ICommand m_ButtonCommand;

        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }
        private ICommand m_SecondCommand;
        public ICommand SecondCommand
        {
            get
            {
                return m_SecondCommand;
            }
            set
            {
                m_SecondCommand = value;
            }
        }
        public ModelView()
        {
            ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
            SecondCommand = new RelayCommand(new Action<object>(ShowMessage));
        }
        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

    }
}
