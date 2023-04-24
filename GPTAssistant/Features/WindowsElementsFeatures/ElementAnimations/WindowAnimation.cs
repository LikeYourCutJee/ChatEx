using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace GPTAssistant.Features.WindowsElementsFeatures.ElementAnimations
{
    class WindowAnimation
    {
        public static void FadeInAnimation(Window window, double durationInSec) 
        {

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(durationInSec)
            };

            fadeInAnimation.Completed += (s, e) => { window.Hide(); };

            window.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        }

        public static void FadeOutAnimation(Window window, double durationInSec)
        {
            window.Show();

            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(durationInSec)
            };


            window.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        } 
    }
}
