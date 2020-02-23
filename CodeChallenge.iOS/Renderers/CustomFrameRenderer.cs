using CodeChallenge.Components;
using CoreGraphics;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CodeChallenge.iOS.Renderers.CustomFrameRenderer))]
namespace CodeChallenge.iOS.Renderers
{
    class CustomFrameRenderer : Xamarin.Forms.Platform.iOS.FrameRenderer
    {
        public static void Initialize()
        {
            // empty, but used for beating the linker
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

            if (e.NewElement.HasShadow)
            {
                UpdateElevation();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if( e.PropertyName == CustomFrame.ElevationProperty.PropertyName)
            {
                UpdateElevation();
            }
        }

        private void UpdateElevation()
        {
            var frame = Element as CustomFrame;

            if (frame != null && frame.HasShadow)
            {
                Layer.ShadowRadius = frame.Elevation;
                Layer.ShadowColor = Color.Gray.ToCGColor();
                Layer.ShadowOffset = new CGSize(0,0);
                Layer.MasksToBounds = false;
                Layer.ShadowOpacity = 0.8f;
            }
        }
    }
}