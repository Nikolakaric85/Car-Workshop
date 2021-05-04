// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

//REGISTER https://softdevpractice.com/blog/asp-net-core-mvc-ajax-modals/

$(function () {
    var placeholderElement = $('#modal-placeholder');

    $('#registerModal').click(function (event) {
        var url = $(this).data('url');
        event.preventDefault()
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
            }
        });
    });

    //LOGIN

    //$('#loginModal').click(function (event) {
    //    var url = $(this).data('url')
    //    event.preventDefault();

    //    $.get(url).done(function (data) {
    //        placeholderElement.html(data);
    //        placeholderElement.find('.modal').modal('show');
    //    });

    //    placeholderElement.on('click', '[data-login="modalLogin"]', function (event) {
    //        event.preventDefault();

    //        var form = $(this).parents('.modal').find('form');
    //        var actionUrl = form.attr('action');
    //        var dataToSend = form.serialize();

    //        $.post(actionUrl, dataToSend).done(function (data) {
    //            var newBody = $('.modal-body', data);
    //            placeholderElement.find('.modal-body').replaceWith(newBody);

    //            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
    //            if (isValid) {
    //                placeholderElement.find('.modal').modal('hide');
    //                location.reload();
                    
    //            }
    //        });
    //    })
    //})

   

    // SHOW ADD NEW SERVICE MODAL

    showPopup = (url, title) => (
        $.ajax({
            type: 'GET',
            url: url,
            success: function (res) {
                
                $("#form-modal .modal-body").html(res)
                $("#form-modal .modal-title").html(title)
                $("#form-modal").modal('show')
                $('.selectpicker').selectpicker();

            }
        })
     )
    
    //LOGIN 2

    login2 = (url,title) => (
                
        $.ajax({
            type: 'GET',
            url:url,
            success: function (res) {
                $("#logReg .modal-title").html(title)
                $("#logReg .modal-body").html(res)
                $("#logReg").modal('show')
            }
        })
    )



    log = () => (
        $.ajax({
            type: 'GET',
            url: "Account/_Login",
            success: function (res) {
                var err = $(this).text('@TempData["error"]')
                if (err != null) {

                    
                //    $("#logReg .modal-title").html(title)
                    $("#logReg .modal-body").html(res)
                  
                    $("#logReg").modal('show')

                    //console.log('forma nije validna')
                }
                
              
            }
        })
    )


    // res mi daje formu kada je on prvi u "success: function ( res, event)" u suprotnom vraca samo rec success



});
   

       
   
//$("a#impersonate").click(function () {

//    $.ajax({
//        type: "POST",
//        url: "@Url.Action("Impersonation", "UserRoles")",
//        data: $('#form').serialize(),
//        success: function (result) {
//            if (result == "success") {
//                $('#dialogDiv').modal('hide');

//            } else {
//                $('#dialogContent').html(result);
//            }
//        }
//    });
//});



    


  


