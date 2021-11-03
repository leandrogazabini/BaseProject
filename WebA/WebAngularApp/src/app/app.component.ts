import { Component } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'WebAngularApp';
  jsonValueExample = {
    a:'Hello',
    b:'World!'
  }
  newData = new Date();

// New class....
  userObject = {
    name: 'Leandro',
    age: '61',
    id: 1
  }

  constructor(private httpService: HttpService){

  }
  handleEvent(){
    this.httpService.getRequest('https://jsonplaceholder.typicode.com/todos/1')
    .subscribe((response) =>
     this.jsonValueExample = response
    )
  console.log('Nothing...')}

  handleUserEvent(event:any){
    console.log(event)

  }
}
