$.validator.addMethod("emailzzz", function (value, element) {
	if (value == false) {
		return true;
	}
	this.optional(element) || /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i.test(value);
});
$.validator.unobtrusive.adapters.addBool("emailzzz");

//value 輸入的值 / param 條件值
$.validator.addMethod("nois", function (value, element, param) {
	if (value == false) {
		return true;
	}

	if (value.indexOf(param) != -1) {
		return false;
	}
	else {
		return true;
	}
});
$.validator.unobtrusive.adapters.addSingleVal("nois", "input");

$.validator.addMethod("rangeday", function (value, element, param) {
    if (!value)
        return true;

    var valueDateParts = value.split('-');
    var minDate = new Date();
    var maxDate = new Date();
    var now = new Date();
    var dateValue = new Date(valueDateParts[0],
                        (valueDateParts[1] - 1),
                         valueDateParts[2],
                         now.getHours(),
                         now.getMinutes(),
                         (now.getSeconds() + 5));

    //minDate.setDate(minDate.getDate() - parseInt(param.min));
    minDate.setDate(minDate.getDate() + parseInt(param[0]));
    //maxDate.setDate(maxDate.getDate() + parseInt(param.max));
    maxDate.setDate(maxDate.getDate() + parseInt(param[1]));

    return dateValue >= minDate && dateValue <= maxDate;
});
$.validator.unobtrusive.adapters.addMinMax('rangeday', 'min', 'max', 'rangeday');

$.validator.addMethod('notequalto', function (value, element, param) {
    //空則略過
    debugger;
    return this.optional(element) || value != $('#' + param).val();
});
$.validator.unobtrusive.adapters.add('notequalto', ['other'], function (options) {
    //options.rules['notequalto'] = '#' + options.params.other;
    options.rules['notequalto'] = options.params.other;
    if (options.message) {
        options.messages['notequalto'] = options.message;
    }
});

