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

namespace TpIGL1.Views
{
    /// <summary>
    /// Interaction logic for NmbrOccurencesMotView.xaml
    /// </summary>
    public partial class NmbrOccurencesMotView : UserControl
    {
        public NmbrOccurencesMotView()
        {
            InitializeComponent();
        }

        private string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            intermidiate.Content = StringFromRichTextBox(richTextBox);
        }
    }
}
