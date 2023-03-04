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
        $('#btn-EnviarPista').click(function () {
            var href = $(this).attr('href');
            var data = $('#msform').serializeArray();
            
            //data.push({ name: "NonFormValue", value: NonFormValue });
            data.push({ name: "fl_street", value: $('#myCheckbox1').is(":checked") });
            data.push({ name: "fl_vert", value: $('#myCheckbox2').is(":checked") });
            data.push({ name: "fl_plaza", value: $('#myCheckbox3').is(":checked") });
            data.push({ name: "fl_half", value: $('#myCheckbox4').is(":checked") });
            data.push({ name: "fl_hill", value: $('#myCheckbox5').is(":checked") });
            data.push({ name: "fl_facil", value: $('#myCheckbox6').is(":checked") });
            data.push({ name: "fl_medio", value: $('#myCheckbox8').is(":checked") });
            data.push({ name: "fl_dificil", value: $('#myCheckbox10').is(":checked") });
            data.push({ name: "fl_facilMedio", value: $('#myCheckbox7').is(":checked") });
            data.push({ name: "fl_medioDificil", value: $('#myCheckbox9').is(":checked") });
            data.push({ name: "fl_paga", value: Number($('#myCheckbox11').is(":checked")) });
            data.push({ name: "fl_pista_ativa", value: Number($('#myCheckbox12').is(":checked")) });
            data.push({ name: "fl_capacete", value: Number($('#myCheckbox13').is(":checked")) });
            data.push({ name: "fl_aluga_capacete", value: Number($('#myCheckbox14').is(":checked")) });
            data.push({ name: "fl_cobertura", value: Number($('#myCheckbox15').is(":checked")) });
            alert(data);

            /*
            var street = $('#myCheckbox1').is(":checked");
            var vert = $('#myCheckbox2').is(":checked");
            var plaza = $('#myCheckbox3').is(":checked");
            var half = $('#myCheckbox4').is(":checked");
            var hill = $('#myCheckbox5').is(":checked");
            var facil = $('#myCheckbox6').is(":checked");
            var medio = $('#myCheckbox7').is(":checked");
            var dificil = $('#myCheckbox8').is(":checked");
            var facilMedio = $('#myCheckbox9').is(":checked");
            var medioDificil = $('#myCheckbox10').is(":checked");
            var paga = $('#myCheckbox11').is(":checked");
            var ativa = $('#myCheckbox12').is(":checked");
            var capacete = $('#myCheckbox13').is(":checked");
            var aluga = $('#myCheckbox14').is(":checked");
            var cobertura = $('#myCheckbox15').is(":checked");*/
            
            $.ajax({
                url: '/Aprovacoes/SalvarUser',
                type: 'POST',
                dataType: 'html',
                cache: false,
                data: $.param(data),
                success: function (response) {
                    alert("chegouuu uuhuu");
                },
                async: true,
                error: function (xhr, status, error) {
                    alert(xhr + " - " + status + " - " + error)
                }

            });

            /*
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
                */
            //return false;
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
            if (document.getElementById("mySidebarFiltro").style.width == "400px") {
                closeFilt()
            }
            else {
                openFilt()
            }
        });
        $('.copyEndereco').click(function () {
            CopiarEnd();
        });
        function CopiarEnd() {
            // Get the text field
            var copyText = document.getElementById("enderecoPista");

            // Select the text field
            //copyText.select();
            //copyText.setSelectionRange(0, 99999); // For mobile devices

            // Copy the text inside the text field
            navigator.clipboard.writeText(copyText.innerText);

            // Alert the copied text
            alert("Copied the text: " + copyText.innerText);
        }



        $('#btn-filtrar').click(function () {
            var data = $('#frm-pistas').serialize();
            data = data.split('&');
            var nome = data[0].split('=')[1];
            var cidade = data[2].split('=')[1];
            var estado = data[1].split('=')[1];

            var street = $('#myCheckbox1').is(":checked");
            var vert = $('#myCheckbox2').is(":checked");
            var plaza = $('#myCheckbox3').is(":checked");
            var half = $('#myCheckbox4').is(":checked");
            var hill = $('#myCheckbox5').is(":checked");
            var facil = $('#myCheckbox6').is(":checked");
            var medio = $('#myCheckbox7').is(":checked");
            var dificil = $('#myCheckbox8').is(":checked");
            var facilMedio = $('#myCheckbox9').is(":checked");
            var medioDificil = $('#myCheckbox10').is(":checked");
            var paga = $('#myCheckbox11').is(":checked");
            var ativa = $('#myCheckbox12').is(":checked");
            var capacete = $('#myCheckbox13').is(":checked");
            var aluga = $('#myCheckbox14').is(":checked");
            var cobertura = $('#myCheckbox15').is(":checked");



            
            $.ajax({
                url: '/Home/FiltrarPistaHome',
                type: 'GET',
                dataType: 'html',
                cache: false,
                data: {
                    nm_pista : nome,
                    id_cidade : cidade,
                    id_estado : estado,
                    fl_street : street,
                    fl_vert : vert,
                    fl_plaza: plaza,
                    fl_half :half,
                    fl_hill: hill,
		            fl_facil : facil,
                    fl_medio :medio,
                    fl_dificil :dificil
                },
                success: function (response) {
                    alert("chegouuu uuhuu");
                },
                async: true,
                error: function (xhr, status, error) {
                    alert(xhr + " - " + status + " - " + error)
                }

            });



            //alert(cidade);
        });
        function checkView() {

            var id = document.getElementById("codP").innerHTML;
            //var str = Html.Raw(Json.Encode(ViewData["Title"]));
            
            if (id != 0) {
                $.ajax({
                    url: '/Home/Details',
                    type: 'Post',
                    dataType: 'html',
                    cache: false,
                    data: {
                        id: id
                    },
                    success: function (response) {
                        //alert('Chegouu');
                        $('#mySidebarInfos').html(response);
                    },
                    async: true,
                    error: function (xhr, status, error) {
                        alert(xhr + " - " + status + " - " + error)
                    }

                });
            }
            openNav();

             //alert(id);
        }
        checkView();
        function openNav() {
            document.getElementById("mySidebarInfos").style.width = "400px";
            //document.getElementById("map_wrapper").style.marginLeft = "400px";
            $('#btn-expandir-recolher').html('<i class="fas fa-angle-left"></i>');
            document.getElementById("btn-expandir-recolher").style.marginLeft = "400px";
            //document.getElementById("map_wrapper").style.width = "calc(100% - 400px)";
        }
        /* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
        function closeNav() {
            document.getElementById("mySidebarInfos").style.width = "0";
            //document.getElementById("map_wrapper").style.marginLeft = "0";
            $('#btn-expandir-recolher').html('<i class="fas fa-angle-right"></i>');
            document.getElementById("btn-expandir-recolher").style.marginLeft = "0";
            //document.getElementById("map_wrapper").style.width = "100%";
        }
        function openFilt() {
            document.getElementById("mySidebarFiltro").style.width = "400px";
            document.getElementById("mySidebar3").style.width = "400px";
            //document.getElementById("map_wrapper").style.marginLeft = "400px";
            //$('#btn-expandir-recolher').html('<i class="fas fa-angle-left"></i>');
            document.getElementById("floatMenu").style.marginRight = "400px";
            //document.getElementById("map_wrapper").style.width = "calc(100% - 400px)";
        }
        /* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
        function closeFilt() {
            document.getElementById("mySidebarFiltro").style.width = "0";
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