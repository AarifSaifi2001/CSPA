import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BodyType } from "../Models/bodytype";
import { Car } from "../Models/car";
import { FuelType } from "../Models/fueltype";

@Injectable()
export class CarService{

  constructor(private http: HttpClient){

  }

  getCar(id: number){

    return this.http.get<Car>("http://localhost:5000/api/car/detail/"+id.toString());
    // return this.getAllcar().pipe(
    //   map(carArray => {
    //     return carArray.find(c => {
    //       c.id === id
    //     })
    //   })
    // );
  }

  getAllcar(sellRent?: number): Observable<Car[]>{

    return this.http.get<Car[]>("http://localhost:5000/api/car/list/"+sellRent.toString());

    // return this.http.get<Car[]>("./assets/car.json").pipe(
    //   map((data) => {
    //     const carArray: Car[] = [];
    //     const localCars = JSON.parse(localStorage.getItem('NewCar'));

    //     if(localCars){

    //       for(let key in localCars) {
    //         if(sellRent){
    //           if (localCars.hasOwnProperty(key) && localCars[key].sellRent === sellRent) {
    //             carArray.push(localCars[key]);
    //           }
    //         }else{
    //            carArray.push(localCars[key]);
    //         }
    //       }
    //     }

    //     for(let key in data) {
    //       if(sellRent){
    //         if (data.hasOwnProperty(key) && data[key].sellRent === sellRent) {
    //           carArray.push(data[key]);
    //         }
    //       }else{
    //         carArray.push(data[key]);
    //       }

    //     }

    //     return carArray;
    //   })
    // );
  }

  getUserCars(currentUserId: any): Observable<Car[]>{
    return this.http.get<Car[]>("http://localhost:5000/api/car/usercars/"+currentUserId.toString());
  }

  getFuelType(){

    return this.http.get<FuelType[]>("http://localhost:5000/api/fueltype/list");
  }

  getBodyType(){

    return this.http.get<BodyType[]>("http://localhost:5000/api/bodytype/list");
  }

  addNewCar(car: Car){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };

    return this.http.post("http://localhost:5000/api/car/add", car, httpOptions);
    // let nCar = [car];

    // if(localStorage.getItem('NewCar')){
    //   nCar = [car,
    //             ...JSON.parse(localStorage.getItem('NewCar'))];
    // }

    // localStorage.setItem('NewCar', JSON.stringify(nCar));
  }

  newCarId(): number{

    if(localStorage.getItem('PID')){
      localStorage.setItem('PID', String(+localStorage.getItem('PID') + 1));
      return +localStorage.getItem('PID');
    }

    else{
      localStorage.setItem('PID', '101');
      return 101;
    }
  }

  getAllCities(): Observable<string[]>{

    return this.http.get<string[]>('http://localhost:5000/api/Cities');
  }

  setPrimaryPhoto(carId: number, carPhotoId: string){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };

    return this.http.post("http://localhost:5000/api/car/set-primary-photo/"+String(carId)+"/"+carPhotoId, {}, httpOptions);
  }

  deletePhoto(carId: number, carPhotoId: string){
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + localStorage.getItem('token')
      })
    };

    return this.http.delete("http://localhost:5000/api/car/delete-photo/"+String(carId)+"/"+carPhotoId, httpOptions)
  }

}
