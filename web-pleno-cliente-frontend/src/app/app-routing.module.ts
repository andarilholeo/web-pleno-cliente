import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteListComponent } from './components/cliente-list/cliente-list.component';
import { ClienteFormComponent } from './components/cliente-form/cliente-form.component';
import { EnderecoListComponent } from './components/endereco-list/endereco-list.component';
import { EnderecoFormComponent } from './components/endereco-form/endereco-form.component';

const routes: Routes = [
  { path: 'clientes', component: ClienteListComponent },
  { path: 'clientes/new', component: ClienteFormComponent },
  { path: 'clientes/edit/:id', component: ClienteFormComponent },
  { path: 'enderecos', component: EnderecoListComponent },
  { path: 'enderecos/new', component: EnderecoFormComponent },
  { path: 'enderecos/edit/:id', component: EnderecoFormComponent },
  { path: '', redirectTo: '/clientes', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
