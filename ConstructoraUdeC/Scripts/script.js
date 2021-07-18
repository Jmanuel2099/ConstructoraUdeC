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