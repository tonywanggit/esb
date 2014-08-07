
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
Ext.reg('formviewport', Ext.ux.FormViewport);