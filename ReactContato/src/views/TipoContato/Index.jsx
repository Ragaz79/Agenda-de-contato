import { useState, useEffect } from 'react';
import tipoContatoService from '../../services/ServiceTipoContato';

function TipoContato() {
  const [tipos, setTipos] = useState([]);
  const [novoTipo, setNovoTipo] = useState({ TIPO_COD: 0, TIPO_NOME: '' });

  useEffect(() => {
    fetchTipos();
  }, []);

  const fetchTipos = () => {
    tipoContatoService
      .listarTipos()
      .then((res) => {
        // console.log(res.data);
        setTipos(res.data);

      })
      .catch((err) => console.error('Erro ao listar tipos:', err));
  };

  const handleChange = (e) => {
  setNovoTipo({ ...novoTipo, TIPO_NOME: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!novoTipo.TIPO_NOME.trim()) {
      alert('O nome do tipo é obrigatório.');
      return;
    }

    tipoContatoService
      .criarTipo(novoTipo)
      .then(() => {
        setNovoTipo({ tipO_COD: 0, tipO_NOME: '' });
        fetchTipos();
      })
      .catch((err) => console.error('Erro ao criar tipo:', err));
  };

  const handleDelete = (id) => {
    if (window.confirm('Deseja excluir este tipo de contato?')) {
      tipoContatoService
        .deletarTipo(id)
        .then(() => fetchTipos())
        .catch((err) => console.error('Erro ao excluir tipo:', err));
    }
  };

  return (
    <div className="container">
      <h1>Tipos de Contato</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label>Nome do Tipo</label>
          <input
            type="text"
            value={novoTipo.TIPO_NOME}
            onChange={handleChange}
            className="form-control"
            placeholder="Ex.: Pessoal, Trabalho"
            required
          />
        </div>
        <button type="submit" className="btn btn-success">
          Adicionar
        </button>
      </form>
      <table className="table">
        <thead>
          <tr>
            <th>Nome</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {tipos.map((tipo) => (
            <tr key={tipo.tipO_COD}>
              <td>{tipo.tipO_NOME}</td> {/* Fixed: Use TIPO_NOME instead of NOME */}
              <td>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(tipo.tipO_COD)}
                >
                  Excluir
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default TipoContato;