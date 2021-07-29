import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { ApiClientService } from '../../../services/apiclient.service';
import { Dados } from '../dados.model';


@Component({
  selector: 'app-adicionar',
  templateUrl: './adicionar.component.html',
  styleUrls: ['./adicionar.component.css']
})
export class adicionarComponent implements OnInit {

  projeto: Dados;
  submitted = false;
  apiUrl: string;

  constructor(
    private router: Router,
    private apiService: ApiClientService) {
  }

  ngOnInit() {
    this.projeto = new Dados();
  }

  onSubmit() {
    if (!this.submitted) {
      this.submitted = true;
      this.apiService.post<Dados>(this.apiUrl, this.projeto).subscribe(
        projeto => {
          this.router.navigateByUrl('/projeto');
        },
        error => {
          this.submitted = false;
        });
    }
  }

}
