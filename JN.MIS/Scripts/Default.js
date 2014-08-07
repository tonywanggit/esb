
function onReady() {
    var treeMenu = Ext.getCmp(IDS.mainMenu);
    var btnExpandAll = Ext.getCmp(IDS.btnExpandAll);
    var mainTabStrip = Ext.getCmp(IDS.mainTabStrip);

    btnExpandAll.on('click', function () {
        treeMenu.expandAll();
    });

    // Click collapse toolbar button.
    var btnCollapseAll = Ext.getCmp(IDS.btnCollapseAll);
    btnCollapseAll.on('click', function () {
        treeMenu.collapseAll();
    });


    function addExampleTab(node) {
        var href = node.attributes.href;

        var openNewWindowButton = new Ext.Button({
            text: '新窗口打开',
            type: "button",
            cls: "x-btn-text-icon",
            icon: './res.axd?icon=TabGo',
            listeners: {
                click: function (button, e) {
                    window.open(href, "_blank");
                    e.stopEvent();
                }
            }
        });

        var refreshButton = new Ext.Button({
            text: '刷新',
            type: "button",
            cls: "x-btn-text-icon",
            icon: './res.axd?icon=Reload',
            listeners: {
                click: function (button, e) {
                    // Note: button.ownerCt is toolbar, button.ownerCt.ownerCt is current active tab.
                    Ext.DomQuery.selectNode('iframe', button.ownerCt.ownerCt.getEl().dom).contentWindow.location.replace(href);
                    e.stopEvent();
                }
            }
        });

        // Add a dynamic tab (With toolbar).
        var tabID = 'dynamic_added_tab' + node.id.replace('__', '-');
        mainTabStrip.addTab({
            'id': tabID,
            'url': href,
            'title': node.parentNode.text + ' -> ' + node.text,
            'closable': true,
            'bodyStyle': 'padding:0px;',
            'iconCls': 'icon_' + href.replace(/[^.]+\./, ''),
            'tbar': new Ext.Toolbar({
                items: ['->', refreshButton, '-', openNewWindowButton]
            })
        });
    }

    // Click the tree node.
    treeMenu.on('click', function (node, event) {
        if (node.isLeaf()) {
            var href = node.attributes.href;
            // Modify the location of current url.
            window.location.href = '#' + href;

            addExampleTab(node);

            // Don't response to this tree node's default behavior. 
            event.stopEvent();
        }
    });

    (function pageFirstLoad() {
        var currentHash = window.location.hash.substr(1);
        var level1Nodes = treeMenu.getRootNode().childNodes;
        for (var i = 0; i < level1Nodes.length; i++) {
            var level2Nodes = level1Nodes[i].childNodes;
            for (var j = 0; j < level2Nodes.length; j++) {
                var currentNode = level2Nodes[j];
                if (currentNode.attributes.href === currentHash) {
                    level1Nodes[i].expand();
                    // We must retrieve this node again, because currentNode doesn't has parentNode property.
                    var foundNode = treeMenu.getNodeById(currentNode.id);
                    foundNode.select();
                    addExampleTab(foundNode);
                    return;
                }
            }
        }
    })();
}