
:: DEBUG
type ux\Ext.ux.FormViewport.js > ux\ux.js
type ux\Ext.ux.layout.RowLayout.js >> ux\ux.js
type ux\Ext.ux.TabCloseMenu.js >> ux\ux.js
type ux\Ext.ux.SimplePagingToolbar.js >> ux\ux.js
type ux\Ext.ux.grid.RowExpander.js >> ux\ux.js
type ux\Ext.ux.form.FileUploadField.js >> ux\ux.js

type X\X.util.js > X\X.js
type X\X.ajax.js >> X\X.js
type X\X.wnd.js >> X\X.js
type X\extender.js >> X\X.js
type X\X.simulateTree.js >> X\X.js




:: RELEASE
type lib\json2.js > x-debug.js
type lib\Base64.js >> x-debug.js
type X\X.js >> x-debug.js



type lib\ext-base.js > .core
type pkgs\ext-core.js >> .core
type pkgs\ext-foundation.js >> .core
type pkgs\cmp-foundation.js >> .core



type pkgs\ext-dd.js > .foundation
type pkgs\data-foundation.js >> .foundation
type pkgs\data-json.js >> .foundation
type pkgs\resizable.js >> .foundation
type pkgs\window.js >> .foundation
type pkgs\data-list-views.js >> .foundation
type pkgs\pkg-tips.js >> .foundation
type pkgs\pkg-buttons.js >> .foundation
type pkgs\pkg-toolbars.js >> .foundation
type ux\Ext.ux.FormViewport.js >> .foundation
type ux\Ext.ux.layout.RowLayout.js >> .foundation




type pkgs\pkg-forms.js > .form
type ux\Ext.ux.form.FileUploadField.js >> .form



type pkgs\pkg-grid-foundation.js > .grid
type ux\Ext.ux.SimplePagingToolbar.js >> .grid
type ux\Ext.ux.grid.RowExpander.js >> .grid
type ux\Ext.ux.grid.ColumnHeaderGroup.js >> .grid



type pkgs\pkg-menu.js > .menutabtree
type pkgs\pkg-tabs.js >> .menutabtree
type ux\Ext.ux.TabCloseMenu.js >> .menutabtree
type pkgs\pkg-tree.js >> .menutabtree




java -jar ..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type js --charset utf-8 -o x.js x-debug.js

java -jar ..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type js --charset utf-8 -o ext-core.js .core
java -jar ..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type js --charset utf-8 -o ext-foundation.js .foundation
java -jar ..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type js --charset utf-8 -o ext-form.js .form
java -jar ..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type js --charset utf-8 -o ext-grid.js .grid
java -jar ..\tools\yuicompressor-2.4.6\build\yuicompressor-2.4.6.jar --type js --charset utf-8 -o ext-menutabtree.js .menutabtree
