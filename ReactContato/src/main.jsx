import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
//import CriarTipoContato from './views/TipoContato/Criar'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <CriarTipoContato />
  </StrictMode>,
)
