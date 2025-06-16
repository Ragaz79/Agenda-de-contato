import { useState } from 'react'
import IndexContato from './views/Home/Index';
import Favorito from './views/Home/Favorito';
// import Index from './views/TipoContato/Index';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import './App.css'


function App() {
  
  // useEffect(() => {
  //   var res = funcaoController().then(res =>console.log(res));
  // },
  // []);

  return (
    <Router>
      <div>
        <nav className='sidebar'>
            <h3>Agenda de Contatos</h3>
            <Link to='/'>Contatos</Link>
            <Link to='/favoritos'>Favoritos</Link>
            <Link to='/tipocontato'>Favoritos</Link>
        </nav>
        <div>
          <main>
              <Routes>
                <Route path="/" element={<IndexContato />} />
                <Route path="/favoritos" element={<Favorito />} />
                {/* <Route path="/tipocontato" element={<Index />} /> */}
              </Routes>
          </main>
          <footer className="border-top footer text-muted mt-auto">
            <div className="container"></div>
          </footer>
        </div>
      </div>
    </Router>
  )
}

export default App
