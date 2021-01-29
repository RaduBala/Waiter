using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Waiter.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            ImageSource imageSource = null;

            if( !String.IsNullOrWhiteSpace(ResourceId) )
            {
                imageSource = ImageSource.FromResource(ResourceId);
            }

            return imageSource;
        }
    }
}
