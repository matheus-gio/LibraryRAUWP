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


<html>
<body style='background-color:##D7ECF8;'>
<h3>Plugin Builder Results</h3>
<div id='help' style='font-size:.9em;'>
Your plugin <b>GeneticSimplifier</b> was created in:<br>
&nbsp;&nbsp;<b>C:/Documents and Settings/Luiz Claudio/.qgis2/python/plugins\GeneticSimplifier</b>
<p>
Your QGIS plugin directory is located at:<br>
&nbsp;&nbsp;<b>C:/Documents and Settings/Luiz Claudio/.qgis2/python/plugins</b>
<p>
<b>What's Next</b>
<ol>
    <li>Copy the entire directory containing your new plugin to the QGIS plugin directory
    <li>Compile the ui file using pyuic4
    <li>Compile the resources file using pyrcc4
    <li>Test the plugin by enabling it in the QGIS plugin manager
    <li>Customize it by editing the implementation file <b>geneticsimplifier.py</b>
    <li>Create your own custom icon, replacing the default <b>icon.png</b>
    <li>Modify your user interface by opening <b>geneticsimplifier.ui</b> in Qt Designer (don't forget to compile it with pyuic4 after changing it)
    <li>You can use the <b>Makefile</b> to compile your Ui and resource files when you make changes. This requires GNU make (gmake)
</ul>
</div>
<div style='font-size:.9em;'>
<p>
For more information, see the PyQGIS Developer Cookbook at:
<a href="http://www.qgis.org/pyqgis-cookbook/index.html">http://www.qgis.org/pyqgis-cookbook/index.html</a>.
</p>
</div>
<img src="http://geoapt.com/geoapt_logo_p.png" alt='GeoApt LLC' title='GeoApt LLC' align='absmiddle'>
&copy;2011-2014 GeoApt LLC - geoapt.com
</body>
</html>
