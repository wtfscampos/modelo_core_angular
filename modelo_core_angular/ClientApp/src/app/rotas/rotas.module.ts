import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { privacidadeComponent } from './privacidade/privacidade.component';
import { HomeComponent } from '../home/home.component';
import { statusComponent } from './status/status.component';
import { contatoComponent } from './contato/contato.component';
import { FormularioModule } from './formulario/formulario.module';


const Rotas: Routes = [
  { path: '',            component: HomeComponent,        },
  { path: 'privacidade', component: privacidadeComponent, data: { breadcrumb: "Privacidade" } },
  { path: 'status',      component: statusComponent,      data: { breadcrumb: "Sobre"       } },
  { path: 'contato',     component: contatoComponent,     data: { breadcrumb: "Contato"     } }
];

@NgModule({
  declarations: [
    privacidadeComponent,
    statusComponent,
    contatoComponent
  ],
  imports: [
    RouterModule.forRoot(Rotas),
    FormularioModule
  ],
  exports: [
    RouterModule
  ]
})
export class RotasModule { }
