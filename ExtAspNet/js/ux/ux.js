
Ext.namespace('Ext.ux');

Ext.ux.FormViewport = Ext.extend(Ext.Container, {

    initComponent: function() {
        Ext.ux.FormViewport.superclass.initComponent.call(this);
        document.getElementsByTagName('html')[0].className += ' x-viewport';

        // added by sanshi.ustc@gmail.com at 2008-07-03
        if (this.renderTo != '') {
            this.el = Ext.get(this.renderTo);
        }
        else {
            this.el = Ext.get(document.forms[0]);
        }

        this.el.addClass('formviewport');
        this.el.setHeight = Ext.emptyFn;
        this.el.setWidth = Ext.emptyFn;
        this.el.setSize = Ext.emptyFn;
        this.el.dom.scroll = 'no';
        this.allowDomMove = false;
        this.autoWidth = true;
        this.autoHeight = true;
        Ext.EventManager.onWindowResize(this.fireResize, this);
        this.renderTo = this.el;
    },
    fireResize: function(w, h) {
        this.fireEvent('resize', this, w, h, w, h);
        //this.onResize(w, h, w, h);
    }
});
Ext.reg('formviewport', Ext.ux.FormViewport);/*
 * Ext JS Library 2.2
 * Copyright(c) 2006-2008, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */


// We are adding these custom layouts to a namespace that does not
// exist by default in Ext, so we have to add the namespace first:
Ext.ns('Ext.ux.layout');

/*
 * ================  CenterLayout  =======================
 */
/**
 * @class Ext.ux.layout.CenterLayout
 * @extends Ext.layout.FitLayout
 * <p>This is a very simple layout style used to center contents within a container.  This layout works within
 * nested containers and can also be used as expected as a Viewport layout to center the page layout.</p>
 * <p>As a subclass of FitLayout, CenterLayout expects to have a single child panel of the container that uses 
 * the layout.  The layout does not require any config options, although the child panel contained within the
 * layout must provide a fixed or percentage width.  The child panel's height will fit to the container by
 * default, but you can specify <tt>autoHeight:true</tt> to allow it to autosize based on its content height.  
 * Example usage:</p> 
 * <pre><code>
// The content panel is centered in the container
var p = new Ext.Panel({
    title: 'Center Layout',
    layout: 'ux.center',
    items: [{
        title: 'Centered Content',
        width: '75%',
        html: 'Some content'
    }]
});

// If you leave the title blank and specify no border
// you'll create a non-visual, structural panel just
// for centering the contents in the main container.
var p = new Ext.Panel({
    layout: 'ux.center',
    border: false,
    items: [{
        title: 'Centered Content',
        width: 300,
        autoHeight: true,
        html: 'Some content'
    }]
});
</code></pre>
 */
Ext.ux.layout.CenterLayout = Ext.extend(Ext.layout.FitLayout, {
	// private
    setItemSize : function(item, size){
        this.container.addClass('ux-layout-center');
        item.addClass('ux-layout-center-item');
        if(item && size.height > 0){
            if(item.width){
                size.width = item.width;
            }
            item.setSize(size);
        }
    }
});
Ext.Container.LAYOUTS['ux.center'] = Ext.ux.layout.CenterLayout;

///*
// * CenterLayout demo panel
// */
//var centerLayout = {
//	id: 'center-panel',
//    layout:'ux.center',
//    items: {
//        title: 'Centered Panel: 75% of container width and fit height',
//        layout: 'ux.center',
//        autoScroll: true,
//        width: '75%',
//        bodyStyle: 'padding:20px 0;',
//        items: [{
//        	title: 'Inner Centered Panel',
//        	html: 'Fixed 300px wide and auto height. The container panel will also autoscroll if narrower than 300px.',
//        	width: 300,
//        	frame: true,
//        	autoHeight: true,
//        	bodyStyle: 'padding:10px 20px;'
//        }]
//    }
//};

/*
 * ================  RowLayout  =======================
 */
