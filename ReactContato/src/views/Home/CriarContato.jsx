import { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import contatoService from '../../services/ServiceHome';
import tipoContatoService from '../../services/ServiceTipoContato';

function CriarContato() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [contato, setContato] = useState({
    contatO_COD: 0,
    contatO_NOME: '',
    contatO_NUMERO: '',
    tipO_COD: 0,
    contatO_FAVORITO: false,
  });
  const [tipos, setTipos] = useState([]);

  useEffect(() => {
    // Buscar tipos de contato
    tipoContatoService
      .listarTipos()
      .then((res) => setTipos(res.data))
      .catch((err) => console.error('Erro ao listar tipos:', err));

    // Se estiver editando, buscar dados do contato
    if (id) {
      contatoService
        .buscarContato(id)
        .then((res) => setContato(res.data))
        .catch((err) => console.error('Erro ao buscar contato:', err));
    }
  }, [id]);

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;

    const newValue =
      type === 'checkbox'
        ? checked
        : name === 'tipO_COD'
        ? parseInt(value)
        : value;

    setContato((prev) => ({
      ...prev,
      [name]: newValue,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    console.log('Enviando contato:', contato); // Para você verificar antes do envio

    const action = id
      ? contatoService.atualizarContato(id, contato)
      : contatoService.criarContato(contato);

    action
      .then(() => navigate('/'))
      .catch((err) =>
        console.error(`Erro ao ${id ? 'atualizar' : 'criar'} contato:`, err)
      );
  };

  return (
    <div className="container">
      <h1>{id ? 'Editar Contato' : 'Criar Contato'}</h1>
      <form onSubmit={handleSubmit}>
        <input type="hidden" name="contatO_COD" value={contato.contatO_COD} />
        <div className="form-group">
          <label>Nome</label>
          <input
            type="text"
            name="contatO_NOME"
            value={contato.contatO_NOME}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>
        <div className="form-group">
          <label>Número</label>
          <input
            type="number"
            name="contatO_NUMERO"
            value={contato.contatO_NUMERO}
            onChange={handleChange}
            className="form-control"
            required
          />
        </div>
        <div className="form-group">
          <label>Tipo de Contato</label>
          <select
            name="tipO_COD"
            value={contato.tipO_COD}
            onChange={handleChange}
            className="form-control"
            required
          >
            <option value="0">Selecione...</option>
            {tipos.map((tipo) => (
              <option key={tipo.tipO_COD} value={tipo.tipO_COD}>
                {tipo.tipO_NOME}
              </option>
            ))}
          </select>
        </div>
        <button type="submit" className="btn btn-success">
          {id ? 'Atualizar' : 'Criar'}
        </button>
        <button
          type="button"
          className="btn btn-secondary"
          onClick={() => navigate('/')}
        >
          Cancelar
        </button>
      </form>
    </div>
  );
}

export default CriarContato;
