


function ListarCola() {

    
    $.ajax({
        type: "POST",
        url: "Index.aspx/ActualizarColas",
        data: JSON.stringify({ idcola: '1' }),
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            document.getElementById("ListCola1").innerHTML = '';
            document.getElementById("ListCola1").innerHTML = response.d;
            
            $.ajax({
                type: "POST",
                url: "Index.aspx/ActualizarColas",
                data: JSON.stringify({ idcola: '2' }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    document.getElementById("ListCola2").innerHTML = '';
                    document.getElementById("ListCola2").innerHTML = response.d;

                },
                failure: function (xhr, ajaxOptions, thrownError) {
                    alert("Error:" + xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                }
            });



        },
        failure: function (xhr, ajaxOptions, thrownError) {
            alert("Error:" + xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        }
    });
}




$(document).on('click', '.btn-insert', function (e) {
    e.preventDefault();


    let nombre = $("#txtNombre").val().trim();;
    let Id = $("#txtId").val().trim();
   

    if ((nombre != '') && (Id != '')) {
        $.ajax({
            url: "Index.aspx/InsertCola",
            contentType: "application/json",
            type: "POST",
            datatype: "json",
            data: JSON.stringify({ id: Id, nombre: nombre }),
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                alert(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);

            },
            success: function (response) {

                if (response.d) {
                    ListarCola();
                    $("#txtNombre").val('');
                    $("#txtId").val('');

                    alert("Registro cargado.Sele llamara por el numero de Id");


                } else {
                    alert("No se pudo cargar el registro en el sistema");
                }

            },
            failure: function (xhr, ajaxOptions, thrownError) {
                alert("Error:" + xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            }

        });

    }
    else {
        alert("Todos los campos son obligatorios");

    }


});

ListarCola();


