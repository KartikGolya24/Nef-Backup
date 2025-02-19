$(document).ready(function () {


    //making navigation menu action START
    var currentUrl = window.location.pathname; // Get current page URL
    $(".tabs-link").each(function () {
        if ($(this).attr("href") === currentUrl) {
            $(".tabs-link").removeClass("active"); // Remove 'active' from all tabs
            $(this).addClass("active"); // Add 'active' to the matching tab
        }
    });
    //making navigation menu action END



    $(document).on('click', '.videoBtn', function () {
        // Grab the URL from the button's data-href attribute
        var videoURL = $(this).data('href');
        // console.log(videoURL)
        // Get the target modal's id (e.g., "#modalId")
        var targetModal = $(this).data('bs-target');
        // Find the modal element
        var modal = $(targetModal);

        // Update the <source> element for the mp4 video
        modal.find('video source[type="video/mp4"]').attr('src', videoURL);

        // Reload the video element so it picks up the new source
        modal.find('video').get(0).load();
    });


    //Changing Tagimage on hover START
    $(".order-nef-card").hover(
        function () {
            $(this).find(".defaultImage").addClass("d-none");
            $(this).find(".hoverImage").removeClass("d-none");
        },
        function () {
            $(this).find(".defaultImage").removeClass("d-none");
            $(this).find(".hoverImage").addClass("d-none");
        }
    );
    //Changing Tagimage on hover END



    //Load more updates on load more button in information page START
    $(".load_more_update").click(function () {
        let updateContainer = $(this).closest(".update-power");
        let hiddenBlocks = updateContainer.find(".update-power-box:hidden").slice(0, 4);

        hiddenBlocks.show();

        if (updateContainer.find(".update-power-box:hidden").length === 0) {
            $(this).hide();
        }
    });
    //Load more updates on load more button in information page END




    //Load more vacancies on load more button in vacancies section START
    $(".load_more_vacancies").click(function () {
        let positionList = $(".position-list");
        let hiddenBlocks = positionList.find("li:hidden").slice(0, 3);

        hiddenBlocks.show();

        if (positionList.find("li:hidden").length === 0) {
            $(this).hide();
        }
    });
    //Load more vacancies on load more button in vacancies section END


    //scroll button on home banner
    $("#scrollButton").click(function () {
        window.scrollBy({ top: 660, behavior: "smooth" });
    })

})