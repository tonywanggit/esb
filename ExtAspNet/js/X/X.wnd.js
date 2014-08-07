

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
