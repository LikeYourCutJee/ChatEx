using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace ChatEx.Features.WindowsElementsFeatures.TextBoxFeatures
{
    public class TextBoxCustomBehaviour
    {
        public static void GoToNextRow(TextBox? textBox) 
        {
            if (textBox == null)
                return;

            textBox.Text += "\n";
            textBox.CaretIndex = textBox.Text.Length;
        }

        public static void PasteText(TextBox? textBox) 
        {
            if (textBox != null && Clipboard.ContainsText())
            {
                var text = Clipboard.GetText(TextDataFormat.Text);
                textBox.Text = text;
                textBox.CaretIndex = textBox.Text.Length;
            }
        }
    }
}
