import { Link } from 'react-router-dom';
import './style.css';

function Index() {
  const contatos = [
    { id: 1, nome: 'João', telefone: '11 99999-9999' },
    { id: 2, nome: 'Maria', telefone: '21 98888-8888' },
  ];

  return (
    <div className="form-container">
      <h2>Contatos</h2>

      <Link to="/criar">
        <button className="btn btn-primary">Criar Contato</button>
      </Link>

      <ul style={{ marginTop: '1rem' }}>
        {contatos.map((c) => (
          <li key={c.id}>
            <strong>{c.nome}</strong> - {c.telefone}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default Index;
