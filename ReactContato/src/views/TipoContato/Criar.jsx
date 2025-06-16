import { useState } from 'react';
import './style.css';

function Criar() {
  const [nome, setNome] = useState('');
  const [erro, setErro] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!nome.trim()) {
      setErro('Este campo é obrigatório.');
      return;
    }

    console.log('Contato salvo:', nome);
    setNome('');
    setErro('');
  };

  return (
    <div className="form-container">
      <h2>Criar Contato</h2>

      <form onSubmit={handleSubmit}>
        <input type="hidden" name="TIPO_COD" value="1" />

        <label className="mt-2">Nome do Contato</label>
        <input
          className="form-control"
          name="TIPO_NOME"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
        />

        {erro && <span className="text-danger">{erro}</span>}

        <button className="btn btn-primary mt-2" type="submit">
          <i className="fa-solid fa-floppy-disk"></i> Salvar
        </button>
      </form>
    </div>
  );
}

export default Criar;
