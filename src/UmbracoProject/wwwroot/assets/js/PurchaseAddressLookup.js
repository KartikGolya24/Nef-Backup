var addressId = "";

dawaAutocomplete.dawaAutocomplete(document.getElementById("adresse"), {
    select: function (selected) {
        addressId = selected.data.id

        $(".location-search-button").prop("disabled", false);

    }
});

$(document).ready(function () {
    var packageType = $("#packageType").val();
    var packageContainer = $("#packagesList");
    var UrlForPackages = "";
    if (packageType == "tv") {
        UrlForPackages = "/packages/get-tv-packages";
    } else {
        UrlForPackages = "/packages/get-fiber-packages";
    }

    GetPackagesHtml(UrlForPackages, packageContainer);

    $("#adresse").on('keyup', function () {
        $(".location-search-button").prop("disabled", true);
    })

    $(".location-search-button").on('click', function () {
        if (addressId && addressId != "") {
            $.ajax({
                url: "https://productsapi.nef.dk/api/CheckAddress" + "?adresseGUID=" + addressId,
                type: "Get",
                success: function (res) {
                    console.log(res)
                },
                error: function () {
                    alert("error")
                }
            })
        } else {
            $(".location-search-button").prop("disabled", false);
        }
    });




    function GetPackagesHtml(url, container) {
        $.ajax({
            url: url,
            type: "Get",
            success: function (res) {
                container.html(res)
            },
            error: function () {
                consol.log("error")
            }
        })
    }

})