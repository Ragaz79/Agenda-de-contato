import { useState, useEffect } from 'react';
import contatoService from '../../services/ServiceHome';
import { Link } from 'react-router-dom';

function IndexContato() {
  const [contatos, setContatos] = useState([]);

  useEffect(() => {
    fetchContatos();
  }, []);

  const fetchContatos = () => {
    contatoService
      .listarContatos()
      .then((res) => {
        // console.log(res.data);
        setContatos(res.data);
      })
      .catch((err) => console.error('Erro ao listar contatos:', err));
  };

  const handleDelete = (id) => {
    if (window.confirm('Deseja excluir este contato?')) {
      contatoService
        .deletarContato(id)
        .then(() => fetchContatos())
        .catch((err) => console.error('Erro ao excluir contato:', err));
    }
  };

  const handleToggleFavorito = (id) => {
    contatoService
      .alternarFavorito(id)
      .then(() => fetchContatos())
      .catch((err) => console.error('Erro ao alternar favorito:', err));
  };

  return (
    <div className="container">
      <h1>Contatos</h1>
      <Link to="/contatos/novo" className="btn btn-success">
        + Novo Contato
      </Link>
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
          {contatos.map((contato) => (
            <tr key={contato.contatO_COD}>
              <td>{contato.contatO_NOME}</td>
              <td>{contato.contatO_NUMERO}</td>
              <td>{contato.tipocontato?.tipO_NOME || 'Sem tipo'}</td>
              <td>
                <button
                  className="btn btn-icon"
                  onClick={() => handleToggleFavorito(contato.contatO_COD)}
                >
                  {contato.contatO_FAVORITO ? '★' : '☆'}
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

export default IndexContato;