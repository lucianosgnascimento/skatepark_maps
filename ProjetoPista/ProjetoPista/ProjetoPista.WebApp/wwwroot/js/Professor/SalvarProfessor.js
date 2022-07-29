(function () {
    'use strict';
    
    $(document).ready(function () {
        $('a#btn-salvar').click(function () {
            var href = $(this).attr('href');
            var data = $('#frm-professor').serialize();
            alert(data)
            $.post(href, data, function (result) {
                console.log("success");
                if (result.sucesso)
                    alert('Registro salvo com sucesso!', function () {
                        window.location.href = result.url;
                    });
                else
                    bootbox.alert('Não foi possível salvar o registro.');
            })
                .fail(function (e) {
                    bootbox.alert(e);
                });

            return false;
        });
    });

    $('#btn-filtrar').on('click', function (evt) {
        evt.preventDefault();
        evt.stopPropagation();

        var data = {
            nm_professor : $('#nome').val()
        }
        $.ajax({
            url: 'DashProfessor/Filtrar',
            type: 'POST',
            dataType: 'html',
            cache:false,
            data: {
                professores: data
            },
            success: function (response) {
                $('#CardsProfessor').html(response);
            },
            async:true,
            error: function (xhr, status, error) {
                alert(xhr + " - " + status + " - " + error)
            }
                    
        });
    });
    
})();