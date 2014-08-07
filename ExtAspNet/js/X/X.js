
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




})();﻿
(function () {

    X.ajax = {

        errorMsg: "Error! {0} ({1})",

        hookPostBack: function () {
            if (typeof (__doPostBack) != 'undefined') {
                __doPostBack = x__doPostBack;
            }
        }

    };

    function enableAjax() {
        if (typeof (X.control_enable_ajax) === 'undefined') {
            return X.global_enable_ajax;
        }
        return X.control_enable_ajax;
    }

    function enableAjaxLoading() {
        if (typeof (X.control_enable_ajax_loading) === 'undefined') {
            return X.global_enable_ajax_loading;
        }
        return X.control_enable_ajax_loading;
    }

    function ajaxLoadingType() {
        if (typeof (X.control_ajax_loading_type) === 'undefined') {
            return X.global_ajax_loading_type;
        }
        return X.control_ajax_loading_type;
    }


    function x__doPostBack_internal() {
        if (typeof (X.util.beforeAjaxPostBackScript) === 'function') {
            X.util.beforeAjaxPostBackScript();
        }

        // Ext.encode will convert Chinese characters. Ext.encode({a:"你好"}) => '{"a":"\u4f60\u597d"}'
        // We will include the official JSON object from http://json.org/
        // 现在还是用的 Ext.encode，在 IETester的 IE8下 JSON.stringify 生成的中文是\u9009\u9879形式。
        //X.util.setHiddenFieldValue('X_STATE', encodeURIComponent(JSON.stringify(getXState())));

        var xstate = Ext.encode(getXState());
        if (Ext.isIE6 || Ext.isIE7) {
            X.util.setHiddenFieldValue('X_STATE_URI', 'true');
            xstate = encodeURIComponent(xstate);
        } else {
            xstate = Base64.encode(xstate);
        }
        X.util.setHiddenFieldValue('X_STATE', xstate);
        //X.util.setHiddenFieldValue('X_STATE', encodeURIComponent(Ext.encode(getXState())));
        if (!enableAjax()) {
            // 当前请求结束后必须重置 X.control_enable_ajax
            X.control_enable_ajax = undefined;
            X.util.setHiddenFieldValue('X_AJAX', 'false');
            theForm.submit();
        } else {
            // 当前请求结束后必须重置 X.control_enable_ajax
            X.control_enable_ajax = undefined;
            X.util.setHiddenFieldValue('X_AJAX', 'true');
            var url = document.location.href;
            var urlHashIndex = url.indexOf('#');
            if (urlHashIndex >= 0) {
                url = url.substring(0, urlHashIndex);
            }
            Ext.Ajax.request({
                form: theForm.id,
                url: url,
                isUpload: X.form_upload_file,
                //params: serializeForm(theForm) + '&X_AJAX=true',
                success: function (data) {
                    // see: http://extjs.com/forum/showthread.php?t=8129
                    // 如果页面中有FileUpload，responseObj.responseText会包含于 <pre>标签。
                    var scripts = data.responseText;
                    if (scripts) {
                        // 已经经过encodeURIComponent编码了，在ResponseFilter中的Close函数中
                        var prefix = scripts.substr(0, 4);
                        if (prefix.toLowerCase() === '<pre') {
                            //scripts = scripts.substr(5, scripts.length - 11);
                            //scripts = decodeURIComponent(scripts.replace(/<\/?pre>/ig, ''));
                            scripts = scripts.replace(/<\/?pre[^>]*>/ig, '');
                            scripts = decodeURIComponent(scripts);
                        }
                        //eval(scripts);
                        new Function(scripts)();
                    }
                    X.ajaxReady();
                },
                failure: function (data) {
                    var lastDisabledButtonId = X.util.getHiddenFieldValue('X_TARGET');
                    if (lastDisabledButtonId) {
                        X.enable(lastDisabledButtonId);
                    }
                    //X.util.alert(String.format(X.ajax.errorMsg, data.statusText, data.status));

                    if (!X.ajax.errorWindow) {
                        initErrorWindow();
                    }
                    X.ajax.errorWindow.show();
                    X.ajax.errorWindow.body.dom.innerHTML = X.wnd.createIFrameHtml('about:blank', 'EXTASPNET_ERROR');
                    X.ajax.errorWindow.setTitle(String.format(X.ajax.errorMsg, data.statusText, data.status));
                    writeContentToIFrame(X.ajax.errorWindow.body.query('iframe')[0], data.responseText);
                    //writeContentToIFrame(Ext.DomQuery.selectNode('iframe', X.ajax.errorWindow.body), data.responseText);
                }
            });
        }
    }


    // 如果启用 Ajax，则所有对 __doPostBack 的调用都会到这里来
    function x__doPostBack(eventTarget, eventArgument) {
        // 回发页面之前延时 100 毫秒，确保页面上的操作完成（比如选中复选框的动作）
        window.setTimeout(function () {
            // theForm variable will always exist, because we invoke the GetPostBackEventReference in PageManager.
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.__EVENTTARGET.value = eventTarget;
                theForm.__EVENTARGUMENT.value = eventArgument;

                x__doPostBack_internal();
            }
        }, 100);
    }


    function writeContentToIFrame(iframe, content) {
        // http://stackoverflow.com/questions/1477547/getelementbyid-contentdocument-error-in-ie
        // contentWindow is always there.
        if (iframe) {
            var doc = iframe.contentWindow.document;
            //            if (iframe.contentDocument) {
            //                doc = iframe.contentDocument;
            //            } else if (iframe.contentWindow) {
            //                doc = iframe.contentWindow.document;
            //            }
            if (doc) {
                doc.open();
                doc.write(content);
                doc.close();
            }
        }
    }

    function initErrorWindow() {
        X.ajax.errorWindow = new Ext.Window({
            id: "EXTASPNET_ERROR",
            renderTo: window.body,
            width: 550,
            height: 350,
            border: true,
            animCollapse: true,
            collapsible: false,
            collapsed: false,
            closeAction: "hide",
            plain: false,
            modal: true,
            draggable: true,
            minimizable: false,
            minHeight: 100,
            minWidth: 200,
            resizable: false,
            maximizable: false,
            closable: true
        });
    }

    // Ext.Ajax.serializeForm has a fault. The result will include type="submit" section, which is not always right.
    /*
    function serializeForm(form) {
    var originalStr = Ext.Ajax.serializeForm(form);
    for (var i = 0; i < form.elements.length; i++) {
    el = form.elements[i];
    if (el.type === 'submit') {
    var submitStr = encodeURIComponent(el.name) + '=' + encodeURIComponent(el.value);
    if (originalStr.indexOf(submitStr) == 0) {
    originalStr = originalStr.replace(submitStr, '');
    } else {
    originalStr = originalStr.replace('&' + submitStr, '');
    }
    }
    }
    return originalStr;
    }
    */

    // 序列化表单为 URL 编码字符串，除去 <input type="submit" /> 的按钮
    /*
    var extjsSerializeForm = Ext.lib.Ajax.serializeForm;
    Ext.lib.Ajax.serializeForm = function (form) {
    var el, originalStr = extjsSerializeForm(form);
    for (var i = 0; i < form.elements.length; i++) {
    el = form.elements[i];
    if (el.type === 'submit') {
    var submitStr = encodeURIComponent(el.name) + '=' + encodeURIComponent(el.value);
    if (originalStr.indexOf(submitStr) == 0) {
    originalStr = originalStr.replace(submitStr, '');
    } else {
    originalStr = originalStr.replace('&' + submitStr, '');
    }
    }
    }
    return originalStr;
    };
    */

    function getXState() {
        var state = {};
        Ext.ComponentMgr.all.each(function (cmp, index) {
            if (cmp.isXType) {
                // x_props store the properties which has been changed on server-side or client-side.
                // Every ExtAspNet control should has this property.
                var xstate = cmp['x_state'];
                if (xstate && Ext.isObject(xstate)) {
                    var cmpState = getXStateViaCmp(cmp, xstate);
                    if (!X.util.isObjectEmpty(cmpState)) {
                        state[cmp.id] = cmpState;
                    }
                }
            }
        });
        return state;
    }

    X.ajax.getXState = getXState;

    function getXStateViaCmp(cmp, xstate) {
        var state = {};

        Ext.apply(state, xstate);

        function saveInHiddenField(property, currentValue) {
            // Save this client-changed property in a form hidden field. 
            X.util.setHiddenFieldValue(cmp.id + '_' + property, currentValue);
        }



        // 有些属性可以在客户端改变，因此需要在每个请求之前计算
        if (cmp.isXType('panel')) {
            saveInHiddenField('Collapsed', cmp.collapsed);
        }

        if (cmp.isXType('datepicker')) {
            saveInHiddenField('SelectedDate', cmp.getValue().format(cmp.initialConfig.format));
        }

        if (cmp.isXType('button')) {
            if (cmp.initialConfig.enableToggle) {
                saveInHiddenField('Pressed', cmp.pressed);
            }
        }

        if (cmp.isXType('grid')) {
            saveInHiddenField('SelectedRowIndexArray', cmp.x_getSelectedRows().join(','));
            saveInHiddenField('HiddenColumnIndexArray', cmp.x_getHiddenColumns().join(','));
            saveInHiddenField('RowStates', Ext.encode(cmp.x_getRowStates()));
        }

        if (cmp.isXType('treepanel')) {
            saveInHiddenField('ExpandedNodes', cmp.x_getExpandedNodes(cmp.getRootNode().childNodes).join(','));
            saveInHiddenField('CheckedNodes', cmp.x_getCheckedNodes().join(','));
            saveInHiddenField('SelectedNodeIDArray', cmp.x_getSelectedNodes().join(','));
        }

        if (cmp.isXType('tabpanel')) {
            saveInHiddenField('ActiveTabIndex', cmp.x_getActiveTabIndex());
        }

        if (cmp['x_type']) {
            if (cmp['x_type'] === 'tab') {
                saveInHiddenField('Hidden', cmp.tabEl.style.display === 'none');
            }
        }

        //        if (cmp.isXType('combo')) {
        //            saveInHiddenField('SelectedValue', cmp.getValue());
        //        }

        return state;

        //        function clientChangableProperty(property, currentValue, saveInHiddenField) {
        //            if (saveInHiddenField) {
        //                // Save this client-changed property in a form hidden field. 
        //                X.util.setHiddenFieldValue(cmp.id + '_' + property, currentValue);
        //            }

        //            // xstate is changed in server-side.
        //            //            var lastValue = xstate[property];
        //            //            // If lastValue is not exist or it has been changed, then save the new value.
        //            //            if (!lastValue || lastValue.toString() !== currentValue.toString()) {
        //            //                xstate[property] = currentValue;
        //            //            }
        //        }

        //        var xType = cmp.getXType();
        //        switch (xType) {
        //            case 'button':
        //                // The EnablePress property has been enabled for this button.
        //                if (cmp.initialConfig.enableToggle) {
        //                    saveInHiddenField('Pressed', cmp.pressed);
        //                }
        //                break;
        //            case 'checkbox':
        //            case 'radio':
        //                // Although the 'Checked' property can be changed in client-side.
        //                // But we don't save it in X_STATE, because it will be exist in form (input type="checkbox").
        //                clientChangableProperty('Checked', cmp.getValue());
        //                break;
        //            case 'radiogroup':
        //                // Although the 'Checked' property can be changed in client-side.
        //                // But we don't save it in X_STATE, because it will be exist in form (input type="checkbox").
        //                clientChangableProperty('SelectedValue', cmp.getValue());
        //                break;
        //            case 'combo':
        //                clientChangableProperty('X_SelectedValue', cmp.getValue());
        //                break;
        //            case 'textfield':
        //                // Although the 'Text' property can be changed in client-side.
        //                // But we don't save it in X_STATE, because it will be exist in form.
        //                clientChangableProperty('Text', cmp.getValue());
        //                break;
        //            case 'window':
        //                // Although the 'Hidden' property can be changed in client-side.
        //                // But we don't save it in X_STATE, because it will be exist in form - HiddenHiddenFieldID.
        //                clientChangableProperty("Hidden", X.util.getHiddenFieldValue(cmp.id + '_Hidden') === 'true' ? true : false);
        //                break;
        //            case 'grid':
        //                // X('Grid1').getStore().indexOfId(X('Grid1').getSelectionModel().getSelections()[0].id)
        //                clientChangableProperty('SelectedRowIndexArray', cmp.x_getSelectedRows(), true);
        //                break;
        //            case 'tabpanel':
        //                clientChangableProperty('ActiveTabIndex', cmp.items.indexOf(cmp.getActiveTab()), true);
        //                break;
        //        }
    }



    // 显示“正在载入...”的提示信息
    function _showAjaxLoading(ajaxLoadingType) {
        if (_requestCount > 0) {

            if (ajaxLoadingType === "default") {
                X.ajaxLoadingDefault.setStyle('left', (Ext.getBody().getWidth() - X.ajaxLoadingDefault.getWidth()) / 2 + 'px');
                X.ajaxLoadingDefault.show();
            } else {
                X.ajaxLoadingMask.show();
            }

        }
    }

    // 隐藏“正在载入...”的提示信息
    function _hideAjaxLoading(ajaxLoadingType) {
        if (_requestCount <= 0) {
            _requestCount = 0;

            if (ajaxLoadingType === "default") {
                X.ajaxLoadingDefault.hide();
            } else {
                X.ajaxLoadingMask.hide();
            }

        }
    }

    // 当前 Ajax 的并发请求数
    var _requestCount = 0;

    // 发起 Ajax 请求之前事件处理
    Ext.Ajax.on('beforerequest', function (conn, options) {
        _requestCount++;

        if (!enableAjaxLoading()) {
            // Do nothing
        } else {
            Ext.defer(_showAjaxLoading, 100, window, [ajaxLoadingType()]);
        }
    });

    // Ajax 请求结束
    Ext.Ajax.on('requestcomplete', function (conn, options) {
        _requestCount--;

        if (!enableAjaxLoading()) {
            // ...
        } else {
            Ext.defer(_hideAjaxLoading, 80, window, [ajaxLoadingType()]);
        }
        X.control_enable_ajax_loading = undefined;
        X.control_ajax_loading_type = undefined;
    });

    // Ajax 请求发生异常
    Ext.Ajax.on('requestexception', function (conn, options) {
        _requestCount--;

        if (!enableAjaxLoading()) {
            // ...
        } else {
            Ext.defer(_hideAjaxLoading, 100);
        }
        X.control_enable_ajax_loading = undefined;
        X.control_ajax_loading_type = undefined;
    });






    //        // 不适用于所有Extjs控件（比如Toolbar中放置按钮，这个按钮就没有ownerCt对象）
    //        // 更新一个Javascript对象
    //        updateObject: function(obj, newObjFunction, renderImmediately) {
    //            var id = obj.id;
    //            if (Ext.type(renderImmediately) == 'boolean' && !renderImmediately) {

    //                // 1.取得父容器
    //                var owner = obj.ownerCt;
    //                // 2.本控件在父容器的位置
    //                var insertIndex = owner.items.indexOf(obj);
    //                // 3.从父容器中销毁此控件
    //                owner.remove(obj);
    //                // 4.创建新的控件
    //                newObjFunction();
    //                // 5.将新的控件添加到删除的位置
    //                owner.insert(insertIndex, Ext.getCmp(id));
    //                // 6.父容器重新布局
    //                owner.doLayout();

    //            }
    //            else {

    //                // 1.销毁此控件
    //                obj.destroy();
    //                // 2.新建此控件
    //                newObjFunction();
    //            }
    //        }

})();﻿

