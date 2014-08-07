
Ext.override(Ext.Component, {

    x_setDisabled: function () {
        this.setDisabled(!this.x_state['Enabled']);
    },

    x_setVisible: function () {
        this.setVisible(!this.x_state['Hidden']);
    }

});

// 验证一个表单是否有效，会递归查询表单中每个字段
Ext.override(Ext.Panel, {
    isValid: function () {
        var valid = true;
        var firstInvalidField = null;
        this.items.each(function (f) {
            if (f.isXType('field')) {
                if (!f.validate()) {
                    valid = false;
                    if (firstInvalidField == null) {
                        firstInvalidField = f;
                    }
                }
            }
            else if (f.items) {
                var validResult = this.isValid(f);
                if (!validResult[0]) {
                    valid = false;
                    if (firstInvalidField == null) {
                        firstInvalidField = validResult[1];
                    }
                }
            }
        });
        return [valid, firstInvalidField];
    },


    x_setCollapse: function () {
        var collapsed = this.x_state['Collapsed'];
        if (collapsed) {
            this.collapse(true);
        }
        else {
            this.expand(true);
        }
    },

    x_setTitle: function () {
        this.setTitle(this.x_state['Title']);
    }


});

/*
Ext.override(Ext.form.field.HtmlEditor, {

//  Add functionality to Field's initComponent to enable the change event to bubble
initComponent: Ext.Function.createSequence(Ext.form.field.Base.prototype.initComponent, function () {
this.enableBubble('change');
}),

x_setValue: function () {
this.setValue(this.x_state['Text']);
}

});
*/

if (Ext.form.Field) {
    Ext.override(Ext.form.Field, {

        //  Add functionality to Field's initComponent to enable the change event to bubble
        initComponent: Ext.form.Field.prototype.initComponent.createSequence(function () {
            this.enableBubble('change');
        }),

        // When show or hide the field, also hide the label.
        hide: function () {
            Ext.form.Field.superclass.hide.call(this);
            //this.callOverridden();

            //var label = Ext.get(this.el.findParent('div[class=x-form-item]')).first('label[for=' + this.id + ']');
            var labelAndField = this.el.findParentNode('div[class*=x-form-item]', 10, true);
            if (labelAndField) {
                if (this.hideMode == 'display') {
                    labelAndField.setVisibilityMode(Ext.Element.DISPLAY);
                } else {
                    labelAndField.setVisibilityMode(Ext.Element.VISIBILITY);
                }
                labelAndField.hide();
            }
        },

        show: function () {
            Ext.form.Field.superclass.show.call(this);
            //this.callOverridden();

            //var label = Ext.get(this.el.findParent('div[class=x-form-item]')).first('label[for=' + this.id + ']');
            var labelAndField = this.el.findParentNode('div[class*=x-form-item]', 10, true);
            if (labelAndField) {
                if (this.hideMode == 'display') {
                    labelAndField.setVisibilityMode(Ext.Element.DISPLAY);
                } else {
                    labelAndField.setVisibilityMode(Ext.Element.VISIBILITY);
                }
                labelAndField.show();
            }
        },

        x_setValue: function () {
            this.setValue(this.x_state['Text']);
        }

    });
}

if (Ext.form.Checkbox) {
    Ext.override(Ext.form.Checkbox, {

        x_setValue: function () {
            this.setValue(this.x_state['Checked']);
        }

    });
}

if (Ext.form.Radio) {
    Ext.override(Ext.form.Radio, {

        x_setValue: function () {
            this.setValue(this.x_state['Checked']);
        }

    });
}


if (Ext.form.RadioGroup) {
    Ext.override(Ext.form.RadioGroup, {

        // 单选框列表的getValue函数，ExtJS没有实现
        // Extjs3.4已经有相应的实现了
        /*
        getValue: function () {
        var value = null;
        Ext.each(this.items.items, function (item, index) {
        if (item.checked) {
        value = item.inputValue;
        }
        });
        return value;
        }
        */

        x_setValue: function (value) {
            if (typeof (value) === 'undefined') {
                value = this.x_state['SelectedValue'];
            }
            this.setValue(value);
        }

    });
}


