



Ext.apply(X.ajax, {
    errorMsg: "出错了！{0} ({1})"
});

Ext.apply(X.util, {
    alertTitle: "提示对话框",
    confirmTitle: "确认对话框",
    formAlertMsg: "请为 {0} 提供有效值！",
    formAlertTitle: "表单不完整",
    loading: "正在加载..."
});


Ext.apply(X.wnd, {
    closeButtonTooltip: "关闭此窗口",
    formModifiedConfirmTitle: "确认关闭",
    formModifiedConfirmMsg: "当前表单已经被修改。<br/><br/>确认放弃修改？"
});


if (Ext.ux.SimplePagingToolbar) {
    Ext.apply(Ext.ux.SimplePagingToolbar.prototype, {
        beforePageText: "转到",
        afterPageText: " 共 {0} 页",
        firstText: "第一页",
        prevText: "前一页",
        nextText: "下一页",
        lastText: "最后页",
        displayMsg: "显示 {0} - {1}，共 {2} 条",
        emptyMsg: '没有数据需要显示'
    });
}

if (Ext.ux.TabCloseMenu) {
    Ext.apply(Ext.ux.TabCloseMenu.prototype, {
        closeTabText: "关闭标签",
        closeOtherTabsText: "关闭其它标签",
        closeAllTabsText: "关闭全部标签"
    });
}


if (Ext.ux.form && Ext.ux.form.FileUploadField) {
    Ext.apply(Ext.ux.form.FileUploadField.prototype, {
        buttonText: "浏览..."
    });
}