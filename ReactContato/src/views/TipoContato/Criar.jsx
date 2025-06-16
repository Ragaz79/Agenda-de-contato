import { useState } from 'react';
import './style.css';

function CriarTipoContato() {
    return(
        <div style={{ maxWidth: '500px', margin: '0 auto', padding: '1rem'}}>
            <h2>
                Criar Contatos
            </h2>
            <form>
                <input type="hidden" name="TIPO_COD" value="1"/>
                <label className="mt-2">Nome do Contato</label>
                <input className="form-control" name="TIPO_NOME" />
                <span className="text-danger">Este campo é obrigatório.</span>
                <button className="btn btn-primary mt-2" type="submit">
                    <i className="fa-solid fa-floppy-disk"></i> Salvar
                </button>
            </form>
        </div>
    )
}

export default CriarTipoContato;