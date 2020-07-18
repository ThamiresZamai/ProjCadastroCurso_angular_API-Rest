import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CursoModel } from './cursos/curso.model';
import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CursosService {

  constructor(private http : HttpClient) {   }
  
 


  ListarCursos() : Observable<any>{
    return this.http.get(environment.apiurlcurso.concat("findAll"));
  }

  cadastrarCurso(curso: CursoModel) : Observable<any>{
    let headers = {
      'Content-Type':'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Credentials': 'true',
      'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE',
      'Access-Control-Allow-Origin': 'http://localhost:52159'
    }; 
    // let headers = new HttpHeaders();
    // headers.append('Content-Type', 'application/json');
    // headers.append('Accept', 'application/json');    
    // headers.append('Access-Control-Allow-Credentials', 'true');
    // headers.append('Access-Control-Allow-Methods', 'GET,PUT,POST,DELETE');
    // headers.append('Access-Control-Allow-Origin', 'http://localhost:52159');

    console.log(JSON.stringify({curso}));

    return this.http.post(environment.apiurlcurso.concat("create"), curso);
  }

  atualizarCurso(id: any, curso: CursoModel): Observable<any>{
    return this.http.put(environment.apiurlcurso.concat("update/").concat(id), curso);
  }

  removerAluno(id: any):Observable<any>{
    return this.http.delete(environment.apiurlcurso.concat("delete/").concat(id));
  }
}
