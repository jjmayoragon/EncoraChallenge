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

namespace ChallengeTestCases
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var lines = input.LineCount;

            var rawText = input.Text;

            output.Text = String.Empty;

            var textLines = rawText.Split('\n');

            int numStrings;

            bool isNumeric = int.TryParse(textLines[0], out numStrings);

            if (numStrings >= 1)
            {
                if (numStrings == textLines.Length - 1)
                {
                    for (int i = 1; i <= numStrings; i++)
                    {

                        if (!String.IsNullOrEmpty(textLines[i].ToString()))
                        {
                            var line = textLines[i].Trim().ToLower();

                            output.Text += sortingOperations(line) + "\n";
                        }
                        else
                        {
                            var msg = "The " + i + "º string cannot be empty";
                            MessageBox.Show(msg);

                        }

                    }
                }
                else
                {
                    var msg = "Number of lines does not match the number of strings. You must write " + numStrings + " lines of strings below the first line";
                    MessageBox.Show(msg);
                }

            }
            else
            {
                MessageBox.Show("First line must be a number greater than zero");
            }

        }

        private string sortingOperations(string line)
        {
            //"WRITE YOUR LOGIC HERE"
           
            var lineArray = new List<Letter>();

            for (int i = 0; i < line.Length; i++)
            {
                var letter = new Letter();

                letter.value = line[i].ToString();
                letter.inputIndex = i;
                letter.lexicographicOrder = (int)line[i];
                letter.frequency = line.Where(x => (x == line[i])).Count();
                
                lineArray.Add(letter);
            }

            var orderedLine = lineArray
                            .OrderByDescending(l => l.frequency)
                            .ThenBy(l=>l.lexicographicOrder)
                            .Select(l => l.value);

            var outputString = String.Empty;

            foreach(var letter in orderedLine)
            {
                outputString += letter;
            }

            return outputString;

        }
    }
   
    public class Letter
    {
        public string value { get; set; }
        public int inputIndex { get; set; }
        public int lexicographicOrder { get; set; }
        public int frequency { get; set; }
    }
}
