import { Injectable } from '@angular/core';

import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  constructor(private http : HttpClient) { }

  ListarCategorias() : Observable<any>{
    return this.http.get(environment.apiurlcat);
  }
}