if (Ext.form.CheckboxGroup) {
    Ext.override(Ext.form.CheckboxGroup, {

        x_reloadData: function (name, isradiogroup) {
            var container = this.ownerCt;
            var newConfig = Ext.apply(this.initialConfig, {
                "x_state": this.x_state,
                "items": X.util.resolveCheckBoxGroup(name, this.x_state)
            });

            if (container) {
                var originalIndex = container.items.indexOf(this);
                container.remove(this, true);

                if (isradiogroup) {
                    container.insert(originalIndex, new Ext.form.RadioGroup(newConfig));
                } else {
                    container.insert(originalIndex, new Ext.form.CheckboxGroup(newConfig));
                }
                container.doLayout();
            } else {
                this.destroy();
                if (isradiogroup) {
                    new Ext.form.RadioGroup(newConfig);
                } else {
                    new Ext.form.CheckboxGroup(newConfig);
                }

            }
        },

        x_toBeDeleted: function () {
            var tobedeleted = this.items.items[0];
            if (tobedeleted && tobedeleted.inputValue === 'tobedeleted') {
                tobedeleted.destroy();
                this.items.remove(tobedeleted);
            }
        },

        x_setValue: function (value) {
            var valueArray = value || this.x_state['SelectedValueArray'];
            // 此时value的值类似于：["value1", "value2", "value3"]

            var selectedArray = [];
            this.eachItem(function (item) {
                if (valueArray.indexOf(item.getRawValue()) === -1) {
                    selectedArray.push(false);
                } else {
                    selectedArray.push(true);
                }
            });

            this.setValue(selectedArray);

            /* 
            var result = {}, i, currentSelectedCheckboxs;
            currentSelectedCheckboxs = this.getValue();
            for (i = 0; i < currentSelectedCheckboxs.length; i++) {
            result[currentSelectedCheckboxs[i].getRawValue()] = false;
            }

            for (i = 0; i < valueArray.length; i++) {
            result[valueArray[i]] = true;
            }
            this.setValue(result);
            */
        }

    });
}

if (Ext.form.ComboBox) {
    Ext.override(Ext.form.ComboBox, {
        // Load data from local cache.
        mode: "local",
        // Show all content when click the trigger button.
        triggerAction: "all",
        // User must select an item inside the list.
        forceSelection: true,
        // This list cann't be edited.
        //        typeAhead: true,
        //        selectOnFocus: true,
        editable: true,
        displayField: "text",
        valueField: "value",
        tpl: "<tpl for=\".\"><div class=\"x-combo-list-item <tpl if=\"!enabled\">x-combo-list-item-disable</tpl>\">{prefix}{text}</div></tpl>",
        // These variables are in the Ext.form.ComboBox.prototype, therefore all instance will refer to the same store instance.
        //store: new Ext.data.ArrayStore({ fields: ['value', 'text', 'enabled', 'prefix'] }),

        x_setValue: function (value) {
            // value 可以是空字符串
            if (typeof (value) === 'undefined') {
                value = this.x_state['SelectedValue'];
            }
            this.setValue(value);
        },

        x_loadData: function (data) {
            data = data || this.x_state['X_Items'];
            if (data) {
                this.store.loadData(X.simulateTree.transform(data));
            }
        }
        /*,

        // private
        assertValue: function () {
        var val = this.getRawValue(),
        rec = this.findRecord(this.displayField, val);

        if (!rec && this.forceSelection) {
        if (val.length > 0 && val != this.emptyText) {
        this.el.dom.value = Ext.value(this.lastSelectionText, '');
        this.applyEmptyText();
        } else {
        this.clearValue();
        }
        } else {
        if (rec) {
        // onSelect may have already set the value and by doing so
        // set the display field properly.  Let's not wipe out the
        // valueField here by just sending the displayField.

        //if (val == rec.get(this.displayField) && this.value == rec.get(this.valueField)) {
        // return;
        // }

        if (val == rec.get(this.displayField)) {
        return;
        }
        val = rec.get(this.valueField || this.displayField);
        }
        this.setValue(val);
        }
        }
        */

    });
}


