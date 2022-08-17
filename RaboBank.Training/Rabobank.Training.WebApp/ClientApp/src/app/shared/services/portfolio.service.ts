import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';
import { PortfolioVM } from "../models/portfolio.model";
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})

export class PortfolioService {
  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:7007/api/';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getAllPortfolios() {
    console.log("Executing GetAllPortfolio from service");
    return this.http.get<PortfolioVM>(this.baseURL + "portfolio").pipe(map((res: PortfolioVM) => {
      return res;
    }));
  }
}
