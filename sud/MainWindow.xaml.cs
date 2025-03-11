using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Linq;

namespace sud
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[] tb = new TextBox[82];

        public int[] end = new int[82];
        public int[] str = new int[82];

        public TextBox[] Tb { get => tb; set => tb = value; }

        public MainWindow()
        {

            InitializeComponent();
        }

        private void Startup(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 81; i++)
            {
                Tb[i] = new TextBox();
                Layoot.Children.Add(Tb[i]);
                Grid.SetColumn(Tb[i], (i % 9) + 1 + (i % 9));
                Grid.SetRow(Tb[i], (i / 9) + 1 + (i / 9));
                Tb[i].FontSize = 50;
                Tb[i].Name = "tb" + i.ToString();
                RegisterName("tb" + i.ToString(), Tb[i]);
                Tb[i].Background = new SolidColorBrush(Color.FromArgb(255, 229, 229, 229));
                Tb[i].MaxLength = 1;
                Tb[i].MaxLines = 1;
                Tb[i].TextAlignment = TextAlignment.Center;
                Tb[i].Padding = new Thickness(0, -13, 0, 0);
                Tb[i].PreviewTextInput += new TextCompositionEventHandler(Selectchanj);
                Tb[i].TextChanged += new TextChangedEventHandler(Err);
                Tb[i].PreviewKeyDown += new KeyEventHandler(TestBTN);
            }
        }
        private void Close_bybtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Minim_bybtn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Solve()
        {
            bool back = false;
            for (int i = 0; i < 81; i++)
            {
                if (back) { i -= 2; }
                if (i < 0) { break; }
                if (str[i] != 0) { continue; }
                else
                {
                    int start = 1;
                    if (back)
                    {
                        start = end[i] + 1;
                        if (start > 9)
                        {
                            end[i] = 0;
                            continue;
                        }
                    }
                    for (int j = start; j < 10; j++)
                    {
                        bool that = true;
                        end[i] = j;
                        for (int ck1 = 0; ck1 < 3; ck1++)
                        {
                            for (int ck2 = 0; ck2 < 3; ck2++)
                            {
                                if ((end[i] == end[(i / 9) * 9 + (ck1 * 3) + ck2]) && (i != (i / 9) * 9 + (ck1 * 3) + ck2))
                                {
                                    that = false;
                                    break;
                                }
                                else if ((end[i] == end[(i % 9) + ((ck1 * 3) + ck2) * 9]) && (i != (i % 9) + ((ck1 * 3) + ck2) * 9))
                                {
                                    that = false;
                                    break;
                                }
                                else if ((end[i] == end[(((i / 3) * 3) - ((i / 9) * 9) + (((i / 9) / 3) * 3) * 9) + ((ck1 * 9) + ck2)]) && ((((i / 3) * 3) - ((i / 9) * 9) + (((i / 9) / 3) * 3) * 9) + ((ck1 * 9) + ck2) != i))
                                {
                                    that = false;
                                    break;
                                }
                            }
                            if (!that)
                            {
                                break;
                            }
                        }
                        if (that)
                        {
                            back = false;
                            break;
                        }
                        else if (j == 9)
                        {
                            back = true;
                            end[i] = 0;
                        }
                    }
                }
            }
        }
        private async void Press(object sender, RoutedEventArgs e)
        {
            bool error = false;
            List<int> errcell = new List<int>();
            List<int> march8 = new List<int> { 3, 7, 11, 13, 15, 17, 19, 23, 27, 28, 36, 38, 44, 47, 53, 57, 61, 67, 69, 77 };
            errcell.Clear();
            for (int i = 0; i < 81; i++)
            {
                if (((FindName("tb" + i.ToString()) as TextBox).Background as SolidColorBrush).Color.G == 0)
                {
                    error = true;
                    errcell.Add(i + 1);
                }
            }
            if (error)
            {
                ///
                /// Включение на 8-е февраля
                /// 
                if (errcell.SequenceEqual(march8))
                {
                    Window2 window2 = new Window2();
                    window2.Topmost = true;
                    window2.Show();
                }
                else
                {
                    var result = (MessageBox.Show("Ошибка в следующих ячейках " + string.Join(" ", errcell) + "\nПерейдти в неверную ячейку?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error));
                    if (result == MessageBoxResult.Yes)
                    {
                        (FindName("tb" + (errcell[0] - 1).ToString()) as TextBox).Focus();
                    }
                }
            }
            else
            {
                for (int i = 0; i < 81; i++)
                {
                    if ((FindName("tb" + i.ToString()) as TextBox).Text != "")
                    {
                        str[i] = Convert.ToInt32((FindName("tb" + i.ToString()) as TextBox).Text);
                        end[i] = Convert.ToInt32((FindName("tb" + i.ToString()) as TextBox).Text);
                    }
                    else
                    {
                        str[i] = 0;
                        end[i] = 0;
                    }
                }
                await Task.Run(Solve);
                for (int i = 0; i < 81; i++)
                {
                    if (end[i] != 0)
                    {
                        (FindName("tb" + i.ToString()) as TextBox).Text = end[i].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Unreachible", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                    if (i == 80)
                        MessageBox.Show("Complite", "Done", MessageBoxButton.OK);
                }
            }
        }
        private void Clear_butn(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 81; i++)
            {
                (FindName("tb" + i.ToString()) as TextBox).Text = "";
            }
        }
        private void Err(object sender, TextChangedEventArgs e)
        {
            bool err = true;
            for (int i = 1; i < 10; i++)
            {
                if ((((sender as TextBox).Text) == i.ToString()) || (((sender as TextBox).Text) == ""))
                {
                    err = false;
                }
            }
            if (err)
            {
                (sender as TextBox).Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(255 - (26 * slider.Value)), 0, 0));
            }
            else
            {
                (sender as TextBox).Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(255 - (26 * slider.Value)), Convert.ToByte(255 - (26 * slider.Value)), Convert.ToByte(255 - (26 * slider.Value))));
            }
            if (e.Changes.First().AddedLength == 1)
            {
                if (Convert.ToInt32((sender as TextBox).Name.Substring(2)) + 1 <= 80)
                {
                    (FindName("tb" + (Convert.ToInt32((sender as TextBox).Name.Substring(2)) + 1).ToString()) as TextBox).Focus();
                }
                else
                {
                    (FindName("tb" + 0.ToString()) as TextBox).Focus();
                }
            }
        }
        private void TestBTN(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Back) && (Keyboard.FocusedElement.GetType() == typeof(TextBox)))
            {
                TextBox nowfocus = Keyboard.FocusedElement as TextBox;
                if (Convert.ToInt32((nowfocus).Name.Substring(2)) - 1 >= 0)
                {
                    (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) - 1).ToString()) as TextBox).Focus();
                }
                else
                {
                    (FindName("tb" + 80.ToString()) as TextBox).Focus();
                }
            }
            if (((e.Key == Key.Up) || (e.Key == Key.Left) || (e.Key == Key.Right) || (e.Key == Key.Down)) && (Keyboard.FocusedElement.GetType() == typeof(TextBox)))
            {
                TextBox nowfocus = Keyboard.FocusedElement as TextBox;

                if (Keyboard.FocusedElement.GetType() == typeof(TextBox))
                {
                    (Keyboard.FocusedElement as TextBox).SelectionStart = 0;
                    (Keyboard.FocusedElement as TextBox).SelectionLength = 2;
                }
                switch (e.Key.ToString())
                {
                    case "Up":
                        if (Convert.ToInt32((nowfocus).Name.Substring(2)) - 9 >= 0)
                        {
                            (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) - 9).ToString()) as TextBox).Focus();
                        }
                        else
                        {
                            (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) + 72).ToString()) as TextBox).Focus();
                        }
                        break;
                    case "Down":
                        if (Convert.ToInt32((nowfocus).Name.Substring(2)) + 9 <= 80)
                        {
                            (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) + 9).ToString()) as TextBox).Focus();
                        }
                        else
                        {
                            (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) - 72).ToString()) as TextBox).Focus();
                        }
                        break;
                    case "Left":
                        if (Convert.ToInt32((nowfocus).Name.Substring(2)) - 1 >= 0)
                        {
                            (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) - 1).ToString()) as TextBox).Focus();
                        }
                        break;
                    case "Right":
                        if (Convert.ToInt32((nowfocus).Name.Substring(2)) + 1 <= 80)
                        {
                            (FindName("tb" + (Convert.ToInt32((nowfocus).Name.Substring(2)) + 1).ToString()) as TextBox).Focus();

                        }
                        break;
                }
            }
        }
        private void Drag(object sender, MouseEventArgs e)
        {
            if ((e.LeftButton == MouseButtonState.Pressed) && (e.GetPosition(this).Y <= 25) && (e.GetPosition(this).X < 510))
                this.DragMove();
        }
        private void Dark_modeSLD(object sender, RoutedEventArgs e)
        {
            if (Layoot.IsLoaded)
            {
                minbt.Foreground = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(0 + (211 * slider.Value)), Convert.ToByte(0 + (211 * slider.Value)), Convert.ToByte(0 + (211 * slider.Value))));
                clsbt.Foreground = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(0 + (211 * slider.Value)), Convert.ToByte(0 + (211 * slider.Value)), Convert.ToByte(0 + (211 * slider.Value))));
                gsup.Color = Color.FromArgb(255, Convert.ToByte(170 - (149 * slider.Value)), Convert.ToByte(170 - (149 * slider.Value)), Convert.ToByte(170 - (149 * slider.Value)));
                gsdw.Color = Color.FromArgb(255, Convert.ToByte(255 - (221 * slider.Value)), Convert.ToByte(255 - (221 * slider.Value)), Convert.ToByte(255 - (221 * slider.Value)));
                title.Foreground = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(255 * slider.Value), Convert.ToByte(255 * slider.Value), Convert.ToByte(255 * slider.Value)));
                for (int i = 0; i < 81; i++)
                {
                    if (((FindName("tb" + i.ToString()) as TextBox).Background as SolidColorBrush).Color.G > 0)
                    {
                        (FindName("tb" + i.ToString()) as TextBox).Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(255 - (26 * slider.Value)), Convert.ToByte(255 - (26 * slider.Value)), Convert.ToByte(255 - (26 * slider.Value))));
                    }
                    else
                    {
                        (FindName("tb" + i.ToString()) as TextBox).Background = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(255 - (26 * slider.Value)), 0, 0));
                    }
                }
            }
        } 
        private void Selectchanj(object sender, TextCompositionEventArgs e)
        {
            (e.Source as TextBox).Text = null;
        }
    }
}