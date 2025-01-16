function getCurrentLocationWeather() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(position => {
            const latitude = position.coords.latitude;
            const longitude = position.coords.longitude;

            const apiUrl = `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`;

            fetch(apiUrl)
                .then(response => response.json())
                .then(data => {
                    const weather = data.current_weather;
                    displayWeather(weather);
                })
                .catch(error => {
                    console.error('Error fetching weather data:', error);
                    document.getElementById('weather-info').innerHTML = 'Failed to load weather data.';
                });
        }, error => {
            console.error('Error getting location:', error);
            document.getElementById('weather-info').innerHTML = 'Could not retrieve location.';
        });
    } else {
        alert('Geolocation is not supported by this browser.');
    }
}

function displayWeather(weather) {
    const weatherInfo = `
        <p><strong>Temperature:</strong> ${weather.temperature}°C</p>
        <p><strong>Wind Speed:</strong> ${weather.windspeed} km/h</p>
        <p><strong>Wind Direction:</strong> ${weather.winddirection}°</p>
    `;

    document.getElementById('weather-info').innerHTML = weatherInfo;
}
