using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AdaptiveCards.Rendering.Uwp;
// ...

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CardTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string jsonString = "{\"type\":\"AdaptiveCard\",\"version\":\"1.0\",\"body\":[{\"type\":\"TextBlock\",\"text\":\"Here is a ninja cat [hover me](https://www.google.com)\"},{\"type\":\"Image\",\"url\":\"http://adaptivecards.io/content/cats/1.png\"}]}";
        public MainPage()
        {
            this.InitializeComponent();
            var renderer = new AdaptiveCardRenderer();
            var card = AdaptiveCard.FromJsonString(jsonString).AdaptiveCard;

            RenderedAdaptiveCard renderedAdaptiveCard = renderer.RenderAdaptiveCard(card);

            // Check if the render was successful
            if (renderedAdaptiveCard.FrameworkElement != null)
            {
                // Get the framework element
                var uiCard = renderedAdaptiveCard.FrameworkElement;

                // Add it to your UI
                myGrid.Children.Add(uiCard);
            }

        }
    }
}
