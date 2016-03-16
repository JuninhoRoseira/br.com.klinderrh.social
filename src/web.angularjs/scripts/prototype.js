String.prototype.capitalise = function () {
	var pieces = this.split(" ");

	for (var i = 0; i < pieces.length; i++) {
		var j = pieces[i].charAt(0).toUpperCase();

		pieces[i] = j + pieces[i].substr(1);

	}

	return pieces.join(" ");

};

String.prototype.right = function (n) {
	return this.substring(this.length - n);
};

String.prototype.left = function (n) {
	return this.substring(0, n);
};

String.prototype.trim = function () {
	return this.replace(/^\s+|\s+$/g, "");
};

String.prototype.lTrim = function () {
	return this.replace(/^\s+/, "");
};

String.prototype.rTrim = function () {
	return this.replace(/\s+$/, "");
};

String.prototype.isEmpty = function () {
	return (this.trim().length == 0);
};

String.prototype.format = function () {
	var pattern = /\{\d+\}/g;
	var args = arguments;

	return this.replace(pattern, function (capture) {
		return args[capture.match(/\d+/)];
	});

};

String.prototype.startsWith = function (prefix) {
	return this.indexOf(prefix) === 0;
};

String.prototype.isValidEmail = function () {
	var pattern = /^([a-zA-Z0-9_.-])+@([a-zA-Z0-9_.-])+\.([a-zA-Z])+([a-zA-Z])+/;

	if (pattern.test(this)) {
		return true;
	} else {
		return false;
	}

};

String.prototype.replaceAll = function (token, newtoken) {
	var er = new RegExp("\\" + token, "g");
	var ret = this.replace(er, newtoken);

	return ret;

};

String.prototype.lineBreakToBr = function () {
	var ret = this.replace(/(\r\n|\n|\r)/gm, "<br />");

	return ret;

};

String.prototype.toDate = function () {
	var splitedDate = this.split("/"); // "dd/MM/yyyy"

	return new Date(splitedDate[2], parseFloat(splitedDate[1]) - 1, splitedDate[0]);

};

String.prototype.toDateTime = function () {
	var splitedDateTime = this.split(" "); // "dd/MM/yyyy HH:mm:ss"

	var splitedDate = splitedDateTime[0].split("/"); // "dd/MM/yyyy"
	var splitedTime = splitedDateTime[1].split(":"); // "HH:mm:ss"

	return new Date(
		splitedDate[2],
		parseFloat(splitedDate[1]) - 1,
		splitedDate[0],
		splitedTime[0],
		splitedTime[1],
		(splitedTime.length > 2 ? splitedTime[2] : 0)
	);

};

String.prototype.toBoolean = function () {
	switch (this.toLowerCase()) {
		case "true":
		case "yes":
		case "sim":
		case "1":
			return true;
		case "false":
		case "no":
		case "nao":
		case "não":
		case "0":
		case null:
			return false;
		default:
			return Boolean(this);
	}
};

String.prototype.format = function () {
	var s = this,
        i = arguments.length;

	while (i--) {
		s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
	}

	return s;

};

Date.prototype.compare = function (date2) {
	var date1 = this;

	//Get 1 day in milliseconds
	var oneDay = 1000 * 60 * 60 * 24;

	// Convert both dates to milliseconds
	var date1Ms = date1.getTime();
	var date2Ms = date2.getTime();

	// Calculate the difference in milliseconds
	var differenceMs = date2Ms - date1Ms;
	//return date2Ms - date1Ms;

	// Convert back to days and return
	return Math.round(differenceMs / oneDay);

};

Date.prototype.maiorQue = function (d) {
	return (this > d);
};

Date.prototype.maiorIgualA = function (d) {
	return (this >= d);
};

Date.prototype.toShortString = function () {
	var day = ("00" + this.getDate()).right(2);
	var month = ("00" + (this.getMonth() + 1)).right(2);
	var year = this.getFullYear();

	return (day + "/" + month + "/" + year);

};

Date.prototype.toShortDBString = function () {
	var day = ("00" + this.getDate()).right(2);
	var month = ("00" + (this.getMonth() + 1)).right(2);
	var year = this.getFullYear();

	return (year + "-" + month + "-" + day);

};

Date.prototype.toShortTimeString = function () {
	var hours = ("00" + this.getHours()).right(2);
	var minutes = ("00" + this.getMinutes()).right(2);

	return (hours + ":" + minutes);

};

Date.prototype.toShortDateString = function () {
	var day = ("00" + this.getDate()).right(2);
	var month = ("00" + (this.getMonth() + 1)).right(2);
	var year = this.getFullYear();

	return (day + "/" + month + "/" + year);

};

Date.prototype.toLongString = function () {
	var day = ("00" + this.getDate()).right(2);
	var month = ("00" + (this.getMonth() + 1)).right(2);
	var year = this.getFullYear();
	var hour = ("00" + this.getHours()).right(2);
	var minutes = ("00" + this.getMinutes()).right(2);
	var seconds = ("00" + this.getSeconds()).right(2);

	return (day + "/" + month + "/" + year + " " + hour + ":" + minutes + ":" + seconds);

};

Date.prototype.toLongDBString = function () {
	var day = ("00" + this.getDate()).right(2);
	var month = ("00" + (this.getMonth() + 1)).right(2);
	var year = this.getFullYear();
	var hour = ("00" + this.getHours()).right(2);
	var minutes = ("00" + this.getMinutes()).right(2);
	var seconds = ("00" + this.getSeconds()).right(2);

	return (year + "/" + month + "/" + day + " " + hour + ":" + minutes + ":" + seconds);

};

Date.prototype.somaDias = function (days) {
	var day = this.getDate();
	var month = this.getMonth();
	var year = this.getFullYear();
	var thisDate = new Date(year, month, day);

	thisDate.setDate(thisDate.getDate() + days);

	return thisDate;

};

Date.prototype.somaMes = function (months) {
	var day = this.getDate();
	var month = this.getMonth();
	var year = this.getFullYear();
	var thisDate = new Date(year, month, day);

	thisDate.setMonth(thisDate.getMonth() + months);

	return thisDate;

};

Date.prototype.somaMinutos = function (minutos) {
	this.setMinutes(this.getMinutes() + minutos);
	return this;
};

Date.prototype.somaHoras = function (horas) {
	return this.setHours(this.getHours() + horas);
};

hoje = function () {
	var currentDate = new Date();
	var day = currentDate.getDate();
	var month = currentDate.getMonth();
	var year = currentDate.getFullYear();

	return new Date(year, month, day);

};

agora = function () {
	var currentDate = new Date();
	var day = currentDate.getDate();
	var month = currentDate.getMonth();
	var year = currentDate.getFullYear();
	var hours = currentDate.getHours();
	var minutes = currentDate.getMinutes();
	var seconds = currentDate.getSeconds();

	return new Date(year, month, day, hours, minutes, seconds);

};

function htmlEncode(html) {
	var d = document;
	var a = d.createElement('a');

	return a.appendChild(d.createTextNode(html)).parentNode.innerHTML;

};

function htmlDecode(html) {
	var d = document;
	var a = d.createElement('a');

	a.innerHTML = html;

	return a.textContent;

};

Array.prototype.removeAll = function () {
	for (var i = 0; i < arguments.length; i++) {
		for (var k = 0; k < this.length; k++) {
			if (JSON.stringify(arguments[i]) === JSON.stringify(this[k])) {
				this.splice(k, 1);
			}
		}
	}
};

Array.prototype.insert = function () {
	for (var i = 0; i < arguments.length; i++) {
		this.push(arguments[i]);
	}
};