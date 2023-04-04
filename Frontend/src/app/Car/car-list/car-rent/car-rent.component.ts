// import { Component, OnInit } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { Ibikes } from 'src/app/Models/Ibike';
// import { BikeService } from 'src/app/Services/bike.service';

// @Component({
//   selector: 'app-bike-rent',
//   templateUrl: './bike-rent.component.html',
//   styleUrls: ['./bike-rent.component.css']
// })
// export class BikeRentComponent implements OnInit {

//   bikes: Ibikes[];

//   constructor(private bikeServ: BikeService, private router: ActivatedRoute) { }

//   sellRent: number = 1;
//   ngOnInit() {

//     console.log(this.router.snapshot.url.toString());

//     this.bikeServ.getAllBikes(this.sellRent).subscribe((data) => {

//       this.bikes = data;
//       console.log(data);
//     }, (error) => {
//       console.log(error.message);
//     })
//   }

// }
