
// No use.

Ext.ux.AspNetProxy = function(clientId) {
    // Must define a dummy api with "read" action to satisfy DataProxy#doRequest and Ext.data.Api#prepare *before* calling super
    var api = {};
    api[Ext.data.Api.actions.read] = true;
    Ext.data.MemoryProxy.superclass.constructor.call(this, {
        api: api
    });
    this.clientId = clientId;
};

Ext.extend(Ext.ux.AspNetProxy, Ext.data.DataProxy, {

    doRequest: function(action, rs, params, reader, callback, scope, arg) {
        // No implementation for CRUD in MemoryProxy.  Assumes all actions are 'load'
        params = params || {};

        this.onDoRequest(reader, params, arg, function(data) {
            callback.call(scope, reader.readRecords(data), arg, true);
        }, function(e) {
            // @deprecated loadexception
            this.fireEvent("loadexception", this, null, arg, e);

            this.fireEvent('exception', this, 'response', action, arg, null, e);
            callback.call(scope, null, arg, false);
        });
    },

    onDoRequest: function(reader, params, arg, success, failure) {
        if (params.dir && params.sort) {
            var columnIndex = Ext.getCmp(this.clientId).getColumnModel().getIndexById(params.sort);
            __doPostBack(this.clientId, "Sort$" + columnIndex, success, failure);
        }
    }
});