import { useState } from 'react'

function CriarContato() {
    return (

        <div>
            <h1>Criar Contatos</h1>

            <form action="CriarContatoForm">
                <input type="number" hidden id='CONTATO_COD' />
                <div className="container">
                    <label>Número</label>
                    <input type="text" className='form-control'/>
                </div>
                <div className="container">
                    <label>Nome</label>
                    <input type="text"/>
                </div>
                <div className="container">
                    <label>Tipo de Contato</label>
                    <select name="" id=""></select>
                </div>
            </form>
        </div>
    )
}
export default CriarContato