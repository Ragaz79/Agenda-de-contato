import axios from 'axios';

const API_BASE_URL = 'http://localhost:5033/api/TipoContato';

const tipoContatoService = {
  listarTipos: () => axios.get(`${API_BASE_URL}/ListarTipo`),
  buscarTipo: (id) => axios.get(`${API_BASE_URL}/SelecionarTipo/${id}`),
  criarTipo: (tipo) => axios.post(`${API_BASE_URL}/CadastrarTipo`, tipo),
  atualizarTipo: (id, tipo) => axios.put(`${API_BASE_URL}/AlterarTipo/${id}`, tipo),
  deletarTipo: (id) => axios.delete(`${API_BASE_URL}/DeletarTipo/${id}`),
};

export default tipoContatoService;