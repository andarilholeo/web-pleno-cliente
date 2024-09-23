import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnderecoDTO } from '../models/enderecoDTO';

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {
  private apiUrl = 'http://localhost:5000/api/endereco';

  constructor(private http: HttpClient) { }

  getEnderecosPorCliente(clienteId: number): Observable<EnderecoDTO[]> {
    return this.http.get<EnderecoDTO[]>(`${this.apiUrl}/cliente/${clienteId}`);
  }

  getEndereco(id: number): Observable<EnderecoDTO> {
    return this.http.get<EnderecoDTO>(`${this.apiUrl}/${id}`);
  }

  addEndereco(endereco: EnderecoDTO): Observable<EnderecoDTO> {
    return this.http.post<EnderecoDTO>(this.apiUrl, endereco);
  }

  updateEndereco(id: number, endereco: EnderecoDTO): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, endereco);
  }

  deleteEndereco(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}