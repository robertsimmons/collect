function CustomLiveValidation(elementId, prettyName) {

	var validation = new LiveValidation(elementId, {
		onValid: function () {
			this.insertMessage(this.createMessageSpan());
			this.addFieldClass();
			$("#" + this.elementId).next("span.LV_valid").html("&#10004;");
		}
	});
	validation.elementId = elementId;
	validation.prettyName = prettyName

	validation.add(Validate.Presence, { failureMessage: prettyName + " must be provided." });

	return validation;
}