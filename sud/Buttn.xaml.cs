using System;
using System.ComponentModel;
using System.Data.Common;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Buttn
    /// </summary>
    public partial class Buttn : UserControl
    {
        public static readonly RoutedEvent Press_ButtonEvent = EventManager.RegisterRoutedEvent("Press_Button",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Buttn));
        public Buttn()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        
        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register("Background_MouseOver", typeof(Brush), typeof(Panel), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(190, 230, 253)), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
        public static readonly DependencyProperty BackgroundDefaultProperty = DependencyProperty.Register("Default_Background", typeof(Brush), typeof(Panel), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(230, 230, 230)), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
        public static readonly DependencyProperty DefaultButtonTextAttribute = DependencyProperty.Register("DefaultButtontText", typeof(string), typeof(TextBlock), new PropertyMetadata("Btn"));
        public static readonly DependencyProperty RoundStrengthProperty = DependencyProperty.Register("RoundStrengt", typeof(double), typeof(RectangleGeometry), new PropertyMetadata((double)0));
        public static readonly DependencyProperty TimeToColorChangeProperty = DependencyProperty.Register("TimeColorChange", typeof(double), typeof(ColorAnimation), new PropertyMetadata((double)0));
        public static readonly DependencyProperty PaddingX_Property = DependencyProperty.Register("Padding_X", typeof(double), typeof(Transform), new PropertyMetadata((double)0));
        public static readonly DependencyProperty PaddingY_Property = DependencyProperty.Register("Padding_Y", typeof(double), typeof(Transform), new PropertyMetadata((double)0));

        public event RoutedEventHandler Press_Button
        { 
            add
            {
                // добавление обработчика
                AddHandler(Buttn.Press_ButtonEvent, value);
            }
            remove
            {
                // удаление обработчика
                RemoveHandler(Buttn.Press_ButtonEvent, value);
            }
        }

        [Bindable(true)]
        [Category("Btn")]
        public double RoundStrength
        {
            get { return (double)GetValue(RoundStrengthProperty); }
            set { SetValue(RoundStrengthProperty, value); }
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
        public double PaddingX
        {
            get { return (double)GetValue(PaddingX_Property); }
            set { SetValue(PaddingX_Property, value); }
        }
        public double PaddingY
        {
            get { return (double)GetValue(PaddingY_Property); }
            set { SetValue(PaddingY_Property, value); }
        }
        public new double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        public new double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
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
            if ((this.IsMouseOver))
            {
                RaiseEvent(new RoutedEventArgs(Press_ButtonEvent));
            }
        }
        private void Loaded_seter_RectSize(object sender, RoutedEventArgs e)
        {
            Rect.Rect = new Rect(0, 0, Width, Height);
        }
    }
}