using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HW_5.Models;
using System.ComponentModel;


namespace HW_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BindingList<TimeStamp> timeStampsList = new BindingList<TimeStamp>();
        private TimeStamp? selectedTime;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timeStampsList.Add(new TimeStamp("23", "5", "8"));
            timeStampsList.Add(new TimeStamp("23", "59", "59"));
            timeStampsList.Add(new TimeStamp("0", "0", "0"));
            timeStampsList.Add(new TimeStamp("21", "22", "33"));
            timeStampsList.Add(new TimeStamp("3", "45", "55"));
            timeStamps.ItemsSource = timeStampsList;
            
        }

        private void tbTimeEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;
            if (selectedTime != null)
            {
                selectedTime.TimeStampString = tbTimeEnter.Text;
                timeStamps.SelectedItem = selectedTime;
                timeStamps.Items.Refresh();
                tbTimeEnter.Clear();
                selectedTime = null;
                timeStamps.SelectedItem = null;
                return;
            }
            string[] time = tbTimeEnter.Text.Split(":");
            if (time[0].Length == 0 || time[1].Length == 0 || time[2].Length == 0)
            {
                MessageBox.Show("Incorrect input. Try again");
                return;
            }
            if (Int32.Parse(time[0]) >= 24 || Int32.Parse(time[1]) >= 60 || Int32.Parse(time[2]) >= 60)
            {
                MessageBox.Show("Incorrect input. Try again");
                return;
            }
            timeStampsList.Add( new TimeStamp(time[0], time[1], time[2]) );
            tbTimeEnter.Clear();
        }

        private void timeStamps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTime = timeStamps.SelectedItem as TimeStamp;
            tbTimeEnter.Clear();
            tbInformation.Clear();
            if (selectedTime != null)
            {
                tbTimeEnter.Text = selectedTime.TimeStampString;
                informationChanger();
            }
        }

        private void tbTimeEnter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0) || e.Text[0] == 58);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0) || e.Text[0] == 43 || e.Text[0] == 45);
        }

        private void btnHours_Click(object sender, RoutedEventArgs e)
        {
            bool isParsed = Int32.TryParse(tbHours.Text, out int intHours);
            if (selectedTime != null && isParsed == true)
            {
                selectedTime.timeChanger(intHours, 0, 0);
                timeStamps.Items.Refresh();
                tbTimeEnter.Text = selectedTime.TimeStampString;
                informationChanger();
            }
        }

        private void btnMinutes_Click(object sender, RoutedEventArgs e)
        {
            bool isParsed = Int32.TryParse(tbMinutes.Text, out int intMinutes);
            if (selectedTime != null && isParsed == true)
            {
                selectedTime.timeChanger(0, intMinutes, 0);
                timeStamps.Items.Refresh();
                tbTimeEnter.Text = selectedTime.TimeStampString;
                informationChanger();
            }
        }

        private void btnSeconds_Click(object sender, RoutedEventArgs e)
        {
            bool isParsed = Int32.TryParse(tbSeconds.Text, out int intSeconds);
            if (selectedTime != null && isParsed == true)
            {
                selectedTime.timeChanger(0, 0, intSeconds);
                timeStamps.Items.Refresh();
                tbTimeEnter.Text = selectedTime.TimeStampString;
                informationChanger();
            }
        }

        private void btnApplyAll_Click(object sender, RoutedEventArgs e)
        {
            btnSeconds.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            btnMinutes.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            btnHours.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        private void informationChanger()
        {
            tbInformation.Text = selectedTime.ToString();
        }
    }
}


/*Вариант 5
 * 
Составить описание класса для представления времени.
Предусмотреть возможности установки времени и изменения его отдельных полей (час, минута, секунда)
с проверкой допустимости вводимых значений. В случае недопустимых значений полей выбрасываются исключения.
Создать методы изменения времени на заданное количество часов, минут и секунд.
Написать программу, демонстрирующую все разработанные элементы класса.*/