/**
 * @class Ext.ux.layout.RowLayout
 * @extends Ext.layout.ContainerLayout
 * <p>This is the layout style of choice for creating structural layouts in a multi-row format where the height of
 * each row can be specified as a percentage or fixed height.  Row widths can also be fixed, percentage or auto.
 * This class is intended to be extended or created via the layout:'ux.row' {@link Ext.Container#layout} config,
 * and should generally not need to be created directly via the new keyword.</p>
 * <p>RowLayout does not have any direct config options (other than inherited ones), but it does support a
 * specific config property of <b><tt>rowHeight</tt></b> that can be included in the config of any panel added to it.  The
 * layout will use the rowHeight (if present) or height of each panel during layout to determine how to size each panel.
 * If height or rowHeight is not specified for a given panel, its height will default to the panel's height (or auto).</p>
 * <p>The height property is always evaluated as pixels, and must be a number greater than or equal to 1.
 * The rowHeight property is always evaluated as a percentage, and must be a decimal value greater than 0 and
 * less than 1 (e.g., .25).</p>
 * <p>The basic rules for specifying row heights are pretty simple.  The logic makes two passes through the
 * set of contained panels.  During the first layout pass, all panels that either have a fixed height or none
 * specified (auto) are skipped, but their heights are subtracted from the overall container height.  During the second
 * pass, all panels with rowHeights are assigned pixel heights in proportion to their percentages based on
 * the total <b>remaining</b> container height.  In other words, percentage height panels are designed to fill the space
 * left over by all the fixed-height and/or auto-height panels.  Because of this, while you can specify any number of rows
 * with different percentages, the rowHeights must always add up to 1 (or 100%) when added together, otherwise your
 * layout may not render as expected.  Example usage:</p>
 * <pre><code>
// All rows are percentages -- they must add up to 1
var p = new Ext.Panel({
    title: 'Row Layout - Percentage Only',
    layout:'ux.row',
    items: [{
        title: 'Row 1',
        rowHeight: .25 
    },{
        title: 'Row 2',
        rowHeight: .6
    },{
        title: 'Row 3',
        rowHeight: .15
    }]
});

// Mix of height and rowHeight -- all rowHeight values must add
// up to 1. The first row will take up exactly 120px, and the last two
// rows will fill the remaining container height.
var p = new Ext.Panel({
    title: 'Row Layout - Mixed',
    layout:'ux.row',
    items: [{
        title: 'Row 1',
        height: 120,
        // standard panel widths are still supported too:
        width: '50%' // or 200
    },{
        title: 'Row 2',
        rowHeight: .8,
        width: 300
    },{
        title: 'Row 3',
        rowHeight: .2
    }]
});
</code></pre>
 */
Ext.ux.layout.RowLayout = Ext.extend(Ext.layout.ContainerLayout, {
    // private
    monitorResize:true,

    // private
    isValidParent : function(c, target){
        return c.getEl().dom.parentNode == this.innerCt.dom;
    },

    // private
    onLayout : function(ct, target){
        var rs = ct.items.items, len = rs.length, r, i;

        if(!this.innerCt){
            target.addClass('ux-row-layout-ct');
            this.innerCt = target.createChild({cls:'x-row-inner'});
        }
        this.renderAll(ct, this.innerCt);

        var size = target.getViewSize();

        if(size.width < 1 && size.height < 1){ // display none?
            return;
        }

        var h = size.height - target.getPadding('tb'),
            ph = h;

        this.innerCt.setSize({height:h});
        
        // some rows can be percentages while others are fixed
        // so we need to make 2 passes
        
        for(i = 0; i < len; i++){
            r = rs[i];
            if(!r.rowHeight){
                ph -= (r.getSize().height + r.getEl().getMargins('tb'));
            }
        }

        ph = ph < 0 ? 0 : ph;

        for(i = 0; i < len; i++){
            r = rs[i];
            if(r.rowHeight){
                r.setSize({height: Math.floor(r.rowHeight*ph) - r.getEl().getMargins('tb')});
            }
        }
    }
    
    /**
     * @property activeItem
     * @hide
     */
});
Ext.Container.LAYOUTS['ux.row'] = Ext.ux.layout.RowLayout;