if (Ext.Button) {
    Ext.override(Ext.Button, {

        x_setTooltip: function () {
            this.setTooltip(this.x_state['ToolTip']);
        },

        x_toggle: function () {
            this.toggle(this.x_state['Pressed']);
        },

        x_setText: function () {
            this.setText(this.x_state['Text']);
        }


    });
}



if (Ext.grid.GridPanel) {
    Ext.override(Ext.grid.GridPanel, {

        x_getData: function () {
            var data = this.x_state['X_Rows']['Values'];

            //////////////////////////////////////////////////
            var tpls = this.x_tpls;
            //if (!tpls) {
            if (typeof (tpls) === 'undefined') {
                tpls = this.x_getTpls();
            }

            // 将Grid1_ctl37与对应的outHTML放在哈希表中
            var tplsHash = {};
            var e = document.createElement('div');
            e.innerHTML = tpls;
            Ext.each(e.childNodes, function (item, index) {
                tplsHash[item.id] = item.outerHTML;
            });

            // INPUT:  /(<div id="(.+)_container">)<\/div>/ig.exec("<div id=\"Grid1_ctl37_container\"></div>")
            // OUTPUT: ["<div id="Grid1_ctl37_container"></div>", "<div id="Grid1_ctl37_container">", "Grid1_ctl37"]
            Ext.each(data, function (row, rowIndex) {
                Ext.each(row, function (item, index) {
                    /*
                    var regTpl = /(<div id=\"(.+)_container\">)<\/div>/ig.exec(item);
                    if (regTpl) {
                    row[index] = regTpl[1] + tplsHash[regTpl[2]] + '</div>';
                    }
                    */
                    if (item.substr(0, 7) === "#@TPL@#") {
                        var clientId = item.substr(7);
                        row[index] = '<div id="' + clientId + '_container">' + tplsHash[clientId] + '</div>';
                    }
                });
            });
            //////////////////////////////////////////////////

            return data;
        },

        x_getTpls: function () {
            //var tplsNode = this.el.parent().down('.x-grid-tpls');
            var tplsNode = Ext.get(this.id + '_tpls');
            tpls = tplsNode.dom.innerHTML;
            tplsNode.remove();
            return tpls;
        },


        x_updateTpls: function (tpls) {
            if (typeof (tpls) == 'undefined') {
                tpls = this.x_getTpls();
            }

            var e = document.createElement('div');
            e.innerHTML = tpls;
            Ext.each(e.childNodes, function (item, index) {
                var nodeId = item.id;
                Ext.get(nodeId + '_container').dom.innerHTML = item.outerHTML;
            });
        },


        x_loadData: function () {
            var datas = this.x_getData();
            var pagingBar = this.getBottomToolbar();
            if (pagingBar) {
                var pagingDatas = [];
                for (var i = pagingBar.x_startRowIndex; i <= pagingBar.x_endRowIndex; i++) {
                    pagingDatas.push(datas[i]);
                }
                this.getStore().loadData(pagingDatas);
            }
            else {
                this.getStore().loadData(datas);
            }
        },

        // Expand all expander rows.
        x_expandAllRows: function () {
            for (var i = 0, count = this.store.getCount(); i < count; i++) {
                this.plugins[0].expandRow(i);
            }
        },

        // http://evilcroco.name/2010/10/making-extjs-grid-content-selectable/
        /* allow grid text selection in IE */
        x_enableTextSelection: function () {
            if (Ext.isIE) {
                var elems = Ext.DomQuery.select("div[unselectable=on]", this.el.dom);
                for (var i = 0, len = elems.length; i < len; i++) {
                    Ext.get(elems[i]).set({ 'unselectable': 'off' });
                }
            }
        },

        x_selectRows: function (rows) {
            rows = rows || this.x_state['SelectedRowIndexArray'] || [];
            this.getSelectionModel().selectRows(rows);
        },

        x_getSelectedRows: function () {
            var selections = this.getSelectionModel().getSelections();
            var store = this.getStore();

            var selectRows = [];
            Ext.each(selections, function (record, index) {
                selectRows.push(store.indexOfId(record.id));
            });

            return selectRows;
        },

        x_getHiddenColumns: function () {
            var hiddens = [], model = this.getColumnModel(), columns = model.config;
            Ext.each(columns, function (column, index) {
                if (model.isHidden(index)) {
                    hiddens.push(index);
                }
            });
            return hiddens;
        },

        x_hiddenColumns: function (hiddens) {
            hiddens = hiddens || this.x_state['HiddenColumnIndexArray'] || [];
            var model = this.getColumnModel(), columns = model.config;
            Ext.each(columns, function (column, index) {
                if (hiddens.indexOf(index) !== -1) {
                    model.setHidden(index, true);
                }
                else {
                    model.setHidden(index, false);
                }
            });
        },

        // .x-grid3-hd-over
        x_setSortIcon: function (sortColumnIndex, sortDirection) {
            var gridEl = Ext.get(this.id), columns = this.x_getColumns();

            function getHeaderNode(index) {
                if (typeof (index) === 'number') {
                    return gridEl.select('.x-grid3-hd-row .x-grid3-cell.x-grid3-td-' + columns[index].id);
                } else {
                    return gridEl.select('.x-grid3-hd-row .x-grid3-cell.x-grid3-hd');
                }
            }

            // Clear sort icon for all column header.
            getHeaderNode().removeClass(['sort-asc', 'sort-desc']);

            // Add cursor to all server sortable column header.
            Ext.each(columns, function (item, index) {
                if (item['x_serverSortable']) {
                    getHeaderNode(index).addClass('cursor-pointer');
                }
            });

            // Set current sort column
            if (sortColumnIndex >= 0 && sortColumnIndex < columns.length) {
                getHeaderNode(sortColumnIndex).addClass('sort-' + sortDirection.toLowerCase());
            }
        },

        x_getColumns: function () {
            var columns = [];
            // this.getColumnModel().config -> An Array of Column definition objects representing the configuration of this ColumnModel.
            var configColumns = this.getColumnModel().config;
            Ext.each(configColumns, function (item, index) {
                // expander也属于表格列的一种类型，否则设置x_setSortIcon会出错
                if (item.id !== 'numberer' && item.id !== 'checker') { // && item.id !== 'expander'
                    columns.push(item);
                }
            });
            return columns;
        },

        x_setRowStates: function (states) {
            var gridEl = Ext.get(this.id), columns = this.x_getColumns(), states = states || this.x_state['X_States'] || [];

            function setCheckBoxStates(columnIndex, stateColumnIndex) {
                var checkboxRows = gridEl.select('.x-grid3-body .x-grid3-row .x-grid3-td-' + columns[columnIndex].id + ' .box-grid-checkbox');
                checkboxRows.each(function (row, rows, index) {
                    if (states[index][stateColumnIndex]) {
                        if (row.hasClass('box-grid-checkbox-unchecked-disabled')) {
                            row.removeClass('box-grid-checkbox-unchecked-disabled');
                        } else {
                            row.removeClass('box-grid-checkbox-unchecked');
                        }
                    } else {
                        if (row.hasClass('box-grid-checkbox-disabled')) {
                            row.addClass('box-grid-checkbox-unchecked-disabled')
                        } else {
                            row.addClass('box-grid-checkbox-unchecked')
                        }
                    }
                });
            }

            var stateColumnIndex = 0;
            Ext.each(columns, function (column, index) {
                if (column['x_persistState']) {
                    if (column['x_persistStateType'] === 'checkbox') {
                        setCheckBoxStates(index, stateColumnIndex);
                        stateColumnIndex++;
                    }
                }
            });
        },

        x_getRowStates: function () {
            var gridEl = Ext.get(this.id), columns = this.x_getColumns(), states = [];

            function getCheckBoxStates(columnIndex) {
                var checkboxRows = gridEl.select('.x-grid3-body .x-grid3-row .x-grid3-td-' + columns[columnIndex].id + ' .box-grid-checkbox');
                var states = [];
                checkboxRows.each(function (row, index) {
                    if (row.hasClass('box-grid-checkbox-unchecked') || row.hasClass('box-grid-checkbox-unchecked-disabled')) {
                        states.push(false);
                    } else {
                        states.push(true);
                    }
                });
                return states;
            }

            Ext.each(columns, function (column, index) {
                if (column['x_persistState']) {
                    if (column['x_persistStateType'] === 'checkbox') {
                        states.push(getCheckBoxStates(index));
                    }
                }
            });
            return states;
        }

    });
}


