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
            $('#btn-filtrar').removeAttr('disabled');
            if (document.getElementById("FiltrosViz").hidden == true) {
                document.getElementById("ProfessorProfile").hidden = true;
                document.getElementById("FiltrosViz").hidden = false;
                document.getElementById("btn-filtrar").innerHTML = "Filtrar";
            }
            else {
                if (document.getElementById("mySidebarFiltro").style.width == "400px") {
                    closeFilt()
                }
                else {
                    openFilt()
                }
            }
            
        });
        $(document).on('click', '[class=copyEndereco]', function () {
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
            //alert("Copied the text: " + copyText.innerText);
        }
        $(document).on('click', '[name=Professor]', function () {
            //alert($(this).val());
            //evt.preventDefault();
            //evt.stopPropagation();

            var data = $(this).attr("value");

            $.ajax({
                url: '/DashProfessor/Profile',
                type: 'GET',
                dataType: 'html',
                cache: false,
                data: {
                    id: data
                },
                success: function (response) {
                    //alert(response);
                    openFilt();
                    document.getElementById("ProfessorProfile").hidden = false;
                    document.getElementById("FiltrosViz").hidden = true;
                    $('#ProfessorProfile').html(response);
                    document.getElementById("explicaProf").innerHTML = "Este professor está disponivel para dar aulas nessa pista ! <br><br>Para ver todas as pistas que o professor dá aulas clique no botão abaixo.";
                    
                    document.getElementById("btn-filtrar").innerHTML = "Pistas professor";
                    document.getElementById("btn-filtrar").value = data;
                    $('#btn-filtrar').removeAttr('disabled');


                    //window.history.replaceState({ additionalInformation: 'Updated the URL with JS' }, 'Pista', '/Home/Pista/' + data.toString());
                },
                async: true,
                error: function (xhr, status, error) {
                    alert(xhr + " - " + status + " - " + error)
                }

            });
        });

        $(document).on('click', '[name=Mais]', function () {
            //alert($(this).val());
            //evt.preventDefault();
            //evt.stopPropagation();

            var data = $(this).val();

            $.ajax({
                url: '/Home/Details',
                type: 'GET',
                dataType: 'html',
                cache: false,
                data: {
                    id: data
                },
                success: function (response) {
                    //alert(response);
                    $('#mySidebarInfos').html(response);
                    openNav();
                    window.history.replaceState({ additionalInformation: 'Updated the URL with JS' }, 'Pista', '/Home/Pista/' + data.toString());
                },
                async: true,
                error: function (xhr, status, error) {
                    alert(xhr + " - " + status + " - " + error)
                }

            });
        });


        $('#btn-filtrar').click(function () {


            if (document.getElementById("ProfessorProfile").hidden == true) {
                var data = $('#frm-pistas').serialize();
                data = data.split('&');
                var nome = data[0].split('=')[1];
                var cidade = data[2].split('=')[1];
                var estado = data[1].split('=')[1];

                var street = $('#myCheckbox10').is(":checked");
                var vert = $('#myCheckbox20').is(":checked");
                var plaza = $('#myCheckbox30').is(":checked");
                var half = $('#myCheckbox40').is(":checked");
                var hill = $('#myCheckbox50').is(":checked");
                var facil = $('#myCheckbox60').is(":checked");
                var medio = $('#myCheckbox70').is(":checked");
                var dificil = $('#myCheckbox80').is(":checked");


                $.ajax({
                    url: '/Home/FiltrarPistaHome',
                    type: 'POST',
                    dataType: 'html',
                    cache: false,
                    data: {
                        nm_pista: nome,
                        id_cidade: cidade,
                        id_estado: estado,
                        fl_street: street,
                        fl_vert: vert,
                        fl_plaza: plaza,
                        fl_half: half,
                        fl_hill: hill,
                        fl_facil: facil,
                        fl_medio: medio,
                        fl_dificil: dificil
                    },
                    success: function (response) {
                        //alert("chegouuu uuhuu");
                        $('#map_wrapper').html(response);
                    },
                    async: true,
                    error: function (xhr, status, error) {
                        alert(xhr + " - " + status + " - " + error)
                    }

                });
            }
            else {
                // filtra pistas do professor DashProfessor" asp-action="PistasProf" asp-route-id="@item.id_professor
                var data = $(this).attr("value");

                $.ajax({
                    url: '/Home/FiltraPistasProf',
                    type: 'Post',
                    dataType: 'html',
                    cache: false,
                    data: {
                        id: data
                    },
                    success: function (response) {
                        //alert('Chegouu');
                        $('#map_wrapper').html(response);
                        document.getElementById("btn-filtrar").setAttribute('disabled', 'true');

                        //openNav();
                    },
                    async: true,
                    error: function (xhr, status, error) {
                        alert(xhr + " - " + status + " - " + error)
                    }

                });
            }



            //alert(cidade);
        });
        $('#btn-limpar').click(function () {



                $.ajax({
                    url: '/Home/FiltrarPistaHome',
                    type: 'POST',
                    dataType: 'html',
                    cache: false,
                    success: function (response) {
                        //alert("chegouuu uuhuu");
                        $('#map_wrapper').html(response);
                    },
                    async: true,
                    error: function (xhr, status, error) {
                        alert(xhr + " - " + status + " - " + error)
                    }

                });
            
            
            



            //alert(cidade);
        });
        function checkView() {

            var idPista = document.getElementById("codP").innerHTML;
            //var str = Html.Raw(Json.Encode(ViewData["Title"]));
            
            if (idPista != 0) {
                $.ajax({
                    url: '/Home/Details',
                    type: 'Post',
                    dataType: 'html',
                    cache: false,
                    data: {
                        id: idPista
                    },
                    success: function (response) {
                        //alert('Chegouu');
                        $('#mySidebarInfos').html(response);
                        openNav();
                    },
                    async: true,
                    error: function (xhr, status, error) {
                        alert(xhr + " - " + status + " - " + error)
                    }

                });
            }
            var idProf = document.getElementById("codPro").innerHTML;
            //var str = Html.Raw(Json.Encode(ViewData["Title"]));

            if (idProf != 0) {
                $.ajax({
                    url: '/DashProfessor/Profile',
                    type: 'Post',
                    dataType: 'html',
                    cache: false,
                    data: {
                        id: idProf
                    },
                    success: function (response) {
                        //alert('Chegouu');
                        $('#ProfessorProfile').html(response);
                        document.getElementById("ProfessorProfile").hidden = false;
                        document.getElementById("FiltrosViz").hidden = true;

                        openFilt();
                        document.getElementById("btn-filtrar").innerHTML = "Pistas professor";

                        document.getElementById("btn-filtrar").setAttribute('disabled', 'true');

                    },
                    async: true,
                    error: function (xhr, status, error) {
                        alert(xhr + " - " + status + " - " + error)
                    }

                });
            }

             //alert(id);
        }
        checkView();

        $(document).on('click', '#close_button', function () {

            closeFilt();
        });

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
            document.getElementById("btn-filtrar").innerHTML = "Filtrar";

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
            //openNav();
            //alert(fired_button);
        });
        function showPosition(position) {
            $("form").attr("asp-route-latitude", position.coords.latitude);
            $("form").attr("asp-route-longitude", position.coords.longitude);

            $.ajax({
                url: '/Home/NearMe?lat=' + position.coords.latitude + '&lon=' + position.coords.longitude,
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