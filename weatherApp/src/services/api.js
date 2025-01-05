import axios from 'axios';
const API_URL = 'https://localhost:44352/api/Weather/'; // Backend URL


const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getWeather = async (city) => {
    try {
      const response = await api.get(`/${city}`); // Doğru URL formatı
      return response.data;
    } catch (error) {
      console.error('API Error:', error.response ? error.response.data : error.message); // Hata mesajını daha net al
      throw error;
    }
  };