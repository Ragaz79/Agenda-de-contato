import IndexContato from './views/Home/Index';
import Favorito from './views/Home/Favorito';
import TipoContato from './views/TipoContato/Index';
import CriarContato from './views/Home/CriarContato';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './style.css';

function App() {
  return (
    <Router>
      <div className="app-container">
        <nav className="sidebar">
          <h3>Agenda de Contatos</h3>
          <Link to="/">Contatos</Link>
          <Link to="/favoritos">Favoritos</Link>
          <Link to="/tipocontato">Tipos de Contato</Link>
        </nav>
        <div className="content">
          <main>
            <Routes>
              <Route path="/" element={<IndexContato />} />
              <Route path="/favoritos" element={<Favorito />} />
              <Route path="/tipocontato" element={<TipoContato />} />
              <Route path="/contatos/novo" element={<CriarContato />} />
              <Route path="/contatos/editar/:id" element={<CriarContato />} />
            </Routes>
          </main>
          <footer className="footer">
            <div className="container">© 2025 Agenda de Contatos</div>
          </footer>
        </div>
      </div>
    </Router>
  );
}

export default App;