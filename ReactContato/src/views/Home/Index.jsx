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
      <br/> <br/>
      <Link to="/contatos/novo" className="btn btn-success" style={{ textDecoration: 'none', color: 'white' }}>
        + Novo Contato
      </Link>
      <br/> 
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
                  style={{ color: contato.contatO_FAVORITO ? 'blue' : 'gray' }}
                >
                  {contato.contatO_FAVORITO ? '★' : '☆'}
                </button>
              </td>
              <td>
                <Link
                  to={`/contatos/editar/${contato.contatO_COD}`}
                  className="btn btn-primary btn-sm w-100"
                  style={{ textDecoration: 'none', color: 'white' }}
                >
                  Editar
                </Link>
                <button
                  className="btn btn-danger btn-sm w-100"
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