import axios from 'axios';

const freeConnectApi = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
});

export default freeConnectApi;
