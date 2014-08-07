
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