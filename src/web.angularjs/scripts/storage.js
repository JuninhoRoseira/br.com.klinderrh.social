var storage = new LocalStorageDb();

function LocalStorageDb() {
	var instance = this;

	instance.get = function (key) {
		var value = localStorage.getItem(key);

		return value ? value : null;

	};

	instance.getObject = function (key) {
		var obj = localStorage.getItem(key);

		return obj ? JSON.parse(obj) : null;

	};

	instance.set = function (key, value) {
		if (key && value) {
			localStorage.setItem(key, value);
		}
	};

	instance.setObject = function (key, value) {
		if (key && value) {
			localStorage.setItem(key, JSON.stringify(value));
		}
	};

	instance.remove = function (key) {
		if (key) {
			localStorage.removeItem(key);
		}
	};

	instance.clear = function () {
		localStorage.clear();
	};

	return instance;

}