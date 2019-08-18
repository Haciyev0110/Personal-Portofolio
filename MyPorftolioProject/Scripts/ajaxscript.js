$(function () {

    //$('#contactform').validator();

    $('#contactform').on('submit', function (e) {
        if (!e.isDefaultPrevented()) {
            var url = "/Home/Index3";
            var name = $("#name").val();
            var email = $("#email").val();
            var body = $("#comment").val();
            var form = $("#contactform");

            $.ajax({
                url: url,
                type: "POST",
                data: {
                    "_from": email,
                    "_subject": name,
                    "_body": body,
                },
                success: function (data) {
                    swal("Thank You!", "Message has been sent successfully!.", "success");
                }
            });
            form[0].reset();
            return false;
        };
    });
});