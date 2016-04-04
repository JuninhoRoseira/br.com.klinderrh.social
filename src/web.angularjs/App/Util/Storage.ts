import Interfaces = require("../interfaces/Interfaces");

export class Storage {
	static get(key) {
		var value = localStorage.getItem(key);

		return value ? value : null;

	}

	static getObject(key) {
		var obj = localStorage.getItem(key);

		return obj ? JSON.parse(obj) : null;

	}

	static set(key, value) {
		if (key && value) {
			localStorage.setItem(key, value);
		}
	}

	static setObject(key, value) {
		if (key && value) {
			localStorage.setItem(key, JSON.stringify(value));
		}
	}

	static remove(key) {
		if (key) {
			localStorage.removeItem(key);
		}
	}

	static clear() {
		localStorage.clear();
	}

}