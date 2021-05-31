function ajax(direccion, tipo, datos, btn, callback) {
    if (btn !== null) {
        if (btn.length > 0) {
            btn.attr('autocomplete', 'off');
            btn.attr('disabled', true);
        }
    }
    $.ajax({
        url: direccion,
        type: 'post',
        dataType: tipo,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(datos),
        complete: function () {
            if (btn !== null) {
                if (btn.length > 0) {
                    btn.attr('disabled', false);
                }
            }
        },
        success: callback,
        error: function (xhr, ajaxOption, thrownError) {
            try {
                var errors = JSON.parse(xhr.responseText);
                var mensaje = 'Errores:\n\n';
                $.each(errors, function (key, value) {
                    mensaje += (value + '\n');
                });
                alert(mensaje);
            }
            catch (err) {
                console.log(thrownError);
                console.log(xhr.responseText);
            }
        }
    });
}


function ajax2(url, params, btn, callback) {
    if (params == null) params = { id: Math.random };
    ajax(url, "html", params, btn, function (response) {

        response = jsonResponse(response);
        if (response.hasOwnProperty("error")) {
            alert("Error:\n" + response.error);
        } else {
            for (var propiedad in response) {
                if (typeof response[propiedad] === 'string') {
                    if (response[propiedad].charAt(0) == '[' || response[propiedad].charAt(0) == '{') {
                        response[propiedad] = convertObjectStringToJson(response[propiedad]);
                    }
                }
            }
            callback(response);
        }
    });
};

function jsonResponse(response) {
    var myJson = '';
    if (response.charAt(0) == '<') {
        myJson = response.replace('<?xml version="1.0" encoding="utf-8"?>', '').replace('<string xmlns="http://tempuri.org/">', '').replace('</string>', '');
    } else {
        var jsonResponseWithD = $.parseJSON(response);
        myJson = jsonResponseWithD.d;
    }
    return $.parseJSON(myJson);
}

function convertObjectStringToJson(objeto_string) {
    var s = $.parseJSON(objeto_string);
    s.forEach(function (e) {
        for (var propiedad in e) {
            if (typeof e[propiedad] === 'string') {
                if (String(e[propiedad]).charAt(0) == '[') {
                    e[propiedad] = convertObjectStringToJson(String(e[propiedad]));
                }
            }
        }
    });

    return s;
}
