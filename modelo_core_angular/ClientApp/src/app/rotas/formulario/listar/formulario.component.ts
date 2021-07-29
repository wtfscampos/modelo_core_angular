import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../../../services/apiclient.service';
import { AppInitService } from '../../../services/app-init.service';
import { Dados } from '../dados.model';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})

export class formularioComponent implements OnInit {

  dados: Dados[];
  status = { message: "", detail: "" };

  constructor(private apiService: ApiClientService, private configuracao: AppInitService) { }

  ngOnInit() {
    this.Popular("api/Projeto");
  }

  // Bind
  Popular(apiUrl) {
    this.dados = [];
    this.status.message = "Carregando...";
    this.status.detail = "";
    this.apiService.listar<Dados>(apiUrl).subscribe(
      dados => {
        this.dados = dados;
        this.status.message = "";
      },
      errorResponse => {
        this.status.message = errorResponse.error.message;
        this.status.detail = errorResponse.error.detail;
      }
    );
  }

}
