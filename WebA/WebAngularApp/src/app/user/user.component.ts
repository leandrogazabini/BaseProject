import { Component, OnInit,Input, Output, EventEmitter } from '@angular/core';

interface UserInterface{
  name: string;
  age: string;
  id:number;
}

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  @Input() user:UserInterface;

  @Output() userEvent:EventEmitter<UserInterface>;

  constructor() {
    this.user = {} as UserInterface;
    this.userEvent = new EventEmitter<UserInterface>();
  }

  ngOnInit(): void {
  }

  sendUserEvent():void{
    this.userEvent.emit(this.user);
  }

}
