function CargarCiudadesPorPais(selectPais) {
    let country = $(selectPais).val();
    $.ajax({
        url: '/City/LoadCitiesByCountry',
        method: 'POST',
        data: {
            countryId: country
        },
        success: (data) => {
            let options = "";
            data.forEach((city) => {
                options += `<option value='${city.Id}'>${city.Name}</option>`;
            });
            document.querySelector("#selectCity").innerHTML = options;
        }
    });
}

function CargarProyectosPorCiudades(selectCiudad) {
    let city = $(selectCiudad).val();
    $.ajax({
        url: '/Project/LoadProjectsByCity',
        method: 'POST',
        data: {
            cityId: city
        },
        success: (data) => {
            let options = "";
            data.forEach((project) => {
                options += `<option value='${project.Id}'>${project.Name}</option>`;
            });
            document.querySelector("#selectProject").innerHTML = options;
        }
    });
}

function CargarBloquesPorProyectos(selectProyecto) {
    let proyecto = $(selectProyecto).val();
    $.ajax({
        url: '/Block/LoadBlockByProject',
        method: 'POST',
        data: {
            projectId: proyecto
        },
        success: (data) => {
            let options = "";
            data.forEach((block) => {
                options += `<option value='${block.Id}'>${block.Name}</option>`;
            });
            document.querySelector("#selectBlock").innerHTML = options;
        }
    });

  
}

$('.botonF1').hover(function () {
    $('.btn').addClass('animacionVer');
})
$('.contenedor').mouseleave(function () {
    $('.btn').removeClass('animacionVer');
})




