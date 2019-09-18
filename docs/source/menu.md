
# Getstarted
Para utilizar a biblioteca se faz necessário a instalação do Desenvolvimento com a plataforma universal do windows.
A instalação e a criação de projeto que vamos utiliizar para uma breve explicação pode-ser encontrada em : Configuração e inicialização de um projeto em branco <https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up>.

# Adicao Biblioteca

Após a instalação e inicialização do projeto é necessário adicionar a DLL da biblioteca, para realizar este procedimento siga os seguintes passos :
1. Clique com o botão direito em referências
2. Adicionar Referência
3. Procurar
4. Encontre o arquivo no disco e precione adicionar
5. Pronto a biblioteca foi adicionada, agora é so codar.

# Exemplos básicos


Criação quadrado
------
O exemplo abaixo foi criado para criar um quadrado de tamanho 200 na posicao (300,300) do canvas.

	CanvasDraw canvasDraw = new CanvasDraw();
    canvasDraw.CreateSquarePosition(canvas, 200, Color.FromArgb(255,255,255,255), 300, 300);

Exportar uma imagem do canvas
------
O exemplo abaixo foi criado para criar um quadrado de tamanho 200 na posicao (300,300) do canvas.

	ImageControl imageControl = new ImageControl();
	StorageFolder pasta = KnownFolders.PicturesLibrary;
	String nome_arquivo = "nome_mapeamento.png";
	imageControl.saveImageAsync(canvas, pasta, nome_arquivo);

Exibição imagens do disco
-----
Abaixo segue um código de exemplo, onde as imagens do disco da pasta de fotos->teste são colocadas em uma lista para serem exibidas no canvas, estas imagens devem ser geradas anteriormente de forma a serem exibidos os mapeamentos dos objetos que serão apresentados a Realidade Aumentada

		// Instancias da biblioteca
        ImageControl imageControl = new ImageControl();

        List<Image> list_imagens = null; // Lista de imagens para exibição

        int time = 2000; // tempo troca de imagens
        public MainPage()
        {
            this.InitializeComponent();

            Thread t1 = new Thread(ImagensCanvas);
            t1.Start();

        }

        private async void ImagensCanvas()
        {
            // Pega as imagens do disco
            StorageFolder folder = KnownFolders.PicturesLibrary; // encontra a pasta imagens
            folder = await folder.GetFolderAsync("teste"); // requisita a pasta teste dentro de imagens
            list_imagens = await imageControl.GetDiskImagesAsync(folder);

            int cont = 0;
            while (true)
            {
                if (list_imagens != null)
                {
                    if (cont > list_imagens.Count) // verifica se tem mais imagens que o contador atual
                    {
                        cont = 0; // zera o contador
                    }
                    if (list_imagens.Count > 0) // garante que tenha uma imagem
                    {
                        await imageControl.AddImgtoCanvasAsync(canvas, list_imagens[cont]); // adicionar a imagem no canvas
                    }
                }
                Thread.Sleep(time); // tempo definido para a thread aguardar
            }
        }

Tela cheia e Window
-----
Abaixo segue um código de exemplo para deixar o canvas em tela cheia e em Window.

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


Download imagens WEB para disco
-----
Segue o código que realiza o download de imagens para o disco.

			// url que será usado para formar a url final juntamente com nome das imagens
            String url_base = "http://exemple.com/images/";

            List<String> nome_imagens = new List<String>();
            // abaixo nome das imagens
            nome_imagens.Add("imagem1.jpg");
            nome_imagens.Add("imagem1.png");
            nome_imagens.Add("imagem2.jpg");
            nome_imagens.Add("imagem3.png");
            nome_imagens.Add("imagem4.jpg");
            nome_imagens.Add("imagem5.jpg");

            StorageFolder pasta_destino = KnownFolders.PicturesLibrary;
            pasta_destino = await pasta_destino.GetFolderAsync("imagens_web");

            imageControl.GetImagesWebAsync(url_base, nome_imagens, pasta_destino);
            // realiza internamente o download das imagens de forma asyncrona

Inicializar Vídeo
-----
Segue o código para inicilizar vídeo presente em disco.

		StorageFolder videos_folder = await KnownFolders.VideosLibrary.GetFolderAsync("videos_ra");
            // pega o arquivo do disco
            StorageFile videofile = await videos_folder.GetFileAsync("video.mp4");

            VideoControl videoControl = new VideoControl();

            // passa o arquivo de video e o elemento do xaml.
            videoControl.StartVideo(videofile, UImediaElement);


