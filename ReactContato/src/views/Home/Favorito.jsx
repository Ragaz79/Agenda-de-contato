import { useState } from 'react'

function favorito() {
    return (
        <div>
            <h1>Contatos</h1>
            <a href="CriarContato"></a>
            <br />

            <table className='table table-bordered table-striped mt-3'>
                <thead className='thead-dark'>
                    <tr>
                        <th>Nome</th>
                        <th>Telefone</th>
                        <th>Categoria</th>
                        <th>Ação</th>
                    </tr>
                </thead>
                <tbody>
                    {/* foreach(){ */}
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <button>
                                    <i></i>
                                </button>
                            </td>
                            <td>
                                <a href=""></a>
                                <a href=""></a>
                            </td>
                        </tr>
                    {/* } */}
                </tbody>
            </table>

            <div className="d-flex justify-content-center mt-4">
                
            </div>
        </div>
    )
}