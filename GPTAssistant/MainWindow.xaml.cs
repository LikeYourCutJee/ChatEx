using ChatEx.Features.WindowsElementsFeatures.TextBoxFeatures;
using GPTAssistant.Features.functionality;
using GPTAssistant.Features.WindowsElementsFeatures.ElementAnimations;
using OpenAiChatBotApi.ChatBots.CommonInterfaces;
using OpenAiChatBotApi.ChatBots.Gpt;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPTAssistant
{
    public partial class MainWindow : Window
    {
        public IChatBot AI { get; set; } //Declaring a chatbot

        //*** Declare requered UI elements to separate GUI
        public StackPanel ChatMessagesStackPanel { get; set; }
        public ScrollViewer ChatMessagesscrollViewer { get; set; }
        public TextBox UserTextBox { get; set; }
        //***

        private GlobalHotkey HidingHotKey; //Declareing global hotkey

        public MainWindow()//Initializing fields
        {
            InitializeComponent();

            HidingHotKey = new GlobalHotkey(new WindowInteropHelper(this).Handle, HideShowWindow, 0x1, (int)KeyInterop.VirtualKeyFromKey(Key.A), 9000);//Registering global hotkey

            AI = new ChatGptBot(OpenAiChatBotApi.ChatBots.Gpt.Enums.GptModels.gpt3_5_turbo, "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");//Creating a bot

            ChatMessagesStackPanel = ChatStackPanel;//Assign UI elements
            ChatMessagesscrollViewer = MainScrollVieser;
            UserTextBox = ClientTextBox;

        }

        private void CloseWindow(object sender, EventArgs e) //Closing window method
        {
            Close();
        }

        private void HideShowWindow() //Hide window method with animation
        {
            if(this.IsVisible) 
            {
                WindowAnimation.FadeInAnimation(this, 0.1);
            }
            else 
            {
                WindowAnimation.FadeOutAnimation(this, 0.1);
            }
        }

        private void ClearChat(object sender, RoutedEventArgs e) //CLearing chat stackpanel end reseting chatbot conversation
        {
            AI.ClearConversation(); // Reset chatbot
            ChatMessagesStackPanel.Children.Clear();// Clear stack panel
        }

        private async void ConverstionTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.V)
            {
                TextBoxCustomBehaviour.PasteText(sender as TextBox);//Pasting raw text logic
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && e.Key == Key.Enter)
            {
                TextBoxCustomBehaviour.GoToNextRow(sender as TextBox);// Offseting logic
            }
            else if (e.Key == Key.Enter)
            {
                await UpdateChat();
            }
        }

        private async Task UpdateChat()// Main conversation logic
        {
            var Question = UserTextBox.Text;// Creating new textbox with user message
            var QuestionTextbox = new TextBox()
            {
                Text = Question,
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(5),
                Background = new SolidColorBrush(Color.FromRgb(52, 53, 65)),
                Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                FontSize = 13
            };

            ChatMessagesStackPanel.Children.Add(QuestionTextbox);

            UserTextBox.Text = "";

            var ResponseTextbox = new TextBox()// Creating response textbox with chatAI respond
            {
                IsReadOnly = true,
                TextWrapping = TextWrapping.Wrap,
                BorderThickness = new Thickness(0),
                Padding = new Thickness(5),
                Background = new SolidColorBrush(Color.FromRgb(68, 70, 84)),
                Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                FontSize = 13
            };

            ChatMessagesStackPanel.Children.Add(ResponseTextbox);

            var Response = AI.SendRequestAsync(Question);

            while (!Response.IsCompleted)//Simple animation to show process (Needs to be modified)
            {
                ResponseTextbox.Text = "Writing.";
                await Task.Delay(250);
                ResponseTextbox.Text = "Writing..";
                await Task.Delay(250);
                ResponseTextbox.Text = "Writing...";
                await Task.Delay(250);
            }

            var finalResponse = await Response;
            ResponseTextbox.Text = finalResponse;

            ChatMessagesscrollViewer.ScrollToEnd();
        }
    }
}
