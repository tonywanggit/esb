



Ext.apply(X.ajax, {
    errorMsg: "出錯了！{0} ({1})"
});

Ext.apply(X.util, {
    alertTitle: "提示對話方塊",
    confirmTitle: "確認對話方塊",
    formAlertMsg: "請為 {0} 提供有效值！",
    formAlertTitle: "表單不完整",
    loading: "正在載入..."
});


Ext.apply(X.wnd, {
    closeButtonTooltip: "關閉此窗口",
    formModifiedConfirmTitle: "確認關閉",
    formModifiedConfirmMsg: "當前表單已經被修改。<br/><br/>確認放棄修改？"
});


if (Ext.ux.SimplePagingToolbar) {
    Ext.apply(Ext.ux.SimplePagingToolbar.prototype, {
        beforePageText: "轉到",
        afterPageText: " 共 {0} 頁",
        firstText: "第一頁",
        prevText: "前一頁",
        nextText: "下一頁",
        lastText: "最後頁",
        displayMsg: "顯示 {0} - {1}，共 {2} 條",
        emptyMsg: "没有資料需要顯示"
    });
}

if (Ext.ux.form && Ext.ux.TabCloseMenu) {
    Ext.apply(Ext.ux.TabCloseMenu.prototype, {
        closeTabText: "關閉標籤",
        closeOtherTabsText: "關閉其它標籤",
        closeAllTabsText: "關閉全部標籤"
    });
}

if (Ext.ux.form && Ext.ux.form.FileUploadField) {
    Ext.apply(Ext.ux.form.FileUploadField.prototype, {
        buttonText: "瀏覽..."
    });
}