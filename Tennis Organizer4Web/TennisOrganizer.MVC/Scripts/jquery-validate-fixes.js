$.validator.methods.range = function (value, element, param) {
	var globalizedValue = value.replace(",", ".");
	return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
	return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}
$.validator.addMethod('regexp', function (value, element, param) {
	return this.optional(element) || value.match(param);
});
$.validator.addClassRules({
	jquery_datepicker: {
		regexp: /^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$/
	}
});