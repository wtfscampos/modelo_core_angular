import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CabecalhoComponent } from './cabecalho/cabecalho.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RodapeComponent } from './rodape/rodape.component';
import { PopMenuComponent } from './pop-menu/pop-menu.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { RotasModule } from '../rotas/rotas.module';

@NgModule({
  declarations: [
    NavMenuComponent,
    CabecalhoComponent,
    RodapeComponent,
    PopMenuComponent,
    BreadcrumbComponent
  ],
  imports: [
    CommonModule,
    RotasModule
  ],
  exports: [
    NavMenuComponent,
    CabecalhoComponent,
    RodapeComponent,
    PopMenuComponent,
    BreadcrumbComponent
  ],
  providers: [
  ]
})

export class ComumModule {

}