# Referência

Segue abaixo a referência da biblioteca.

Cursor Mouse
-----

* Classe AutomateDraw

    * Cursor de Seta - SetArrowCursor()
    ********
    * Sem cursor - SetNoneCursor()
    ********
    * Setar Cursor Automaticamente - Cursors(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color) 
    ********

* Classe CanvasDraw
    * Cursor de Circulo - Cursor_Circle(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)
    ********
    * Cursor Quadrado- Cursor_Square(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)
    ********
    * Cursor de Linha - Cursor_Line(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)
    ********


Arquivos
-----

* Classe VideoControl
    * Ler Duração Vídeo - GetDurationVideoAsync(StorageFile)
    ********
    * Iniciar Vídeo - StartVideo(StorageFile, MediaElement
    ********


* Classe ImageControl
    * Ler Imagens de Disco - GetDiskImagesAsync(StorageFolder)
    ********
    * Baixar pacote de Imagens via URL - GetImagesWebAsync(String url_base, List list_nomes, StorageFolder)
    ********
    * Baixar Imagem via URL - DownloaImageDisk(string url_base, string path_file, StorageFolder)
    ********
    * Ler Arquivos Disco - GetDiskFileAsync(StorageFolder)
    ********
    * File Picker para Imagem - GetImageFilePicker()
    ********


Canvas
-----

* Classe ImageControl
    * Salvar em disco - saveImageAsync(Canvas, StorageFolder, string nome)
    ********
    * Adicionar imagem do disco - AddImgtoCanvasAsync(Canvas, Image)
    ********
    * Remover Imagem de auxilio - BackgroundImageDraw(Canvas canvas)
    ********
    * Adicionar Imagem de auxilio - BackgroundImageDraw(Canvas canvas, Image img_draw, double opacity)
    ********


* Classe AutomateDraw
    * Verificar seleção de Menu - Text, Line, Square, Circle, Rectangle
    ********
    * Criar componente baseado em click e no menu - CreateElementPointerPressed(Canvas,double size, Color, UIElement, PointerRoutedEventArgs)
    ********
    * Limpar Canvas - ClearCanvas(Canvas canvas)
    ********
    * Desfazer última ação - Undo_Draw(Canvas canvas)
    ********

* Classe CanvasDraw
    * Esquerdo Pressionado - LeftPressed(PointerRoutedEventArgs e, UIElement ui)
    ********
    * Direito Pressionado - RigthPressed(PointerRoutedEventArgs e, UIElement ui)
    ********
    * Criar Circulo - CreateCircle(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor) 
    ********
    * Criar Quadrado - CreateSquare(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor)
    ********
    * Criar Linha - CreateLine(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor)
    ********
    * Criar Retangulo - Create_Rectangle(Canvas canvas, PointerRoutedEventArgs e, Color cor)
    ********
    * Criar Texto - CreateText(string val, Canvas canvas, double size, PointerRoutedEventArgs e, Color cor, double x, double y)
    ********
    * Componentes UI Visiveis - HideComponent(UIElement[] component)
    ********
    * Componentes UI Invisiveis - VisibleComponent(UIElement[] component)
    ********
    * Criar Circulo Posição Especifica - CreateCirclePosition(Canvas canvas, double size, Color cor, double x, double y)
    ********
    * Criar Quadrado Posição Especifica - CreateSquarePosition(Canvas canvas, double size, Color cor, double x, double y)
    ********
    * Criar Linha Posição Especifica - CreateLinePosition(Canvas canvas, double size, Color cor, double x1, double x2, double y1, double y2)
    ********


Icones
-----
Observação : Para os icones funcionarem corretamente é necessário estar setado da seguinte forma dentro do xaml: 

    <MenuFlyoutItem.Icon>
          <FontIcon FontFamily="Segoe MDL2 Assets" x:Name="menu_fullScreen_icon"/>
    </MenuFlyoutItem.Icon>

* Classe IconsControl
    * Checado - SetChecked(FontIcon element) 
    ********
    * Sem icone - SetNotIcon(FontIcon element)
    ********
    * Tela cheia - SetGoFullScreen(FontIcon element)
    ********
    * Sair Tela Cheia - SetGoWindowScreen(FontIcon element)
    ********


Componentes
--------

* Classe MessageControl
    * Dialogo de Texto - InputTextDialogAsync(CanvasDraw canvasdraw, string title)
    ********