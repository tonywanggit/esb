
type ux\ExtAspNet.css > ux\ux.css
type ux\PageLoading.css >> ux\ux.css
type ux\CheckBox-disable.css >> ux\ux.css
type ux\FormViewport.css >> ux\ux.css
type ux\box-panel-big-header.css >> ux\ux.css
type ux\BigFont.css >> ux\ux.css
type ux\FileUploadField.css >> ux\ux.css
type ux\ColumnHeaderGroup.css >> ux\ux.css

type ext\ext-all-notheme.css > .notheme
type ux\ux.css >> .notheme
java -jar ..\..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type css --charset utf-8 -o notheme.css .notheme

java -jar ..\..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type css --charset utf-8 -o blue.css ext\xtheme-blue.css

java -jar ..\..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type css --charset utf-8 -o gray.css ext\xtheme-gray.css

java -jar ..\..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type css --charset utf-8 -o access.css ext\xtheme-access.css

