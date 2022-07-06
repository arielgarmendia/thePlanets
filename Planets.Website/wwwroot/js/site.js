function notifyOk(text, isHtml) {
    isHtml = isHtml || false;

    if (isHtml) {
        swal({
            title: "Ok!",
            html: text,
            type: "success"
        });
    }
    else {
        swal({
            title: "Ok!",
            text: text,
            type: "success"
        });
    }
}

function notifyError(text, isHtml) {
    isHtml = isHtml || false;

    if (isHtml) {
        swal({
            title: "Error!",
            html: text,
            type: "error"
        });
    }
    else {
        swal({
            title: "Error!",
            text: text,
            type: "error"
        });
    }
}
