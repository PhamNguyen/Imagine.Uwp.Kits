// ******************************************************************
// Copyright (c) 2017 by Nguyen Pham. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Imagine.Uwp.Kits.Controls
{
    /// <summary>
    /// Đây là control để hiển thị hình ảnh với 2 chế độ. Nếu không có Source thì mặc định hiển thị Placeholder. Ngoài ra cho phép tạo hình ảnh tròn thông qua thuộc tính CornerRadius
    /// </summary>
    public class ImageView : Control
    {
        private ImageBrush PART_DisplayImage;
        private Border PART_PlaceholderContainer;
        private Border PART_DisplayContainer;

        #region PlaceholderImageSource
        public DependencyProperty PlaceholderImageSourceProperty = DependencyProperty.Register("PlaceholderImageSource", typeof(ImageSource), typeof(ImageView), new PropertyMetadata(null));

        public ImageSource PlaceholderImageSource
        {
            set { this.SetValue(PlaceholderImageSourceProperty, value); }
            get { return (ImageSource)this.GetValue(PlaceholderImageSourceProperty); }
        }
        #endregion

        #region Source
        public DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageView), new PropertyMetadata(null));

        public ImageSource Source
        {
            set { this.SetValue(SourceProperty, value); }
            get { return (ImageSource)this.GetValue(SourceProperty); }
        }
        #endregion

        #region Stretch
        public DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ImageView), new PropertyMetadata(Windows.UI.Xaml.Media.Stretch.None));

        public Windows.UI.Xaml.Media.Stretch Stretch
        {
            set { this.SetValue(StretchProperty, value); }
            get { return (Windows.UI.Xaml.Media.Stretch)this.GetValue(StretchProperty); }
        }
        #endregion

        #region CornerRadius
        public DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ImageView), new PropertyMetadata(new CornerRadius(0)));

        public CornerRadius CornerRadius
        {
            set { this.SetValue(CornerRadiusProperty, value); }
            get { return (CornerRadius)this.GetValue(CornerRadiusProperty); }
        }
        #endregion

        public ImageView()
        {
            this.DefaultStyleKey = typeof(ImageView);
        }

        private void PART_DisplayImage_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ShowPlaceholderImage(true);
        }

        private void PART_DisplayImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            ShowPlaceholderImage(false);
        }

        private void ShowPlaceholderImage(bool isShow)
        {
            if(isShow)
            {
                PART_DisplayContainer.Visibility = Visibility.Collapsed;
                PART_PlaceholderContainer.Visibility = Visibility.Visible;
            }
            else
            {
                PART_DisplayContainer.Visibility = Visibility.Visible;
                PART_PlaceholderContainer.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnApplyTemplate()
        {
            this.PART_DisplayImage = (ImageBrush)GetTemplateChild(nameof(PART_DisplayImage));
            this.PART_DisplayImage.ImageOpened += PART_DisplayImage_ImageOpened;
            this.PART_DisplayImage.ImageFailed += PART_DisplayImage_ImageFailed;
            this.PART_PlaceholderContainer = (Border)GetTemplateChild(nameof(PART_PlaceholderContainer));
            this.PART_DisplayContainer = (Border)GetTemplateChild(nameof(PART_DisplayContainer));
        }
    }
}