(function () {

    // 计算黄金分割点的位置
    // bodySize : 整个页面的Body的大小 
    // windowSize : 窗口的大小
    function _calculateGoldenPosition(bodySize, windowSize) {
        var top = (bodySize.height - (bodySize.height / 1.618)) - windowSize.height / 2;
        if (top < 0) {
            top = 0;
        }
        var left = (bodySize.width - windowSize.width) / 2;
        if (left < 0) {
            left = 0;
        }
        return { left: left, top: top };
    }

    // 计算中间的位置
    // bodySize : 整个页面的Body的大小 
    // windowSize : 窗口的大小
    function _calculateCenterPosition(bodySize, windowSize) {
        var top = (bodySize.height - windowSize.height) / 2;
        if (top < 0) {
            top = 0;
        }
        var left = (bodySize.width - windowSize.width) / 2;
        if (left < 0) {
            left = 0;
        }
        return { left: left, top: top };
    }



    // 创建IFrame节点片段
    function _createIFrameHtml(iframeUrl, iframeName) {
        return '<iframe frameborder="0" style="overflow:auto;height:100%;width:100%;" name="' + iframeName + '" src="' + iframeUrl + '"></iframe>';
    }

    // 获取窗体的外部容器
    function _getWrapperNode(panel) {
        return Ext.get(panel.el.findParentNode('.x-window-wrapper'));
    }

    // ExtAspNet窗口域（Window）
    X.wnd = {

        closeButtonTooltip: "Close this window",
        formModifiedConfirmTitle: "Close Confrim",
        formModifiedConfirmMsg: "Current form has been modified.<br/><br/>Abandon changes?",

        createIFrameHtml: function (iframeUrl, iframeName) {
            return _createIFrameHtml(iframeUrl, iframeName);
        },

        // 显示一个弹出窗体
        // 在 panel 实例中，定义了几个自定义属性，用于标示此实例的状态（在PanelBase中定义）
        // 属性 - x_iframe/x_iframe_url/x_iframe_name/x_iframe_loaded
        // panel : 当前弹出的窗体（Ext-Window）
        // iframeUrl : 弹出窗体中包含的IFrame的地址
        // windowTitle : 弹出窗体的标题
        // left/top : 弹出窗体的左上角坐标（如果为空字符串，则使用中间位置或黄金分隔位置）
        // isGoldenSection : 弹出窗体位于页面的黄金分隔位置
        // hiddenHiddenFieldID : 在页面中放置表单字段记录此窗体是否弹出，也页面回发时保持状态用
        show: function (panel, iframeUrl, windowTitle, left, top, isGoldenSection, hiddenHiddenFieldID) {
            var target = X.util.getTargetWindow(panel['box_property_target']);
            var guid = panel['box_property_guid'];
            if (window.frameElement && target !== window) {
                // 当前页面在IFrame中（也即时 window.frameElement 存在）
                // 此弹出窗体需要在父窗口中弹出
                if (!target.X[guid]) {
                    // 父窗口中已经创建了这个Ext-Window对象
                    var wrapper = guid + '_wrapper';
                    if (!target.Ext.get(wrapper)) {
                        target.X.util.appendFormNode('<div class="x-window-wrapper" id="' + wrapper + '"></div>');
                    } else {
                        target.Ext.get(wrapper).dom.innerHTML = '';
                    }
                    // Ext.apply 的第三个参数是default obejct
                    var config = Ext.apply({}, {
                        'renderTo': wrapper,
                        'manager': target.X.window_default_group,
                        'id': guid,
                        'box_hide': null,
                        'box_hide_refresh': null,
                        'box_hide_postback': null,
                        'box_show': null,
                        // 在 X.wnd.getActiveWindow 中需要用到这个参数
                        //'box_property_frame_element_name': window.frameElement.name,
                        //'box_property_client_id': panel.getId(),
                        'box_property_window': window,
                        'box_property_ext_window': panel
                    }, panel.initialConfig);

                    // 在父页面中创建一个Ext-Window的幻影（拷贝）
                    // 在这个幻影中，通过“box_property_frame_element_name”属性标示这是一个幻影
                    // box_property_frame_element_name: 并且真正的Ext-Window在当前页面中的哪个IFrame中
                    // box_property_client_id: 并且真正的Ext-Window在所在页面中的客户端ID
                    target.X[guid] = new target.Ext.Window(config);
                }
                panel = target.X[guid];
            }
            if (iframeUrl !== '') {
                X.wnd.updateIFrameNode(panel, iframeUrl);
            }
            if (windowTitle != '') {
                panel.setTitle(windowTitle);
            }

            var bodySize = target.window.Ext.getBody().getViewSize();

            //            // Update container's width and height
            //            var wrapperNode = _getWrapperNode(panel);
            //            wrapperNode.setWidth(bodySize.width).setHeight(bodySize.height);
            //            
            //            // 显示窗体之前，记着显示外部的容器
            //            wrapperNode.show();

            Ext.get(hiddenHiddenFieldID).dom.value = 'false';
            panel.show();

            if (left !== '' && top !== '') {
                panel.setPosition(parseInt(left, 10), parseInt(top, 10));
            }
            else {
                var panelSize = panel.getSize(), leftTop;
                if (isGoldenSection) {
                    leftTop = _calculateGoldenPosition(bodySize, panelSize);
                } else {
                    leftTop = _calculateCenterPosition(bodySize, panelSize);
                    //panel.alignTo(target.Ext.getBody(), "c-c");
                }
                panel.setPosition(leftTop.left, leftTop.top);
            }


            X.wnd.fixMaximize(panel);
        },

        // 隐藏Ext-Window（比如用户点击了关闭按钮）
        hide: function (panel, targetName, enableIFrame, hiddenHiddenFieldID, guid) {
            var target = X.util.getTargetWindow(targetName);
            // 修改当前页面中记录弹出窗口弹出状态的隐藏表单字段
            Ext.get(hiddenHiddenFieldID).dom.value = 'true';
            if (window.frameElement && target !== window) {
                // 从父页面中查找幻影Ext-Window对象
                panel = target.X[guid];
            }
            // 如果启用IFrame，则清空IFrame的内容，防止下次打开时显示残影
            if (enableIFrame) {
                panel.body.first().dom.src = 'about:blank';
                panel['x_iframe_url'] = 'about:blank';
            }
            panel.hide();

            //            // 关闭窗体的时候，记着隐藏外部的容器
            //            var wrapperNode = _getWrapperNode(panel);
            //            wrapperNode.hide();
        },

        // 这是 Extjs 的一个 bug，如果 Window 控件不是渲染在 document.body 中，则 maximize 函数并不能真正的最大化
        // 现在的 Window 控件时渲染在 from 表单里面的一个 DIV 中的
        fixMaximize: function (panel) {
            if (panel.maximized) {
                var target = X.util.getTargetWindow(panel['box_property_target']);
                var bodySize = target.window.Ext.getBody().getViewSize();
                panel.setSize(bodySize.width, bodySize.height);
                // 不要忘记左上角坐标
                panel.setPosition(0, 0);
            }
        },

        // 创建或更新IFrame节点，同时更新panel实例中的自定义属性值
        updateIFrameNode: function (panel, iframeUrl) {
            var iframeUrlChanged = false;
            // 如果此Panel中包含有IFrame
            if (panel && panel['x_iframe']) {
                if (iframeUrl && panel['x_iframe_url'] !== iframeUrl) {
                    panel['x_iframe_url'] = iframeUrl;
                    iframeUrlChanged = true;
                }
                // 如果此Panel中包含的IFrame还没有加载
                if (!panel['x_iframe_loaded']) {
                    window.setTimeout(function () {
                        // 如果此Panel已经创建完毕，但有时Panel可能是延迟创建的（比如TabStrip中的Tab，只有点击这个Tab时才创建Tab的内容）
                        if (panel.body) {
                            panel['x_iframe_loaded'] = true;
                            panel.body.dom.innerHTML = _createIFrameHtml(panel['x_iframe_url'], panel['x_iframe_name']);
                        }
                    }, 0);
                }
                else {
                    if (iframeUrlChanged) {
                        panel.body.first().dom.src = panel['x_iframe_url'];
                    }
                }
            }
        },


        // 处理表单中有任何字段发生变化时，关闭当前窗口时的提示
        confirmFormModified: function (closeFn) {
            if (X.util.isPageStateChanged()) {
                Ext.MessageBox.show({
                    title: X.wnd.formModifiedConfirmTitle,
                    msg: X.wnd.formModifiedConfirmMsg,
                    buttons: Ext.MessageBox.OKCANCEL,
                    icon: 'ext-mb-warning',
                    fn: function (btn) {
                        if (btn == 'cancel') {
                            return false;
                        } else {
                            closeFn.apply(window, arguments);
                        }
                    }
                });
            } else {
                closeFn.apply(window, arguments);
            }
        },


        // Ext-Window中IFrame里页面中的表单发生变化时弹出确认消息
        extWindowIFrameFormModifiedConfirm: function (panel, closeFn) {
            // 这个页面所在的Window对象
            var pageWindow = X.wnd.getIFrameWindowObject(panel);
            // 如果弹出的页面没能正常加载（比如说网络暂时连接中断）
            // 则直接关闭弹出的Ext-Window，而不会去检查页面表单变化，因为页面对象不存在
            if (pageWindow.X) {
                pageWindow.X.wnd.confirmFormModified(closeFn);
            }
            else {
                panel.box_hide();
            }
        },

        // 取得panel的Iframe节点的window对象（可以是幻影Ext-Window中的页面window对象）
        getIFrameWindowObject: function (panel) {
            // 当前页面在IFrame中（也即时 window.frameElement 存在）
            // 此Ext-Window需要在父窗口中弹出
            if (window.frameElement && panel['box_property_show_in_parent']) {
                panel = parent.X[panel['box_property_guid']];
            }
            var iframeNode = Ext.query('iframe', panel.body.dom);
            if (iframeNode.length === 0) {
                // 当前panel（Ext-Window）不包含iframe
                return window;
            }
            else {
                return iframeNode[0].contentWindow;
            }
        },


        // 这是老方法，虽然也能正常工作，但是绕了一个弯 => 在幻影ExtWindow中保存当前IFrame的parent.window以及iframe name。
        // 其实没必要，直接在幻影ExtWindow中保存真实的ExtWindow对象即可（只不过这个对象可能是在其他页面中）。
        // 取得当前页面所在的Ext-Window实际的对象，返回[实际的Ext-Window对象，实际的Ext-Window对象所在的window对象]
        // 注意
        // 1. 如果是在当前页面弹出窗口的话，“实际的Ext-Window对象”存在于父页面（parent.box）中
        // 2. 如果是在父页面弹出窗口的话，“实际的Ext-Window对象”存在于父页面（parent）下面的IFrame页面中
        // 3. 通过判断当前的Ext-Window是否存在“box_property_frame_element_name”属性，可知当前的Ext-Window是否幻影（即时实际Ext-Window对象在父页面的一个拷贝），在X.wnd.show中设置的属性
        /*
        getActiveWindow: function () {
        var activeWindow = parent.window;
        var activeExtWindow = parent.X.window_default_group.getActive();
        if (activeExtWindow['box_property_frame_element_name']) {
        var iframeParentWindow = activeExtWindow['box_property_parent_window'];
        activeWindow = iframeParentWindow.Ext.query('iframe[name=' + activeExtWindow['box_property_frame_element_name'] + ']')[0].contentWindow;
        activeExtWindow = activeWindow.Ext.getCmp(activeExtWindow['box_property_client_id']);
        }

        return [activeExtWindow, activeWindow];
        },
        */

        getActiveWindow: function () {
            var activeWindow = parent.window;
            var activeExtWindow = parent.X.window_default_group.getActive();
            if (activeExtWindow['box_property_window']) {
                activeWindow = activeExtWindow['box_property_window'];
                activeExtWindow = activeExtWindow['box_property_ext_window'];
            }

            return [activeExtWindow, activeWindow];
        },


        //    // 从url中提取box_parent_client_id参数的值
        //    window.box_getParentClientIdFromUrl = function() {
        //        var result = '';
        //        var url = window.location.href;
        //        var startIndex = url.indexOf('box_parent_client_id');
        //        if (startIndex >= 0) {
        //            result = url.substr(startIndex + 'box_parent_client_id'.length + 1);
        //        }

        //        return result;
        //    };

        //    // 取得当前页面所在窗口，返回数组[当前窗口对象，当前窗口所在的window对象]
        //    window.box_getActiveWindow = function() {
        //        var aw = null;
        //        var window2 = null;

        //        var parentClientID = box_getParentClientIdFromUrl();
        //        if (parentClientID) {
        //            window2 = parent.window;
        //            aw = parent.window.Ext.getCmp(parentClientID);
        //            if (aw.box_property_frame_element_name) {
        //                window2 = parent.Ext.query('iframe[name=' + aw.box_property_frame_element_name + ']')[0].contentWindow;
        //                aw = eval('window2.X.' + aw.id);
        //            }
        //        }

        //        if (aw) {
        //            return [aw, window2];
        //        }
        //        else {
        //            return null;
        //        }
        //    };

        // 向弹出此Ext-Window的页面写入值
        writeBackValue: function () {
            var aw = X.wnd.getActiveWindow();
            var controlIds = aw[0]['box_property_save_state_control_client_ids'];
            var controlCount = Math.min(controlIds.length, arguments.length);
            for (var i = 0; i < controlCount; i++) {
                aw[1].Ext.getCmp(controlIds[i]).setValue(arguments[i]);
            }
            //        var controlClientIds = (function() {
            //            if (aw) {
            //                return eval('aw[1].X.' + aw[0].id + '.box_string_state');
            //            }
            //        })();
            //        if (typeof (controlClientIds) == 'string') {
            //            aw[1].Ext.getCmp(controlClientIds).setValue("哈哈");
            //        } else {
            //            aw[1].Ext.getCmp(controlClientIds[0]).setValue("哈哈");
            //            var controlValues = ['哈哈 的值', '哈哈 的值2'];
            //            var controlCount = Math.min(controlClientIds.length - 1, controlValues.length);
            //            for (var i = 0; i < controlCount; i++) {
            //                aw[1].Ext.getCmp(controlClientIds[i + 1]).setValue(controlValues[i]);
            //            }
            //        }
            //        var aw = X.wnd.getActiveWindow();
            //        if (aw) {
            //            aw[0].box_hide();
            //        }
        }

    };

})();
﻿
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
}﻿
(function() {

    function getParentIndex(levels, level, index) {
        if (level > 0) {
            for (var i = index - 1; i >= 0; i--) {
                if (levels[i] == level - 1) {
                    return i;
                }
            }
        }
        return -1;
    }

    function hasLittleBrother(levels, level, index) {
        if (index < levels.length - 1) {
            for (var i = index + 1; i < levels.length; i++) {
                if (levels[i] == level) {
                    return true;
                } else if (levels[i] < level) {
                    return false;
                }
            }
        }
        return false;
    }

    function getParentTempData(tempdatas, tempdata, prefixIndex) {
        for (var i = 0; i < prefixIndex - 1; i++) {
            tempdata = tempdatas[tempdata.parentIndex];
        }
        return tempdata;
    }

    function getPrefixInner(tempdatas, tempdata, prefixIndex) {
        // If level = 3, then prefixIndex array will be: [3, 2, 1]
        // prefixIndex === 1 will always present the nearest prefix next to the Text.
        if (prefixIndex === 1) {
            if (tempdata.littleBrother) {
                return '<div class="x-elbow"></div>';
            }
            else {
                return '<div class="x-elbow-end"></div>';
            }
        } else {
            var parentdata = getParentTempData(tempdatas, tempdata, prefixIndex);
            if (parentdata.littleBrother) {
                return '<div class="x-elbow-line"></div>';
            }
            else {
                return '<div class="x-elbow-empty"></div>';
            }
        }
        return "";
    }

    function getPrefix(tempdatas, index) {
        var tempdata = tempdatas[index];
        var level = tempdata.level;
        var prefix = [];
        for (var i = level; i > 0; i--) {
            prefix.push(getPrefixInner(tempdatas, tempdata, i));
        }
        return prefix.join('');
    }

    X.simulateTree = {

        transform: function(datas) {
            if (!datas.length || datas[0].length < 4) {
                return datas;
            }

            //// store: new Ext.data.ArrayStore({ fields: ['value', 'text', 'enabled', 'prefix'] })
            //// Sample data:      
            //[
            //    ["0", "jQuery", 0, 0],
            //    ["1", "Core", 0, 1],
            //    ["2", "Selectors", 0, 1],
            //    ["3", "Basic Filters", 1, 2],
            //    ["4", "Content Filters", 1, 2],
            //    ["41", "Contains", 1, 3],
            //    ["5", "Attribute Filters", 1, 2],
            //    ["6", "Traversing", 1, 1],
            //    ["7", "Filtering", 1, 2],
            //    ["8", "Finding", 1, 2],
            //    ["9", "Events", 0, 1],
            //    ["10", "Page Load", 1, 2],
            //    ["11", "Event Handling", 1, 2],
            //    ["12", "Interaction Helpers", 1, 2],
            //    ["13", "Ajax", 1, 1]
            //]
            var levels = [];
            Ext.each(datas, function(data, index) {
                levels.push(data[3]);
            });

            var tempdatas = [];
            Ext.each(levels, function(level, index) {
                tempdatas.push({
                    'level': level,
                    'parentIndex': getParentIndex(levels, level, index),
                    'littleBrother': hasLittleBrother(levels, level, index)
                });
            });

            var newdatas = [];
            Ext.each(datas, function(data, index) {
                newdatas.push([data[0], data[1], data[2], getPrefix(tempdatas, index)]);
            });
            return newdatas;

        }


    };

})();