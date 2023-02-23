function eliminarCSRF(url, id, nombre) {
    swal({
        title: '¿Desea eliminar el registro: ' + nombre + '?',
        text: "Esta acción no se podrá revertir",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: '¡Sí, eliminar!',
        cancelButtonText: '¡No, cancelar!',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                var form = $('#__AjaxAntiForgeryForm');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                $.ajax({
                    url: url + id,
                    method: "post",
                    dataType: "json",
                    data: {
                        __RequestVerificationToken: token,
                        id: id
                    },
                    success: function (data) {
                        if (data.success) {
                            swal({
                                type: 'success',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        } else {
                            swal({
                                type: 'info',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        }

                    },
                    error: function () {
                        swal({
                            title: "¡Algo salió mal!",
                            text: "¡Ha ocurrido un error al eliminar el registro, si el problema continua comunicate con el administrador!",
                            type: "error",
                            allowOutsideClick: false,
                            confirmButtonColor: '#0c7cd5',
                            allowEscapeKey: false
                        }, function () {
                            location.reload();
                        });
                    }
                });
            });
        },
        allowOutsideClick: false,
        allowEscapeKey: false
    });
};

function eliminarEmpleado(url, id, nombre) {
    swal({
        title: '¿Desea eliminar el registro: ' + truncate(nombre) + '?',
        text: "Esta acción no se podrá revertir",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: '¡Sí, eliminar!',
        cancelButtonText: '¡No, cancelar!',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                var form = $('#__AjaxAntiForgeryForm');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                $.ajax({
                    url: url + id,
                    method: "post",
                    dataType: "json",
                    data: {
                        __RequestVerificationToken: token,
                        id: id
                    },
                    success: function (data) {
                        if (data.success) {
                            swal({
                                type: 'success',
                                title: data.msj,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                confirmButtonText: 'Aceptar',
                                showCloseButton: true,
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        } else {
                            swal({
                                type: 'info',
                                title: data.msj,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        }

                    },
                    error: function () {
                        swal({
                            title: "¡Algo salió mal!",
                            text: "¡Ha ocurrido un error al eliminar el registro!",
                            type: "error",
                            allowOutsideClick: false,
                            confirmButtonColor: '#0c7cd5',
                            confirmButtonText: 'Aceptar',
                            allowEscapeKey: false
                        }, function () {
                            location.reload();
                        });
                    }
                });
            });
        },
        allowOutsideClick: false,
        allowEscapeKey: false
    });
};

function eliminarCSRFEdit(url, id, nombre, c) {
    swal({
        title: '¿Desea eliminar el registro: ' + truncate(nombre) + '?',
        text: "Esta acción no se podrá revertir",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: '¡Sí, eliminar!',
        cancelButtonText: '¡No, cancelar!',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                var form = $('#__AjaxAntiForgeryForm');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                $.ajax({
                    url: url + id,
                    method: "post",
                    dataType: "json",
                    data: {
                        __RequestVerificationToken: token,
                        id: id
                    },
                    success: function (data) {
                        if (data.success) {
                            swal({
                                type: 'success',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                confirmButtonText: 'Aceptar',
                                allowEscapeKey: false
                            }).then(function () {
                                location.href = '/' + c + '/Index';
                            });
                        } else {
                            swal({
                                type: 'info',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                confirmButtonText: 'Aceptar',
                                allowEscapeKey: false
                            }).then(function () {
                                location.href = '/' + c + '/Index';
                            });
                        }

                    },
                    error: function () {
                        swal({
                            title: "¡Algo salió mal!",
                            text: "¡Ha ocurrido un error al eliminar el registro!",
                            type: "error",
                            allowOutsideClick: false,
                            confirmButtonColor: '#0c7cd5',
                            confirmButtonText: 'Aceptar',
                            allowEscapeKey: false
                        }, function () {
                            location.href = '/' + c + '/Index';
                        });
                    }
                });
            });
        },
        allowOutsideClick: false,
        allowEscapeKey: false
    })
};

function truncate(input) {
    if (input.length > 20)
        return input.substring(0, 20) + '...';
    else
        return input;
};

