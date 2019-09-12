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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Pickers;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Aplicacao4
{

    public sealed partial class MainPage : Page
    {
        // Observacao, nao adicionei pontuacao nos comentarios, por conta de evitar problemas.

        // Instancias da biblioteca
        CanvasDraw canvasDraw = new CanvasDraw();
        AutomateDraw automateDraw;
        ImageControl imageControl = new ImageControl();
        IconsControl iconsControl = new IconsControl();


        bool m_color = false, m_size = false, draw = false, m_image = false; // ferramentas do menu
        double size = 10; // tamanho padrão dos shapes
        Color color = Colors.White; // cor padrão branda
        string filename = String.Empty; // define nome do arquivo como vazio
        public MainPage()
        {
            this.InitializeComponent();
            automateDraw = new AutomateDraw(canvasDraw);

            var view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
            // Seta icone como Tela cheia
            iconsControl.SetGoWindowScreen(menu_fullScreen_icon);

            //remove os componentes do canvas
            canvasDraw.RemoveComponentCanvas(canvas, colorpicker, Sizeslider);

        }

        private void Menu_fullScreen_Click(object sender, RoutedEventArgs e)
        {
            var view = ApplicationView.GetForCurrentView();
            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
                // Troca o icone para modo tela Window
                iconsControl.SetGoWindowScreen(menu_fullScreen_icon);
                menu_fullScreen.Text = "Go to FullScreen";
            }
            else
            {
                view.TryEnterFullScreenMode();
                // Troca icone por tela cheia
                iconsControl.SetGoFullScreen(menu_fullScreen_icon);
                menu_fullScreen.Text = "Go to Window";
            }
        }

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (!m_color && !m_size)
            {
                // Caso a seleção de cor e tamanho não estejam selecionadas, ele insere o elemento no canvas.
                automateDraw.CreateElementPointerPressed(canvas, size, color, this, e);
            }
        }

        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!m_color && !m_size)
            {
                // seta cursor baseado no elemento que esta selecionado
                automateDraw.Cursors(canvas,size,e,color);
            }
        }

        private void Menu_draw_Click(object sender, RoutedEventArgs e)
        {
            draw = !draw;
            if (draw)
            {
                // deixa visivel os elementos de desenho
                canvasDraw.VisibleComponent(menu_square, menu_line, menu_circle,menu_rectangle,menu_color,menu_size,menu_text,menu_img);
                iconsControl.SetChecked(menu_draw_icon);
            }
            else
            {
                // oculta os elementos de desenho
                canvasDraw.HideComponent(menu_square, menu_line, menu_circle, menu_rectangle, menu_color, menu_size, menu_text, menu_img);
                iconsControl.SetNotIcon(menu_draw_icon);
            }
            
        }

        private void Colorpicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            // troca a cor atual
            color = args.NewColor;
        }

        private void Menu_size_Click(object sender, RoutedEventArgs e)
        {
            m_size = !m_size;
            if (m_size)
            {
                // caso o size slider for selecionado
                canvas.Children.Add(Sizeslider);
            }
            else
            {
                // caso o size slider for removido
                canvas.Children.Remove(Sizeslider);
            }
        }

        private void Sizeslider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            // novo tamanho do size slider
            size = e.NewValue;
        }

        private void Menu_color_Click(object sender, RoutedEventArgs e)
        {
            m_color = !m_color;
            if (m_color)
            {
                // adiciona color picker ao canvas
                canvas.Children.Add(colorpicker);
            }
            else
            {
                // remove color picker do canvas
                canvas.Children.Remove(colorpicker);
            }
        }

        private void Menu_text_Click(object sender, RoutedEventArgs e)
        {
            // ativa o texto de forma atuomatica
            automateDraw.Text = true;
        }
        private void Menu_rectangle_Click(object sender, RoutedEventArgs e)
        {
            // ativa retangulo
            automateDraw.Rectangle = true;
        }

        private void Menu_square_Click(object sender, RoutedEventArgs e)
        {
            // ativa quadrado
            automateDraw.Square = true;
        }

        private async void Menu_save_Click(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = KnownFolders.PicturesLibrary;
            folder = await folder.GetFolderAsync("RALIBRARY");
            Guid id = Guid.NewGuid(); // gera um novo id aleatorio

            if(filename == String.Empty)
            {
                // caso não tenha arquivo selecionado na tela
                await imageControl.saveImageAsync(canvas, folder, id.ToString() + ".jpg");
            }
            else
            {
                // caso já tenha algum arquivo selecionado
                await imageControl.saveImageAsync(canvas, folder, filename + ".jpg");
            }
        }

        private void Menu_new_Click(object sender, RoutedEventArgs e)
        {
            // limpa novo canvas e zera o id
            filename = String.Empty;
            canvas.Children.Clear();
        }

        private async void Menu_img_Click(object sender, RoutedEventArgs e)
        {
            m_image = !m_image;
            if (m_image)
            {
                iconsControl.SetChecked(menu_img_icon);

                Image img = await imageControl.GetImageFilePicker();
                if (img != null)
                {
                    // adiciona a imagem de fundo
                    imageControl.BackgroundImageDraw(canvas, img, 0.5);
                }

            }
            else
            {
                // remove a imagem de fundo
                imageControl.BackgroundImageDraw(canvas);
                iconsControl.SetNotIcon(menu_img_icon);
            }
        }

        private void Menu_circle_Click(object sender, RoutedEventArgs e)
        {
            // selecao de ciruclo
            automateDraw.Circle = true;
        }

        private void Menu_line_Click(object sender, RoutedEventArgs e)
        {
            // selecao de linha
            automateDraw.Line = true;
        }
    }
}
