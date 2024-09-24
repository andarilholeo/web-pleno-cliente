import { Routes } from '@angular/router';
import { MainComponent } from './pages/main/main.component';
import { ClienteCadastroComponent } from './pages/cliente-cadastro/cliente-cadastro.component';
import { EditarComponent } from './pages/editar/editar.component';

export const routes: Routes = [
    {path:'cliente-cadastro', component: ClienteCadastroComponent},
    {path:'cliente-editar', component: EditarComponent},
    {path:'', component: MainComponent},
];
