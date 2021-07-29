import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {

  public httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  };
  
  constructor(private httpClient: HttpClient) {
  }

  public listar<T>(apiUrl:string): Observable<T[]> {
    return this.httpClient.get<T[]>(apiUrl);
  }
  public get<T>(apiUrl:string, id: number): Observable<T> {
    return this.httpClient.get<T>(apiUrl + id.toString());
  }
  public post<T>(apiUrl:string, obj: T): Observable<T> {
    var postData = JSON.stringify(obj);
    return this.httpClient.post<T>(apiUrl, postData, this.httpOptions);
  }
  public put<T>(apiUrl:string, obj: T): Observable<T> {
    var postData = JSON.stringify(obj);
    return this.httpClient.put<T>(apiUrl, postData, this.httpOptions);
  }
  public delete<T>(apiUrl:string, id: number): Observable<T> {
    return this.httpClient.delete<T>(apiUrl + id.toString());
  }
  public status<T>(apiUrl: string): Observable<T> {
    return this.httpClient.get<T>(apiUrl + "/status");
  }

}
