using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace sud
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[] tb = new TextBox[82];

        public TextBox[] Tb { get => tb; set => tb = value; }

        public MainWindow()
        {
            InitializeComponent();
            Btn.Btn_size = new Rect(0, 0, Btn.Width, Btn.Height);
        }

        private void Startup(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 81; i++)
            {
                Tb[i] = new TextBox();
                Layoot.Children.Add(Tb[i]);
                Grid.SetColumn(Tb[i], (i % 9) + 1);
                Grid.SetRow(Tb[i], (i / 9) + 1);
                Tb[i].FontSize = 50;
                Tb[i].Name = "tb" + i.ToString();
                RegisterName("tb" + i.ToString(), Tb[i]);
                Tb[i].Background = new SolidColorBrush(Color.FromArgb(255, 229, 229, 229));
                Tb[i].MaxLength = 1;
                Tb[i].MaxLines = 1;
                Tb[i].TextAlignment = TextAlignment.Center;
                Tb[i].Padding = new Thickness(0, -13, 0, 0);
                Tb[i].TextChanged += new TextChangedEventHandler(Err);
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
        private void Press(object sender, RoutedEventArgs e)
        {
            bool error = false;
            List<int> errcell = new List<int>();
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
                var result = (MessageBox.Show("Ошибка в следующих ячейках " + string.Join(" ", errcell) + "\nПерейдти в неверную ячейку?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error));
                if (result == MessageBoxResult.Yes)
                {
                    (FindName("tb" + (errcell[0] - 1).ToString()) as TextBox).Focus();
                }
            }
            else
            {
                bool unreachible = false;
                bool back = false;
                int[] str = new int[82];
                int[] end = new int[82];
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
                for (int i = 0; i < 81; i++)
                {
                    if (back) { i -= 2; }
                    if (str[i] != 0) { continue; }
                    else
                    {
                        if (i < 0) { unreachible = true; break; }
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
                                        //MessageBox.Show("1 " + i.ToString() + " " + ((i / 9) * 9 + (ck1 * 3) + ck2).ToString() + " : " + end[i].ToString() +" "+ end[(i / 9) * 9 + (ck1 * 3) + ck2]);
                                        that = false;
                                        break;
                                    }
                                    else if ((end[i] == end[(i % 9) + ((ck1 * 3) + ck2) * 9]) && (i != (i % 9) + ((ck1 * 3) + ck2) * 9))
                                    {
                                        //MessageBox.Show("2");
                                        that = false;
                                        break;
                                    }
                                    else if ((end[i] == end[(((i / 3) * 3) - ((i / 9) * 9) + (((i / 9) / 3) * 3) * 9) + ((ck1 * 9) + ck2)]) && ((((i / 3) * 3) - ((i / 9) * 9) + (((i / 9) / 3) * 3) * 9) + ((ck1 * 9) + ck2) != i))
                                    {
                                        //MessageBox.Show("3");
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
                if (unreachible) { MessageBox.Show("Нерешаемо", "Error"); }
                else
                {
                    for (int i = 0; i < 81; i++)
                    {
                        (FindName("tb" + i.ToString()) as TextBox).Text = end[i].ToString();
                    }
                    MessageBox.Show("done");
                }
            }
        }
        private void Clear_butn(object sender, EventArgs e)
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
        }
        private void Drag(object sender, MouseEventArgs e)
        {
            if ((e.LeftButton == MouseButtonState.Pressed) && (e.GetPosition(this).Y <= 25))
                this.DragMove();
        }
        private void Dark_modeSLD(object sender, RoutedEventArgs e)
        {
            if (Layoot.IsLoaded)
            {
                minbt.Foreground = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(0 + (211 * slider.Value)), Convert.ToByte(0 + (211 * slider.Value)), Convert.ToByte(0 + (211 * slider.Value)))); //# FFD3D3D3
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
        private void Buttn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Close();
        }
    }
}







































