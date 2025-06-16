import axios from 'axios';

const Api = axios.create({
    withCredentials: false,
    baseURL:"http://localhost:7000/api"
})

export default Api;