///*
// * RowLayout demo panel
// */
//var rowLayout = {
//	id: 'row-panel',
//	bodyStyle: 'padding:5px',
//	layout: 'ux.row',
//    title: 'Row Layout',
//    items: [{
//        title: 'Height = 25%, Width = 50%',
//        rowHeight: .25,
//        width: '50%'
//    },{
//        title: 'Height = 100px, Width = 300px',
//        height: 100,
//        width: 300
//    },{
//    	title: 'Height = 75%, Width = fit',
//    	rowHeight: .75
//    }]
//};

/**
* @class Ext.ux.TabCloseMenu
* @extends Object 
* Plugin (ptype = 'tabclosemenu') for adding a close context menu to tabs. Note that the menu respects
* the closable configuration on the tab. As such, commands like remove others and remove all will not
* remove items that are not closable.
* 
* @constructor
* @param {Object} config The configuration options
* @ptype tabclosemenu
*/
Ext.ux.TabCloseMenu = Ext.extend(Object, {
    /**
    * @cfg {String} closeTabText
    * The text for closing the current tab. Defaults to <tt>'Close Tab'</tt>.
    */
    closeTabText: 'Close Tab',

    /**
    * @cfg {String} closeOtherTabsText
    * The text for closing all tabs except the current one. Defaults to <tt>'Close Other Tabs'</tt>.
    */
    closeOtherTabsText: 'Close Other Tabs',

    /**
    * @cfg {Boolean} showCloseAll
    * Indicates whether to show the 'Close All' option. Defaults to <tt>true</tt>. 
    */
    showCloseAll: true,

    /**
    * @cfg {String} closeAllTabsText
    * <p>The text for closing all tabs. Defaults to <tt>'Close All Tabs'</tt>.
    */
    closeAllTabsText: 'Close All Tabs',

    constructor: function (config) {
        Ext.apply(this, config || {});
    },

    //public
    init: function (tabs) {
        this.tabs = tabs;
        tabs.on({
            scope: this,
            contextmenu: this.onContextMenu,
            destroy: this.destroy
        });
    },

    destroy: function () {
        Ext.destroy(this.menu);
        delete this.menu;
        delete this.tabs;
        delete this.active;
    },

    // private
    onContextMenu: function (tabs, item, e) {
        this.active = item;
        var m = this.createMenu(),
            disableAll = true,
            disableOthers = true,
            closeAll = m.getComponent('closeall');

        m.getComponent('close').setDisabled(!item.closable);
        tabs.items.each(function () {
            if (this.closable) {
                disableAll = false;
                if (this != item) {
                    disableOthers = false;
                    return false;
                }
            }
        });
        m.getComponent('closeothers').setDisabled(disableOthers);
        if (closeAll) {
            closeAll.setDisabled(disableAll);
        }

        e.stopEvent();
        m.showAt(e.getPoint());
    },

    createMenu: function () {
        if (!this.menu) {
            var items = [{
                itemId: 'close',
                text: this.closeTabText,
                scope: this,
                handler: this.onClose
            }];
            if (this.showCloseAll) {
                items.push('-');
            }
            items.push({
                itemId: 'closeothers',
                text: this.closeOtherTabsText,
                scope: this,
                handler: this.onCloseOthers
            });
            if (this.showCloseAll) {
                items.push({
                    itemId: 'closeall',
                    text: this.closeAllTabsText,
                    scope: this,
                    handler: this.onCloseAll
                });
            }
            this.menu = new Ext.menu.Menu({
                items: items
            });
        }
        return this.menu;
    },

    onClose: function () {
        this.tabs.remove(this.active);
    },

    onCloseOthers: function () {
        this.doClose(true);
    },

    onCloseAll: function () {
        this.doClose(false);
    },

    doClose: function (excludeActive) {
        var items = [];
        this.tabs.items.each(function (item) {
            if (item.closable) {
                if (!excludeActive || item != this.active) {
                    items.push(item);
                }
            }
        }, this);
        Ext.each(items, function (item) {
            this.tabs.remove(item);
        }, this);
    }
});

