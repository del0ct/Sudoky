using System;
using System.ComponentModel;
using System.Data.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace sudb
{ 
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Buttn : UserControl
    {
        public Buttn()
        {
            InitializeComponent();
            this.DataContext = this;
            SetValue(DefaultButtonTextAttribute, "Btn");
        }

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register("Background_MouseOver", typeof(Brush), typeof(Panel), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(190, 230, 253)), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
        public static readonly DependencyProperty BackgroundDefaultProperty = DependencyProperty.Register("Default_Background", typeof(Brush), typeof(Panel), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(230, 230, 230)), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
        public static readonly DependencyProperty DefaultButtonTextAttribute = DependencyProperty.Register("DefaultButtontText", typeof(string), typeof(TextBlock),new PropertyMetadata("Btn"));
        public static readonly DependencyProperty ButtonSizeAttribute = DependencyProperty.Register("Btn_Size", typeof(Rect), typeof(RectangleGeometry), new PropertyMetadata(new Rect(0, 0, 300, 300)));
        public static readonly DependencyProperty RoundStrengthProperty = DependencyProperty.Register("RoundStrengt", typeof(double), typeof(RectangleGeometry), new PropertyMetadata((double)0));
        public static readonly DependencyProperty TimeToColorChangeProperty = DependencyProperty.Register("TimeColorChange", typeof(double), typeof(ColorAnimation), new PropertyMetadata((double)0));
        
        [Bindable(true)]
        [Category("Btn")]
        public double RoundStrength
        {
            get { return (double)GetValue(RoundStrengthProperty); }
            set { SetValue(RoundStrengthProperty, value); }
        }
        [Bindable(true)]
        [Category("Btn")]
        public Rect Btn_size
        {
            get { return (Rect)GetValue(ButtonSizeAttribute); }
            set { SetValue(ButtonSizeAttribute, value); }
        }
        [Bindable(true)]
        [Category("text")]
        public String TextOn
        {
            get { return (String)GetValue(DefaultButtonTextAttribute); }
            set { SetValue(DefaultButtonTextAttribute, value); }
        }
        [Bindable(true)]
        [Category("App")]
        public Brush Color_MouseOver
        {
            get { return (Brush)GetValue(BackgroundMouseOverProperty); }
            set { SetValue(BackgroundMouseOverProperty, value); }
        }
        [Bindable(true)]
        [Category("App")]
        public Brush ColorF
        {
            get { return (Brush)GetValue(BackgroundDefaultProperty); }
            set { SetValue(BackgroundDefaultProperty, value); }
        }
        [Bindable(true)]
        [Category("Btn")]
        public double TimeColorChange
        {
            get { return (double)GetValue(TimeToColorChangeProperty); }
            set { SetValue(TimeToColorChangeProperty, value); }
        }
        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        { 
            ColorAnimation Go = new ColorAnimation();
            Go.From = (bb.Background as SolidColorBrush).Color;
            Go.To = (Color_MouseOver as SolidColorBrush).Color;
            Go.Duration = TimeSpan.FromMilliseconds(TimeColorChange);
            bb.Background = new SolidColorBrush((bb.Background as SolidColorBrush).Color);
            bb.Background.BeginAnimation(SolidColorBrush.ColorProperty, Go);
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            ColorAnimation Go = new ColorAnimation();
            Go.From = (bb.Background as SolidColorBrush).Color;
            Go.To = (ColorF as SolidColorBrush).Color;
            Go.Duration = TimeSpan.FromMilliseconds(TimeColorChange);
            bb.Background = new SolidColorBrush((bb.Background as SolidColorBrush).Color);
            bb.Background.BeginAnimation(SolidColorBrush.ColorProperty, Go);
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ColorAnimation Go = new ColorAnimation();
            Go.From = (bb.Background as SolidColorBrush).Color;
            Go.To = Color.Add(Color.Multiply((Color_MouseOver as SolidColorBrush).Color, (float)0.5), Color.FromArgb(255, 0, 0, 0));
            Go.Duration = TimeSpan.FromMilliseconds(10);
            bb.Background = new SolidColorBrush((bb.Background as SolidColorBrush).Color);
            bb.Background.BeginAnimation(SolidColorBrush.ColorProperty, Go);
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ColorAnimation Go = new ColorAnimation();
            Go.From = (bb.Background as SolidColorBrush).Color;
            Go.To = Color.Add(Color.Multiply((Color_MouseOver as SolidColorBrush).Color, (float)1), Color.FromArgb(255, 0, 0, 0));
            Go.Duration = TimeSpan.FromMilliseconds(10);
            bb.Background = new SolidColorBrush((bb.Background as SolidColorBrush).Color);
            bb.Background.BeginAnimation(SolidColorBrush.ColorProperty, Go);
        } 
    }
}