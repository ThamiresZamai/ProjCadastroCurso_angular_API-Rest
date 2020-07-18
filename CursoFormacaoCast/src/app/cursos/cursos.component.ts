import { Component, OnInit } from '@angular/core';
import { CursosService } from '../cursos.service';
import { CursoModel } from './curso.model';
import { CategoriaService } from '../categoria.service';
import { CategoriaModel } from '../categorias/categorias.model';

@Component({
  selector: 'app-cursos',
  templateUrl: './cursos.component.html',
  styleUrls: ['./cursos.component.css']
})
export class CursosComponent implements OnInit {

  curso: CursoModel = new CursoModel();
  cursos: Array<any> = new Array();
  categorias: Array<any> = new Array();

  constructor(private cursosService: CursosService, private categoria: CategoriaService) { }

  ngOnInit() {
    this.ListarCategorias();
    this.curso.categoria = new CategoriaModel();
  }
  ListarCategorias() {
    this.categoria.ListarCategorias().subscribe(categorias => {
      this.categorias = categorias;
      this.ListarCursos();
    }, err => {
      console.log("Erro ao listar categorias", err);
    })
  }

  ListarCursos() {
    this.cursosService.ListarCursos().subscribe(cursos => {
      this.cursos = cursos;
      this.cursos.forEach(element => {
        element.categoria = this.categorias.find(x => x.id == element.categoriaid);
      });

    }, err => {
      alert("Erro ao listar curso: " + err.error)
    })
  }

  cadastrar() {
    console.log(this.curso.categoria);
    this.cursosService.cadastrarCurso(this.curso).subscribe(cursos => {
      this.curso = new CursoModel();
      this.ListarCursos();
    }, err => {
      alert("Erro ao cadastrar curso: " + err.error)
    })
  }

  atualizar(id: number) {
    this.cursosService.atualizarCurso(id, this.curso).subscribe(cursos => {
      this.curso = new CursoModel();
      this.ListarCursos();
    }, err => {
      alert("Erro ao Atualizar curso: " + err.error)
    })
  }


  remover(id: number) {
    this.cursosService.removerAluno(id).subscribe(cursos => {
      this.curso = new CursoModel();
      this.ListarCursos();
    }, err => {
      alert("Erro ao remover curso: " + err.error)
    })
  }
}