Ext.preg('tabclosemenu', Ext.ux.TabCloseMenu);
// added by sanshi.ustc@gmail.com on 2009-7-4

(function() {

    var T = Ext.Toolbar;

    Ext.ux.SimplePagingToolbar = Ext.extend(Ext.Toolbar, {

        pageSize: 20,
        pageIndex: 0,
        recordCount: 0,
        pageCount: 0,

        displayMsg: 'Displaying {0} - {1} of {2}',

        emptyMsg: 'No data to display',

        beforePageText: "Page",

        afterPageText: "of {0}",

        firstText: "First Page",

        prevText: "Previous Page",

        nextText: "Next Page",

        lastText: "Last Page",

        initComponent: function() {
            var pagingItems = [this.first = new T.Button({
                tooltip: this.firstText,
                iconCls: "x-tbar-page-first",
                disabled: true,
                handler: this.onClick,
                scope: this
            }), this.prev = new T.Button({
                tooltip: this.prevText,
                iconCls: "x-tbar-page-prev",
                disabled: true,
                handler: this.onClick,
                scope: this
            }), '-', this.beforePageText,
            this.inputItem = new T.Item({
                height: 18,
                autoEl: {
                    tag: "input",
                    type: "text",
                    size: "3",
                    value: "1",
                    cls: "x-tbar-page-number"
                }
            }), this.afterTextItem = new T.TextItem({
                text: String.format(this.afterPageText, 1)
            }), '-', this.next = new T.Button({
                tooltip: this.nextText,
                iconCls: "x-tbar-page-next",
                disabled: true,
                handler: this.onClick,
                scope: this
            }), this.last = new T.Button({
                tooltip: this.lastText,
                iconCls: "x-tbar-page-last",
                disabled: true,
                handler: this.onClick,
                scope: this
            })];


            var userItems = this.items || this.buttons || [];
            if (this.prependButtons) {
                this.items = userItems.concat(pagingItems);
            } else {
                this.items = pagingItems.concat(userItems);
            }
            delete this.buttons;
            if (this.displayInfo) {
                this.items.push('->');
                this.items.push(this.displayItem = new T.TextItem({}));
            }
            Ext.PagingToolbar.superclass.initComponent.call(this);

            this.on('afterlayout', this.onFirstLayout, this, { single: true });
        },


        load: function(options) {
            Ext.apply(this, options);
            this.onLoad();
        },

        // private
        onFirstLayout: function(ii) {
            this.mon(this.inputItem.el, "keydown", this.onPagingKeyDown, this);
            this.mon(this.inputItem.el, "blur", this.onPagingBlur, this);
            this.mon(this.inputItem.el, "focus", this.onPagingFocus, this);

            this.field = this.inputItem.el.dom;

            this.onLoad();
        },

        // private
        updateInfo: function() {
            if (this.displayItem) {
                var msg = '';
                if (this.recordCount == 0) {
                    msg = this.emptyMsg;
                }
                else {
                    var endPoint = (this.pageIndex + 1) * this.pageSize;
                    endPoint = endPoint < this.recordCount ? endPoint : this.recordCount;
                    msg = String.format(this.displayMsg, this.pageIndex * this.pageSize + 1, endPoint, this.recordCount);
                }
                this.displayItem.setText(msg);
            }
        },

        // private
        onLoad: function() {
            var d = this.getPageData(), ap = d.activePage, ps = d.pages;

            this.afterTextItem.setText(String.format(this.afterPageText, d.pages));
            this.field.value = ap;
            this.first.setDisabled(ap == 1);
            this.prev.setDisabled(ap == 1);
            this.next.setDisabled(ap == ps);
            this.last.setDisabled(ap == ps);
            this.updateInfo();
        },

        // private
        getPageData: function() {
            return {
                total: this.recordCount,
                activePage: this.pageIndex + 1,
                pages: this.pageCount <= 0 ? 1 : this.pageCount
            };
        },


        // private
        readPage: function(d) {
            var v = this.field.value, pageNum;
            if (!v || isNaN(pageNum = parseInt(v, 10))) {
                this.field.value = d.activePage;
                return false;
            }
            return pageNum;
        },

        onPagingFocus: function() {
            this.field.select();
        },

        //private
        onPagingBlur: function(e) {
            this.field.value = this.getPageData().activePage;
        },

        // private
        onPagingKeyDown: function(e) {
            var k = e.getKey(), d = this.getPageData(), pageNum;
            if (k == e.RETURN) {
                e.stopEvent();
                pageNum = this.readPage(d);
                if (pageNum !== false) {
                    pageNum = Math.min(Math.max(1, pageNum), d.pages) - 1;

                    this.onLoadPage(pageNum);
                }
            } else if (k == e.HOME || k == e.END) {
                e.stopEvent();
                pageNum = k == e.HOME ? 1 : d.pages;
                this.field.value = pageNum;
            } else if (k == e.UP || k == e.PAGEUP || k == e.DOWN || k == e.PAGEDOWN) {
                e.stopEvent();
                if ((pageNum = this.readPage(d))) {
                    var increment = e.shiftKey ? 10 : 1;
                    if (k == e.DOWN || k == e.PAGEDOWN) {
                        increment *= -1;
                    }
                    pageNum += increment;
                    if (pageNum >= 1 & pageNum <= d.pages) {
                        this.field.value = pageNum;
                    }
                }
            }
        },


        // private
        onClick: function(button) {
            switch (button) {
                case this.first:
                    this.onLoadPage(0);
                    break;
                case this.prev:
                    var page = this.pageIndex - 1;
                    page = page < 0 ? 0 : page;
                    this.onLoadPage(page);
                    break;
                case this.next:
                    var page = this.pageIndex + 1;
                    page = page >= this.pageCount ? this.pageCount - 1 : page;
                    this.onLoadPage(page);
                    break;
                case this.last:
                    this.onLoadPage(this.pageCount - 1);
                    break;
            }
        },

        // overrided by user to do page navigation
        onLoadPage: function(pageIndex) {

        },

        // private
        onDestroy: function() {
            Ext.PagingToolbar.superclass.onDestroy.call(this);
        }

    });

})();

