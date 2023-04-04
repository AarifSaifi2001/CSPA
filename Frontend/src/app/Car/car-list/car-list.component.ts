import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { zipAll } from 'rxjs';
import { Icar } from 'src/app/Models/Icar';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {

  cars: Icar[];
  sellRent: number = 1;
  searchText: string = '';
  selectedRadioButtonValue: string = "ALL";

  constructor(private carServ: CarService, private router: ActivatedRoute) { }

  ngOnInit() {

    if(this.router.snapshot.url.toString()){
      this.sellRent = 2;
    }

    this.carServ.getAllcar(this.sellRent).subscribe((data) => {

      this.cars = data;
      // console.log(this.cars);
      // const newCar = JSON.parse(localStorage.getItem('NewCar'));

      // if(newCar.sellRent === this.sellRent){
      //   this.cars = [newCar, ...this.cars];
      // }
    }, (error) => {
      console.log(error.message);
    })

  }

}
