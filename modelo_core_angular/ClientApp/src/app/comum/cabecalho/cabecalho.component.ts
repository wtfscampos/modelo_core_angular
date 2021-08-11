import { Component, OnInit } from '@angular/core';
import { ApiClientService } from '../../services/apiclient.service';

@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {
  nomeusuario: string;

  constructor(private apiService: ApiClientService) { }

  ngOnInit() {
    this.BuscarUsuario("api/Configuracao/usuario");
  }

  BuscarUsuario(apiUrl) {
    this.apiService.usuario<any>(apiUrl).subscribe(
      usuario => {
        this.nomeusuario = usuario.Nome;
      },
      errorResponse => {
        this.nomeusuario = errorResponse.error.message;
      }
    );
  }
}
