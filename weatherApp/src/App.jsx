import React, { useState } from "react";
import { getWeather } from "./services/api";
import "./App.css"; // CSS dosyasını dahil ettik

const App = () => {
  const [city, setCity] = useState("");
  const [weatherData, setWeatherData] = useState(null);
  const [error, setError] = useState("");

  const handleSearch = async () => {
    try {
      setError("");
      const data = await getWeather(city);
      setWeatherData(data);
    } catch (err) {
      console.error("Error fetching weather data:", err);
      setError("Hava durumu bilgisine ulaşılamadı.");
    }
  };

  return (
    <div className="container">
      <div className="card">
        <h1 className="title">🌦️ Hava Durumu Uygulaması</h1>
        <div className="input-container">
          <input
            type="text"
            value={city}
            onChange={(e) => setCity(e.target.value)}
            placeholder="Şehir ismi girin"
            className="input"
          />
          <button onClick={handleSearch} className="button">
            Ara
          </button>
        </div>

        {error && <p className="error">{error}</p>}

        {weatherData && (
          <div className="weather-info">
            <h2>{weatherData.name}</h2>
            <p>🌡️ Sıcaklık: {weatherData.main.temp}°C</p>
            <p>🌥️ Hava Durumu: {weatherData.weather[0].description}</p>
            <p>🌬️ Rüzgar Hızı: {weatherData.wind.speed} m/s</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default App;