if (Ext.tree.TreePanel) {
    Ext.override(Ext.tree.TreePanel, {

        x_loadData: function () {
            var datas = this.x_state['X_Nodes'];
            var nodes = this.x_tranformData(datas);
            var root = this.getRootNode();
            if (root) {
                root.removeAll();
            }
            this.setRootNode(new Ext.tree.AsyncTreeNode({
                id: this.id + '_root',
                children: nodes
            }));
        },

        x_tranformData: function (datas) {
            var that = this, i = 0, nodes = [];
            for (var i = 0; i < datas.length; i++) {
                var data = datas[i], node = {};

                //            function copyIfExists(prop) {
                //                if (typeof (data[prop]) !== 'undefined') {
                //                    node[prop] = data[prop];
                //                }
                //            }

                // 0 - Text
                // 1 - Leaf
                // 2 - NodeID
                // 3 - Enabled
                // 4 - EnableCheckBox
                // 5 - Checked
                // 6 - Expanded
                // 7 - NavigateUrl
                // 8 - Target
                // 9 - href
                // 10 - Icon
                // 11 - IconUrl
                // 12 - iconUrl
                // 13 - ToolTip
                // 14 - SingleClickExpand
                // 15 - OnClientClick
                // 16 - EnablePostBack
                // 17 - AutoPostBack
                // 18 - CommandName
                // 19 - CommandArgument
                // 20 - Nodes
                node.text = data[0];
                node.leaf = !!data[1];
                node.id = data[2];
                node.disabled = !data[3];
                if (!!data[4]) {
                    node.checked = !!data[5];
                }
                if (!data[1]) {
                    node.expanded = !!data[6];
                }
                if (data[9]) {
                    node.href = data[9];
                    node.hrefTarget = data[8];
                }
                if (data[12]) {
                    node.icon = data[12];
                }
                node.qtip = data[13];
                node.singleClickExpand = !!data[14];


                node.listeners = {};

                if (!data[3]) {
                    node.listeners.beforeclick = function () {
                        return false;
                    };
                }

                if (!!data[4] && !!data[17]) {
                    node.listeners.checkchange = function (node, checked) {
                        var args = 'Check$' + node.id + '$' + checked;
                        __doPostBack(that.name, args);
                    };
                }

                var clickScript = '';
                if (data[15]) {
                    clickScript += data[15] + ';';
                }
                if (!!data[16]) {
                    clickScript += "__doPostBack('" + that.name + "', 'Command$" + node.id + "$" + data[18] + "$" + data[19] + "');";
                }
                if (clickScript) {
                    node.listeners.click = new Function('node', clickScript);
                }


                if (data[20] && data[20].length > 0) {
                    node.children = that.x_tranformData(data[20]);
                }

                nodes.push(node);
            }
            return nodes;
        },

        x_getExpandedNodes: function (nodes) {
            var i = 0, that = this, expandedNodes = [];

            for (; i < nodes.length; i++) {
                var node = nodes[i];
                if (node.isExpanded()) {
                    expandedNodes.push(node.id);
                }
                if (node.hasChildNodes()) {
                    expandedNodes = expandedNodes.concat(that.x_getExpandedNodes(node.childNodes));
                }
            }

            return expandedNodes;
        },

        x_getCheckedNodes: function () {
            return this.getChecked('id');
        },

        x_getSelectedNodes: function () {
            var model = this.getSelectionModel(), nodes = [];
            if (model.constructor === Ext.tree.MultiSelectionModel) {
                Ext.each(model.getSelectedNodes(), function (item, index) {
                    nodes.push(item.id);
                });
            } else {
                var selectedNode = model.getSelectedNode();
                if (selectedNode) {
                    nodes.push(selectedNode.id);
                }
            }
            return nodes;
        },

        x_selectNodes: function () {
            var datas = this.x_state['SelectedNodeIDArray'] || [];
            var model = this.getSelectionModel(), i = 0;
            for (var i = 0; i < datas.length; i++) {
                model.select(this.getNodeById(datas[i]), null, true);
            }
        }


    });
}


