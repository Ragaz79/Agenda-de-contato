import { useState } from 'react'
import CriarContato from './CriarContato'
import { Link } from 'react-router-dom';



function IndexContato() {

    // <Route path="/criar-contato" element={<CriarContato />} />
    
    return (
        <div>

            <h1>Contatos</h1>
            <Link to='CriarContato' className='btn btn-primary'>Criar Contato</Link>
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
                                    <i className='fa-solid fa-star'></i>
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

export default IndexContato