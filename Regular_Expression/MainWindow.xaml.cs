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
using System.Text.RegularExpressions;

namespace Regular_Expression
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string matched;
        Regex regex;
        private void txt_regex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FillMatchedText(txt_text.Text))
            {
                txt_match.Text = matched;
            }
        }

        public bool FillMatchedText(string input)
        {
            string s = string.Empty;
            foreach (var item in regex.Matches(input))
            {
                s += item;
            }
            matched = s;
            return true;
        }

        private void cmb_RegularExpression_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            cmb_RegularExpression.Items.Add(cmb_RegularExpression.Text);
        }

        private void btn_Adjust_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                regex = new Regex(cmb_RegularExpression.Text);
                txt_text.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Format !!", "Format Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_text.IsEnabled = false;
            }
        }

        private void cmb_RegularExpression_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                regex = new Regex(cmb_RegularExpression.Text);
                txt_text.IsEnabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong Format !!", "Format Error !", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_text.IsEnabled = false;
            }
        }
    }
}
