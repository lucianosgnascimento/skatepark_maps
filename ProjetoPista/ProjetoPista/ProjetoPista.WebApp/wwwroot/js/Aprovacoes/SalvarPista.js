(function () {
    'use strict';
    $("#estadoCombo").change( function () {
        var estado = $("#estadoCombo option:selected").val();
        $.ajax({
            type: 'Post',
            data: { estado: estado },
            url: '/Aprovacoes/BuscaCidades',
            dataType: 'json',
            success: function (dados) {
                if (dados !== null) {

                    var selectbox = $('#cidadeCombo');
                    $("#cidadeCombo").empty()
                    $('<option>').val("0").text("Selecione o Município").appendTo(selectbox);
                    $.each(dados.cidade, function (i, d) {
                        $('<option>').val(d.value).text(d.text).appendTo(selectbox);
                    })


                }
            },
        })
    });
    $(document).ready(function () {
        $('a#btn-salvar').click(function () {
            var href = $(this).attr('href');
            var data = $('#frm-pista').serialize();
            alert(data)
            $.post(href, data, function (result) {
                console.log("success");
                if (result.sucesso)
                    alert('Registro salvo com sucesso!', function () {
                        window.location.href = result.url;
                    });
                else
                    alert('Não foi possível salvar o registro.');
            })
                .fail(function (e) {
                    bootbox.alert(e);
                });

            return false;
        });
        $('#btn-NearMe').click(function () {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(showPosition);
            }
            else {
                console.log("Geolocation not supported by browser.");
            }
        });

        $('#controle_sidebar').click(function () {
            var element = document.getElementById('controle_sidebar');
            var text = element.outerHTML;
            //element.innerHTML = text;
            //var icone = $('#controle_sidebar')
            text = text.toString();
            if (text.includes("fa-angle-left")) {
                closeNav()
            }
            else {
                openNav()
            }
        });
        $('#btn-filtro').click(function () {
            var element = document.getElementById('controle_sidebar');
            var text = element.outerHTML;
            //element.innerHTML = text;
            //var icone = $('#controle_sidebar')
            text = text.toString();
            if (document.getElementById("mySidebar2").style.width == "400px") {
                closeFilt()
            }
            else {
                openFilt()
            }
        });
        function openNav() {
            document.getElementById("mySidebar").style.width = "400px";
            //document.getElementById("map_wrapper").style.marginLeft = "400px";
            $('#btn-expandir-recolher').html('<i class="fas fa-angle-left"></i>');
            document.getElementById("btn-expandir-recolher").style.marginLeft = "400px";
            //document.getElementById("map_wrapper").style.width = "calc(100% - 400px)";
        }
        /* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
        function closeNav() {
            document.getElementById("mySidebar").style.width = "0";
            //document.getElementById("map_wrapper").style.marginLeft = "0";
            $('#btn-expandir-recolher').html('<i class="fas fa-angle-right"></i>');
            document.getElementById("btn-expandir-recolher").style.marginLeft = "0";
            //document.getElementById("map_wrapper").style.width = "100%";
        }
        function openFilt() {
            document.getElementById("mySidebar2").style.width = "400px";
            document.getElementById("mySidebar3").style.width = "400px";
            //document.getElementById("map_wrapper").style.marginLeft = "400px";
            //$('#btn-expandir-recolher').html('<i class="fas fa-angle-left"></i>');
            document.getElementById("floatMenu").style.marginRight = "400px";
            //document.getElementById("map_wrapper").style.width = "calc(100% - 400px)";
        }
        /* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
        function closeFilt() {
            document.getElementById("mySidebar2").style.width = "0";
            document.getElementById("mySidebar3").style.width = "0";
            //document.getElementById("map_wrapper").style.marginLeft = "0";
            //$('#btn-expandir-recolher').html('<i class="fas fa-angle-right"></i>');
            document.getElementById("floatMenu").style.marginRight = "0";
            //document.getElementById("map_wrapper").style.width = "100%";
        }


        function reply_click(clicked_id) {
            alert(clicked_id);
        }
        /*$(function () {
            $(".btn-mapa-nearme").click(function () {
                var fired_button = $(this).val();
                openNav();
                alert(fired_button);
            });
        });*/
        $(document).on('click', '.btn-primary', function () {
            var fired_button = $(this).val();
            openNav();
            //alert(fired_button);
        });
        function showPosition(position) {
            $("form").attr("asp-route-latitude", position.coords.latitude);
            $("form").attr("asp-route-longitude", position.coords.longitude);

            $.ajax({
                url: 'Home/NearMe?lat=' + position.coords.latitude + '&lon=' + position.coords.longitude,
                type: 'POST',
                data: {
                    'Mapa': {}
                },
                dataType: 'html',
                success: function (data) {
                    $('#map_wrapper').html(data);
                },
                error: function (request, error) {
                    console.log(error);
                }
            });
        }
    });
    
})();