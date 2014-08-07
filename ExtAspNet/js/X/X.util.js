
// ExtAspNet应用程序域
var X = function (cmpName) {
    return Ext.getCmp(cmpName);
};

X.state = function (cmp, state) {
    X.util.setXState(cmp, state);
};

X.enable = function (id) {
    X.util.enableSubmitControl(id);
};

X.disable = function (id) {
    X.util.disableSubmitControl(id);
};

X.target = function (target) {
    return X.util.getTargetWindow(target);
};

X.alert = function () {
    X.util.alert.apply(window, arguments);
};

X.init = function () {
    if (typeof (onInit) == 'function') {
        onInit();
    }
};

X.ready = function () {
    if (typeof (onReady) == 'function') {
        onReady();
    }
};

X.ajaxReady = function () {
    if (typeof (onAjaxReady) == 'function') {
        onAjaxReady();
    }
};

(function () {


    // ExtAspNet常用函数域（Utility）
    X.util = {

        alertTitle: "Alert Dialog",
        confirmTitle: "Confirm Dialog",
        formAlertMsg: "Please provide valid value for {0}!",
        formAlertTitle: "Form Invalid",
        loading: "Loading...",


        // 生成加载过程中的时间信息
        /*
        getTimeInfo: function () {
        var str = String.format("Total time:\t\t{0}\r\n", x_render_end_time - x_start_time);
        str += String.format("-Download time:\t\t{0} [ExtJS:{1}]\r\n", x_end_time - x_start_time, x_end_javascript_time - x_start_javascript_time);
        str += String.format("-Wait time:\t\t{0}\r\n", x_render_start_time - x_end_time);
        str += String.format("-Render time:\t\t{0}", x_render_end_time - x_render_start_time);
        return str;
        },
        */

        init: function (msgTarget, labelWidth, labelSeparator, enableBigFont,
            blankImageUrl, enableAspnetSubmitButtonAjax, enableAjaxLoading, ajaxLoadingType, enableAjax) {
            // Ext.QuickTips.init(true); 在原生的IE7（非IE8下的IE7模式）会有问题
            // 表现为iframe中的页面出现滚动条时，页面上的所有按钮都不能点击了。
            // 测试例子在：aspnet/test.aspx
            Ext.QuickTips.init(false);

            X.ajax.hookPostBack();
            if (enableAspnetSubmitButtonAjax) {
                //X.util.makeAspnetSubmitButtonAjax();
            }

            X.global_enable_ajax = enableAjax;

            X.global_enable_ajax_loading = enableAjaxLoading;
            X.global_ajax_loading_type = ajaxLoadingType;

            // 添加Ajax Loading提示节点
            X.ajaxLoadingDefault = Ext.get(X.util.appendLoadingNode());
            X.ajaxLoadingMask = new Ext.LoadMask(Ext.getBody(), { msg: X.util.loading });


            X.form_upload_file = false;
            X.global_disable_ajax = false;
            X.window_default_group = new Ext.WindowGroup();
            X.window_default_group.zseed = 6000;
            X.util.setHiddenFieldValue('X_CHANGED', 'false');
            document.forms[0].autocomplete = 'off';

            if (Ext.form.Field) {
                // Form cofiguration
                var fieldPro = Ext.form.Field.prototype;
                // editorPro = Ext.form.HtmlEditor.prototype;
                fieldPro.msgTarget = msgTarget;
                fieldPro.labelWidth = labelWidth;
                fieldPro.labelSeparator = labelSeparator;
                fieldPro.autoFitErrors = false;
            }

            if (enableBigFont) {
                Ext.getBody().addClass('bigfont');
            }

            // Default empty image
            if (Ext.isIE6 || Ext.isIE7) {
                Ext.BLANK_IMAGE_URL = blankImageUrl;
            }

            //            // 页面缩放时改变页面上所有Window控件的容器大小
            //            Ext.EventManager.onWindowResize(function(w, h){
            //                var viewSize = window.Ext.getBody().getViewSize();
            //                Ext.select('.x-window-wrapper').setWidth(viewSize.width).setHeight(viewSize.height);       
            //            });
        },


        setXState: function (cmp, state) {
            if (!cmp || !cmp['x_state']) {
                return;
            }

            var oldValue, newValue, el;
            // 如果state中包含CssClass，也就是在服务器端修改了CssClass属性，则需要首先删除原来的CssClass属性。
            if (typeof (state['CssClass']) !== 'undefined') {
                newValue = state['CssClass'];
                oldValue = cmp['x_state']['CssClass'];
                if (!oldValue) {
                    oldValue = cmp.initialConfig.cls;
                }
                el = cmp.el;
                el.removeClass(oldValue);
                el.addClass(newValue);
            }

            if (typeof (state['FormItemClass']) !== 'undefined') {
                newValue = state['FormItemClass'];
                oldValue = cmp['x_state']['FormItemClass'];
                if (!oldValue) {
                    oldValue = cmp.initialConfig.itemCls;
                }
                // Search for max 10 depth.
                el = cmp.el.findParent('.x-form-item', 10, true);
                el.removeClass(oldValue);
                el.addClass(newValue);
            }

            Ext.apply(cmp['x_state'], state);

        },

        stopEventPropagation: function (event) {
            event = event || window.event;
            if (typeof (event.cancelBubble) === 'boolean') {
                event.cancelBubble = true;
            } else {
                event.stopPropagation();
            }
        },

        // 绑定函数的上下文
        bind: function (fn, scope) {
            return function () {
                return fn.apply(scope, arguments);
            };
        },

        // 在页面上查找id为findId的节点，替换成replaceHtml
        replace: function (findId, replaceHtml) {
            // 在findId外面添加一个DIV层，然后更新此wrapper的InnerHTML
            var findedControl = Ext.get(findId);
            if (findedControl) {
                var wrapper = findedControl.wrap().update(replaceHtml);
                // 将新增的节点移到wrapper上面
                wrapper.first().insertBefore(wrapper);
                // 然后删除wrapper
                wrapper.remove();
            }
        },

        // 去除PageLoading节点
        removePageLoading: function (fadeOut) {
            if (fadeOut) {
                Ext.get("loading").remove();
                Ext.get("loading-mask").fadeOut({ remove: true });
            }
            else {
                Ext.get("loading").remove();
                Ext.get("loading-mask").remove();
            }
        },


        // 去掉字符串中的html标签
        stripHtmlTags: function (str) {
            return str.replace(/<[^>]*>/g, "");
        },


        // 弹出Alert对话框
        alert: function (msg, title, icon, okscript) {
            title = title || X.util.alertTitle;
            icon = icon || Ext.MessageBox.INFO;
            Ext.MessageBox.show({
                title: title,
                msg: msg,
                buttons: Ext.MessageBox.OK,
                icon: icon,
                fn: function (buttonId) {
                    if (buttonId === "ok") {
                        if (typeof (okscript) === "function") {
                            okscript.call(window);
                        }
                    }
                }
            });
        },

        // 向页面添加Loading...节点
        appendLoadingNode: function () {
            return X.util.appendFormNode({ tag: "div", cls: "x-ajax-loading", html: X.util.loading });
        },

        // 向页面的 form 节点最后添加新的节点
        appendFormNode: function (htmlOrObj) {
            return Ext.DomHelper.append(document.forms[0], htmlOrObj);
        },

        // 向页面添加一个隐藏字段，如果已经存在则更新值
        setHiddenFieldValue: function (fieldId, fieldValue) {
            var itemNode = Ext.get(fieldId);
            if (itemNode == null) {
                // Ext.DomHelper.append 有问题，例如下面这个例子得到的结果是错的；变通一下，先插入节点，在设置节点的值。
                // Ext.DomHelper.append(document.forms[0], { tag: "input", type: "hidden", value: '{"X_Items":[["Value1","选项 1",1],["Value2","选项 2（不可选择）",0],["Value3","选项 3（不可选择）",0],["Value4","选项 4",1],["Value5","选项 5",1],["Value6","选项 6",1],["Value7","选项 7",1],["Value8","选项 8",1],["Value9","选项 9",1]],"SelectedValue":"Value1"}'});
                // 上面的这个字符串，在IETest的IE8模式下会变成：
                // {"DropDownList1":{"X_Items":[["Value1","\u9009\u9879 1",1],["Value2","\u9009\u9879 2\uff08\u4e0d\u53ef\u9009\u62e9\uff09",0],["Value3","\u9009\u9879 3\uff08\u4e0d\u53ef\u9009\u62e9\uff09",0],["Value4","\u9009\u9879 4",1],["Value5","\u9009\u9879 5",1],["Value6","\u9009\u9879 6",1],["Value7","\u9009\u9879 7",1],["Value8","\u9009\u9879 8",1],["Value9","\u9009\u9879 9",1]],"SelectedValue":"Value1"}}

                X.util.appendFormNode({ tag: "input", type: "hidden", id: fieldId, name: fieldId });
                Ext.get(fieldId).dom.value = fieldValue;
            }
            else {
                itemNode.dom.value = fieldValue;
            }
        },

        // 获取页面中一个隐藏字段的值
        getHiddenFieldValue: function (fieldId) {
            var itemNode = Ext.get(fieldId);
            if (itemNode) {
                return itemNode.getValue();
            }
            return null;
        },

        // 禁用提交按钮（在回发之前禁用以防止重复提交）
        disableSubmitControl: function (controlClientID) {
            X(controlClientID).disable();
            X.util.setHiddenFieldValue('X_TARGET', controlClientID);
        },

        // 启用提交按钮（在回发之后启用提交按钮）
        enableSubmitControl: function (controlClientID) {
            X(controlClientID).enable();
            X.util.setHiddenFieldValue('X_TARGET', '');
        },

        // 更新ViewState的值
        updateViewState: function (newValue, startIndex) {
            var oldValue = X.util.getHiddenFieldValue("__VIEWSTATE");
            if (Ext.type(startIndex) == "number") {
                if (startIndex < oldValue.length) {
                    oldValue = oldValue.substr(0, startIndex);
                }
            } else {
                // Added on 2011-5-2, this is a horrible mistake.
                oldValue = '';
            }
            X.util.setHiddenFieldValue("__VIEWSTATE", oldValue + newValue);
        },

        // 更新EventValidation的值
        updateEventValidation: function (newValue) {
            X.util.setHiddenFieldValue("__EVENTVALIDATION", newValue);
        },

        // 设置页面状态是否改变
        setPageStateChanged: function () {
            var pageState = Ext.get("X_CHANGED");
            if (pageState && pageState.getValue() == "false") {
                pageState.dom.value = "true";
            }
        },

        // 页面状态是否改变
        isPageStateChanged: function () {
            var pageState = Ext.get("X_CHANGED");
            if (pageState && pageState.getValue() == "true") {
                return true;
            }
            return false;
        },


        // 验证多个表单，返回数组[是否验证通过，第一个不通过的表单字段]
        validForms: function (forms, targetName, showBox) {
            var target = X.util.getTargetWindow(targetName);
            var valid = true;
            var firstInvalidField = null;
            for (var i = 0; i < forms.length; i++) {
                var result = X(forms[i]).isValid();
                if (!result[0]) {
                    valid = false;
                    if (firstInvalidField == null) {
                        firstInvalidField = result[1];
                    }
                }
            }

            if (!valid) {
                if (showBox) {
                    var alertMsg = String.format(X.util.formAlertMsg, firstInvalidField.fieldLabel);
                    target.X.util.alert(alertMsg, X.util.formAlertTitle, Ext.MessageBox.INFO);
                }
                return false;
            }
            return true;
        },


        // 判断隐藏字段值（数组）是否包含value
        isHiddenFieldContains: function (domId, testValue) {
            testValue += "";
            var domValue = Ext.get(domId).dom.value;
            if (domValue === "") {
                //console.log(domId);
                return false;
            }
            else {
                var sourceArray = domValue.split(",");
                return sourceArray.indexOf(testValue) >= 0 ? true : false;
            }
        },


        // 将一个字符添加到字符列表中，将2添加到[5,3,4]
        addValueToHiddenField: function (domId, addValue) {
            addValue += "";
            var domValue = Ext.get(domId).dom.value;
            if (domValue == "") {
                Ext.get(domId).dom.value = addValue + "";
            }
            else {
                var sourceArray = domValue.split(",");
                if (sourceArray.indexOf(addValue) < 0) {
                    sourceArray.push(addValue);
                    Ext.get(domId).dom.value = sourceArray.join(",");
                }
            }
        },


        // 从字符列表中移除一个字符，将2从dom的值"5,3,4,2"移除
        removeValueFromHiddenField: function (domId, addValue) {
            addValue += "";
            var domValue = Ext.get(domId).dom.value;
            if (domValue != "") {
                var sourceArray = domValue.split(",");
                if (sourceArray.indexOf(addValue) >= 0) {
                    sourceArray = sourceArray.remove(addValue);
                    Ext.get(domId).dom.value = sourceArray.join(",");
                }
            }
        },


        // 取得隐藏字段的值
        getHiddenFieldValue: function (fieldId) {
            var itemNode = Ext.get(fieldId);
            if (itemNode == null) {
                return "";
            }
            else {
                return itemNode.dom.value;
            }
        },


        // 取得表单字段的值，日期字段的值类似"2008-07-08"
        getFormFieldValue: function (cmp) {
            if (cmp.getXType() == "datefield") {
                return cmp.value;
            }
            else {
                return cmp.getValue();
            }
        },

        // 由target获取window对象
        getTargetWindow: function (target) {
            var wnd = null;
            if (target === '_self') {
                wnd = window;
            } else if (target === '_parent') {
                wnd = parent;
            } else if (target === '_top') {
                wnd = top;
            }
            return wnd;
        },


        // 预加载图片
        preloadImages: function (images) {
            var imageInstance = [];
            for (var i = 0; i < images.length; i++) {
                imageInstance[i] = new Image();
                imageInstance[i].src = images[i];
            }
        },

        hasCSS: function (id) {
            return !!Ext.get(id);
        },

        addCSS: function (id, content) {
            //        // 下面的代码在IE下不对，不能将style标签添加到head中
            //        // 如果这个样式还没有添加到页面中
            //        if (!Ext.get(id)) {
            //            Ext.DomHelper.append(Ext.DomQuery.selectNode("head"), {
            //                tag: "style",
            //                type: "text/css",
            //                id: id,
            //                html: content
            //            });
            //        }

            if (!Ext.get(id)) {
                // Tricks From: http://www.phpied.com/dynamic-script-and-style-elements-in-ie/
                var ss1 = document.createElement("style");
                var def = content;
                ss1.setAttribute("type", "text/css");
                ss1.setAttribute("id", id);
                if (ss1.styleSheet) {   // IE
                    ss1.styleSheet.cssText = def;
                } else {                // the world
                    var tt1 = document.createTextNode(def);
                    ss1.appendChild(tt1);
                }
                var hh1 = document.getElementsByTagName("head")[0];
                hh1.appendChild(ss1);
            }
        },


        // 在启用AJAX的情况下，使所有的Asp.net的提交按钮（type="submit"）不要响应默认的submit行为，而是自定义的AJAX
        makeAspnetSubmitButtonAjax: function (buttonId) {

            /*
            function clickEvent(e, el) {
            __doPostBack(el.getAttribute("name"), "");
            e.stopEvent();
            }
            
            if (typeof (buttonId) === "undefined") {
            Ext.each(Ext.DomQuery.select("input[type=submit], input[type=images]"), function (item, index) {
            Ext.get(item).addListener("click", clickEvent);
            });
            } else {
            var button = Ext.get(buttonId);
            if (button.getAttribute("type") === "submit") {
            button.addListener("click", clickEvent);
            }
            }
            */

            function resetButton(button) {
                //button.set({ "type": "button" });
                button.addListener("click", function (event, el) {
                    __doPostBack(el.getAttribute("name"), "");
                    event.stopEvent();
                });
            }

            if (typeof (buttonId) === "undefined") {
                Ext.each(Ext.DomQuery.select("input[type=submit]"), function (item, index) {
                    resetButton(Ext.get(item));
                });
            } else {
                var button = Ext.get(buttonId);
                if (button.getAttribute("type") === "submit") {
                    resetButton(button);
                }
            }

        },

        // Whether a object is empty (With no property) or not.
        isObjectEmpty: function (obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    return false;
                }
            }
            return true;
        },

        // Convert an array to object.
        // ['Text', 'Icon']  -> {'Text':true, 'Icon': true}
        arrayToObject: function (arr) {
            var obj = {};
            Ext.each(arr, function (item, index) {
                obj[item] = true;
            });
            return obj;
        },

        hideScrollbar: function () {
            if (Ext.isIE) {
                window.document.body.scroll = 'no';
            } else {
                window.document.body.style.overflow = 'hidden';
            }
        },


        // 动态添加一个标签页
        // addExampleTab(node) or addExampleTab(id, url, text)
        addMainTab: function (mainTabStrip, id, url, text, icon, tbarCallback) {
            var iconId, iconCss, tabId, currentTab, tabConfig;
            if (typeof (id) !== 'string') {
                tbarCallback = url;
                url = id.attributes.href;
                icon = id.attributes.icon;
                text = id.text;

                id = id.id;
            }
            //var href = node.attributes.href;
            if (icon) {
                iconId = icon.replace(/\W/ig, '_');
                if (!X.util.hasCSS(iconId)) {
                    iconCss = [];
                    iconCss.push('.');
                    iconCss.push(iconId);
                    iconCss.push('{background-image:url("');
                    iconCss.push(icon);
                    iconCss.push('")}');
                    X.util.addCSS(iconId, iconCss.join(''));
                }
            }
            // 动态添加一个带工具栏的标签页
            tabId = 'dynamic_added_tab' + id.replace('__', '-');
            currentTab = mainTabStrip.getTab(tabId);
            if (!currentTab) {
                tabConfig = {
                    'id': tabId,
                    'url': url,
                    'title': text,
                    'closable': true,
                    'bodyStyle': 'padding:0px;'
                };
                if (icon) {
                    tabConfig['iconCls'] = iconId;
                }
                if (tbarCallback) {
                    tabConfig['tbar'] = tbarCallback.call(window);
                }
                mainTabStrip.addTab(tabConfig);
            } else {
                mainTabStrip.setActiveTab(currentTab);
            }
        },

        initTreeTabStrip: function (treeMenu, mainTabStrip, tbarCallback) {

            // 注册树的节点点击事件
            function registerTreeClickEvent(treeInstance) {
                treeInstance.on('click', function (node, event) {
                    if (node.isLeaf()) {
                        // 阻止事件传播
                        event.stopEvent();

                        var href = node.attributes.href;

                        // 修改地址栏
                        window.location.hash = '#' + href;

                        // 新增Tab节点
                        X.util.addMainTab(mainTabStrip, node, tbarCallback);
                    }
                });
            }

            // treeMenu可能是Accordion或者Tree
            if (treeMenu.getXType() === 'panel') {
                treeMenu.items.each(function (item) {
                    var tree = item.items.itemAt(0);
                    if (tree && tree.getXType() === 'treepanel') {
                        registerTreeClickEvent(tree);
                    }
                });
            } else if (treeMenu.getXType() === 'treepanel') {
                registerTreeClickEvent(treeMenu);
            }


            // 切换主窗口的Tab
            mainTabStrip.on('tabchange', function (tabStrip, tab) {
                if (tab.url) {
                    //window.location.href = '#' + tab.url;
                    window.location.hash = '#' + tab.url;
                } else {
                    window.location.hash = '#';
                }
            });


            // 页面第一次加载时，根据URL地址在主窗口加载页面
            var HASH = window.location.hash.substr(1);
            var FOUND = false;

            function initTreeMenu(treeInstance, node) {
                var i, currentNode, nodes, node, path;
                if (!FOUND && node.hasChildNodes()) {
                    nodes = node.childNodes;
                    for (i = 0; i < nodes.length; i++) {
                        currentNode = nodes[i];
                        if (currentNode.isLeaf()) {
                            if (currentNode.attributes.href === HASH) {
                                path = currentNode.getPath();
                                treeInstance.expandPath(path); //node.expand();
                                treeInstance.selectPath(path); // currentNode.select();
                                X.util.addMainTab(mainTabStrip, currentNode, tbarCallback);
                                FOUND = true;
                                return;
                            }
                        } else {
                            arguments.callee(treeInstance, currentNode);
                        }
                    }
                }
            }

            if (treeMenu.getXType() === 'panel') {
                treeMenu.items.each(function (item) {
                    var tree = item.items.itemAt(0);
                    if (tree && tree.getXType() === 'treepanel') {
                        initTreeMenu(tree, tree.getRootNode());

                        // 找到树节点
                        if (FOUND) {
                            item.expand();
                            return false;
                        }
                    }
                });
            } else if (treeMenu.getXType() === 'treepanel') {
                initTreeMenu(treeMenu, treeMenu.getRootNode());
            }

        },


        resolveCheckBoxGroup: function (name, xstateContainer) {
            var items = [], i, count, xitem, xitemvalue, xitems, xselectedarray, xselected, xchecked, xitemname;

            xitems = xstateContainer.X_Items;
            xselectedarray = xstateContainer.SelectedValueArray;
            xselected = xstateContainer.SelectedValue;

            if (xitems && xitems.length > 0) {
                for (i = 0, count = xitems.length; i < count; i++) {
                    xitem = xitems[i];
                    xitemvalue = xitem[1];
                    if (xselectedarray) {
                        xchecked = (xselectedarray.indexOf(xitemvalue) >= 0) ? true : false;
                        xitemname = name + '_' + i;
                    } else {
                        xchecked = (xselected === xitemvalue) ? true : false;
                        xitemname = name;
                    }
                    items.push({
                        'inputValue': xitemvalue,
                        'boxLabel': xitem[0],
                        'name': xitemname,
                        'checked': xchecked
                    });
                }
            } else {
                items.push({
                    'inputValue': "tobedeleted",
                    'boxLabel': "&nbsp;",
                    'name': "tobedeleted"
                });
            }

            return items;

        }


    };




})();