function eliminarConvocatoria(url, id) {
    swal({
        title: '¿Desea eliminar el registro?',
        text: "Esta acción no se podrá revertir",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: '¡Sí, eliminar!',
        cancelButtonText: '¡No, cancelar!',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                var form = $('#__AjaxAntiForgeryForm');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                $.ajax({
                    url: url + id,
                    method: "post",
                    dataType: "json",
                    data: {
                        __RequestVerificationToken: token,
                        id: id
                    },
                    success: function (data) {
                        if (data.success) {
                            swal({
                                type: 'success',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        } else {
                            swal({
                                type: 'info',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        }

                    },
                    error: function () {
                        swal({
                            title: "¡Algo salió mal!",
                            text: "¡Ha ocurrido un error al eliminar el registro, si el problema continua comunicate con el administrador!",
                            type: "error",
                            allowOutsideClick: false,
                            confirmButtonColor: '#0c7cd5',
                            allowEscapeKey: false
                        }, function () {
                            location.reload();
                        });
                    }
                });
            });
        },
        allowOutsideClick: false,
        allowEscapeKey: false
    });
};

function CambiarEstatusProyecto(id, titulo, cuerpo, activo) {
    swal({
        title: titulo + ' el proyecto',
        text: cuerpo,
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: '¡Sí, continuar!',
        cancelButtonText: '¡No, cancelar!',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                var form = $('#__AjaxAntiForgeryForm');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                $.ajax({
                    url: "/Proyectos/CambiarEstatusProyecto/",
                    method: "post",
                    dataType: "json",
                    data: {
                        __RequestVerificationToken: token,
                        idProyecto: id,
                        activo: activo
                    },
                    success: function (data) {
                        if (data.success) {
                            swal({
                                type: 'success',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            })
                        } else {
                            swal({
                                type: 'info',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            })
                        }

                    },
                    error: function () {
                        swal({
                            title: "¡Algo salió mal!",
                            text: "¡Ha ocurrido un error al " + titulo + " el proyecto!",
                            type: "error",
                            allowOutsideClick: false,
                            confirmButtonColor: '#0c7cd5',
                            allowEscapeKey: false
                        }, function () {
                            location.reload();
                        });
                    }
                });
            })
        },
        allowOutsideClick: false,
        allowEscapeKey: false
    })
};

function desactivarCuestionario(url, id, nombre) {
    swal({
        title: '¿Está seguro de desactivar el cuestionario: ' + nombre + '?',
        html: '<span><b>Este cuestionario ya no podrá ser contestado ni editado.</b></span><br/><span>Esta acción no se podrá revertir.</span>',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: '¡Sí, desactivar!',
        cancelButtonText: '¡No, cancelar!',
        showLoaderOnConfirm: true,
        preConfirm: function () {
            return new Promise(function (resolve, reject) {
                var form = $('#__AjaxAntiForgeryForm');
                var token = $('input[name="__RequestVerificationToken"]', form).val();
                $.ajax({
                    url: url + id,
                    method: "post",
                    dataType: "json",
                    data: {
                        __RequestVerificationToken: token,
                        id: id,

                    },
                    success: function (data) {
                        if (data.success) {
                            swal({
                                type: 'success',
                                title: 'Cuestionario desactivado exitosamente.',
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        } else {
                            swal({
                                type: 'info',
                                title: data.message,
                                allowOutsideClick: false,
                                confirmButtonColor: '#0c7cd5',
                                allowEscapeKey: false
                            }).then(function () {
                                location.reload();
                            });
                        }

                    },
                    error: function () {
                        swal({
                            title: "¡Algo salió mal!",
                            text: "¡Ha ocurrido un error al eliminar el registro, si el problema continua comunicate con el administrador!",
                            type: "error",
                            allowOutsideClick: false,
                            confirmButtonColor: '#0c7cd5',
                            allowEscapeKey: false
                        }, function () {
                            location.reload();
                        });
                    }
                });
            });
        },
        allowOutsideClick: false,
        allowEscapeKey: false
    });
};

function cotizacionDolar(url, idCotizacion, idProyecto) {
    swal({
        title: "Desea descargar la cotización en pesos mexicanos o en dolares",
        text: "Elija la opción",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: 'red',
        cancelButtonColor: '#0c7cd5',
        confirmButtonText: 'MXN',
        cancelButtonText: 'USD',
        showLoaderOnConfirm: true,
        allowOutsideClick: false,
        allowEscapeKey: false
    }).then((result) => {
        if (result.value) {
            window.open(url + "?idCotizacion=" + idCotizacion + "&idProyecto=" + idProyecto + "&isActive=" + false, "_blank");
        } else {
            window.open(url + "?idCotizacion=" + idCotizacion + "&idProyecto=" + idProyecto + "&isActive=" + true, "_blank");
        }
    });
};