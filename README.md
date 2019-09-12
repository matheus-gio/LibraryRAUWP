Esta biblioteca foi desenvolvida com intuito de facilitar o desenvolvimento de aplicações de Realidade Aumentada focada na utilização de projetores, a biblioteca é capaz de auxiliar o desenvolvedor a desenvolver ferramentas capazes de realizarem mapeamentos do mundo real.

Na imagem abaixo é demonstrado um mapeamento gerado e em seguida o objeto sendo projetado no mundo fisico.
![Mapeamento gerado utilizando o software de exemplo.](https://raw.githubusercontent.com/matheus-gio/LibraryRAUWP/master/Mapeamento%26Projecao.jpg)

<h1>Referência biblioteca</h1>
|  Tipos Cursor | Cursor Mouse | Classe Reponsavel |  Função Reponsavel |
| :---         |     :---:      |   :---:      |          :--- |
| Seta | OK  |  AutomateDraw  |SetArrowCursor()
| Nenhum  | OK  |AutomateDraw  |SetNoneCursor()
| Circulo  | OK  |CanvasDraw  |Cursor_Circle(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)
| Quadrado  | OK  |CanvasDraw  |Cursor_Square(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)
| Linha  | OK  |  CanvasDraw  | Cursor_Line(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)
| Setar Cursor automaticamente  | OK  | AutomateDraw  | Cursors(Canvas, double, PointerRoutedEventArgs, Windows.UI.Color)

|   | Arquivos | Classe Reponsavel |  Função Reponsavel |
| :---         |     :---:      |   :---:      |          :--- |
| Ler Duração Vídeo | OK  |VideoControl|GetDurationVideoAsync(StorageFile)
| Iniciar Vídeo  | OK  |VideoControl|StartVideo(StorageFile, MediaElement)
| Ler Imagens de Disco  | OK  |ImageControl| GetDiskImagesAsync(StorageFolder)
| Baixar pacote de Imagens via URL  | OK  |ImageControl|GetImagesWebAsync(String url_base, List<String> list_nomes, StorageFolder)
| Baixar Imagem via URL  | OK  |ImageControl|DownloaImageDisk(string url_base, string path_file, StorageFolder)
| Ler Arquivos Disco  | OK  |FileControl|GetDiskFileAsync(StorageFolder)
| File Picker para Imagem  | OK  |ImageControl|GetImageFilePicker()
  
|   | Canvas | Classe Reponsavel |  Função Reponsavel |
| :---         |     :---:      |   :---:      |          :--- |
| Salvar em disco | OK  | ImageControl  |saveImageAsync(Canvas, StorageFolder, string nome)
| Adicionar imagem do disco | OK  |ImageControl|AddImgtoCanvasAsync(Canvas, Image)
| Verificar seleção de Menu  | OK  |AutomateDraw| Text, Line, Square, Circle, Rectangle;
| Criar componente baseado em click e no menu | OK  | AutomateDraw |CreateElementPointerPressed(Canvas,double size, Color, UIElement, PointerRoutedEventArgs)
| Limpar Canvas  | OK  |AutomateDraw|ClearCanvas
| Desfazer última ação  | OK  |AutomateDraw|Undo_Draw
| Esquerdo Pressionado | OK  |CanvasDraw|LeftPressed(PointerRoutedEventArgs e, UIElement ui)
| Direito Pressionado  | OK  |CanvasDraw|RigthPressed(PointerRoutedEventArgs e, UIElement ui)
| Criar Circulo  | OK  |CanvasDraw|CreateCircle(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor)
| Criar Quadrado  | OK  |CanvasDraw| CreateSquare(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor)
| Criar Linha  | OK  |CanvasDraw|CreateLine(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor)
| Criar Retangulo  | OK  |CanvasDraw|Create_Rectangle(Canvas canvas, PointerRoutedEventArgs e, Color cor)
| Criar Texto  | OK  |CanvasDraw| CreateText(string val, Canvas canvas, double size, PointerRoutedEventArgs e, Color cor, double x, double y)
| Criar Circulo Posição Especifica | OK  |CanvasDraw|CreateCirclePosition(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor, double x, double y)
| Criar Quadrado  Posição Especifica| OK  |CanvasDraw|CreateSquarePosition(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor, double x, double y)
| Criar Linha Posição Especifica | OK  |CanvasDraw|CreateLinePosition(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor, double x1, double x2, double y1, double y2)
| Adicionar Imagem de auxilio  | OK  |ImageControl| BackgroundImageDraw(Canvas canvas, Image img_draw, double opacity)
| Remover Imagem de auxilio  | OK  |ImageControl| BackgroundImageDraw(Canvas canvas)

Para os icones funcionarem é necessario uma configuração adicional no arquivo de layout, deve-se setar FontFamily="Segoe MDL2 Assets", segue o exemplo abaixo :

<MenuFlyoutItem x:Name="menu_fullScreen" Visibility="Visible" Text="Go to Window" Click="Menu_fullScreen_Click">

    <MenuFlyoutItem.Icon>
    
        <FontIcon FontFamily="Segoe MDL2 Assets" x:Name="menu_fullScreen_icon"/>
        
    </MenuFlyoutItem.Icon>
    
</MenuFlyoutItem>
                    
|   | Icones | Classe Reponsavel |  Função Reponsavel |
| :---         |     :---:      |   :---:      |          :--- |
| Checado | OK  |IconsControl|SetChecked(FontIcon element)
| Sem icone  | OK  |IconsControl|SetNotIcon(FontIcon element)
| Tela cheia  | OK  |IconsControl|SetGoFullScreen(FontIcon element)
| Sair tela cheia  | OK  |  IconsControl|SetGoWindowScreen(FontIcon element)

|   | Componentes | Classe Reponsavel |  Função Reponsavel |
| :---         |     :---:      |   :---:      |          :--- |
| Dialogo de Texto | OK  |MessageControl|InputTextDialogAsync(CanvasDraw canvasdraw, string title)
| Componentes UI Visiveis  | OK  |MessageControl|HideComponent(UIElement[] component)
| Componentes UI Invisiveis  | OK  |MessageControl|VisibleComponent(UIElement[] component)
