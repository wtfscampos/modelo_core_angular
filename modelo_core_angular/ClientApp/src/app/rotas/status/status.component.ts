import { Component, OnInit } from '@angular/core';

import { ApiClientService } from '../../services/apiclient.service';
import { AppInitService } from '../../services/app-init.service';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})

export class statusComponent implements OnInit {
  //Informações do AppSettings.json na pasta ClientApp
  build: string;
  release: string;
  ambiente: string;
  tipodeploy: string;
  plataforma: string;
  issuer: string;
  realm: string;
  apiendereco: string;
  status: string;

  constructor(private apiService: ApiClientService, private configuracao: AppInitService) {
  }

  ngOnInit() {
    this.BuscarStatus("api/Projeto");
    this.BuscarConfiguracao();
  }

  BuscarStatus(apiUrl) {
    this.apiService.status<string>(apiUrl).subscribe(
      status => {
        this.status = status;
      },
      errorResponse => {
        this.status = errorResponse.error.message;
      }
    );
  }

  BuscarConfiguracao() {
    this.configuracao.getAppSettings<any>().subscribe(
      appSettings => {
        this.build = appSettings.dadosdeploy.build;
        this.release = appSettings.dadosdeploy.release;
        this.ambiente = appSettings.dadosdeploy.ambiente;
        this.tipodeploy = appSettings.dadosdeploy.tipodeploy;
        this.plataforma = appSettings.dadosdeploy.plataforma;
        this.issuer = appSettings.identity.issuer;
        this.realm = appSettings.identity.realm;
        this.apiendereco = appSettings.apiendereco.url;
      }
    );
  }
}
