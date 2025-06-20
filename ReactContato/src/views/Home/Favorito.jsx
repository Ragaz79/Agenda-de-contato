import { useState, useEffect } from 'react';
import contatoService from '../../services/ServiceHome';
import { Link } from 'react-router-dom';

function Favorito() {
  const [favoritos, setFavoritos] = useState([]);

  useEffect(() => {
    fetchFavoritos();
  }, []);

  const fetchFavoritos = () => {
    contatoService
      .listarFavoritos()
      .then((res) => setFavoritos(res.data))
      .catch((err) => console.error('Erro ao listar favoritos:', err));
  };

  const handleToggleFavorito = (id) => {
    contatoService
      .alternarFavorito(id)
      .then(() => fetchFavoritos())
      .catch((err) => console.error('Erro ao alternar favorito:', err));
  };

  const handleDelete = (id) => {
    if (window.confirm('Deseja excluir este contato?')) {
      contatoService
        .deletarContato(id)
        .then(() => fetchFavoritos())
        .catch((err) => console.error('Erro ao excluir contato:', err));
    }
  };

  return (
    <div className="container">
      <h1>Contatos Favoritos</h1>
      <table className="table">
        <thead>
          <tr>
            <th>Nome</th>
            <th>Telefone</th>
            <th>Categoria</th>
            <th>Favorito</th>
            <th>Ações</th>
          </tr>
        </thead>
        <tbody>
          {favoritos.map((contato) => (
            <tr key={contato.contatO_COD}>
              <td>{contato.contatO_NOME}</td>
              <td>{contato.contatO_NUMERO}</td>
              <td>{contato.tipocontato?.tipO_NOME || 'Sem tipo'}</td>
              <td>
                <button
                  className="btn btn-icon"
                  onClick={() => handleToggleFavorito(contato.contatO_COD)}
                >
                  ★
                </button>
              </td>
              <td>
                <Link
                  to={`/contatos/editar/${contato.contatO_COD}`}
                  className="btn btn-primary"
                >
                  Editar
                </Link>
                <button
                  className="btn btn-danger"
                  onClick={() => handleDelete(contato.contatO_COD)}
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

export default Favorito;