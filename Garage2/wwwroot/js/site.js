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
        var actionUrl = "/Account/_RegisterModalPartialView"
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

    $('#loginModal').click(function (event) {
        var url = $(this).data('url')
        event.preventDefault();

        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });

        placeholderElement.on('click', '[data-login="modalLogin"]', function (event) {
            event.preventDefault();

            var form = $(this).parents('.modal').find('form');
            //var actionUrl = form.attr('action');
            var actionUrl = "/Account/_LoginModalPartialView"
            var dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {
                
                var newBody = $('.modal-body', data);
                placeholderElement.find('.modal-body').replaceWith(newBody);

                var isValid = newBody.find('[name="IsValid"]').val() == 'True';
                if (isValid) {
                    placeholderElement.find('.modal').modal('hide');
                    location.reload();
                    
                }
            });
        })
    })

    //LOGIN FOR "YOUR SERVICE" NOT WORKING BECAUSE SAME ID IN NAVBAR

    $('#loginModal2').click(function (event) {
        var url = $(this).data('url')
        event.preventDefault();

        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });

        placeholderElement.on('click', '[data-login="modalLogin"]', function (event) {
            event.preventDefault();

            var form = $(this).parents('.modal').find('form');
            //var actionUrl = form.attr('action');
            var actionUrl = "/Account/_LoginModalPartialView"
            var dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {

                var newBody = $('.modal-body', data);
                placeholderElement.find('.modal-body').replaceWith(newBody);

                var isValid = newBody.find('[name="IsValid"]').val() == 'True';
                if (isValid) {
                    placeholderElement.find('.modal').modal('hide');
                    location.reload();

                }
            });
        })
    })


   

    // SHOW ADD NEW SERVICE MODAL

    showPopup = (url, title) => (
        $.ajax({
            type: 'GET',
            url: url,
            success: function (res) {
                var url = window.location.pathname;                     //get curent URl
                var id = url.substring(url.lastIndexOf('/') + 1);       //gat ID from url
          
                $("#form-modal .modal-body").html(res)
                $("#form-modal .modal-title").html(title)
                $("#carId").val(id)
                $("#form-modal").modal('show')
                $('.selectpicker').selectpicker();

            }
        })
    )

    //  CREATE NEW CAR

    createNewCar = (url,title) => (
        $.ajax({
            type: 'GET',
            url: url,
            success: function (res) {
                var url = window.location.pathname;                     //get curent URl
                var id = url.substring(url.lastIndexOf('/') + 1);       //gat ID from url
                
                $("#car-modal .modal-body").html(res)
                $("#car-modal .modal-title").html(title)
                $("#userId").val(id)
                $("#car-modal").modal('show')
            }
        })
    )


    // SERVICE DETAILS 

    serviceDetails = (url, title) => {
        $.ajax({
            type: 'GET',
            url: url,
            success: function (res) {
                $("#serviceDetails .modal-body").html(res)
                $("#serviceDetails .modal-title").html(title)
                $("#serviceDetails").modal('show')
            }
        })
    }

});
   

       

  


