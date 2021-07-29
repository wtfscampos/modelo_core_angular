import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { formularioComponent } from './listar/formulario.component';
import { adicionarComponent } from './adicionar/adicionar.component';

const RotasFormulario: Routes = [
  {
    path: 'formulario',  data: { breadcrumb: "Formulário" },
    children: [
      { path: '', component: formularioComponent },
      { path: 'adicionar', component: adicionarComponent,  data: { breadcrumb: "Adicionar"  } }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(RotasFormulario)
  ],
  exports: [
    RouterModule
  ]
})
export class FormularioRotasModule { }
