import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';
import { ClienteDTO } from '../../models/cliente.dto';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [],
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})

export class MainComponent implements OnInit {
  clientes : ClienteDTO[] = [];
  clientesGeral : ClienteDTO[] = [];

  constructor(private serivceCliente:ClienteService){}

  ngOnInit(): void {
    this.serivceCliente.GetClientes().subscribe(response =>{
      this.clientes = response;
      this.clientesGeral = response;

      console.log(response);
    });
  }

  search(event:Event){

    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.clientes = this.clientesGeral.filter(cliente =>{
      return cliente.nome.toLowerCase().includes(value);
    })
  }

  deletar(id:number | undefined){
    this.serivceCliente.DeletarCliente(id).subscribe(response => {
      console.log(response);
      window.location.reload();
    })
  }
}