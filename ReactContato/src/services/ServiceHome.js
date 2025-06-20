import axios from 'axios';

const API_BASE_URL = 'http://localhost:5033/api/Home'; // ajuste a porta se necessário

const contatoService = {
  listarContatos: (page = 1, pageSize = 10) =>
    axios.get(`${API_BASE_URL}/ListarContatos?page=${page}&pageSize=${pageSize}`),

  buscarContato: (id) =>
    axios.get(`${API_BASE_URL}/SelecionarContato/${id}`),

  criarContato: (contato) =>
    axios.post(`${API_BASE_URL}/CadastrarContato`, contato),

  atualizarContato: (id, contato) =>
    axios.put(`${API_BASE_URL}/AlterarContato/${id}`, contato),

  deletarContato: (id) =>
    axios.delete(`${API_BASE_URL}/DeletaContato/${id}`),

  alternarFavorito: (id) =>
    axios.patch(`${API_BASE_URL}/${id}/favorito`),

  listarFavoritos: (page = 1, pageSize = 10) =>
    axios.get(`${API_BASE_URL}/favoritos?page=${page}&pageSize=${pageSize}`)
};

export default contatoService;
