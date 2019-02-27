# LibraryRAUWP

Função para uso :
CanvasDraw draw = new CanvasDraw();

AddimgToCanvasPath(Canvas canvas, String path) - Adiciona ao canvas uma imagem baseada no caminho da imagem.
CreateCircle(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor) - Cria um circulo no canvas, baseado na posição do mouse, tamanho e cor.
CreateCirclePosition(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor, double x, double y) - Cria um circulo com as mesmas propriedades de CreateCircle, porém sendo possível adicionar a posição x e y.
CreateSquare(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor) - Cria um quadrado, baseado na posição do mouse, tamanho e cor.
Create_Rectangle(Canvas canvas, PointerRoutedEventArgs e, Color cor) - Cria um retangulo - Baseado nos click pelo canvas.
CreateSquarePosition(Canvas canvas, PointerRoutedEventArgs e, double size, Color cor, double x, double y)Pode-se criar quadrados passando mesmos parametros de CreateSquare, porém pode-se adicionar a posição x e y.
CreateLine(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor) - Cria uma linha, baseada na posição do mouse.
CreateLinePosition(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor, double x1, double x2, double y1, double y2) - Cria uma linha com os mesmos parametros de CreateLine, porém acrescido das coordenadas.
CreateText(string val, Canvas canvas, double size, PointerRoutedEventArgs e, Color cor, double x, double y) - Cria textos na tela, baseado nas coordenadas geograficas fornecidas.
Cursor_Circle(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor) - Cria um cursor de circulo ao arrastar o mouse pelo canvas.
Cursor_Square(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor) - Cria um cursor de quadrado ao arrastas o mouse pelo canvas.
Line_Cursor(Canvas canvas, double size, PointerRoutedEventArgs e, Color cor) - Cria um cursor de linha pelo canvas, após ser clicado e arrastada. 
DisableClick() - Desabilita o click do cursor.
Undo_Draw(Canvas canvas) - Desfaz a ultima ação no canvas.

HideComponent(params UIElement[] component) - É utilizado para Deixar esconder N componentes de uma vez.
VisibleComponent(params UIElement[] component) - É utilizado para Deixar visivel N componentes de uma vez.




FileControl() file = new FileControl();
GetDiskFileAsync(StorageFolder filefolder) - Retorna uma lista de arquivos que estão no folder passado como parametro.
saveImageAsync(Canvas canvas, StorageFolder folder, string nome) - Salva o conteúdo do canvas, sendo necessário o local de destino e o nome do arquivo.



ImageControl imgcontrol = new ImageControl();
GetDiskImagesAsync(StorageFolder picturesFolder) - Retorna List<Image> do folder passado como parametro.
AddImgtoCanvasAsync(Canvas canvas, Image image) - Adiciona uma imagem ao canvas de maneira asyncrona.
GetImageWebAsync(string url, List<string> path) - Retorna List<Image> de uma url passada como parametro, juntamente com uma lista dos nomes das imagens.
  
  
VideoControl vidcontrol = new VideoControl();
getDurationVideoAsync(StorageFile vid) - Retorna um double com o tamanho do video passado como StorageFile
StartVideo(StorageFile vid, MediaElement mediaelement) - Inicia um vídeo, passando o arquivo e o componente de destino.
