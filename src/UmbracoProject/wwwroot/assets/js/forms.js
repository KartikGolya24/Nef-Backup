$(document).ready(function () {
    function validateForm($form) {

        var isValid = true;
        $('.error-text').addClass('d-none')
        $form.find(".required").each(function () {
            if (isValid) {
                var $field = $(this);
                if ($.trim($field.val()) === "") {
                    isValid = false;
                    $field.addClass("error");
                    $field.siblings(".required-error").removeClass("d-none");
                } else {
                    $field.removeClass("error");
                    $field.siblings(".required-error").addClass("d-none");
                }
            }
        });
        if (isValid)
            // Check regex validation of regex-reuired fields i.e, email and gsrn number 
            $form.find(".regex-reuired").each(function () {
                if (isValid) {
                    var $field = $(this);
                    var fieldValue = $.trim($field.val());
                    var regexPatternStr = $field.data('regex');
                    var regexPattern = new RegExp(regexPatternStr);

                    if (fieldValue !== "" && !regexPattern.test(fieldValue)) {
                        isValid = false;
                        $field.addClass("error");
                        $field.siblings(".regex-error").removeClass("d-none");
                    } else {
                        $field.removeClass("error");
                        $field.siblings(".regex-error").addClass("d-none");
                    }
                }
            });
        return isValid;

    }
    function callAjax($contactForm, requestModel) {
        $contactForm.find('.form_submit_btn').prop('disabled', true); // Disable button during submission to avoid multiple entries

        let $formOuter = $contactForm.find('.form-outer');
        let $formSubmissionSection = $contactForm.find('.form-submitted');
        $.ajax({
            type: 'POST',
            url: `${window.location.origin}/umbraco/surface/CustomForm/SubmitForm`,
            data: JSON.stringify(requestModel),
            contentType: "application/json; charset=utf-8",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("RequestVerificationToken", $('body').find('input:hidden[name="__RequestVerificationToken"]').val());
            },
            success: function () {
                $contactForm.find('.form-outer').hide();
                $formSubmissionSection.removeClass('d-none');
            },
            error: function (err) {
                $contactForm.find('.form_submit_btn').prop('disabled', false);
                $formOuter.show();
                console.warn(err);
            }
        });
    }

    // Sunbeam form submission
    $(document).on('click', '.sunbeam_story_form_submit', function () {
        var $form = $(this).closest("form");

        if (validateForm($form)) {

            var requestModel = new Array();
            requestModel[0] = { key: "formId", value: $form.find('#formId').val() };
            requestModel[1] = { key: "fuldeNavn", value: $form.find('#fuldeNavn').val() };
            requestModel[2] = { key: "adresse", value: $form.find('#adresse').val() };
            requestModel[3] = { key: "telefon", value: $form.find('#telefon').val() };
            requestModel[4] = { key: "email", value: $form.find('#email').val() };
            requestModel[5] = { key: "gSRNNummer", value: $form.find('#gSRNNummer').val() };
            requestModel[6] = { key: "evtKommentar", value: $form.find('#evtKommentar').val() };

            let $contactForm = $form.closest('.contact-form');

            callAjax($contactForm, requestModel);
        }
    });

    // Change existing charging box form submission
    $(document).on('click', '.change_existing_box_form_submit', function () {
        var $form = $(this).closest("form");

        if (validateForm($form)) {

            var requestModel = new Array();
            requestModel[0] = { key: "formId", value: $form.find('#formId').val() };
            requestModel[1] = { key: "forOgEfternavn", value: $form.find('#forOgEfternavn').val() };
            requestModel[2] = { key: "adresse", value: $form.find('#adresse').val() };
            requestModel[3] = { key: "postNr", value: $form.find('#postNr').val() };
            requestModel[4] = { key: "by", value: $form.find('#by').val() };
            requestModel[5] = { key: "telefon", value: $form.find('#telefon').val() };
            requestModel[6] = { key: "email", value: $form.find('#email').val() };
            requestModel[7] = { key: "evtKommentar", value: $form.find('#evtKommentar').val() };

            let $contactForm = $form.closest('.contact-form');

            callAjax($contactForm, requestModel);
        }
    });

    // Tailor Charging Solution Form submission
    $(document).on('click', '.tailor_charging_solution_submit', function () {
        var $form = $(this).closest("form");

        if (validateForm($form)) {

            var requestModel = new Array();
            requestModel[0] = { key: "formId", value: $form.find('#formId').val() };
            requestModel[1] = { key: "forOgEfternavn", value: $form.find('#forOgEfternavn').val() };
            requestModel[2] = { key: "adresse", value: $form.find('#adresse').val() };
            requestModel[3] = { key: "postNr", value: $form.find('#postNr').val() };
            requestModel[4] = { key: "by", value: $form.find('#by').val() };
            requestModel[5] = { key: "telefon", value: $form.find('#telefon').val() };
            requestModel[6] = { key: "email", value: $form.find('#email').val() };
            requestModel[7] = { key: "evtKommentar", value: $form.find('#evtKommentar').val() };

            let $contactForm = $form.closest('.contact-form');

            callAjax($contactForm, requestModel);
        }
    });

    // Board of Representatives Form submission
    $(document).on('click', '.representatives_form_submit', function () {
        var $form = $(this).closest("form");

        if (validateForm($form)) {

            var requestModel = new Array();
            requestModel[0] = { key: "formId", value: $form.find('#formId').val() };
            requestModel[1] = { key: "forOgEfternavn", value: $form.find('#forOgEfternavn').val() };
            requestModel[2] = { key: "adresse", value: $form.find('#adresse').val() };
            requestModel[3] = { key: "cPRNummer", value: $form.find('#cPRNummer').val() };
            requestModel[4] = { key: "telefon", value: $form.find('#telefon').val() };
            requestModel[5] = { key: "email", value: $form.find('#email').val() };

            let $contactForm = $form.closest('.contact-form');

            callAjax($contactForm, requestModel);
        }
    });

    // Ensure the field to enter only 18 digits
    $(document).on("input", " .gsrn-field", function () {
        var val = $(this).val();
        $(this).val(val.replace(/\D/g, "").substring(0, 18));
    });

    // Remove error messages when typing on input fields
    $(document).on("input", ".required, .regex-reuired", function () {
        let $form = $(this).closest("form");
        $(this).removeClass('error')
        $form.find('.error-text').addClass('d-none');
    });
});
