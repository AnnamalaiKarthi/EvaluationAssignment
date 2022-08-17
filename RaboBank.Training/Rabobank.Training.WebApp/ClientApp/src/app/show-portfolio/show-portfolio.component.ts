import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PortfolioVM } from '../shared/models/portfolio.model';
import { PortfolioService } from '../shared/services/portfolio.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-show-portfolio',
  templateUrl: './show-portfolio.component.html'
})
export class ShowPortfolioComponent implements OnInit {
  constructor(private service: PortfolioService, private router: Router) { }

  portfoliodata: any;

  ngOnInit() {
    this.service.getAllPortfolios().subscribe((res: PortfolioVM) => {
      this.portfoliodata = res;
    },
      err => console.log('HTTP Error', err));
  }
}
