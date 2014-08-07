


Ext.apply(X.ajax, {
    errorMsg: "Error! {0} ({1})"
});

Ext.apply(X.util, {
    alertTitle: "Alert Dialog",
    confirmTitle: "Confirm Dialog",
    formAlertMsg: "Please provide valid value for {0}!",
    formAlertTitle: "Form Invalid",
    loading: "Loading..."
});

Ext.apply(X.wnd, {
    closeButtonTooltip: "Close this window",
    formModifiedConfirmTitle: "Close Confrim",
    formModifiedConfirmMsg: "Current form has been modified.<br/><br/>Abandon changes?"
});



if (Ext.ux.SimplePagingToolbar) {
    Ext.apply(Ext.ux.SimplePagingToolbar.prototype, {
        beforePageText: "Page",
        afterPageText: "of {0}",
        firstText: "First Page",
        prevText: "Previous Page",
        nextText: "Next Page",
        lastText: "Last Page",
        displayMsg: "Displaying {0} - {1} of {2}",
        emptyMsg: 'No data to display'
    });
}

if (Ext.ux.TabCloseMenu) {
    Ext.apply(Ext.ux.TabCloseMenu.prototype, {
        closeTabText: "Close Tab",
        closeOtherTabsText: "Close Other Tabs",
        closeAllTabsText: "Close All Tabs"
    });
}

if (Ext.ux.form && Ext.ux.form.FileUploadField) {
    Ext.apply(Ext.ux.form.FileUploadField.prototype, {
        buttonText: "Browse..."
    });
}