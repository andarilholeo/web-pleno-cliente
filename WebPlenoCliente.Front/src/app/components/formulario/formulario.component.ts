import { Component, EventEmitter ,OnInit, Input, Output } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ClienteDTO } from '../../models/cliente.dto';

@Component({
  selector: 'app-formulario',
  standalone: true,
  imports: [RouterModule, FormsModule, ReactiveFormsModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.scss'
})

export class FormularioComponent implements OnInit {
  @Input() dadosUsuario : ClienteDTO | null = null
  @Output() onSubmit = new EventEmitter<ClienteDTO>();

  clienteForm!: FormGroup;

  ngOnInit(): void {

    this.clienteForm = new FormGroup({

      id: new FormControl(this.dadosUsuario ? this.dadosUsuario.id : 0),
      nome: new FormControl(this.dadosUsuario ? this.dadosUsuario.nome :''),
      telefone: new FormControl(this.dadosUsuario ? this.dadosUsuario.telefone :''),
      email: new FormControl(this.dadosUsuario ? this.dadosUsuario.email :''),
      dataNascimento: new FormControl(this.dadosUsuario ? new Date(this.dadosUsuario.dataNascimento) : null)
    });
  }

  submit(){
    console.log();
    this.onSubmit.emit(this.clienteForm.value);
  }
}