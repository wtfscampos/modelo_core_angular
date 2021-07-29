import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { FormularioRotasModule } from './formulario-rotas.module';
import { adicionarComponent } from './adicionar/adicionar.component';
import { formularioComponent } from './listar/formulario.component';

@NgModule({
  declarations: [
    adicionarComponent,
    formularioComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule,
    BrowserModule,
    FormsModule,
    FormularioRotasModule
  ],
  exports: [
    RouterModule
  ]
})
export class FormularioModule { }
