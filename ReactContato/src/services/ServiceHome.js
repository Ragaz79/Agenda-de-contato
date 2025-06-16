import Api from '../helpers/api'

export default function ListarHome(){
    return Api.get('/Home/funcaoController')
}