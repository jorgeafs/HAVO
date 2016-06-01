using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HAVO.Views
{
    class ItemCell : ViewCell
    {
        public ItemCell()
        {
            var title = new Label
            {
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            title.SetBinding(Label.TextProperty, "Title");

            var detail = new Label
            {
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            detail.SetBinding(Label.TextProperty, "Detail");

            var tick = new Image
            {
                Source = FileImageSource.FromFile("check.png"),
                HorizontalOptions = LayoutOptions.End
            };

            tick.SetBinding(Image.IsVisibleProperty, "Done");

            var layout = new StackLayout
            {
                Padding = new Thickness(20, 0, 20, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { title, detail, tick }
            };

            View = layout;
        }
    }
}