if (Ext.PagingToolbar) {
    // We don't use this Class in current version.
    Ext.override(Ext.PagingToolbar, {

        x_hideRefresh: function () {
            var index = this.items.indexOf(this.refresh);
            this.items.get(index - 1).hide();
            this.refresh.hide();
        }

    });
}


if (Ext.TabPanel) {
    Ext.override(Ext.TabPanel, {

        x_autoPostBackTabsContains: function (tabId) {
            var tabs = this.x_state['X_AutoPostBackTabs'];
            return tabs.indexOf(tabId) !== -1;
        },

        x_setActiveTab: function () {
            var tabIndex = this.x_state['ActiveTabIndex'];
            this.setActiveTab(tabIndex);
        },

        x_getActiveTabIndex: function () {
            return this.items.indexOf(this.getActiveTab());
        },

        /*
        // private
        onBeforeShowItem: function (item) {
        this.showTab(item);
        if (item != this.activeTab) {
        this.setActiveTab(item);
        return false;
        }
        },
        // private
        onStripMouseDown: function (e) {
        if (e.button !== 0) {
        return;
        }
        e.preventDefault();
        var t = this.findTargets(e);
        if (t.close) {
        if (t.item['x_dynamic_added_tab']) {
        if (t.item.fireEvent('beforeclose', t.item) !== false) {
        t.item.fireEvent('close', t.item);
        this.remove(t.item);
        }
        } else {
        this.hideTab(t.item);
        }
        return;
        }
        if (t.item && t.item != this.activeTab) {
        this.setActiveTab(t.item);
        }
        },
        */


        activateNextTab: function (c) {
            if (c == this.activeTab) {
                var next = this.stack.next();
                if (next) {
                    this.setActiveTab(next);
                }
                if (next = this.items.find(function (t) { return t.tabEl.style.display !== 'none'; })) {
                    // Find the first visible tab and set it active tab. 
                    this.setActiveTab(next);
                } else {
                    this.setActiveTab(null);
                }
            }
        },

        hideTab: function (item) {
            item = this.getComponent(item);
            this.hideTabStripItem(item);
            item.hide();
            this.activateNextTab(item);
        },

        showTab: function (item) {
            item = this.getComponent(item);
            this.unhideTabStripItem(item);
        },


        addTab: function (id, url, title, closable) {
            var options = {};
            if (typeof (id) === 'string') {
                Ext.apply(options, {
                    'id': id,
                    'title': title,
                    'closable': closable,
                    'url': url
                });
            } else {
                // id is not a string, then there should be only one argument.
                Ext.apply(options, id);
            }
            Ext.apply(options, {
                'x_dynamic_added_tab': true,
                'html': '<iframe id="' + options.id + '" name="' + options.id + '" src="' + options.url + '" frameborder="0" style="height:100%;width:100%;overflow:auto;"\></iframe\>'
            });
            var tab = this.add(options);
            this.activate(tab);

            return tab;
        },

        getTab: function (id) {
            return this.getItem(id);
        },

        removeTab: function (id) {
            this.remove(id);
        }

    });
}



// 修正IE7下，窗口出现滚动条时，点击Window控件标题栏有时node为null的问题
var originalIsValidHandleChild = Ext.dd.DragDrop.prototype.isValidHandleChild;
Ext.dd.DragDrop.prototype.isValidHandleChild = function (node) {
    if (!node || !node.nodeName) {
        return false;
    }
    return originalIsValidHandleChild.apply(this, [node]);
};

if (Ext.grid.GridPanel) {
    // 修正在IE下，Grid的模版列中出现文本输入框或者下拉列表时，第一次不能选中的问题
    // 已经有网友发现这个问题：http://www.sencha.com/forum/archive/index.php/t-49653.html
    // This is what caused my self-rendered-Html-Elements to "flicker" as described in my other thread. 
    // The Dropdown receives the Click, opens and stays open for the Millisecond until
    // Ext calls back and gives focus to the Cell, causing my Drop-Down to close again.
    Ext.grid.GridView.prototype.focusCell = function (row, col, hscroll) {
        this.syncFocusEl(this.ensureVisible(row, col, hscroll));

        var focusEl = this.focusEl;

        focusEl.focus();
    };
}