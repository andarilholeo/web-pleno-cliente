import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteDTO } from '../models/cliente.dto';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  ApiUrl = environment.urlWebPlenoAPI;

  constructor(private http : HttpClient) { }

  GetClientes(): Observable<ClienteDTO[]>{
    return this.http.get<ClienteDTO[]>(this.ApiUrl);
  }

  CriarCliente(cliente: ClienteDTO) : Observable<ClienteDTO[]>{
    return this.http.post<ClienteDTO[]>(this.ApiUrl,cliente);
  }


  GetClienteId(id:number):Observable<ClienteDTO>{
    return this.http.get<ClienteDTO>(`${this.ApiUrl}/${id}`);
  }

  EditarCliente(cliente: ClienteDTO):Observable<ClienteDTO[]>{
    return this.http.put<ClienteDTO[]>(this.ApiUrl, cliente);
  }

  DeletarCliente(id:number | undefined) : Observable<ClienteDTO[]>{
    return this.http.delete<ClienteDTO[]>(`${this.ApiUrl}/${id}`);
  }
}
