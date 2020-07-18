import { CategoriaModel } from '../categorias/categorias.model';

export class CursoModel{
    id: number;
    descricao: string;
    dataInicio: string;
    dataFim: string;
    qtdAluno: number;
    categoria: CategoriaModel;
}