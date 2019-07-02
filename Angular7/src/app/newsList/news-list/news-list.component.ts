import { Component, OnInit } from '@angular/core';
import { News } from '../news';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {
  newses: Array<News>;
  news: News;
  url = '//localhost:54277/api/values';
  
  searchValue = '';
  

  constructor( private http: HttpClient) {
  
  }

  ngOnInit() {
    this.http.get<News[]>
    (this.url)
      .subscribe(response => {
        this.newses = response;
      });
  }


  onEnter(value: string) { 
    this.searchValue = value;
    this.url = '//localhost:54277/api/values/'+ this.searchValue;
    this.http.get<News[]>
    (this.url)
    .subscribe(response => {
      this.newses = response;
    });
   }


}
