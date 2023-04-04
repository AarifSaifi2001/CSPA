import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/Models/car';
import { CarService } from 'src/app/Services/car.service';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';
import { Photo } from 'src/app/Models/photos';
import { AuthService } from 'src/app/Services/auth.service';


@Component({
  selector: 'app-bike-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {

  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[] = [];
  mainPhotoUrl: string;
  carId: number;
  carDetails: Car[];
  details: Car;
  photos: Photo[];
  currentUserId: any;
  // photoUrls : NgxGalleryImage[] = [];
  latitude = 51.678418;
  longitude = 7.809007;

  constructor(private activeRoute: ActivatedRoute, private carServ: CarService, private rounter: Router, private authServ: AuthService) { }

  ngOnInit() {

    this.activeRoute.paramMap.subscribe((param) => {
      this.carId = +param.get('id');
      this.carServ.getCar(this.carId).subscribe((data) => {
        this.details = data;
        this.photos = this.details.photos;
        console.log(this.photos);
        console.log(this.details.postedBy);
        // this.carDetails = data;
        // console.log(this.carDetails);
        // this.details = this.carDetails.find(c => { return c.id === this.carId})



        // for(let photo of this.photos){
        //   if(photo.isPrimary){
        //     this.mainPhotoUrl = photo.imageUrl;
        //   }
        //   this.photoUrls.push(
        //     {
        //       small: photo.imageUrl,
        //       medium: photo.imageUrl,
        //       big: photo.imageUrl
        //     }
        //   )
        // }

        this.galleryImages = this.getCarPhotos();
        console.log(this.mainPhotoUrl);
        console.log(this.galleryImages);
      })
    }, (error) => {
      this.rounter.navigate(['/']);
    })

    this.currentUserId = localStorage.getItem('currentUserId');
    console.log(this.currentUserId);
    // this.authServ.currentUsedId().subscribe((data) => {
    //   console.log(data);
    // })
    // console.log(this.carDetails);
    // this.carServ.getAllcar().subscribe((data) => {
    //   this.allCars = data;
    //   this.carDetails = this.allCars.find(c => {c.id === this.carId});
    // }, (error) => {
    //   console.log(error.message);
    // })

    this.galleryOptions = [
      {
        width: '100%',
        height: '450px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: true
      },

    ];

    // console.log(this.galleryImages);
    // this.galleryImages = [
    //   {
    //     small:'https://res.cloudinary.com/cspa/image/upload/v1678555795/vnzzqsqhyrzvzg62pwew.jpg',
    //     medium: 'https://res.cloudinary.com/cspa/image/upload/v1678555795/vnzzqsqhyrzvzg62pwew.jpg',
    //     big: 'https://res.cloudinary.com/cspa/image/upload/v1678555795/vnzzqsqhyrzvzg62pwew.jpg'
    //   },
    //   // {
    //   //   small:this.photos[1].imageUrl,
    //   //   medium: this.photos[1].imageUrl,
    //   //   big: this.photos[1].imageUrl
    //   // }
    // ];

  }

  changePrimaryPhoto(mainPhotoUrl: string){
    this.mainPhotoUrl = mainPhotoUrl;
  }

  getCarPhotos(): NgxGalleryImage[]{
    const photoUrls : NgxGalleryImage[] = [];
    for(let photo of this.photos){
      if(photo.isPrimary){
        this.mainPhotoUrl = photo.imageUrl;
      }
      else{
        photoUrls.push(
          {
            small: photo.imageUrl,
            medium: photo.imageUrl,
            big: photo.imageUrl
          }
        );
      }
    }

    return photoUrls;
  }

}
