import { Component } from '@angular/core';
import { FormularioComponent } from "../../components/formulario/formulario.component";
import { ClienteService } from '../../services/cliente.service';
import { ClienteDTO } from '../../models/cliente.dto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cliente-cadastro',
  standalone: true,
  imports: [FormularioComponent],
  templateUrl: './cliente-cadastro.component.html',
  styleUrl: './cliente-cadastro.component.scss'
})
export class ClienteCadastroComponent {
  btnAcao= "Cadastrar";
  descTitulo = "Cadastrar Usuários";

  constructor(private clienteService: ClienteService, private router: Router){}

  criarCliente(cliente : ClienteDTO){
    this.clienteService.CriarCliente(cliente).subscribe(response => {
      this.router.navigate(['/'])
    })
  }
}
