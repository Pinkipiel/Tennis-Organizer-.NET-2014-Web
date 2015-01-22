$.validator.methods.range = function (value, element, param) {
	var globalizedValue = value.replace(",", ".");
	return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
	return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}
$.validator.addMethod('regexp', function (value, element, param) {
	return this.optional(element) || value.match(param);
}, "Wprowadź datę w formacie RRRR-MM-DD");

$.validator.addMethod('regexp_email', function (value, element, param) {
	return this.optional(element) || value.match(param);
}, "Wprowadź poprawny adres email");

$.validator.addMethod('regexp_hour', function (value, element, param) {
	return this.optional(element) || value.match(param);
}, "Wprowadź poprawną godzinę (GG:MM)");

$.validator.addClassRules({
	jquery_datepicker: {
		regexp: /^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$/
	}
});
$.validator.addClassRules({
	validate_email: {
		regexp_email: /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/
	}
});
$.validator.addClassRules({
	validate_hour:{
			regexp_hour: /^([^(2[0-3]|1[0-9]|0[0-9]|[^0-9][0-9]):([0-5][0-9]|[0-9])$/
		}
})
