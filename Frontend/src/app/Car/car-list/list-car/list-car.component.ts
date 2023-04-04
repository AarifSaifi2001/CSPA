import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { BodyType } from 'src/app/Models/bodytype';
import { Car } from 'src/app/Models/car';
import { FuelType } from 'src/app/Models/fueltype';
import { Icar } from 'src/app/Models/Icar';
import { AlertifyService } from 'src/app/Services/alertify.service';
import { CarService } from 'src/app/Services/car.service';

@Component({
  selector: 'app-list-bike',
  templateUrl: './list-car.component.html',
  styleUrls: ['./list-car.component.css']
})
export class ListCarComponent implements OnInit {

  @ViewChild('static') statictab: TabsetComponent;

  addCarForm: FormGroup;
  nextClicked: boolean = false;
  cities: any[];
  car = new Car();
  fuelType: FuelType[];
  bodyType: BodyType[];

  constructor(private alertify: AlertifyService, private carServ: CarService, private router: Router) { }

  ngOnInit() {
    if(!localStorage.getItem('username')){
      this.alertify.error("You must be logged in to add a Car");
      this.router.navigateByUrl('user-login');
    }

    console.log(this.car.id);
    this.createAddCarForm();

    this.carServ.getAllCities().subscribe(data => {
      this.cities = data;
      console.log(this.cities);
    });

    this.carServ.getFuelType().subscribe(data => {
      this.fuelType = data;
    });

    this.carServ.getBodyType().subscribe(data => {
      this.bodyType = data;
    })
  }

  createAddCarForm(){

    this.addCarForm = new FormGroup({

      basicInfo: new FormGroup({

        sellRent: new FormControl("1", Validators.required),
        carBrand: new FormControl(null, Validators.required),
        carModel: new FormControl(null, Validators.required),
        modelYear: new FormControl(null, Validators.required)
      }),

      priceAndDetails: new FormGroup({
        ftype: new FormControl(null, Validators.required),
        btype: new FormControl(null, Validators.required),
        owner: new FormControl(null, Validators.required),
        km: new FormControl(null, Validators.required),
        price: new FormControl(null, Validators.required)
      }),

      address: new FormGroup({
        state: new FormControl(null, Validators.required),
        city: new FormControl(null, Validators.required),
        address: new FormControl(null, Validators.required),
        landmark: new FormControl(null, Validators.required),
        carDesc: new FormControl(null, Validators.required)
      })
    })

  }

 // #region <GetterMethods>
  // #region <FormGroups>

  get BasicInfo()  {
    return this.addCarForm.controls['basicInfo'] as FormGroup;
  }

  get PriceandDetails()  {
    return this.addCarForm.controls['priceAndDetails'] as FormGroup;
  }

  get Address()  {
    return this.addCarForm.controls['address'] as FormGroup;
  }
  //#endregion

  // #region <FormControls>
  get SellRent(){
    return this.BasicInfo.controls['sellRent'] as FormControl;
  }

  get CarBrand(){
    return this.BasicInfo.controls['carBrand'] as FormControl;
  }

  get CarModel(){
    return this.BasicInfo.controls['carModel'] as FormControl;
  }

  get ModelYear(){
    return this.BasicInfo.controls['modelYear'] as FormControl;
  }

  get Ftype(){
    return this.PriceandDetails.controls['ftype'] as FormControl;
  }

  get Btype(){
    return this.PriceandDetails.controls['btype'] as FormControl;
  }

  get Owner(){
    return this.PriceandDetails.controls['owner'] as FormControl;
  }

  get Km(){
    return this.PriceandDetails.controls['km'] as FormControl;
  }

  get Price(){
    return this.PriceandDetails.controls['price'] as FormControl;
  }

  get State(){
    return this.Address.controls['state'] as FormControl;
  }

  get City(){
    return this.Address.controls['city'] as FormControl;
  }

  get Add(){
    return this.Address.controls['address'] as FormControl;
  }

  get LandMark(){
    return this.Address.controls['landmark'] as FormControl;
  }

  get CarDesc(){
    return this.Address.controls['carDesc'] as FormControl;
  }

  // #endregion

  onSubmit(){
    console.log(this.addCarForm);
    this.nextClicked = true;

    if(this.allTabsValid()){
      this.mapCar();
      this.carServ.addNewCar(this.car).subscribe(() => {

        this.alertify.success("Congratulation your car has been listed With Sample car photo. You can Upload and Update car Photos in Car Details section.");

        // this.router.navigateByUrl('/photos');
        if(this.SellRent.value === '2'){
          this.router.navigateByUrl('/rent-car');
        }else{
          this.router.navigateByUrl('/');
        }
        console.log(this.car);
      });

    }else
    this.alertify.error("Please check the form and provide valid values");

    console.log(this.carView.fueltype);
  }

  mapCar(): void{

    // console.log(this.car.id);
    // this.car.id = this.carServ.newCarId();
    this.car.sellRent = +this.SellRent.value;
    this.car.carbrand = this.CarBrand.value;
    this.car.name = this.CarModel.value;
    this.car.modelyear = this.ModelYear.value;
    this.car.fueltypeId = this.Ftype.value;
    this.car.bodytypeId = this.Btype.value;
    this.car.owner = this.Owner.value;
    this.car.km = this.Km.value;
    this.car.price = this.Price.value;
    this.car.state = this.State.value;
    this.car.citiesId = this.City.value;
    this.car.address = this.Add.value;
    this.car.landmark = this.LandMark.value;
    this.car.cardesc = this.CarDesc.value;
    // console.log(this.car.id);
  }

  allTabsValid(): boolean{

    if(this.BasicInfo.invalid){
      this.statictab.tabs[0].active = true;
      return false;
    }

    if(this.PriceandDetails.invalid){
      this.statictab.tabs[1].active = true;
      return false;
    }

    if(this.Address.invalid){
      this.statictab.tabs[2].active = true;
      return false;
    }

    return true;
  }

  selectTab(tabId: number, isCurrentTabValid: boolean){

    this.nextClicked = true;
    if(isCurrentTabValid){
      this.statictab.tabs[tabId].active = true;
    }
  }

  carView: Icar = {
    id: null,
    name: '',
    price: null,
    photo: './assets/images/samplecar.webp',
    sellRent: null,
    km: null,
    location: '',
    modelyear: null,
    fueltype: '',
  };
}
