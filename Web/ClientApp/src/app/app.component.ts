import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  public request?: number;

  constructor(private http: HttpClient){
    
  }
  
  runTest(){
    this.http.get<number>("api/invoice/generate").subscribe(d=> {
      this.request = d;
    });
  }

  download(){
    window.location.href = "api/invoice/download/" + this.request;
  }

}
