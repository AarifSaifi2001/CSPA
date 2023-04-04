import { Component, Input, OnInit } from '@angular/core';
import { Icar } from 'src/app/Models/Icar';

@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.css']
})
export class CarCardComponent implements OnInit {

  constructor() { }

  ngOnInit() {

  }

  @Input()
  car: Icar;

  @Input()
  hideIcons: boolean = false;
}
