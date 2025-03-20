var addressId = "";
var addressName = "";

dawaAutocomplete.dawaAutocomplete(document.getElementById("adresse"), {
    select: function (selected) {
        addressId = selected.data.id
        addressName = selected.tekst;

        $(".location-search-button").prop("disabled", false);

    }
});

$(document).ready(function () {
    $("#adresse").on('keyup', function () {
        $(".location-search-button").prop("disabled", true);
    })

    $(".location-search-button").on('click', function () {
        var flowName = "Privat";
        var packageType = $(this).data("package");
        var origin = window.location.origin;
        var redirectUrl = $(this).data("redirecturl");
        if ($("#tab_id").hasClass("business-tab")) {
            flowName = "Business";
        }

        if (addressId && addressId != "") {
            $.ajax({
                url: "https://productsapi.nef.dk/api/CheckAddress" + "?adresseGUID=" + addressId,
                type: "Get",
                success: function (res) {
                    debugger
                    var TvPackageStatus = 1;
                    var FiberPackageStatus = 1;
                    if (packageType == "tv") {
                        TvPackageStatus = res.tvPackageResult;
                        FiberPackageStatus = null;
                    } else {
                        FiberPackageStatus = res.fiberConnectionResult;
                        TvPackageStatus = null;
                    }

                    console.log(res)
                    var pageUrl = `${origin}${redirectUrl}`;
                    postData(flowName, packageType, pageUrl, TvPackageStatus, FiberPackageStatus, addressName)
                },
                error: function () {
                    alert("error")
                }
            })
        } else {
            $(".location-search-button").prop("disabled", false);
        }
    })

    function postData(flowName, packageType, redirectUrl, TvPackageStatus, FiberPackageStatus,address) {
        var form = document.createElement("form");
        form.method = "POST";
        form.action = redirectUrl;

        var flowInput = document.createElement("input");
        flowInput.type = "hidden";
        flowInput.name = "flowName";
        flowInput.value = flowName;

        var packageInput = document.createElement("input");
        packageInput.type = "hidden";
        packageInput.name = "packageType";
        packageInput.value = packageType;

        var tvPackageInput = document.createElement("input");
        tvPackageInput.type = "hidden";
        tvPackageInput.name = "tvPackageStatus";
        tvPackageInput.value = TvPackageStatus;

        var fiberPackageInput = document.createElement("input");
        fiberPackageInput.type = "hidden";
        fiberPackageInput.name = "fiberPackageStatus";
        fiberPackageInput.value = FiberPackageStatus;

        var addressInput = document.createElement("input");
        addressInput.type = "hidden";
        addressInput.name = "address";
        addressInput.value = address;

        form.appendChild(flowInput);
        form.appendChild(packageInput);
        form.appendChild(tvPackageInput);
        form.appendChild(fiberPackageInput);
        form.appendChild(addressInput);

        document.body.appendChild(form);
        form.submit();
    }
})