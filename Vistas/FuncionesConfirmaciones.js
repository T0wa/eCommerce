
function ValidateInsertProd() {
    if (Page_ClientValidate('AgregarProd'))
        return confirm('¿Desea insertar el producto ingresado?');
    
    return false;
}

function ValidateInsertCategoria() {
    if (Page_ClientValidate('AgregarCat'))
        return confirm('¿Desea insertar la categoría ingresada?');

    return false;
}

function ValidateInsertReseña() {
    if (Page_ClientValidate('AgregarReseña'))
        return confirm('¿Esta seguro que quiere agregar la reseña?')
}

function ValidateInsertSubCategoria() {
    if (Page_ClientValidate('AgregarSubCat'))
        return confirm('¿Desea insertar la SubCategoría ingresada?');

    return false;
}

function prueba(Mensaje) {
    alert(mensaje);
}











