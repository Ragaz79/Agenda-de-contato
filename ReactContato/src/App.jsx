import { useState } from 'react'
import './App.css'


function App() {
  
  // useEffect(() => {
  //   var res = funcaoController().then(res =>console.log(res));
  // },
  // []);

  return (
    <div>
      <nav className='sidebar'>
        
      <h3>Agenda de Contatos</h3>
      <a href="Home">Contatos</a>
      <a href="TipoContato">Favoritos</a>

      </nav>
      <div>
        <main>
            {/* <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/favoritos" element={<TipoContato />} />
            </Routes> */}
        </main>
        <footer className="border-top footer text-muted mt-auto">
          <div className="container"></div>
        </footer>
      </div>
    </div>
  )
}

export default App