Ext.reg('ux-simplepaging', Ext.ux.SimplePagingToolbar);
/*!
 * Ext JS Library 3.4.0
 * Copyright(c) 2006-2011 Sencha Inc.
 * licensing@sencha.com
 * http://www.sencha.com/license
 */
Ext.ns('Ext.ux.grid');

/**
 * @class Ext.ux.grid.RowExpander
 * @extends Ext.util.Observable
 * Plugin (ptype = 'rowexpander') that adds the ability to have a Column in a grid which enables
 * a second row body which expands/contracts.  The expand/contract behavior is configurable to react
 * on clicking of the column, double click of the row, and/or hitting enter while a row is selected.
 *
 * @ptype rowexpander
 */
Ext.ux.grid.RowExpander = Ext.extend(Ext.util.Observable, {
    /**
     * @cfg {Boolean} expandOnEnter
     * <tt>true</tt> to toggle selected row(s) between expanded/collapsed when the enter
     * key is pressed (defaults to <tt>true</tt>).
     */
    expandOnEnter : true,
    /**
     * @cfg {Boolean} expandOnDblClick
     * <tt>true</tt> to toggle a row between expanded/collapsed when double clicked
     * (defaults to <tt>true</tt>).
     */
    expandOnDblClick : true,

    header : '',
    width : 20,
    sortable : false,
    fixed : true,
    hideable: false,
    menuDisabled : true,
    dataIndex : '',
    id : 'expander',
    lazyRender : true,
    enableCaching : true,

    constructor: function(config){
        Ext.apply(this, config);

        this.addEvents({
            /**
             * @event beforeexpand
             * Fires before the row expands. Have the listener return false to prevent the row from expanding.
             * @param {Object} this RowExpander object.
             * @param {Object} Ext.data.Record Record for the selected row.
             * @param {Object} body body element for the secondary row.
             * @param {Number} rowIndex The current row index.
             */
            beforeexpand: true,
            /**
             * @event expand
             * Fires after the row expands.
             * @param {Object} this RowExpander object.
             * @param {Object} Ext.data.Record Record for the selected row.
             * @param {Object} body body element for the secondary row.
             * @param {Number} rowIndex The current row index.
             */
            expand: true,
            /**
             * @event beforecollapse
             * Fires before the row collapses. Have the listener return false to prevent the row from collapsing.
             * @param {Object} this RowExpander object.
             * @param {Object} Ext.data.Record Record for the selected row.
             * @param {Object} body body element for the secondary row.
             * @param {Number} rowIndex The current row index.
             */
            beforecollapse: true,
            /**
             * @event collapse
             * Fires after the row collapses.
             * @param {Object} this RowExpander object.
             * @param {Object} Ext.data.Record Record for the selected row.
             * @param {Object} body body element for the secondary row.
             * @param {Number} rowIndex The current row index.
             */
            collapse: true
        });

        Ext.ux.grid.RowExpander.superclass.constructor.call(this);

        if(this.tpl){
            if(typeof this.tpl == 'string'){
                this.tpl = new Ext.Template(this.tpl);
            }
            this.tpl.compile();
        }

        this.state = {};
        this.bodyContent = {};
    },

    getRowClass : function(record, rowIndex, p, ds){
        p.cols = p.cols-1;
        var content = this.bodyContent[record.id];
        if(!content && !this.lazyRender){
            content = this.getBodyContent(record, rowIndex);
        }
        if(content){
            p.body = content;
        }
        return this.state[record.id] ? 'x-grid3-row-expanded' : 'x-grid3-row-collapsed';
    },

    init : function(grid){
        this.grid = grid;

        var view = grid.getView();
        view.getRowClass = this.getRowClass.createDelegate(this);

        view.enableRowBody = true;


        grid.on('render', this.onRender, this);
        grid.on('destroy', this.onDestroy, this);
    },

    // @private
    onRender: function() {
        var grid = this.grid;
        var mainBody = grid.getView().mainBody;
        mainBody.on('mousedown', this.onMouseDown, this, {delegate: '.x-grid3-row-expander'});
        if (this.expandOnEnter) {
            this.keyNav = new Ext.KeyNav(this.grid.getGridEl(), {
                'enter' : this.onEnter,
                scope: this
            });
        }
        if (this.expandOnDblClick) {
            grid.on('rowdblclick', this.onRowDblClick, this);
        }
    },
    
    // @private    
    onDestroy: function() {
        if(this.keyNav){
            this.keyNav.disable();
            delete this.keyNav;
        }
        /*
         * A majority of the time, the plugin will be destroyed along with the grid,
         * which means the mainBody won't be available. On the off chance that the plugin
         * isn't destroyed with the grid, take care of removing the listener.
         */
        var mainBody = this.grid.getView().mainBody;
        if(mainBody){
            mainBody.un('mousedown', this.onMouseDown, this);
        }
    },
    // @private
    onRowDblClick: function(grid, rowIdx, e) {
        this.toggleRow(rowIdx);
    },

    onEnter: function(e) {
        var g = this.grid;
        var sm = g.getSelectionModel();
        var sels = sm.getSelections();
        for (var i = 0, len = sels.length; i < len; i++) {
            var rowIdx = g.getStore().indexOf(sels[i]);
            this.toggleRow(rowIdx);
        }
    },

    getBodyContent : function(record, index){
        if(!this.enableCaching){
            return this.tpl.apply(record.data);
        }
        var content = this.bodyContent[record.id];
        if(!content){
            content = this.tpl.apply(record.data);
            this.bodyContent[record.id] = content;
        }
        return content;
    },

    onMouseDown : function(e, t){
        e.stopEvent();
        var row = e.getTarget('.x-grid3-row');
        this.toggleRow(row);
    },

    renderer : function(v, p, record){
        p.cellAttr = 'rowspan="2"';
        return '<div class="x-grid3-row-expander">&#160;</div>';
    },

    beforeExpand : function(record, body, rowIndex){
        if(this.fireEvent('beforeexpand', this, record, body, rowIndex) !== false){
            if(this.tpl && this.lazyRender){
                body.innerHTML = this.getBodyContent(record, rowIndex);
            }
            return true;
        }else{
            return false;
        }
    },

    toggleRow : function(row){
        if(typeof row == 'number'){
            row = this.grid.view.getRow(row);
        }
        this[Ext.fly(row).hasClass('x-grid3-row-collapsed') ? 'expandRow' : 'collapseRow'](row);
    },

    expandRow : function(row){
        if(typeof row == 'number'){
            row = this.grid.view.getRow(row);
        }
        var record = this.grid.store.getAt(row.rowIndex);
        var body = Ext.DomQuery.selectNode('tr:nth(2) div.x-grid3-row-body', row);
        if(this.beforeExpand(record, body, row.rowIndex)){
            this.state[record.id] = true;
            Ext.fly(row).replaceClass('x-grid3-row-collapsed', 'x-grid3-row-expanded');
            this.fireEvent('expand', this, record, body, row.rowIndex);
        }
    },

    collapseRow : function(row){
        if(typeof row == 'number'){
            row = this.grid.view.getRow(row);
        }
        var record = this.grid.store.getAt(row.rowIndex);
        var body = Ext.fly(row).child('tr:nth(1) div.x-grid3-row-body', true);
        if(this.fireEvent('beforecollapse', this, record, body, row.rowIndex) !== false){
            this.state[record.id] = false;
            Ext.fly(row).replaceClass('x-grid3-row-expanded', 'x-grid3-row-collapsed');
            this.fireEvent('collapse', this, record, body, row.rowIndex);
        }
    }
});

