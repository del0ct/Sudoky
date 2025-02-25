using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows;
using Windows.Devices.WiFiDirect;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Size = Windows.Foundation.Size;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419
namespace App1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ///Provider.CanResize
        }

        private void end(string[,] sol)
        {
            Aatb.Text = sol[0, 0];
            Astb.Text = sol[0, 1];
            Adtb.Text = sol[0, 2];
            Aftb.Text = sol[0, 3];
            Agtb.Text = sol[0, 4];
            Ahtb.Text = sol[0, 5];
            Ajtb.Text = sol[0, 6];
            Aktb.Text = sol[0, 7];
            Altb.Text = sol[0, 8];
            Satb.Text = sol[1, 0];
            Sstb.Text = sol[1, 1];
            Sdtb.Text = sol[1, 2];
            Sftb.Text = sol[1, 3];
            Sgtb.Text = sol[1, 4];
            Shtb.Text = sol[1, 5];
            Sjtb.Text = sol[1, 6];
            Sktb.Text = sol[1, 7];
            Sltb.Text = sol[1, 8];
            Datb.Text = sol[2, 0];
            Dstb.Text = sol[2, 1];
            Ddtb.Text = sol[2, 2];
            Dftb.Text = sol[2, 3];
            Dgtb.Text = sol[2, 4];
            Dhtb.Text = sol[2, 5];
            Djtb.Text = sol[2, 6];
            Dktb.Text = sol[2, 7];
            Dltb.Text = sol[2, 8];
            Fatb.Text = sol[3, 0];
            Fstb.Text = sol[3, 1];
            Fdtb.Text = sol[3, 2];
            Fftb.Text = sol[3, 3];
            Fgtb.Text = sol[3, 4];
            Fhtb.Text = sol[3, 5];
            Fjtb.Text = sol[3, 6];
            Fktb.Text = sol[3, 7];
            Fltb.Text = sol[3, 8];
            Gatb.Text = sol[4, 0];
            Gstb.Text = sol[4, 1];
            Gdtb.Text = sol[4, 2];
            Gftb.Text = sol[4, 3];
            Ggtb.Text = sol[4, 4];
            Ghtb.Text = sol[4, 5];
            Gjtb.Text = sol[4, 6];
            Gktb.Text = sol[4, 7];
            Gltb.Text = sol[4, 8];
            Hatb.Text = sol[5, 0];
            Hstb.Text = sol[5, 1];
            Hdtb.Text = sol[5, 2];
            Hftb.Text = sol[5, 3];
            Hgtb.Text = sol[5, 5];
            Hhtb.Text = sol[5, 5];
            Hjtb.Text = sol[5, 6];
            Hktb.Text = sol[5, 7];
            Hltb.Text = sol[5, 8];
            Jatb.Text = sol[6, 0];
            Jstb.Text = sol[6, 1];
            Jdtb.Text = sol[6, 2];
            Jftb.Text = sol[6, 3];
            Jgtb.Text = sol[6, 4];
            Jhtb.Text = sol[6, 5];
            Jjtb.Text = sol[6, 6];
            Jktb.Text = sol[6, 7];
            Jltb.Text = sol[6, 8];
            Katb.Text = sol[7, 0];
            Kstb.Text = sol[7, 1];
            Kdtb.Text = sol[7, 2];
            Kftb.Text = sol[7, 3];
            Kgtb.Text = sol[7, 4];
            Khtb.Text = sol[7, 5];
            Kjtb.Text = sol[7, 6];
            Kktb.Text = sol[7, 7];
            Kltb.Text = sol[7, 8];
            Latb.Text = sol[8, 0];
            Lstb.Text = sol[8, 1];
            Ldtb.Text = sol[8, 2];
            Lftb.Text = sol[8, 3];
            Lgtb.Text = sol[8, 4];
            Lhtb.Text = sol[8, 5];
            Ljtb.Text = sol[8, 6];
            Lktb.Text = sol[8, 7];
            Lltb.Text = sol[8, 8];
        } // тут чито вывод обратно в таблицу//

            //Size d = new Size(500, 500);
            //Window.Current.Content.RenderTransform = d;
            private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
               // 
            }

            //this.XamlRoot.Size = new ;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ниже создание переменных и перевод в них из окна программы
            string[,] inp = {
                { Aatb.Text, Astb.Text, Adtb.Text, Aftb.Text, Agtb.Text, Ahtb.Text, Ajtb.Text, Aktb.Text, Altb.Text },
{ Satb.Text, Sstb.Text, Sdtb.Text, Sftb.Text, Sgtb.Text, Shtb.Text, Sjtb.Text, Sktb.Text, Sltb.Text },
{ Datb.Text, Dstb.Text, Ddtb.Text, Dftb.Text, Dgtb.Text, Dhtb.Text, Djtb.Text, Dktb.Text, Dltb.Text },
{ Fatb.Text, Fstb.Text, Fdtb.Text, Fftb.Text, Fgtb.Text, Fhtb.Text, Fjtb.Text, Fktb.Text, Fltb.Text },
{ Gatb.Text, Gstb.Text, Gdtb.Text, Gftb.Text, Ggtb.Text, Ghtb.Text, Gjtb.Text, Gktb.Text, Gltb.Text },
{ Hatb.Text, Hstb.Text, Hdtb.Text, Hftb.Text, Hgtb.Text, Hhtb.Text, Hjtb.Text, Hktb.Text, Hltb.Text },
{ Jatb.Text, Jstb.Text, Jdtb.Text, Jftb.Text, Jgtb.Text, Jhtb.Text, Jjtb.Text, Jktb.Text, Jltb.Text },
{ Katb.Text, Kstb.Text, Kdtb.Text, Kftb.Text, Kgtb.Text, Khtb.Text, Kjtb.Text, Kktb.Text, Kltb.Text },
{ Latb.Text, Lstb.Text, Ldtb.Text, Lftb.Text, Lgtb.Text, Lhtb.Text, Ljtb.Text, Lktb.Text, Lltb.Text } };
            int[,][,] sol = new int[3, 3][,];
            for (int ia = 0; ia < 3; ia++) for (int ib = 0; ib < 3; ib++)
                {
                    sol[ia, ib] = new int[3, 3];
                    for (int oa = 0; oa < 3; oa++) for (int ob = 0; ob < 3; ob++)
                            if (string.IsNullOrEmpty(inp[ia * 3 + oa, ib * 3 + ob]))
                                sol[ia, ib][oa, ob] = 0;
                            else
                                sol[ia, ib][oa, ob] = int.Parse(inp[ia * 3 + oa, ib * 3 + ob]);
                }
            //тут решение судоку
            bool forw = true;
            back:
            if (!forw) {  }
            for (int ia = 0; ia < 3; ia++) for (int ib = 0; ib < 3; ib++)
                    for (int ja = 0;  ja < 3; ja++) for (int jb = 0; jb < 3; jb++)
                        {
                            if ((sol[ia, ib][ja, jb] != 0) && !(string.IsNullOrEmpty(inp[ia * 3 + ja, ib * 3 + jb])))
                                if (int.Parse(inp[ia * 3 + ja, ib * 3 + jb]) == 0)
                                    if (forw) continue;
                                    else
                                    {
                                        forw = false;
                                        goto back;
                                    }
                                else;
                            else
                            {

                            }
                            /*Проверка на не нулевое в массиве. Проверка на то что в начальном массиве не пусто. 
                             * Проверка не вводится ли 0*/
                                {
                                bool pod = false;
                                for (int pdbr = 1; pdbr < 10; pdbr++)
                                    if ((sol[ia, ib][ja, jb] == pdbr))
                                        continue;
                                    else
                                    {
                                        for (int pdbrja = 0; pdbrja < 9; pdbrja++)
                                            for (int pdbrjb = 0; pdbrjb < 9; pdbrjb++) ;

                                    }
                            }
                        }
            //ниже обратное преобразование
            for (int ia = 0; ia < 3; ia++) for (int ib = 0; ib < 3; ib++) 
                    for (int ja = 0; ja < 3; ja++) for (int jb = 0; jb < 3; jb++)
                            inp[ia * 3 + ja, ib * 3 + jb] = Convert.ToString(sol[ia, ib][ja, jb]);
            end(inp);
        } // тут функционал единственной кнопки(сделан перевод текста в массив, доделать логику)
    
        private void err(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            SolidColorBrush errBack = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 210, 20, 80));
            SolidColorBrush errBacktext = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 210, 210, 210));
            SolidColorBrush def = new SolidColorBrush(Windows.UI.Color.FromArgb(153, 255, 255, 255));
            SolidColorBrush deftext = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 0, 0));
            var tt = new ToolTip();
            tt.Content = "Можно только цифры";
            if ((sender.Text != "1") && (sender.Text != "2") && (sender.Text != "3") && (sender.Text != "4") && (sender.Text != "5") && (sender.Text != "6") && (sender.Text != "7") && (sender.Text != "8") && (sender.Text != "9"))
            {
                sender.Background = errBack;
                sender.Foreground = errBacktext;
            }
            else
            {
                sender.Background = def;
                sender.Foreground = deftext;
            }

        } // нужно подумать над popup для текста (можно подумать над полным перерисовщиком), оформить ошибку при не возможном вводе(думаю после основной логики)
    }
}
