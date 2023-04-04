import { Component, OnInit } from '@angular/core';
import { Icar } from 'src/app/Models/Icar';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-user-cars',
  templateUrl: './user-cars.component.html',
  styleUrls: ['./user-cars.component.css']
})
export class UserCarsComponent implements OnInit {

  cars: Icar[];
  currentUserId: any;
  searchText: string = '';
selectedRadioButtonValue: string = "1";

  constructor(private carServ: CarService) { }

  ngOnInit() {
    
    this.currentUserId = localStorage.getItem('currentUserId');

    this.carServ.getUserCars(this.currentUserId).subscribe((data) => {
      this.cars = data;
      console.log(this.cars);
    }, (error) => {
      console.log(error.message);
    });

  }

}
