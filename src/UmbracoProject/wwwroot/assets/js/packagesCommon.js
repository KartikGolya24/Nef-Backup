var addressId = "";

dawaAutocomplete.dawaAutocomplete(document.getElementById("adresse"), {
    select: function (selected) {
        addressId = selected.data.id

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
                    var TvPackageStatus = 1;
                    var FiberPackageStatus = 1;
                    if (packageType == "tv") {
                        TvPackageStatus = res.tvPackageResult;
                        FiberPackageStatus = null;
                    } else {
                        FiberPackageStatus = res.fiberConnectionResult;
                        TvPackageStatus = null;
                    }

                    var url = `${origin}${redirectUrl}?flowName=${flowName}&packageType=${packageType}&tvPackageStatus=${TvPackageStatus}&fiberPackageStatus=${FiberPackageStatus}`;
                    console.log(res)
                    console.log(url)
                },
                error: function () {
                    alert("error")
                }
            })
        } else {
            $(".location-search-button").prop("disabled", false);
        }
    })
})