Ext.preg('rowexpander', Ext.ux.grid.RowExpander);

//backwards compat
Ext.grid.RowExpander = Ext.ux.grid.RowExpander;/*!
 * Ext JS Library 3.4.0
 * Copyright(c) 2006-2011 Sencha Inc.
 * licensing@sencha.com
 * http://www.sencha.com/license
 */
Ext.ns('Ext.ux.form');

/**
 * @class Ext.ux.form.FileUploadField
 * @extends Ext.form.TextField
 * Creates a file upload field.
 * @xtype fileuploadfield
 */
Ext.ux.form.FileUploadField = Ext.extend(Ext.form.TextField,  {
    /**
     * @cfg {String} buttonText The button text to display on the upload button (defaults to
     * 'Browse...').  Note that if you supply a value for {@link #buttonCfg}, the buttonCfg.text
     * value will be used instead if available.
     */
    buttonText: 'Browse...',
    /**
     * @cfg {Boolean} buttonOnly True to display the file upload field as a button with no visible
     * text field (defaults to false).  If true, all inherited TextField members will still be available.
     */
    buttonOnly: false,
    /**
     * @cfg {Number} buttonOffset The number of pixels of space reserved between the button and the text field
     * (defaults to 3).  Note that this only applies if {@link #buttonOnly} = false.
     */
    buttonOffset: 3,
    /**
     * @cfg {Object} buttonCfg A standard {@link Ext.Button} config object.
     */

    // private
    readOnly: true,

    /**
     * @hide
     * @method autoSize
     */
    autoSize: Ext.emptyFn,

    // private
    initComponent: function(){
        Ext.ux.form.FileUploadField.superclass.initComponent.call(this);

        this.addEvents(
            /**
             * @event fileselected
             * Fires when the underlying file input field's value has changed from the user
             * selecting a new file from the system file selection dialog.
             * @param {Ext.ux.form.FileUploadField} this
             * @param {String} value The file value returned by the underlying file input field
             */
            'fileselected'
        );
    },

    // private
    onRender : function(ct, position){
        Ext.ux.form.FileUploadField.superclass.onRender.call(this, ct, position);

        this.wrap = this.el.wrap({cls:'x-form-field-wrap x-form-file-wrap'});
        this.el.addClass('x-form-file-text');
        this.el.dom.removeAttribute('name');
        this.createFileInput();

        var btnCfg = Ext.applyIf(this.buttonCfg || {}, {
            text: this.buttonText
        });
        this.button = new Ext.Button(Ext.apply(btnCfg, {
            renderTo: this.wrap,
            cls: 'x-form-file-btn' + (btnCfg.iconCls ? ' x-btn-icon' : '')
        }));

        if(this.buttonOnly){
            this.el.hide();
            this.wrap.setWidth(this.button.getEl().getWidth());
        }

        this.bindListeners();
        this.resizeEl = this.positionEl = this.wrap;
    },
    
    bindListeners: function(){
        this.fileInput.on({
            scope: this,
            mouseenter: function() {
                this.button.addClass(['x-btn-over','x-btn-focus'])
            },
            mouseleave: function(){
                this.button.removeClass(['x-btn-over','x-btn-focus','x-btn-click'])
            },
            mousedown: function(){
                this.button.addClass('x-btn-click')
            },
            mouseup: function(){
                this.button.removeClass(['x-btn-over','x-btn-focus','x-btn-click'])
            },
            change: function(){
                var v = this.fileInput.dom.value;
                this.setValue(v);
                this.fireEvent('fileselected', this, v);    
            }
        }); 
    },
    
    createFileInput : function() {
        this.fileInput = this.wrap.createChild({
            id: this.getFileInputId(),
            name: this.name||this.getId(),
            cls: 'x-form-file',
            tag: 'input',
            type: 'file',
            size: 1
        });
    },
    
    reset : function(){
        if (this.rendered) {
            this.fileInput.remove();
            this.createFileInput();
            this.bindListeners();
        }
        Ext.ux.form.FileUploadField.superclass.reset.call(this);
    },

    // private
    getFileInputId: function(){
        return this.id + '-file';
    },

    // private
    onResize : function(w, h){
        Ext.ux.form.FileUploadField.superclass.onResize.call(this, w, h);

        this.wrap.setWidth(w);

        if(!this.buttonOnly){
            var w = this.wrap.getWidth() - this.button.getEl().getWidth() - this.buttonOffset;
            this.el.setWidth(w);
        }
    },

    // private
    onDestroy: function(){
        Ext.ux.form.FileUploadField.superclass.onDestroy.call(this);
        Ext.destroy(this.fileInput, this.button, this.wrap);
    },
    
    onDisable: function(){
        Ext.ux.form.FileUploadField.superclass.onDisable.call(this);
        this.doDisable(true);
    },
    
    onEnable: function(){
        Ext.ux.form.FileUploadField.superclass.onEnable.call(this);
        this.doDisable(false);

    },
    
    // private
    doDisable: function(disabled){
        this.fileInput.dom.disabled = disabled;
        this.button.setDisabled(disabled);
    },


    // private
    preFocus : Ext.emptyFn,

    // private
    alignErrorIcon : function(){
        this.errorIcon.alignTo(this.wrap, 'tl-tr', [2, 0]);
    }

});

Ext.reg('fileuploadfield', Ext.ux.form.FileUploadField);

// backwards compat
Ext.form.FileUploadField = Ext.ux.form.FileUploadField;
