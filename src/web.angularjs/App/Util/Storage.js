define(["require", "exports"], function (require, exports) {
    var Storage = (function () {
        function Storage() {
        }
        Storage.get = function (key) {
            var value = localStorage.getItem(key);
            return value ? value : null;
        };
        Storage.getObject = function (key) {
            var obj = localStorage.getItem(key);
            return obj ? JSON.parse(obj) : null;
        };
        Storage.set = function (key, value) {
            if (key && value) {
                localStorage.setItem(key, value);
            }
        };
        Storage.setObject = function (key, value) {
            if (key && value) {
                localStorage.setItem(key, JSON.stringify(value));
            }
        };
        Storage.remove = function (key) {
            if (key) {
                localStorage.removeItem(key);
            }
        };
        Storage.clear = function () {
            localStorage.clear();
        };
        return Storage;
    })();
    exports.Storage = Storage;
});
//# sourceMappingURL=Storage.js.map