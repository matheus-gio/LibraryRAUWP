using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using RALIBRARY_V2;
using Windows.UI;
using Windows.Storage;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Aplicacao4
{

    public sealed partial class MainPage : Page
    {
        CanvasDraw canvasDraw = new CanvasDraw();
        AutomateDraw automateDraw;
        IconsControl iconsControl = new IconsControl();
        bool m_color = false, m_size = false, draw = false;
        int time = 0;
        double size = 10;
        Color color = Colors.White;
        string filename = String.Empty;
        public MainPage()
        {
            this.InitializeComponent();
            automateDraw = new AutomateDraw(canvasDraw);
            // Go to Full Screen
            var view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
            // set icon go to window
            iconsControl.SetGoWindowScreen(menu_fullScreen_icon);

            //remove canvas colorpicker and 
            canvasDraw.RemoveComponentCanvas(canvas, colorpicker, Sizeslider);

        }

        private void Menu_fullScreen_Click(object sender, RoutedEventArgs e)
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                // Change icon and Text Button go to Window
                iconsControl.SetGoWindowScreen(menu_fullScreen_icon);
                menu_fullScreen.Text = "Go to FullScreen";
            }
            else
            {
                view.TryEnterFullScreenMode();
                // Change icon and Text Button go to FullScreen
                iconsControl.SetGoFullScreen(menu_fullScreen_icon);
                menu_fullScreen.Text = "Go to Window";
            }
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (!m_color && !m_size)
            {
                automateDraw.CreateElementPointerPressed(canvas, size, color, this, e);
            }
        }

        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!m_color && !m_size)
            {
                automateDraw.Cursors(canvas,size,e,color);
            }
        }

        private void Menu_draw_Click(object sender, RoutedEventArgs e)
        {
            draw = !draw;
            if (draw)
            {
                canvasDraw.VisibleComponent(menu_square, menu_line, menu_circle,menu_rectangle,menu_color,menu_size,menu_text);
                iconsControl.SetChecked(menu_draw_icon);
            }
            else
            {
                canvasDraw.HideComponent(menu_square, menu_line, menu_circle, menu_rectangle, menu_color, menu_size, menu_text);
                iconsControl.SetNotIcon(menu_draw_icon);
            }
            
        }

        private void Colorpicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            color = args.NewColor;
        }

        private void Menu_size_Click(object sender, RoutedEventArgs e)
        {
            m_size = !m_size;
            if (m_size)
            {
                canvas.Children.Add(Sizeslider);
            }
            else
            {
                canvas.Children.Remove(Sizeslider);
            }
        }

        private void Sizeslider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            size = e.NewValue;
        }

        private void Menu_color_Click(object sender, RoutedEventArgs e)
        {
            m_color = !m_color;
            if (m_color)
            {
                canvas.Children.Add(colorpicker);
            }
            else
            {
                canvas.Children.Remove(colorpicker);
            }
        }

        private void Menu_text_Click(object sender, RoutedEventArgs e)
        {
            automateDraw.Text = true;
        }
        private void Menu_rectangle_Click(object sender, RoutedEventArgs e)
        {
            automateDraw.Rectangle = true;
        }

        private void Menu_square_Click(object sender, RoutedEventArgs e)
        {
            automateDraw.Square = true;
        }

        private async void Menu_save_Click(object sender, RoutedEventArgs e)
        {
            ImageControl imageControl = new ImageControl();
            StorageFolder folder = KnownFolders.PicturesLibrary;
            folder = await folder.GetFolderAsync("RALIBRARY");
            Guid id = Guid.NewGuid();

            if(filename == String.Empty)await imageControl.saveImageAsync(canvas, folder, id.ToString() + ".jpg");
        }

        private void Menu_new_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void Menu_circle_Click(object sender, RoutedEventArgs e)
        {
            automateDraw.Circle = true;
        }

        private void Menu_line_Click(object sender, RoutedEventArgs e)
        {
            automateDraw.Line = true;
        }
    }
}
